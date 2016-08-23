using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Branch;
using sorteSystem.com.proem.sorte.window.util;
using sorteSystem.com.proem.sorte.util;
using log4net;

namespace Branch
{
    public partial class BranchLogin : Form
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(typeof(BranchLogin));

        public BranchLogin()
        {
            InitializeComponent();
        }

        private bool textbox_focus = true;

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = this.userNameTextBox.Text.Trim();
            string pass = this.userPasswordTextBox.Text.Trim();
            if (username.Equals("") || pass.Equals(""))
            {
                promptPanel.Show();
            }
            else
            {
                //调用Md5 获取加密后的密码
                string password = MD5Util.GetMd5(pass);
                //获取数据库连接
                OracleConnection connection = OracleUtil.OpenConn();
                string queryString = "select password from ctp_user where name ='" + username + "'";

                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = queryString;
                try
                {
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string confirmPassword = string.Format("{0}", reader["password"]);
                        if (password.Equals(confirmPassword))
                        {
                            //用户名，密码验证成功
                            //加载权限
                            //loadUserRole(username);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            promptPanel.Show();
                            //MessageBox.Show("用户名或者密码输入错误,请重新输入!");
                        }
                    }
                    else
                    {
                        promptPanel.Show();
                        //MessageBox.Show("用户名或者密码输入错误,请重新输入!");
                    }
                }
                catch (Exception ex)
                {
                    log.Error("获取登录信息失败" + ex.Message, ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 加载用户权限
        /// </summary>
        /// <param name="username"></param>
        private void loadUserRole(string username)
        {
            string sql = "select c.description from CTP_USER a left join CTP_REL_USER_ROLE b on a.id = b.LEFTID left join ctp_role c on b.rightId = c.id where a.name = '"+username+"'";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    ConstantUtil.UserRole = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                log.Error("获取当前登录用户角色失败"+ex.Message, ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
            }
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            //释放全部连接池资源
            OracleConnection.ClearAllPools();
            System.Environment.Exit(0);
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void userPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            promptPanel.Hide();
        }

        private void userNameTextBox_Click(object sender, EventArgs e)
        {
            textbox_focus = true;
        }

        private void userPasswordTextBox_Click(object sender, EventArgs e)
        {
            textbox_focus = false;
        }

        private void BranchLogin_Load(object sender, EventArgs e)
        {
            Times times = new Times();
            times.TopLevel = false;
            this.timePanel.Controls.Add(times);
            times.Show();
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "1";
            }
            else
            {
                userPasswordTextBox.Text += "1";
            }
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "2";
            }
            else
            {
                userPasswordTextBox.Text += "2";
            }
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "3";
            }
            else
            {
                userPasswordTextBox.Text += "3";
            }
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "4";
            }
            else
            {
                userPasswordTextBox.Text += "4";
            }
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "5";
            }
            else
            {
                userPasswordTextBox.Text += "5";
            }
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "6";
            }
            else
            {
                userPasswordTextBox.Text += "6";
            }
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "7";
            }
            else
            {
                userPasswordTextBox.Text += "7";
            }
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "8";
            }
            else
            {
                userPasswordTextBox.Text += "8";
            }
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "9";
            }
            else
            {
                userPasswordTextBox.Text += "9";
            }
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "0";
            }
            else
            {
                userPasswordTextBox.Text += "0";
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                if (userNameTextBox.Text.Length > 0)
                {
                    userNameTextBox.Text = userNameTextBox.Text.Remove(userNameTextBox.Text.Length - 1, 1);
                }
            }
            else
            {
                if (userPasswordTextBox.Text.Length > 0)
                {
                    userPasswordTextBox.Text = userPasswordTextBox.Text.Remove(userPasswordTextBox.Text.Length - 1, 1);
                }
            }
        }
        
        private void clearBotton_Click(object sender, EventArgs e)
        {
            this.userNameTextBox.Clear();
            this.userPasswordTextBox.Clear();
            this.userNameTextBox.Focus();
        }

        private void BranchLogin_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
                
            //}
            if (e.KeyCode == Keys.Escape)
            {
                leaveButton_Click(this, EventArgs.Empty);
            }else if(e.KeyCode == Keys.Enter && userNameTextBox.Focused){
                userPasswordTextBox.Focus();
            }else if(e.KeyCode == Keys.Enter)
            {
                loginButton_Click(this, EventArgs.Empty);
            }
        }

        private void userNameTextBox_TextChanged_1(object sender, EventArgs e)
        {
            promptPanel.Hide();
        }

    }
}
