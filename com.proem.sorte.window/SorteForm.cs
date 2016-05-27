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
    public partial class SorteForm : Form
    {
        /// <summary>
        /// sorteList
        /// </summary>
        private sorteList sorteListForm;

        public SorteForm()
        {
            InitializeComponent();
        }

        public SorteForm(sorteList sorteListForm)
        {
            InitializeComponent();
            this.sorteListForm = sorteListForm;
        }

        private void SorteForm_Load(object sender, EventArgs e)
        {
            DateTime first = DateTime.Today;
            DateTime last = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            string sql = "select a.id, a.code, a.createTime,b.username, a.make_time from zc_sorte a left join zc_user_info b on b.user_id = a.make_men  where a.createTime between :first and :last order by a.createTime ";
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
                da.Fill(ds, "zc_sorte");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "zc_sorte";
                dataGridView1.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                OracleUtil.CloseConn(conn);
            }
        }

        private void SorteForm_KeyDown(object sender, KeyEventArgs e)
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
            string code = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string make_men = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string make_time = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            sorteListForm.setSorte(code, id, make_men, make_time);
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
