using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;
using System.Reflection.Emit;

namespace OrderForm2
{
    public partial class product_list : Form
    {

        SqlConnectionStringBuilder scsb;
        string strDBconnectionString = "";
        List<string> listPsort = new List<string>();
        List<string> listPname = new List<string>();
        List<int> listPrice = new List<int>();
        List<int> listID = new List<int>();

        public int productID = 0; //0 = 新增商品 , 不是的話就是維護商品
        string strDBConnectionString = "";
        string image_Dir = @"images\";
        string image_Name = "";
        int price = 0;


        /*------------------ 加入購物車變數 ------------------*/

        List<string> list_Addon_item = new List<string>(); //加購項目
        List<int> list_Addon_price = new List<int>(); //加購項目金額

        int add_Cart_count; //訂購數量
        int add_Cart_product_price; //產品單價
        string add_Cart_addonItem; //加購項目
        int add_Cart_addonItem_price; //加購項目單價
        int add_Cart_newPrice; //加購後金額
        int add_Cart_sum; //數量x加購後金額


        public product_list()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void product_list_Load(object sender, EventArgs e)
        {
            login login = new login();
            login.ShowDialog();

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb2";
            scsb.IntegratedSecurity = true;
            strDBconnectionString = scsb.ToString();


            讀取資料庫();

            listView產品列表.Clear();
            listView產品列表.View = View.LargeIcon; //四種模式LargeIcon, SmallIcon, List, Tile
            imageList產品圖檔.ImageSize = new Size(120, 120);//圖檔大小
            listView產品列表.LargeImageList = imageList產品圖檔; //LargeIcon, Tile
            listView產品列表.SmallImageList = imageList產品圖檔; //SmallIcon, List

            for (int i = 0; i < imageList產品圖檔.Images.Count; i += 1)
            {

                ListViewItem item = new ListViewItem();
                item.ImageIndex = i; //建立索引值對應
                item.Font = new Font("微軟正黑體", 13, FontStyle.Regular);
                item.Text = listPname[i];
                item.Tag = listID[i]; //id隱藏在tag
                listView產品列表.Items.Add(item);
            }

            panel_Product_info.Hide();


            /*------------------ Product Info ------------------*/

            //加購
            list_Addon_item.Add("無須加購");
            list_Addon_item.Add("中杯那堤 (+$100)");
            list_Addon_item.Add("大杯那堤 (+$115)");

            //加購金額
            list_Addon_price.Add(0);
            list_Addon_price.Add(100);
            list_Addon_price.Add(115);


            foreach (string item in list_Addon_item)
            {
                cbox_Addon.Items.Add(item);
            }

            buy_Count.Text = "1";
            add_Cart_count = 1;
            cbox_Addon.SelectedIndex = 0;

        }

        void 讀取資料庫()
        {

            SqlConnection con = new SqlConnection(strDBconnectionString);
            con.Open();
            string strSQL = "select top 100 * from product;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            //檔名變數
            string image_Dir = @"images\"; //圖檔目錄 做全域變數(相對路徑-執行檔-bin-Debug)
            string image_Name = ""; //圖檔名稱
            int i = 0;

            while (reader.Read())
            {
                listID.Add((int)reader["id"]);
                listPname.Add(reader["pname"].ToString());
                listPrice.Add((int)reader["price"]);
                image_Name = reader["pimage"].ToString();
                imageList產品圖檔.Images.Add(Image.FromFile(image_Dir + image_Name));

                i += 1;
            }

            reader.Close();
            con.Close();
        }


        private void listView產品列表_ItemActivate(object sender, EventArgs e)
        {
            GlobalVar.productId = Convert.ToInt32(listView產品列表.SelectedItems[0].Tag);

            panel_Product_info.Show();
            cbox_Addon.SelectedIndex = 0;
        }

        /*------------------ Product Info ------------------*/

        private void panel_Product_info_Paint(object sender, PaintEventArgs e)
        {

            SqlConnection con = new SqlConnection(strDBconnectionString);
            con.Open();
            string strSQL = "select * from product where id = @SelectPid;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SelectPid", GlobalVar.productId);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                pinfo_Id.Text = reader["id"].ToString();
                pinfo_Name.Text = reader["pname"].ToString();

                add_Cart_product_price = Convert.ToInt32(reader["price"]);
                pinfo_Price.Text = "$" + reader["price"].ToString();
                
                pinfo_Desc.Text = reader["pdesc"].ToString();
                image_Name = reader["pimage"].ToString();
                pinfo_Image.Image = Image.FromFile(image_Dir + image_Name);

                pinfo_Image.Size = new System.Drawing.Size(200, 200);
                pinfo_Image.SizeMode = PictureBoxSizeMode.CenterImage;
                pinfo_Image.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }

        private void buy_Count_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (buy_Count.Text.Length > 0)
                {
                    add_Cart_count = Convert.ToInt32(buy_Count.Text);
                    計算所選產品小計();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
       
        private void cbox_Addon_SelectedIndexChanged(object sender, EventArgs e)
        {
            add_Cart_addonItem = list_Addon_item[cbox_Addon.SelectedIndex];
            add_Cart_addonItem_price = list_Addon_price[cbox_Addon.SelectedIndex];
            計算加購單價();
        }

        void 計算加購單價()
        {
            //加購後金額 = 產品單價 + 咖啡加購項目單價
            add_Cart_newPrice = add_Cart_product_price + add_Cart_addonItem_price;
            計算所選產品小計();
        }

        void 計算所選產品小計()
        {
            //數量x加購後金額 = 加購後金額 * 訂購數量
            add_Cart_sum = add_Cart_newPrice * add_Cart_count;
        }

        private void btn_Add_cart_Click(object sender, EventArgs e)
        {

            計算加購單價();
            計算所選產品小計();
            ArrayList orderInfo = new ArrayList();
            orderInfo.Add(pinfo_Name.Text);
            orderInfo.Add(add_Cart_product_price);
            orderInfo.Add(add_Cart_addonItem);
            orderInfo.Add(add_Cart_count);
            orderInfo.Add(add_Cart_sum);
            orderInfo.Add(GlobalVar.productId);
            GlobalVar.orderList.Add(orderInfo); 
            MessageBox.Show("已加入訂購單");

        }

        private void btn_Go_cart_Click(object sender, EventArgs e)
        {
            cart cart = new cart();
            cart.ShowDialog();
        }


        /*------------------ Top Link ------------------*/

        private void member_Center_Click(object sender, EventArgs e)
        {
            member_center member_Center = new member_center();
            member_Center.ShowDialog();
        }

        private void cart_Link_Click(object sender, EventArgs e)
        {
            cart cart = new cart();
            cart.ShowDialog();
        }

        private void back_product_list_Click(object sender, EventArgs e)
        {
            buy_Count.Text = "1";
            panel_Product_info.Hide();
        }

        private void marquee_Tick(object sender, EventArgs e)
        {

            if (marquee_tx.Left + marquee_tx.Width > 0) { 
                marquee_tx.Left = marquee_tx.Left - 4;
            }
            else if (marquee_tx.Left < 1) { 
                marquee_tx.Left = 500;
            }
        }

    }
}
