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

namespace OrderForm2
{
    public partial class manage_product : Form
    {

        SqlConnectionStringBuilder scsb;
        string strDBconnectionString = "";
        List<int> SearchIDs = new List<int>();


        public int productID = 0; //0 = 新增商品 , 不是的話就是維護商品
        string strDBConnectionString = "";
        string image_Dir = @"images\";
        string image_Name = "";
        bool isChangeImage = false;


        public manage_product()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void manage_product_Load(object sender, EventArgs e)
        {

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb2";//database名稱
            scsb.IntegratedSecurity = true;
            strDBconnectionString = scsb.ToString();


            P_edit_Block_hide();
            panel_Add_product.Hide();

            product_Info_list();


        }

        private void back_Link_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void product_Info_list()
        {
            SqlConnection con = new SqlConnection(strDBconnectionString);
            con.Open();

            string strSQL = "select id as 產品編號, pname as 名稱, pdesc as 簡介, price as 價錢, pimage as 圖片 from product";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                product_Info.DataSource = dt;
            }
            reader.Close();
            con.Close();
        }

        private void product_Info_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                P_edit_Block_show();

                string strSelectedID = product_Info.Rows[e.RowIndex].Cells[0].Value.ToString();
                int intSelID = 0;
                bool isID = Int32.TryParse(strSelectedID, out intSelID);

                if (isID)
                {
                    SqlConnection con = new SqlConnection(strDBconnectionString);
                    con.Open();
                    string strSQL = "select * from product where id = @SearchID;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@SearchID", intSelID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        edit_Id.Text = reader["id"].ToString();
                        edit_Name.Text = reader["pname"].ToString();
                        edit_Price.Text = reader["price"].ToString();
                        edit_Desc.Text = reader["pdesc"].ToString();
                        image_Name = reader["pimage"].ToString();
                        edit_Image.Image = Image.FromFile(image_Dir + image_Name);

                        edit_Image.Size = new System.Drawing.Size(150, 150);
                        edit_Image.SizeMode = PictureBoxSizeMode.CenterImage;
                        edit_Image.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        MessageBox.Show("查無此產品");
                        P_edit_Block_hide();
                    }

                    reader.Close();
                    con.Close();
                }
            }
            else
            {
                P_edit_Block_hide();
            }
        }

        /*------------------ Edit Product ------------------*/

        private void btn_Edit_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "圖檔類型 (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png"; //指定特定檔案類型，or的左邊是過濾檔案的描述，or的右邊是過濾檔案類型(需用分號隔開)
            DialogResult R = f.ShowDialog(); //回傳結果

            if (R == DialogResult.OK)
            {
                edit_Image.Image = Image.FromFile(f.FileName);//FileName 目錄+原始檔名
                string fileExt = System.IO.Path.GetExtension(f.SafeFileName);//取得副檔名，不包含名稱路徑
                Random myRandom = new Random();
                image_Name = DateTime.Now.ToString("yyyyMMddHHmmss") + myRandom.Next(1000, 10000).ToString() + fileExt; //時間+亂數+副檔名

                isChangeImage = true;
                Console.WriteLine(image_Name);
            }
        }

        private void btn_P_edit_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(edit_Id.Text, out intID);

            if ((intID > 0) && (edit_Name.Text != ""))
            {

                if (isChangeImage)
                {
                    edit_Image.Image.Save(image_Dir + image_Name); //存檔
                    isChangeImage = false;
                }

                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strSQL = "update product set pname=@NewName, price=@NewPrice,pdesc=@NewDesc, pimage=@NewImageName where id=@SearchId;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewName", edit_Name.Text);
                int intPrice = 0;
                Int32.TryParse(edit_Price.Text, out intPrice);
                cmd.Parameters.AddWithValue("@NewPrice", intPrice);
                cmd.Parameters.AddWithValue("@NewDesc", edit_Desc.Text);
                cmd.Parameters.AddWithValue("@NewImageName", image_Name);

                cmd.Parameters.AddWithValue("@SearchId", intID);

                int rows = cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("修改成功");

                P_edit_Block_hide();
                product_Info_list();

            }
        }

        private void btn_P_delete_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(edit_Id.Text, out intID);

            if (intID > 0)
            {
                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strSQL = "delete from product where id = @DeleteId;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@DeleteId", intID);

                int rows = cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("刪除成功");

                P_edit_Block_hide();
                product_Info_list();
            }
        }

        void P_edit_Block_hide()
        {
            P_edit_Block.Hide();
            btn_P_edit.Hide();
            btn_P_delete.Hide();
        }

        void P_edit_Block_show()
        {
            P_edit_Block.Show();
            btn_P_edit.Show();
            btn_P_delete.Show();
        }

        /*------------------ Search Member ------------------*/

        private void btn_P_Search_Click(object sender, EventArgs e)
        {
            SearchIDs.Clear();

            if (txt_P_Search.Text != "")
            {

                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strSQL = "select id as 產品編號, pname as 名稱, pdesc as 簡介, price as 價錢, pimage as 圖片 from product where pname like @SearchKeyword";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchKeyword", "%" + txt_P_Search.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    product_Info.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("查無此產品");
                }

                reader.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("請輸入查詢關鍵字");
            }
        }

        private void txt_P_Search_TextChanged(object sender, EventArgs e)
        {
            if (txt_P_Search.Text == "")
            {
                P_edit_Block_hide();
                product_Info_list();
                
            }
        }

        private void txt_P_Search_Click(object sender, EventArgs e)
        {
            txt_P_Search.Text = "";
        }

        /*------------------ Add Product ------------------*/

        private void Add_product_link_Click(object sender, EventArgs e)
        {
            panel_Add_product.Show();
        }

        private void btn_Add_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "圖檔類型 (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png"; //指定特定檔案類型，or的左邊是過濾檔案的描述，or的右邊是過濾檔案類型(需用分號隔開)
            DialogResult R = f.ShowDialog(); //回傳結果

            if (R == DialogResult.OK)
            {
                add_Pimage.Image = Image.FromFile(f.FileName);//FileName 目錄+原始檔名
                string fileExt = System.IO.Path.GetExtension(f.SafeFileName);//取得副檔名，不包含名稱路徑
                Random myRandom = new Random();
                image_Name = DateTime.Now.ToString("yyyyMMddHHmmss") + myRandom.Next(1000, 10000).ToString() + fileExt; //時間+亂數+副檔名

                isChangeImage = true;

                add_Pimage.SizeMode = PictureBoxSizeMode.CenterImage;
                add_Pimage.SizeMode = PictureBoxSizeMode.StretchImage;
                Console.WriteLine(image_Name);
            }
        }

        private void btn_Add_product_Click(object sender, EventArgs e)
        {
            if ((add_Pname.Text != "") && (add_Price.Text != "") && (add_Pdesc.Text != "") && (add_Pimage.Image != null))
            {
                if (isChangeImage)
                {
                    add_Pimage.Image.Save(image_Dir + image_Name);
                    isChangeImage = false;
                }

                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strSQL = "insert product(pname, price, pdesc, pimage) values(@NewName, @NewPrice, @NewPdesc, @NewImageName);";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewName", add_Pname.Text);
                int intPrice = 0;
                Int32.TryParse(add_Price.Text, out intPrice);
                cmd.Parameters.AddWithValue("@NewPrice", intPrice);
                cmd.Parameters.AddWithValue("@NewPdesc", add_Pdesc.Text);
                cmd.Parameters.AddWithValue("@NewImageName", image_Name);

                int rows = cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("新增成功");

                add_info_Clear();

            }
            else
            {
                MessageBox.Show("所有欄位必填");
            }
        }

        void add_info_Clear()
        {
            add_Pname.Clear();
            add_Price.Clear();
            add_Pdesc.Clear();
            add_Pimage.Image = null;
        }

        private void product_List_Link_Click(object sender, EventArgs e)
        {
            panel_Add_product.Hide();
            product_Info_list();
        }

    }
}
