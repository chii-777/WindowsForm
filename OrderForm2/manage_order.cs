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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.AxHost;

namespace OrderForm2
{
    public partial class manage_order : Form
    {

        SqlConnectionStringBuilder scsb;
        string strDBconnectionString = "";
        List<int> SearchOrderID = new List<int>();

        List<string> listPickup = new List<string>();
        List<string> listState = new List<string>(); 

        public manage_order()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void manage_order_Load(object sender, EventArgs e)
        {

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb2";//database名稱
            scsb.IntegratedSecurity = true;
            strDBconnectionString = scsb.ToString();

            history_list_record();


            listPickup.Add("自取");
            listPickup.Add("宅配");

            listState.Add("處理中");
            listState.Add("已完成");

            foreach (string item in listPickup)
            {
                receive_Pickup.Items.Add(item);
            }

            foreach (string item in listState)
            {
                receive_State.Items.Add(item);
            }

        }

        private void back_Link_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void history_list_record()
        {
            SqlConnection con = new SqlConnection(strDBconnectionString);
            con.Open();

            string strSQL = "select orderid as 訂單編號, updated as 訂購時間, pickup as 收貨方式, total as 訂單金額 from orderList order by updated desc";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                order_List.DataSource = dt;
            }
            reader.Close();
            con.Close();
        }

        private void order_List_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                panel_History_info.Show();

                string strSelectedID = order_List.Rows[e.RowIndex].Cells[0].Value.ToString();
                int intSelID = 0;
                bool isOrderID = Int32.TryParse(strSelectedID, out intSelID);

                if (isOrderID)
                {
                    SqlConnection con = new SqlConnection(strDBconnectionString);
                    con.Open();
                    string strSQL = "select * from orderList where orderid = @SearchOrderID;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@SearchOrderID", intSelID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        order_No.Text = "訂單編號：" + reader["orderid"].ToString();
                        receive_Name.Text = reader["receive_name"].ToString();
                        receive_Phone.Text = reader["receive_phone"].ToString();
                        receive_Email.Text = reader["receive_mail"].ToString();
                        string pickup = reader["pickup"].ToString();

                        if (pickup == "自取")
                        {
                            receive_Pickup.SelectedIndex = 0;
                        }
                        else
                        {
                            receive_Pickup.SelectedIndex = 1;
                        }


                        receive_Address.Text = reader["receive_address"].ToString();

                        string state = reader["state"].ToString();

                        if (state == 0.ToString())
                        {
                            receive_State.SelectedIndex = 0;
                        }
                        else
                        {
                            receive_State.SelectedIndex = 1;
                        }

                        order_Price.Text = reader["price"].ToString() + " 元";
                        order_Discount.Text = "-" + reader["discount"].ToString() + " 元";
                        order_Total.Text = reader["total"].ToString() + " 元";
                    }
                    else
                    {
                        MessageBox.Show("無此訂單");
                        panel_History_info.Hide();
                    }

                    reader.Close();


                    /*-------------------- 購買品項 --------------------*/

                    int orderid = Convert.ToInt32(strSelectedID);
                    GlobalVar.manage_orderID = orderid;

                    strSQL = "select product_name,count,addon,subtotal from orderDetial where orderid = @SearchOrderID";
                    SqlCommand cmd1 = new SqlCommand(strSQL, con);
                    cmd1.Parameters.AddWithValue("@SearchOrderID", orderid);
                    SqlDataReader reader1 = cmd1.ExecuteReader();

                    while (reader1.Read())
                    {
                        string item = reader1["product_name"].ToString();
                        string addon = reader1["addon"].ToString();
                        int count = (int)reader1["count"];
                        int price = (int)reader1["subtotal"];

                        string buy_Info = item + " + " + addon + " × " + count + "　--→　小計： $" + price;
                        detial_Order.Items.Add(buy_Info);
                    }

                    reader1.Close();
                    con.Close();

                }
            }
            else
            {
                panel_History_info.Hide();
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if ((receive_Name.Text != "") && (receive_Phone.Text != "") && (receive_Email.Text != "") && (receive_Address.Text != ""))
            {
                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strSQL = "update orderList set receive_name=@NewName,  receive_phone=@NewPhone, receive_mail=@NewEmail, receive_address=@NewAddress, pickup=@NewPickup, state=@NewState where orderid=@OrderId;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewName", receive_Name.Text);
                cmd.Parameters.AddWithValue("@NewPhone", receive_Phone.Text);
                cmd.Parameters.AddWithValue("@NewEmail", receive_Email.Text);
                cmd.Parameters.AddWithValue("@NewAddress", receive_Address.Text);

                if (receive_Pickup.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@NewPickup", "自取");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@NewPickup", "宅配");
                }

                if (receive_State.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@NewState", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@NewState", 1);
                }

                cmd.Parameters.AddWithValue("@OrderId", GlobalVar.manage_orderID);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("修改成功");
            }

            history_list_record();
        }

        private void back_historyList_Click(object sender, EventArgs e)
        {
            panel_History_info.Hide();
        }


        /*------------------ Search Order ------------------*/

        private void btn_O_Search_Click(object sender, EventArgs e)
        {
            SearchOrderID.Clear();

            if (txt_O_Search.Text != "")
            {

                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strSQL = "select orderid as 訂單編號, updated as 訂購時間, pickup as 收貨方式, total as 訂單金額 from orderList where orderid like @SearchKeyword";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchKeyword", "%" + txt_O_Search.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    order_List.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("查無此訂單");
                }

                reader.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("請輸入訂單編號");
            }
        }

        private void txt_O_Search_TextChanged(object sender, EventArgs e)
        {
            if (txt_O_Search.Text == "")
            {
                history_list_record();
            }
        }

        private void txt_O_Search_Click(object sender, EventArgs e)
        {
            txt_O_Search.Text = "";
        }

        
    }
}
