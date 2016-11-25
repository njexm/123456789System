namespace sorteSystem.com.proem.sorte.window
{
    partial class BranchChoose
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.escButton = new System.Windows.Forms.Button();
            this.enterButton = new System.Windows.Forms.Button();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.branchDataGridView = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainPanel.SuspendLayout();
            this.bodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.branchDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackgroundImage = global::sorteSystem.Properties.Resources.login_bg_0;
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainPanel.Controls.Add(this.escButton);
            this.mainPanel.Controls.Add(this.enterButton);
            this.mainPanel.Controls.Add(this.bodyPanel);
            this.mainPanel.Controls.Add(this.textBox1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(584, 361);
            this.mainPanel.TabIndex = 0;
            // 
            // escButton
            // 
            this.escButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.escButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.escButton.FlatAppearance.BorderSize = 0;
            this.escButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.escButton.Font = new System.Drawing.Font("宋体", 16F);
            this.escButton.ForeColor = System.Drawing.Color.White;
            this.escButton.Location = new System.Drawing.Point(158, 286);
            this.escButton.Name = "escButton";
            this.escButton.Size = new System.Drawing.Size(120, 40);
            this.escButton.TabIndex = 2;
            this.escButton.Text = "取消(Esc)";
            this.escButton.UseVisualStyleBackColor = false;
            this.escButton.Click += new System.EventHandler(this.escButton_Click);
            // 
            // enterButton
            // 
            this.enterButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.enterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.enterButton.FlatAppearance.BorderSize = 0;
            this.enterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterButton.Font = new System.Drawing.Font("宋体", 16F);
            this.enterButton.ForeColor = System.Drawing.Color.White;
            this.enterButton.Location = new System.Drawing.Point(305, 286);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(120, 40);
            this.enterButton.TabIndex = 3;
            this.enterButton.Text = "确定(Ent)";
            this.enterButton.UseVisualStyleBackColor = false;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // bodyPanel
            // 
            this.bodyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bodyPanel.Controls.Add(this.branchDataGridView);
            this.bodyPanel.Location = new System.Drawing.Point(0, 60);
            this.bodyPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(584, 220);
            this.bodyPanel.TabIndex = 1;
            // 
            // branchDataGridView
            // 
            this.branchDataGridView.AllowUserToAddRows = false;
            this.branchDataGridView.AllowUserToDeleteRows = false;
            this.branchDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 20F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.branchDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.branchDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.branchDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.street,
            this.branchName,
            this.id});
            this.branchDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.branchDataGridView.Location = new System.Drawing.Point(0, 0);
            this.branchDataGridView.MultiSelect = false;
            this.branchDataGridView.Name = "branchDataGridView";
            this.branchDataGridView.ReadOnly = true;
            this.branchDataGridView.RowTemplate.Height = 23;
            this.branchDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.branchDataGridView.Size = new System.Drawing.Size(584, 220);
            this.branchDataGridView.TabIndex = 0;
            this.branchDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.branchDataGridView_RowPostPaint);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 16F);
            this.textBox1.Location = new System.Drawing.Point(20, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 32);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // street
            // 
            this.street.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.street.DataPropertyName = "street";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.street.DefaultCellStyle = dataGridViewCellStyle2;
            this.street.FillWeight = 0.5F;
            this.street.HeaderText = "分店编码";
            this.street.Name = "street";
            this.street.ReadOnly = true;
            // 
            // branchName
            // 
            this.branchName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.branchName.DataPropertyName = "branchName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.branchName.DefaultCellStyle = dataGridViewCellStyle3;
            this.branchName.FillWeight = 0.5F;
            this.branchName.HeaderText = "分店名称";
            this.branchName.Name = "branchName";
            this.branchName.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // BranchChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.mainPanel);
            this.KeyPreview = true;
            this.Name = "BranchChoose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择亭点";
            this.Activated += new System.EventHandler(this.BranchChoose_Activated);
            this.Load += new System.EventHandler(this.BranchChoose_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BranchChoose_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.bodyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.branchDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.DataGridView branchDataGridView;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Button escButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn street;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}