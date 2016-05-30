namespace sorteSystem.com.proem.sorte.window
{
    partial class sorteList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sorteListPanel = new System.Windows.Forms.Panel();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.leaveButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.logoLabel = new System.Windows.Forms.Label();
            this.timePanel = new System.Windows.Forms.Panel();
            this.listGroupBox = new System.Windows.Forms.GroupBox();
            this.sorteTablePanel = new System.Windows.Forms.Panel();
            this.sorteListTableDataGridView = new System.Windows.Forms.DataGridView();
            this.branch_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branch_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobilephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id = new System.Windows.Forms.DataGridViewButtonColumn();
            this.street = new System.Windows.Forms.DataGridViewButtonColumn();
            this.titleGroupBox = new System.Windows.Forms.GroupBox();
            this.sorteTextBox = new System.Windows.Forms.TextBox();
            this.makeDateTextBox = new System.Windows.Forms.TextBox();
            this.remarkTextBox = new System.Windows.Forms.TextBox();
            this.remarkLabel = new System.Windows.Forms.Label();
            this.makerTextBox = new System.Windows.Forms.TextBox();
            this.makerLabel = new System.Windows.Forms.Label();
            this.makeDatelabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.sorteListPanel.SuspendLayout();
            this.logoPanel.SuspendLayout();
            this.listGroupBox.SuspendLayout();
            this.sorteTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sorteListTableDataGridView)).BeginInit();
            this.titleGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sorteListPanel
            // 
            this.sorteListPanel.BackgroundImage = global::sorteSystem.Properties.Resources.login_bg_0;
            this.sorteListPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sorteListPanel.Controls.Add(this.logoPanel);
            this.sorteListPanel.Controls.Add(this.listGroupBox);
            this.sorteListPanel.Controls.Add(this.titleGroupBox);
            this.sorteListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sorteListPanel.Location = new System.Drawing.Point(0, 0);
            this.sorteListPanel.Name = "sorteListPanel";
            this.sorteListPanel.Size = new System.Drawing.Size(1000, 700);
            this.sorteListPanel.TabIndex = 0;
            this.sorteListPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.sorteListPanel_Paint);
            // 
            // logoPanel
            // 
            this.logoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logoPanel.BackgroundImage = global::sorteSystem.Properties.Resources.login_bg_2;
            this.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPanel.Controls.Add(this.button1);
            this.logoPanel.Controls.Add(this.leaveButton);
            this.logoPanel.Controls.Add(this.panel4);
            this.logoPanel.Controls.Add(this.logoLabel);
            this.logoPanel.Controls.Add(this.timePanel);
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(1000, 75);
            this.logoPanel.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(772, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 30;
            this.button1.Text = "返回(A)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // leaveButton
            // 
            this.leaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.leaveButton.FlatAppearance.BorderSize = 0;
            this.leaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leaveButton.Font = new System.Drawing.Font("宋体", 12F);
            this.leaveButton.ForeColor = System.Drawing.Color.White;
            this.leaveButton.Location = new System.Drawing.Point(890, 10);
            this.leaveButton.Name = "leaveButton";
            this.leaveButton.Size = new System.Drawing.Size(100, 40);
            this.leaveButton.TabIndex = 1;
            this.leaveButton.Text = "退出(ESC)";
            this.leaveButton.UseVisualStyleBackColor = false;
            this.leaveButton.Click += new System.EventHandler(this.leaveButton_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel4.BackgroundImage = global::sorteSystem.Properties.Resources.logo;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(20, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 55);
            this.panel4.TabIndex = 28;
            // 
            // logoLabel
            // 
            this.logoLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.logoLabel.AutoSize = true;
            this.logoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.logoLabel.Font = new System.Drawing.Font("宋体", 32F);
            this.logoLabel.Location = new System.Drawing.Point(220, 16);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(191, 43);
            this.logoLabel.TabIndex = 27;
            this.logoLabel.Text = "分拣系统";
            // 
            // timePanel
            // 
            this.timePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.timePanel.Location = new System.Drawing.Point(520, 15);
            this.timePanel.Name = "timePanel";
            this.timePanel.Size = new System.Drawing.Size(119, 32);
            this.timePanel.TabIndex = 25;
            // 
            // listGroupBox
            // 
            this.listGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.listGroupBox.Controls.Add(this.sorteTablePanel);
            this.listGroupBox.Location = new System.Drawing.Point(0, 198);
            this.listGroupBox.Name = "listGroupBox";
            this.listGroupBox.Size = new System.Drawing.Size(1000, 502);
            this.listGroupBox.TabIndex = 1;
            this.listGroupBox.TabStop = false;
            this.listGroupBox.Text = "单据列表";
            // 
            // sorteTablePanel
            // 
            this.sorteTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sorteTablePanel.Controls.Add(this.sorteListTableDataGridView);
            this.sorteTablePanel.Location = new System.Drawing.Point(5, 20);
            this.sorteTablePanel.Name = "sorteTablePanel";
            this.sorteTablePanel.Size = new System.Drawing.Size(990, 477);
            this.sorteTablePanel.TabIndex = 1;
            // 
            // sorteListTableDataGridView
            // 
            this.sorteListTableDataGridView.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.sorteListTableDataGridView.AllowUserToAddRows = false;
            this.sorteListTableDataGridView.AllowUserToDeleteRows = false;
            this.sorteListTableDataGridView.AllowUserToResizeColumns = false;
            this.sorteListTableDataGridView.AllowUserToResizeRows = false;
            this.sorteListTableDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.sorteListTableDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sorteListTableDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.sorteListTableDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 19F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sorteListTableDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sorteListTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sorteListTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.branch_code,
            this.branch_name,
            this.userName,
            this.mobilephone,
            this.detailButton,
            this.id,
            this.street});
            this.sorteListTableDataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 19F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sorteListTableDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.sorteListTableDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sorteListTableDataGridView.EnableHeadersVisualStyles = false;
            this.sorteListTableDataGridView.Location = new System.Drawing.Point(0, 0);
            this.sorteListTableDataGridView.MultiSelect = false;
            this.sorteListTableDataGridView.Name = "sorteListTableDataGridView";
            this.sorteListTableDataGridView.ReadOnly = true;
            this.sorteListTableDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.sorteListTableDataGridView.RowHeadersWidth = 50;
            this.sorteListTableDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.sorteListTableDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.sorteListTableDataGridView.RowTemplate.Height = 35;
            this.sorteListTableDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sorteListTableDataGridView.ShowEditingIcon = false;
            this.sorteListTableDataGridView.Size = new System.Drawing.Size(990, 477);
            this.sorteListTableDataGridView.TabIndex = 0;
            this.sorteListTableDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sorteListTableDataGridView_CellContentClick);
            this.sorteListTableDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.sorteListTableDataGridView_RowPostPaint);
            this.sorteListTableDataGridView.Paint += new System.Windows.Forms.PaintEventHandler(this.sorteListTableDataGridView_Paint);
            // 
            // branch_code
            // 
            this.branch_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.branch_code.DataPropertyName = "branch_code";
            this.branch_code.FillWeight = 0.2F;
            this.branch_code.HeaderText = "分店编码";
            this.branch_code.Name = "branch_code";
            this.branch_code.ReadOnly = true;
            // 
            // branch_name
            // 
            this.branch_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.branch_name.DataPropertyName = "branch_name";
            this.branch_name.FillWeight = 0.2F;
            this.branch_name.HeaderText = "分店名称";
            this.branch_name.Name = "branch_name";
            this.branch_name.ReadOnly = true;
            // 
            // userName
            // 
            this.userName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.userName.DataPropertyName = "username";
            this.userName.FillWeight = 0.2F;
            this.userName.HeaderText = "分店负责人";
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            // 
            // mobilephone
            // 
            this.mobilephone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mobilephone.DataPropertyName = "mobilephone";
            this.mobilephone.FillWeight = 0.2F;
            this.mobilephone.HeaderText = "联系方式";
            this.mobilephone.Name = "mobilephone";
            this.mobilephone.ReadOnly = true;
            // 
            // detailButton
            // 
            this.detailButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.detailButton.DataPropertyName = "buttonText";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.detailButton.DefaultCellStyle = dataGridViewCellStyle2;
            this.detailButton.FillWeight = 0.2F;
            this.detailButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detailButton.HeaderText = "操作";
            this.detailButton.Name = "detailButton";
            this.detailButton.ReadOnly = true;
            this.detailButton.Text = "商品详情";
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // street
            // 
            this.street.DataPropertyName = "street";
            this.street.HeaderText = "street";
            this.street.Name = "street";
            this.street.ReadOnly = true;
            this.street.Visible = false;
            // 
            // titleGroupBox
            // 
            this.titleGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(210)))), ((int)(((byte)(222)))));
            this.titleGroupBox.Controls.Add(this.sorteTextBox);
            this.titleGroupBox.Controls.Add(this.makeDateTextBox);
            this.titleGroupBox.Controls.Add(this.remarkTextBox);
            this.titleGroupBox.Controls.Add(this.remarkLabel);
            this.titleGroupBox.Controls.Add(this.makerTextBox);
            this.titleGroupBox.Controls.Add(this.makerLabel);
            this.titleGroupBox.Controls.Add(this.makeDatelabel);
            this.titleGroupBox.Controls.Add(this.idLabel);
            this.titleGroupBox.Location = new System.Drawing.Point(0, 75);
            this.titleGroupBox.Name = "titleGroupBox";
            this.titleGroupBox.Size = new System.Drawing.Size(1000, 122);
            this.titleGroupBox.TabIndex = 0;
            this.titleGroupBox.TabStop = false;
            this.titleGroupBox.Text = "单据详情";
            // 
            // sorteTextBox
            // 
            this.sorteTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sorteTextBox.Enabled = false;
            this.sorteTextBox.Location = new System.Drawing.Point(115, 35);
            this.sorteTextBox.Name = "sorteTextBox";
            this.sorteTextBox.Size = new System.Drawing.Size(450, 21);
            this.sorteTextBox.TabIndex = 15;
            this.sorteTextBox.Text = "按F1选择一条分拣单";
            // 
            // makeDateTextBox
            // 
            this.makeDateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.makeDateTextBox.Enabled = false;
            this.makeDateTextBox.Location = new System.Drawing.Point(760, 36);
            this.makeDateTextBox.Name = "makeDateTextBox";
            this.makeDateTextBox.Size = new System.Drawing.Size(185, 21);
            this.makeDateTextBox.TabIndex = 14;
            // 
            // remarkTextBox
            // 
            this.remarkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.remarkTextBox.Enabled = false;
            this.remarkTextBox.Location = new System.Drawing.Point(115, 73);
            this.remarkTextBox.Name = "remarkTextBox";
            this.remarkTextBox.Size = new System.Drawing.Size(450, 21);
            this.remarkTextBox.TabIndex = 7;
            // 
            // remarkLabel
            // 
            this.remarkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.remarkLabel.AutoSize = true;
            this.remarkLabel.Location = new System.Drawing.Point(35, 76);
            this.remarkLabel.Name = "remarkLabel";
            this.remarkLabel.Size = new System.Drawing.Size(65, 12);
            this.remarkLabel.TabIndex = 6;
            this.remarkLabel.Text = "备注信息：";
            // 
            // makerTextBox
            // 
            this.makerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.makerTextBox.Enabled = false;
            this.makerTextBox.Location = new System.Drawing.Point(760, 73);
            this.makerTextBox.Name = "makerTextBox";
            this.makerTextBox.Size = new System.Drawing.Size(185, 21);
            this.makerTextBox.TabIndex = 5;
            // 
            // makerLabel
            // 
            this.makerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.makerLabel.AutoSize = true;
            this.makerLabel.Location = new System.Drawing.Point(662, 73);
            this.makerLabel.Name = "makerLabel";
            this.makerLabel.Size = new System.Drawing.Size(53, 12);
            this.makerLabel.TabIndex = 4;
            this.makerLabel.Text = "制单人：";
            // 
            // makeDatelabel
            // 
            this.makeDatelabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.makeDatelabel.AutoSize = true;
            this.makeDatelabel.Location = new System.Drawing.Point(662, 39);
            this.makeDatelabel.Name = "makeDatelabel";
            this.makeDatelabel.Size = new System.Drawing.Size(65, 12);
            this.makeDatelabel.TabIndex = 2;
            this.makeDatelabel.Text = "制单日期：";
            // 
            // idLabel
            // 
            this.idLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(35, 39);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(53, 12);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "单据号：";
            // 
            // sorteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.sorteListPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "sorteList";
            this.RightToLeftLayout = true;
            this.Text = "供应商结算单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.sorteList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sorteList_KeyDown);
            this.sorteListPanel.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            this.logoPanel.PerformLayout();
            this.listGroupBox.ResumeLayout(false);
            this.sorteTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sorteListTableDataGridView)).EndInit();
            this.titleGroupBox.ResumeLayout(false);
            this.titleGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sorteListPanel;
        private System.Windows.Forms.GroupBox titleGroupBox;
        private System.Windows.Forms.GroupBox listGroupBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label makeDatelabel;
        private System.Windows.Forms.Label makerLabel;
        private System.Windows.Forms.TextBox makerTextBox;
        private System.Windows.Forms.TextBox remarkTextBox;
        private System.Windows.Forms.Label remarkLabel;
        private System.Windows.Forms.TextBox makeDateTextBox;
        private System.Windows.Forms.Button leaveButton;
        private System.Windows.Forms.Panel sorteTablePanel;
        private System.Windows.Forms.DataGridView sorteListTableDataGridView;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Panel timePanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox sorteTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobilephone;
        private System.Windows.Forms.DataGridViewButtonColumn detailButton;
        private System.Windows.Forms.DataGridViewButtonColumn id;
        private System.Windows.Forms.DataGridViewButtonColumn street;
    }
}