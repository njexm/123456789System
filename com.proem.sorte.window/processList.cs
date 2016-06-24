using Branch;
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
    public partial class processList : Form
    {
        /// <summary>
        /// process
        /// </summary>
        private Process process;

        public processList()
        {
            InitializeComponent();
        }

        public processList(Process process)
        {
            InitializeComponent();
            this.process = process;
        }

        private void processList_Load(object sender, EventArgs e)
        {
            DateTime first = DateTime.Today;
            DateTime last = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            string sql = "select id, odd, createTime from zc_processgoods where createTime between :first and :last order by createTime ";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            DataSet ds = new DataSet();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":first", first);
                cmd.Parameters.Add(":last", last);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds, "zc_processgoods");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "zc_processgoods";
                dataGridView1.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                //OracleUtil.CloseConn(conn);
            }
        }

        private void processList_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                enterButton_Click(this, EventArgs.Empty);
            }else if(e.KeyCode == Keys.Escape)
            {
                escButton_Click(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterButton_Click(object sender, EventArgs e)
        {
            string odd = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            process.setOddAndProcessId(odd, id);
            this.Close();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void escButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //行号
            using (SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 5, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
