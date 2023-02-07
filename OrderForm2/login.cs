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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Security.Principal;
using System.Threading;

namespace OrderForm2
{
    public partial class login : Form
    {

        SqlConnectionStringBuilder scsb;
        string strDBconnectionString = "";

        public login()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void login_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb2";
            scsb.IntegratedSecurity = true;
            strDBconnectionString = scsb.ToString();


            panel_Redister.Hide();

        }

        private void register_Link_Click(object sender, EventArgs e)
        {
            cutover_Register();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {

            if ((login_Acct.Text != "") && (login_Psw.Text != ""))
            {

                string strAcct = login_Acct.Text;
                string strPsw = login_Psw.Text;

                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();

                string strSQL = "select * from member where phone in ('" + login_Acct.Text + "') and password in ('" + login_Psw.Text + "')";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    GlobalVar.userId = (int)reader["uid"];
                    GlobalVar.userName = reader["name"].ToString();
                    GlobalVar.userPhone = reader["phone"].ToString();
                    GlobalVar.userAddress = reader["address"].ToString();
                    GlobalVar.userEmail = reader["email"].ToString();
                    DateTime birthday = Convert.ToDateTime(reader["birth"]);
                    GlobalVar.userBirth = birthday.ToString("yyyy-MM-dd");
                    GlobalVar.userPsw = reader["password"].ToString();

                    MessageBox.Show("歡迎登入");

                    Close();
                }
                else
                {
                    //管理者帳密
                    if (login_Acct.Text == "admin" && login_Psw.Text == "1234")
                    {
                        MessageBox.Show("歡迎登入");
                        manage_member manage_member = new manage_member();
                        manage_member.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("帳號密碼有誤");
                        info_Clear();
                    }
                }

                reader.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("請輸入帳號密碼");
            }
        }

        private void login_Link_Click(object sender, EventArgs e)
        {
            cutover_Login();
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {

            if (reg_Acct.Text != "" && reg_Psw.Text != "" && reg_Psw_ckeck.Text != "" && reg_Name.Text != "" && reg_Email.Text != "" && reg_Address.Text != "")
            {

                if (reg_Acct.Text != "")
                {
                    string strPhone = reg_Acct.Text;
                    strPhone = strPhone.Replace("-", "");
                    strPhone = strPhone.Replace(" ", "");

                    bool checkPhone = Regex.IsMatch(strPhone, @"^09[0-9]{8}$");

                    if (checkPhone)
                    {
                        if (reg_Psw.Text != reg_Psw_ckeck.Text)
                        {
                            MessageBox.Show("密碼不一致");
                        }
                        else
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
                            cmd.Parameters.AddWithValue("@NewBirth", reg_Birth.Value.ToString("yyyy-MM-dd"));

                            int rows = cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("加入會員成功！");

                            info_Clear();
                            cutover_Login();
                        }
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
            reg_Psw_ckeck.Clear();
            reg_Email.Clear();
            reg_Address.Clear();
            reg_Birth.Value = DateTime.Now;
        }

        void cutover_Login()
        {
            panel_Login.Show();
            panel_Redister.Hide();
        }

        void cutover_Register()
        {
            panel_Login.Hide();
            panel_Redister.Show();
        }

    }
}
