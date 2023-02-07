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
using System.Collections;

namespace OrderForm2
{
    public partial class cart : Form
    {
        
        SqlConnectionStringBuilder scsb;
        string strDBconnectionString = "";


        public cart()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void cart_Load(object sender, EventArgs e)
        {

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb2";//database名稱
            scsb.IntegratedSecurity = true;
            strDBconnectionString = scsb.ToString();


            var currentTime = System.DateTime.Now;
            var DateTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
            lbl訂單成立時間.Text = "訂單成立時間：" + DateTime;


            //取會員
            order_Name.Text = GlobalVar.userName;
            order_Phone.Text = GlobalVar.userPhone;
            order_Email.Text = GlobalVar.userEmail;
            order_Address.Text = GlobalVar.userAddress;


            //取產品
            foreach (ArrayList orderInfo in GlobalVar.orderList)
            {
                
                string 產品項目 = (string)orderInfo[0];
                int 產品單價 = (int)orderInfo[1];
                string 加購項目 = (string)orderInfo[2];
                int 數量 = (int)orderInfo[3];
                int 產品小計 = (int)orderInfo[4];

                string str訂購資訊 = string.Format("{0} (${1}) {2} × {3}   --  小計：{4}元", 產品項目, 產品單價, 加購項目, 數量, 產品小計);
                listBox_order.Items.Add(str訂購資訊);
            }

            計算結帳金額();



            if (listBox_order.Items.Count == 0)
            {
                panel_NoItem.Show();
            }
            else
            {
                panel_NoItem.Hide();
            }


        }

        void 計算結帳金額()
        {
            int 訂單小計 = 0;
            int 隱藏優惠 = 0;
            int 結帳金額 = 0;

            foreach (ArrayList orderInfo in GlobalVar.orderList)
            {
                string 產品項目 = (string)orderInfo[0];
                int 產品單價 = (int)orderInfo[1];
                string 尺寸 = (string)orderInfo[2];
                int 數量 = (int)orderInfo[3];
                int 產品小計 = (int)orderInfo[4];

                訂單小計 = 產品小計;

                if (GlobalVar.orderList.Count > 2)
                {
                    隱藏優惠 = 100;
                    結帳金額 = 訂單小計 - 隱藏優惠;
                    lbl隱藏優惠文字.Text = "(滿三項商品折扣$100)";
                }
                else if (GlobalVar.orderList.Count > 1)
                {
                    隱藏優惠 = 50;
                    結帳金額 = 訂單小計 - 隱藏優惠;
                    lbl隱藏優惠文字.Text = "(滿兩項商品折扣$50)";
                }
                else
                {
                    隱藏優惠 = 0;
                    結帳金額 = 訂單小計 - 隱藏優惠;
                    lbl隱藏優惠文字.Text = "(未達優惠條件)";
                }

            }

            lbl訂單小計.Text = String.Format("{0}元", 訂單小計);
            lbl隱藏優惠.Text = String.Format("- {0}元", 隱藏優惠);
            lbl結帳金額.Text = String.Format("{0}元", 結帳金額);

            GlobalVar.orderPrice = 訂單小計;
            GlobalVar.orderDiscount = 隱藏優惠;
            GlobalVar.orderTotal = 結帳金額;

        }

        private void btn_Delete_pitem_Click(object sender, EventArgs e)
        {
            if (listBox_order.SelectedIndex > -1)  //索引值
            {
                int selIndex = listBox_order.SelectedIndex;

                GlobalVar.orderList.RemoveAt(selIndex);
                listBox_order.Items.RemoveAt(selIndex);

                計算結帳金額();
            }
            else
            {
                MessageBox.Show("請選擇移除項目");
            }
        }

        private void btn_Send_order_Click(object sender, EventArgs e) //送出
        {
            
            string str收貨方式;
            if (radio自取.Checked == true)
            {
                str收貨方式 = "自取";
            }
            else
            {
                str收貨方式 = "宅配";
            }


            if (order_Name.Text == "")
            {
                MessageBox.Show("請輸入姓名");
            }
            else if (order_Phone.Text == "")
            {
                MessageBox.Show("請輸入電話");
            }
            else if (order_Email.Text == "")
            {
                MessageBox.Show("請輸入信箱");
            }
            else if (order_Address.Text == "")
            {
                MessageBox.Show("請輸入地址");
            }
            else if (radio自取.Checked != true && radio宅配.Checked != true)
            {
                MessageBox.Show("請選擇收貨方式");
            }
            else if (listBox_order.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇訂購產品項目");
            }
            else
            {
                Random rnd = new Random(); //亂數編號
                int MinValue = 100000001;
                int MaxValue = 1000000000;
                GlobalVar.orderID = rnd.Next(MinValue, MaxValue);

                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strSQL = "insert orderList(uid, orderid, updated, price, discount, total, pickup, receive_name, receive_phone, receive_mail, receive_address, state) values (@SearchUid, @NewOrderid, @NewUpdated, @NewPrice, @NewDiscount, @NewTotal, @NewPickup,  @NewReceive_name, @NewReceive_phone, @NewReceive_mail, @NewReceive_address, @NewState)";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchUid", GlobalVar.userId);
                cmd.Parameters.AddWithValue("@NewOrderid", GlobalVar.orderID);
                cmd.Parameters.AddWithValue("@NewUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@NewPrice", GlobalVar.orderPrice);
                cmd.Parameters.AddWithValue("@NewDiscount", GlobalVar.orderDiscount);
                cmd.Parameters.AddWithValue("@NewTotal", GlobalVar.orderTotal);
                cmd.Parameters.AddWithValue("@NewPickup", str收貨方式);
                cmd.Parameters.AddWithValue("@NewReceive_name", order_Name.Text);
                cmd.Parameters.AddWithValue("@NewReceive_phone", order_Phone.Text);
                cmd.Parameters.AddWithValue("@NewReceive_mail", order_Email.Text);
                cmd.Parameters.AddWithValue("@NewReceive_address", order_Address.Text);
                cmd.Parameters.AddWithValue("@NewState", 0);

                int rows = cmd.ExecuteNonQuery();

                foreach (ArrayList orderInfo in GlobalVar.orderList)
                {

                    string 產品項目 = (string)orderInfo[0];
                    int 產品單價 = (int)orderInfo[1];
                    string 加購項目 = (string)orderInfo[2];
                    int 數量 = (int)orderInfo[3];
                    int 產品小計 = (int)orderInfo[4];
                    int 產品ID = (int)orderInfo[5];

                    strSQL = "insert orderDetial(uid, orderid, productid, product_name, count, addon, subtotal) values (@SearchUid, @NewOrderid, @SearchProductid, @NewPname, @NewCount,  @NewAddon, @NewSubtotal)";

                    SqlCommand cmd1 = new SqlCommand(strSQL, con);
                    cmd1.Parameters.AddWithValue("@SearchUid", GlobalVar.userId);
                    cmd1.Parameters.AddWithValue("@NewOrderid", GlobalVar.orderID);
                    cmd1.Parameters.AddWithValue("@SearchProductid", 產品ID);
                    cmd1.Parameters.AddWithValue("@NewPname", 產品項目);
                    cmd1.Parameters.AddWithValue("@NewCount", 數量);
                    cmd1.Parameters.AddWithValue("@NewAddon", 加購項目);
                    cmd1.Parameters.AddWithValue("@NewSubtotal", 產品小計);

                    cmd1.ExecuteNonQuery(); //存

                }

                con.Close();

                MessageBox.Show("訂購成功！");

                clear_Cart();
            }
        }

        private void back_product_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void clear_Cart()
        {
            listBox_order.Items.Clear();
            order_Name.Text = "";
            order_Phone.Text = "";
            order_Email.Text = "";
            order_Address.Text = "";
            radio自取.Checked = false;
            radio宅配.Checked = false;
            GlobalVar.orderList.Clear();

            lbl訂單成立時間.Text = "";
            lbl訂單小計.Text = "元";
            lbl隱藏優惠.Text = "元";
            lbl結帳金額.Text = "元";
            lbl隱藏優惠文字.Text = "(未達優惠條件)";

            this.Close();
        }
    }
}
