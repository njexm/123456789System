namespace sorteSystem.com.proem.sorte.window
{
    partial class SorteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.body = new System.Windows.Forms.Panel();
            this.enterButton = new System.Windows.Forms.Button();
            this.escButton = new System.Windows.Forms.Button();
            this.main = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.odd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.make_men = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.make_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.body.SuspendLayout();
            this.main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // body
            // 
            this.body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.body.BackgroundImage = global::sorteSystem.Properties.Resources.login_bg_0;
            this.body.Controls.Add(this.enterButton);
            this.body.Controls.Add(this.escButton);
            this.body.Controls.Add(this.main);
            this.body.Location = new System.Drawing.Point(1, 1);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(583, 361);
            this.body.TabIndex = 0;
            // 
            // enterButton
            // 
            this.enterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.enterButton.FlatAppearance.BorderSize = 0;
            this.enterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterButton.Font = new System.Drawing.Font("宋体", 16F);
            this.enterButton.ForeColor = System.Drawing.Color.White;
            this.enterButton.Location = new System.Drawing.Point(300, 300);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(120, 40);
            this.enterButton.TabIndex = 2;
            this.enterButton.Text = "确定(Ent)";
            this.enterButton.UseVisualStyleBackColor = false;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // escButton
            // 
            this.escButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.escButton.FlatAppearance.BorderSize = 0;
            this.escButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.escButton.Font = new System.Drawing.Font("宋体", 16F);
            this.escButton.ForeColor = System.Drawing.Color.White;
            this.escButton.Location = new System.Drawing.Point(166, 300);
            this.escButton.Name = "escButton";
            this.escButton.Size = new System.Drawing.Size(120, 40);
            this.escButton.TabIndex = 1;
            this.escButton.Text = "取消(Esc)";
            this.escButton.UseVisualStyleBackColor = false;
            this.escButton.Click += new System.EventHandler(this.escButton_Click);
            // 
            // main
            // 
            this.main.Controls.Add(this.dataGridView1);
            this.main.Location = new System.Drawing.Point(0, 0);
            this.main.Name = "main";
            this.main.Size = new System.Drawing.Size(583, 263);
            this.main.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.odd,
            this.createTime,
            this.id,
            this.make_men,
            this.make_time,
            this.groupFlag});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(583, 263);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // odd
            // 
            this.odd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.odd.DataPropertyName = "code";
            this.odd.FillWeight = 0.5F;
            this.odd.HeaderText = "分拣单号";
            this.odd.Name = "odd";
            this.odd.ReadOnly = true;
            // 
            // createTime
            // 
            this.createTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.createTime.DataPropertyName = "createTime";
            this.createTime.FillWeight = 0.5F;
            this.createTime.HeaderText = "创建时间";
            this.createTime.Name = "createTime";
            this.createTime.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // make_men
            // 
            this.make_men.DataPropertyName = "username";
            this.make_men.HeaderText = "makeman";
            this.make_men.Name = "make_men";
            this.make_men.ReadOnly = true;
            this.make_men.Visible = false;
            // 
            // make_time
            // 
            this.make_time.DataPropertyName = "make_time";
            this.make_time.HeaderText = "makeTime";
            this.make_time.Name = "make_time";
            this.make_time.ReadOnly = true;
            this.make_time.Visible = false;
            // 
            // groupFlag
            // 
            this.groupFlag.DataPropertyName = "groupFlag";
            this.groupFlag.HeaderText = "groupFlag";
            this.groupFlag.Name = "groupFlag";
            this.groupFlag.ReadOnly = true;
            this.groupFlag.Visible = false;
            // 
            // SorteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.body);
            this.KeyPreview = true;
            this.Name = "SorteForm";
            this.Text = "选择分拣单";
            this.Load += new System.EventHandler(this.SorteForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SorteForm_KeyDown);
            this.body.ResumeLayout(false);
            this.main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel body;
        private System.Windows.Forms.Panel main;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Button escButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn odd;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn make_men;
        private System.Windows.Forms.DataGridViewTextBoxColumn make_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupFlag;
    }
}