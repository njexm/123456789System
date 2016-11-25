using Branch;
using log4net;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sorteSystem.com.proem.sorte.window
{
    public partial class BranchChoose : Form
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(typeof(BranchChoose));

        private ReturnGoods returnGoods;

        private SorteWithoutOrder sorteWithOutOrder;

        public BranchChoose()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="returnGoods"></param>
        public BranchChoose(ReturnGoods returnGoods)
        {
            InitializeComponent();
            this.returnGoods = returnGoods;
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="sorteWithOutOrder"></param>
        public BranchChoose(SorteWithoutOrder sorteWithOutOrder) 
        {
            InitializeComponent();
            this.sorteWithOutOrder = sorteWithOutOrder;
        }

        private void BranchChoose_KeyDown(object sender, KeyEventArgs e)
        {
            if(textBox1.Focused && e.KeyCode == Keys.Enter){
                enterButton_Click(this, EventArgs.Empty);
            }
            if(e.KeyCode == Keys.Escape){
                escButton_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (branchDataGridView.DataSource == null || branchDataGridView.RowCount == 0)
                {
                    return;
                }
                int index = branchDataGridView.CurrentRow.Index;
                if (index > 0)
                {
                    branchDataGridView.Rows[index - 1].Selected = true;
                    branchDataGridView.CurrentCell = branchDataGridView.Rows[index - 1].Cells[0];
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (branchDataGridView.DataSource == null || branchDataGridView.RowCount == 0)
                {
                    return;
                }
                int index = branchDataGridView.CurrentRow.Index;
                if (index < branchDataGridView.RowCount - 1)
                {
                    branchDataGridView.Rows[index + 1].Selected = true;
                    branchDataGridView.CurrentCell = branchDataGridView.Rows[index + 1].Cells[0];
                }
                
            }
        }

        private void BranchChoose_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            loadBranch();
        }

        private void BranchChoose_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterButton_Click(object sender, EventArgs e)
        {
            if (branchDataGridView.DataSource == null || branchDataGridView.RowCount == 0)
            {
                return;
            }
            string street = branchDataGridView.CurrentRow.Cells[0].Value.ToString();
            string branchName = branchDataGridView.CurrentRow.Cells[1].Value.ToString();
            string id = branchDataGridView.CurrentRow.Cells[2].Value.ToString();
            if (returnGoods != null)
            {
                returnGoods.setBranch(street, branchName);
            }
            else {
                sorteWithOutOrder.setBranch(street, branchName, id);
            }
            this.Close();
        }

        /// <summary>
        /// 取消，关闭页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void escButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 条件查询所有亭点
        /// </summary>
        private void loadBranch() {
            string sql = "select b.STREET, a.BRANCH_NAME as branchName, a.id  from ZC_BRANCH_TOTAL a left join ZC_ZONING b on a.ZONING_ID = b.id where 1=1  ";
            string text = textBox1.Text.Trim();
            if(!string.IsNullOrEmpty(text)){
                sql += " and (b.street like '%" + text + "%' or a.BRANCH_NAME like '%" + text + "%') ";
            }
            sql += " order by STREET asc";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                DataSet ds = new DataSet();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds, "zc_branch_total");
                branchDataGridView.AutoGenerateColumns = false;
                branchDataGridView.DataSource = ds;
                branchDataGridView.DataMember = "zc_branch_total";
            }
            catch (Exception ex)
            {
                log.Error("加载分店信息失败", ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loadBranch();
        }

        private void branchDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //行号
            using (SolidBrush b = new SolidBrush(this.branchDataGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 5, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
