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
    public partial class member_center : Form
    {

        SqlConnectionStringBuilder scsb;
        string strDBconnectionString = "";

        public member_center()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void member_center_Load(object sender, EventArgs e)
        {

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb2";//database名稱
            scsb.IntegratedSecurity = true;
            strDBconnectionString = scsb.ToString();


            info_Name.Text = GlobalVar.userName;
            info_Phone.Text = GlobalVar.userPhone;
            info_Email.Text = GlobalVar.userEmail;
            info_Address.Text = GlobalVar.userAddress;
            info_Birth.Text = GlobalVar.userBirth;


            edit_Name.Text = GlobalVar.userName;
            edit_Email.Text = GlobalVar.userEmail;
            edit_Address.Text = GlobalVar.userAddress;

            history_list_record();

            panel_Member_edit.Hide();
            panel_History_list.Hide();
            panel_History_info.Hide();
        }


        private void show_Member_center_Click(object sender, EventArgs e)
        {
            panel_Member_center.Show();
            panel_Member_edit.Hide();
            panel_History_list.Hide();
            panel_History_info.Hide();
        }

        private void show_Member_edit_Click(object sender, EventArgs e)
        {
            panel_Member_center.Hide();
            panel_Member_edit.Show();
            panel_History_list.Hide();
            panel_History_info.Hide();
        }

        private void show_Hisroty_order_Click(object sender, EventArgs e)
        {
            panel_Member_center.Hide();
            panel_Member_edit.Hide();
            panel_History_list.Show();
            panel_History_info.Hide();
        }


        /*------------------ Member Center ------------------*/

        private void panel_Member_center_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel_Member_edit_Paint(object sender, PaintEventArgs e)
        {
            
        }

        /*------------------ Member Edit ------------------*/

        private void btn_Edit_Click(object sender, EventArgs e)
        {

            if ((GlobalVar.userId > 0) && (edit_Name.Text != "") && (edit_Email.Text != "") && (edit_Address.Text != "") && (edit_OldPsw.Text != "") && (edit_Psw.Text != ""))
            {

                if (edit_OldPsw.Text != GlobalVar.userPsw)
                {
                    MessageBox.Show("舊密碼錯誤");
                }
                else
                {
                    SqlConnection con = new SqlConnection(strDBconnectionString);
                    con.Open();
                    string strSQL = "update member set name=@NewName, email=@NewEmail, address=@NewAddress, password=@NewPsw where uid=@SearchId;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@NewName", edit_Name.Text);
                    cmd.Parameters.AddWithValue("@NewEmail", edit_Email.Text);
                    cmd.Parameters.AddWithValue("@NewAddress", edit_Address.Text);
                    cmd.Parameters.AddWithValue("@NewPsw", edit_Psw.Text);
                    cmd.Parameters.AddWithValue("@SearchId", GlobalVar.userId);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("修改成功");

                    edit_OldPsw.Text = "";
                    edit_Psw.Text = "";

                }
            }
            else
            {
                MessageBox.Show("請輸入所有欄位");
            }
        }


        /*------------------ History List ------------------*/

        void history_list_record()
        {
            SqlConnection con = new SqlConnection(strDBconnectionString);
            con.Open();

            string strSQL = "select orderid as 訂單編號, updated as 訂購時間, pickup as 收貨方式, total as 訂單金額 from orderList where uid = @SearchId order by updated desc";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchId", GlobalVar.userId);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                history_List.DataSource = dt;
            }
            reader.Close();
            con.Close();
        }

        private void history_List_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                panel_History_info.Show();

                string strSelectedID = history_List.Rows[e.RowIndex].Cells[0].Value.ToString();
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
                        receive_Pickup.Text = reader["pickup"].ToString();
                        receive_Address.Text = reader["receive_address"].ToString();

                        receive_State.Text = reader["state"].ToString();

                        if (receive_State.Text == 0.ToString())
                        {
                            receive_State.Text = "處理中";
                        }
                        else
                        {
                            receive_State.Text = "已完成";
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

        private void back_Link_Click(object sender, EventArgs e)
        {
            panel_History_info.Hide();
        }
    }
}
