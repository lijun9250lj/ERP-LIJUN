using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_LIJUN.CommClass;
using ERP_LIJUN.DataClass;


namespace ERP_LIJUN
{
    public partial class FormLogin : Form
    {
        DataBase db = new DataBase();
        SqlDataReader sdr = null;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = "";
            string password = "";
            
            //判断输入的用户名是否为空
            if(String.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                try
                {
                    MessageBox.Show("用户名不能为空", "提示");
                    return;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示");
                }
                finally
                {

                }
            }
            //判断输入的密码是否为空
            if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                try
                {
                    MessageBox.Show("密码不能为空", "提示");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示");
                }
                finally
                {

                }
            }

            username = txtUsername.Text.Trim();
            password = txtPassword.Text.Trim();

            try
            {
               sdr = db.GetDataReader("select * from SYOperator where OperatorCode='"
                + username + "'" + "and PassWord='" + password + "'");
                sdr.Read();
                if (sdr.HasRows)
                {
                    FormMain formMain = new FormMain();
                    this.Hide();
                    PropertyClass.OperatorCode = sdr["OperatorCode"].ToString();
                    PropertyClass.OperatorName = sdr["OperatorName"].ToString();
                    PropertyClass.PassWord = sdr["PassWord"].ToString();
                    PropertyClass.IsAdmin = sdr["IsAdmin"].ToString();
                    formMain.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码不正确！");
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                sdr.Close();//务必要关掉
            }
            
        }
    }
}
