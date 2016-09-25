using Branch;
using Oracle.ManagedDataAccess.Client;
using sorteSystem.com.proem.sorte.domain;
using sorteSystem.com.proem.sorte.util;
using sorteSystem.com.proem.sorte.window.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace sorteSystem.com.proem.sorte.window
{
    public partial class sorteList : Form
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(typeof(sorteList));

        private string sorteId = "";
        DataSet ds = new DataSet();

        private bool isFirst = true;

        public sorteList()
        {
            InitializeComponent();
        }

        private Main mainForm;

        /// <summary>
        /// 0没有
        /// 1一条
        /// 2多条
        /// </summary>
        private string isExist;

        public sorteList(Main main)
        {
            InitializeComponent();
            this.mainForm = main;
        }

        private void sorteList_Load(object sender, EventArgs e)
        {
            loadIp();
            Times times = new Times();
            times.TopLevel = false;
            this.timePanel.Controls.Add(times);
            times.Show();

            DateTime first = DateTime.Today;
            DateTime last = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));

            //获取数据库连接
            OracleConnection connection = OracleUtil.OpenConn();
            string queryString = "select a.*,b.username as checkName,c.username as createName from zc_sorte a left join zc_user_info b on b.user_id=a.audit_men left join zc_user_info c on c.user_id=a.make_men where a.createTime between :first and :last";

            OracleCommand command = new OracleCommand(queryString);
            command.Parameters.Add(":first", first);
            command.Parameters.Add(":last", last);
            command.Connection = connection;
            List<Sorte> list = new List<Sorte>();
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Sorte newSorte = new Sorte();
                    String sorteId = reader.IsDBNull(reader.GetOrdinal("CODE")) ? string.Empty : reader.GetString(reader.GetOrdinal("CODE"));
                    String id = reader.IsDBNull(reader.GetOrdinal("ID")) ? string.Empty : reader.GetString(reader.GetOrdinal("ID"));
                    newSorte.makeMen = reader.IsDBNull(reader.GetOrdinal("createName")) ? string.Empty : reader.GetString(reader.GetOrdinal("createName"));
                    newSorte.createTime = reader.IsDBNull(reader.GetOrdinal("CREATETIME")) ? default(DateTime) : reader.GetDateTime(reader.GetOrdinal("CREATETIME"));
                    newSorte.makeTime = reader.IsDBNull(reader.GetOrdinal("make_time")) ? default(DateTime) : reader.GetDateTime(reader.GetOrdinal("make_time"));
                    newSorte.groupFlag = reader.IsDBNull(reader.GetOrdinal("groupflag")) ? default(int) : reader.GetInt32(reader.GetOrdinal("groupflag"));
                    newSorte.Id = id;
                    newSorte.code = sorteId;
                    list.Add(newSorte);
                }
            }
            catch (Exception ex)
            {
                log.Error("加载分拣单信息失败!", ex);
            }
            finally
            {
                if(connection != null){
                    connection.Close();
                }
            }
            if (list != null && list.Count == 1)
            {
                isExist = "1";
                Sorte obj = list[0];
                sorteId = obj.Id;
                ConstantUtil.sorte_id = obj.Id;
                ConstantUtil.groupFlag = obj.groupFlag;
                sorteTextBox.Text = obj.code;
                makeDateTextBox.Text = obj.makeTime.ToString();
                makerTextBox.Text = obj.makeMen;
                loadBranchTotal(obj.Id);
            }
            else if (list.Count == 0)
            {
                isExist = "0";
            }
            else
            {
                isExist = "2";
            }
            
        }

        private void loadIp()
        {
            string sql = "select workip from zc_workstation ";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                OracleDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string ip = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    ConstantUtil.ipList.Add(ip);
                }
            }
            catch (Exception e)
            {
                log.Error("加载各工位IP", e);
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
            DialogResult dr = MessageBox.Show("确定退出系统?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                //释放全部连接池资源
                OracleConnection.ClearAllPools();
                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
            }
        }

        private void typoButton_Click(object sender, EventArgs e)
        {

        }

        private void loadData()
        {
            sorteId = ConstantUtil.sorte_id;
            loadBranchTotal(sorteId);
        }

        private void sorteListTableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsANonHeaderLinkCell(e))
            {
            }
            else if (IsANonHeaderButtonCell(e))
            {
                if (isFirst)
                {
                    sorteGoodList goodsList = new sorteGoodList(this);
                    ConstantUtil.sortelist = this;
                    ConstantUtil.Branchds = ds;
                    ConstantUtil.index = e.RowIndex;
                    ConstantUtil.street = sorteListTableDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].Value.ToString();
                    ConstantUtil.main = goodsList;
                    goodsList.Show();
                    this.Hide();
                }
                else
                {
                    ConstantUtil.main.Show();
                    ConstantUtil.index = e.RowIndex;
                    ConstantUtil.street = sorteListTableDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].Value.ToString();
                    ConstantUtil.main.setSelectValue();
                    ConstantUtil.main.reLoadSaleTable();
                    this.Hide();
                }
                ConstantUtil.main.startSorte();
                isFirst = false;
            }
        }


        private bool IsANonHeaderLinkCell(DataGridViewCellEventArgs cellEvent)
        {
            if (sorteListTableDataGridView.Columns[cellEvent.ColumnIndex] is
                DataGridViewLinkColumn &&
                cellEvent.RowIndex != -1)
            { return true; }
            else { return false; }
        }

        private bool IsANonHeaderButtonCell(DataGridViewCellEventArgs cellEvent)
        {
            if (sorteListTableDataGridView.Columns[cellEvent.ColumnIndex] is
                DataGridViewButtonColumn &&
                cellEvent.RowIndex != -1)
            { return true; }
            else { return (false); }
        }


        /// <summary>
        /// 加载分店信息
        /// </summary>
        private void loadBranchTotal(string id)
        {
            ds.Clear();
            //DataTable dt = new DataTable();
            //dt.Columns.Add(new DataColumn("branch_code"));
            //dt.Columns.Add(new DataColumn("branch_name"));
            //dt.Columns.Add(new DataColumn("duty_man"));
            //dt.Columns.Add(new DataColumn("mobile_phone"));
            //dt.Columns.Add(new DataColumn("Column1"));
            //dt.Columns.Add(new DataColumn("id"));
            //dt.Columns.Add(new DataColumn("goodsFile_id"));
            //获取数据库连接
            OracleConnection connection = OracleUtil.OpenConn();
            string sql = "select a.*,b.branch_code,b.branch_name,c.username,c.mobilephone,d.street,'商品详情' as buttonText from Zc_sorte_item a "
                 + "left join zc_branch_total b on b.id=a.branch_total_id "
                 + "left join zc_user_info c on c.id=a.customer "
                 + "left join zc_zoning d on d.id=b.zoning_id "
                 + "where a.sorte_id ='" + id + "' order by b.branch_code asc ";
            OracleCommand cmd = new OracleCommand(sql, connection);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds, "Zc_sorte_item");
            sorteListTableDataGridView.DataSource = ds;
            sorteListTableDataGridView.AutoGenerateColumns = false;
            sorteListTableDataGridView.DataMember = "Zc_sorte_item";

            if (connection!= null)
            {
                connection.Close();
            }
            //sorteListTableDataGridView.CurrentCell = null;//不默认选中
            //OracleCommand command = new OracleCommand(sql);
            //command.Connection = connection;

            //try
            //{
            //    var reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        string branch_code = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("BRANCH_CODE"));
            //        string branch_name = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("BRANCH_NAME"));
            //        string duty_man = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("USERNAME"));
            //        string mobile_phone = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("MOBILEPHONE"));
            //        string Id = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("ID"));
            //        string goodsFile_id = reader.IsDBNull(1) ? string.Empty : reader.GetString(reader.GetOrdinal("STREET"));
            //        dt.Rows.Add(new object[] { branch_code, branch_name, duty_man, mobile_phone, "", Id, goodsFile_id });
            //    }
            //    sorteListTableDataGridView.AutoGenerateColumns = false;
            //    sorteListTableDataGridView.DataSource = dt;  
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    OracleUtil.CloseConn(connection);
            //}
        }

        private void sorteListPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableTopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sorteListTableDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //行号
            using (SolidBrush b = new SolidBrush(this.sorteListTableDataGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 5, e.RowBounds.Location.Y + 4);
            }
        }

        private void IPSetButton_Click(object sender, EventArgs e)
        {
            IPSet iPSet = new IPSet();
            iPSet.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mainForm.Show();
            this.Close();
        }

        private void sorteListTableDataGridView_Paint(object sender, PaintEventArgs e)
        {
            sorteListTableDataGridView.ClearSelection();
        }

        private void sorteList_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                leaveButton_Click(this, EventArgs.Empty);
            }else if(e.KeyCode == Keys.A)
            {
                button1_Click(this, EventArgs.Empty);
            }
            else if(e.KeyCode == Keys.F1)
            {
                if("1".Equals(isExist))
                {
                    MessageBox.Show("已选择唯一分拣单，无需重复选择", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                else if ("0".Equals(isExist))
                {
                    MessageBox.Show("尚未创建分拣单", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    SorteForm sorteForm = new SorteForm(this);
                    sorteForm.StartPosition = FormStartPosition.CenterScreen;
                    sorteForm.Show();
                }
            }else if(e.KeyCode == Keys.Enter){
                int index = sorteListTableDataGridView.CurrentCell.RowIndex;
                ConstantUtil.sortelist = this;
                ConstantUtil.Branchds = ds;
                ConstantUtil.index = index;
                ConstantUtil.street = sorteListTableDataGridView.Rows[index].Cells[0].Value.ToString();
                if (isFirst)
                {
                    sorteGoodList goodsList = new sorteGoodList(this);
                    ConstantUtil.main = goodsList;
                }
                else
                {
                    ConstantUtil.main.setSelectValue();
                    ConstantUtil.main.reLoadSaleTable();
                }
                ConstantUtil.main.Show();
                ConstantUtil.main.startSorte();
                this.Hide();
                isFirst = false;
            }
        }

        public void setSorte(string code, string id, string name, string time, int flag)
        {
            sorteTextBox.Text = code;
            makerTextBox.Text = name;
            makeDateTextBox.Text = time;
            sorteId = id;
            ConstantUtil.sorte_id = id;
            ConstantUtil.groupFlag = flag;
            loadData();
        }

        public void returnToMain()
        {
            ConstantUtil.main.Close();
            button1_Click(this, EventArgs.Empty);
        }
    }
}
