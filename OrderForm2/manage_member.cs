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
using System.Text.RegularExpressions;

namespace OrderForm2
{
    public partial class manage_member : Form
    {

        SqlConnectionStringBuilder scsb;
        string strDBconnectionString = "";
        List<int> SearchIDs = new List<int>();

        public manage_member()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void manage_member_Load(object sender, EventArgs e)
        {

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb2";//database名稱
            scsb.IntegratedSecurity = true;
            strDBconnectionString = scsb.ToString();


            menu_List.Hide();
            edit_Block_hide();
            panel_Add_member.Hide();

            member_Info_list();
            

        }

        bool meun_Click;
        private void btn_Meun_list_Click(object sender, EventArgs e)
        {
            
            if (meun_Click != true)
            {
                menu_List.Hide();
                meun_Click = true;
                menu_List.Show();
            }
            else
            {
                menu_List.Show();
                meun_Click = false;
                menu_List.Hide();
            }
        }

        private void menu_List_member_Click(object sender, EventArgs e)
        {

        }

        private void menu_List_product_Click(object sender, EventArgs e)
        {
            manage_product manage_product = new manage_product();
            manage_product.ShowDialog();
        }

        private void menu_List_order_Click(object sender, EventArgs e)
        {
            manage_order manage_order = new manage_order();
            manage_order.ShowDialog();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("登出成功");
            this.Close();
        }


        void member_Info_list()
        {
            SqlConnection con = new SqlConnection(strDBconnectionString);
            con.Open();

            string strSQL = "select uid as 會員編號, name as 姓名, phone as 手機, address as 地址, email as Email, birth as 生日 from member";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                member_Info.DataSource = dt;
            }
            reader.Close();
            con.Close();
        }

        private void member_Info_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                edit_Block_show();

                string strSelectedID = member_Info.Rows[e.RowIndex].Cells[0].Value.ToString();
                int intSelID = 0;
                bool isID = Int32.TryParse(strSelectedID, out intSelID);

                if (isID)
                {
                    SqlConnection con = new SqlConnection(strDBconnectionString);
                    con.Open();
                    string strSQL = "select * from member where uid = @SearchID;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@SearchID", intSelID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        edit_Uid.Text = reader["uid"].ToString();
                        edit_Name.Text = reader["name"].ToString();
                        edit_Address.Text = reader["address"].ToString();
                        edit_Email.Text = reader["email"].ToString();
                        edit_Birth.Value = Convert.ToDateTime(reader["birth"]);
                    }
                    else
                    {
                        MessageBox.Show("查無此人");
                        edit_Block_hide();
                    }

                    reader.Close();
                    con.Close();
                }
            }
            else
            {
                edit_Block_hide();
            }
        }

        /*------------------ Edit Member ------------------*/

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(edit_Uid.Text, out intID);

            if ((intID > 0) && (edit_Name.Text != ""))
            {
                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strSQL = "update member set name=@NewName, email=@NewEmail,address=@NewAddress, birth=@NewBirthday where uid=@SearchId;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewName", edit_Name.Text);
                cmd.Parameters.AddWithValue("@NewEmail", edit_Email.Text);
                cmd.Parameters.AddWithValue("@NewAddress", edit_Address.Text);
                cmd.Parameters.AddWithValue("@NewBirthday", edit_Birth.Value);

                cmd.Parameters.AddWithValue("@SearchId", intID);

                int rows = cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("修改成功");

                edit_Block_hide();
                member_Info_list();

            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(edit_Uid.Text, out intID);

            if (intID > 0)
            {
                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strSQL = "delete from member where uid = @DeleteId;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@DeleteId", intID);

                int rows = cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("刪除成功");

                edit_Block_hide();
                member_Info_list();
            }
        }

        void edit_Block_hide()
        {
            edit_Block.Hide();
            btn_Edit.Hide();
            btn_Delete.Hide();
        }

        void edit_Block_show()
        {
            edit_Block.Show();
            btn_Edit.Show();
            btn_Delete.Show();
        }

        /*------------------ Search Member ------------------*/

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchIDs.Clear();

            if (txt_Search.Text != "")
            {

                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strSQL = "select uid as 會員編號, name as 姓名, phone as 手機, address as 地址, email as Email, birth as 生日 from member where name like @SearchKeyword";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchKeyword", "%" + txt_Search.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    member_Info.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("查無此人");
                }

                reader.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("請輸入查詢關鍵字");
            }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            if (txt_Search.Text == "")
            {
                edit_Block_hide();
                member_Info_list();
            }
        }

        private void txt_Search_Click(object sender, EventArgs e)
        {
            txt_Search.Text = "";
        }

        /*------------------ Add Member ------------------*/

        private void Add_member_link_Click(object sender, EventArgs e)
        {
            panel_Add_member.Show();
        }

        private void btn_Add_member_Click(object sender, EventArgs e)
        {
            if (reg_Acct.Text != "" && reg_Psw.Text != "" && reg_Name.Text != "" && reg_Email.Text != "" && reg_Address.Text != "")
            {

                if (reg_Acct.Text != "")
                {
                    string strPhone = reg_Acct.Text;
                    strPhone = strPhone.Replace("-", "");
                    strPhone = strPhone.Replace(" ", "");

                    bool checkPhone = Regex.IsMatch(strPhone, @"^09[0-9]{8}$");

                    if (checkPhone)
                    {

                        SqlConnection con = new SqlConnection(strDBconnectionString);
                        con.Open();
                        string strSQL = "insert member(name, phone, email, address, birth, password) values (@NewName, @NewPhone, @NewEmail, @NewAddress, @NewBirth, @NewPsw)";

                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@NewName", reg_Name.Text);
                        cmd.Parameters.AddWithValue("@NewPhone", reg_Acct.Text);
                        cmd.Parameters.AddWithValue("@NewPsw", reg_Psw.Text);
                        cmd.Parameters.AddWithValue("@NewEmail", reg_Email.Text);
                        cmd.Parameters.AddWithValue("@NewAddress", reg_Address.Text);
                        cmd.Parameters.AddWithValue("@NewBirth", reg_Birth.Value);

                        int rows = cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("新增成功！");
                        info_Clear();

                    }
                    else
                    {
                        MessageBox.Show("手機號碼格式有誤");
                    }
                }
            }
            else
            {
                MessageBox.Show("請輸入所有欄位");
            }
        }

        void info_Clear()
        {
            reg_Acct.Clear();
            reg_Name.Clear();
            reg_Psw.Clear();
            reg_Email.Clear();
            reg_Address.Clear();
            reg_Birth.Value = DateTime.Now;
        }

        private void member_List_Link_Click(object sender, EventArgs e)
        {
            panel_Add_member.Hide();
            member_Info_list();

        }

    }
}
