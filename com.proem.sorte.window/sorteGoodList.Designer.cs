﻿namespace sorteSystem.com.proem.sorte.window
{
    partial class sorteGoodList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.pTimer = new System.Windows.Forms.Timer(this.components);
            this.sorteGoodListPanel = new System.Windows.Forms.Panel();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.logoLabel = new System.Windows.Forms.Label();
            this.timePanel = new System.Windows.Forms.Panel();
            this.branchIdLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.goodTableGroupBox = new System.Windows.Forms.GroupBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.calculateButton = new System.Windows.Forms.Button();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.Timebutton = new System.Windows.Forms.Button();
            this.greenLabel = new System.Windows.Forms.Label();
            this.yellowLabel = new System.Windows.Forms.Label();
            this.redLabel = new System.Windows.Forms.Label();
            this.greenButton = new System.Windows.Forms.Button();
            this.yellowButton = new System.Windows.Forms.Button();
            this.nextbutton = new System.Windows.Forms.Button();
            this.redButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.endButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.goodTablePanel = new System.Windows.Forms.Panel();
            this.goodDataGridView = new System.Windows.Forms.DataGridView();
            this.serialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sorteNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsfile_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messagePanel = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sorteGoodListPanel.SuspendLayout();
            this.logoPanel.SuspendLayout();
            this.goodTableGroupBox.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.goodTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goodDataGridView)).BeginInit();
            this.messagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // sorteGoodListPanel
            // 
            this.sorteGoodListPanel.BackgroundImage = global::sorteSystem.Properties.Resources.login_bg_0;
            this.sorteGoodListPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sorteGoodListPanel.Controls.Add(this.logoPanel);
            this.sorteGoodListPanel.Controls.Add(this.goodTableGroupBox);
            this.sorteGoodListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sorteGoodListPanel.Location = new System.Drawing.Point(0, 0);
            this.sorteGoodListPanel.Name = "sorteGoodListPanel";
            this.sorteGoodListPanel.Size = new System.Drawing.Size(800, 600);
            this.sorteGoodListPanel.TabIndex = 0;
            // 
            // logoPanel
            // 
            this.logoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logoPanel.BackgroundImage = global::sorteSystem.Properties.Resources.login_bg_2;
            this.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPanel.Controls.Add(this.button1);
            this.logoPanel.Controls.Add(this.panel4);
            this.logoPanel.Controls.Add(this.logoLabel);
            this.logoPanel.Controls.Add(this.timePanel);
            this.logoPanel.Controls.Add(this.branchIdLabel);
            this.logoPanel.Controls.Add(this.textBox1);
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(800, 75);
            this.logoPanel.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(690, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "退出(ESC)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.leaveButton_Click);
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
            this.timePanel.Location = new System.Drawing.Point(550, 15);
            this.timePanel.Name = "timePanel";
            this.timePanel.Size = new System.Drawing.Size(119, 32);
            this.timePanel.TabIndex = 25;
            // 
            // branchIdLabel
            // 
            this.branchIdLabel.AutoSize = true;
            this.branchIdLabel.Font = new System.Drawing.Font("宋体", 16F);
            this.branchIdLabel.Location = new System.Drawing.Point(460, 30);
            this.branchIdLabel.Name = "branchIdLabel";
            this.branchIdLabel.Size = new System.Drawing.Size(120, 22);
            this.branchIdLabel.TabIndex = 37;
            this.branchIdLabel.Text = "当前分店：";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 16F);
            this.textBox1.Location = new System.Drawing.Point(580, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(150, 32);
            this.textBox1.TabIndex = 39;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // goodTableGroupBox
            // 
            this.goodTableGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goodTableGroupBox.Controls.Add(this.topPanel);
            this.goodTableGroupBox.Controls.Add(this.goodTablePanel);
            this.goodTableGroupBox.Controls.Add(this.messagePanel);
            this.goodTableGroupBox.Location = new System.Drawing.Point(0, 75);
            this.goodTableGroupBox.Name = "goodTableGroupBox";
            this.goodTableGroupBox.Size = new System.Drawing.Size(800, 525);
            this.goodTableGroupBox.TabIndex = 0;
            this.goodTableGroupBox.TabStop = false;
            this.goodTableGroupBox.Text = "商品列表";
            this.goodTableGroupBox.Enter += new System.EventHandler(this.goodTableGroupBox_Enter);
            // 
            // topPanel
            // 
            this.topPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(243)))));
            this.topPanel.Controls.Add(this.calculateButton);
            this.topPanel.Controls.Add(this.numberTextBox);
            this.topPanel.Controls.Add(this.Timebutton);
            this.topPanel.Controls.Add(this.greenLabel);
            this.topPanel.Controls.Add(this.yellowLabel);
            this.topPanel.Controls.Add(this.redLabel);
            this.topPanel.Controls.Add(this.greenButton);
            this.topPanel.Controls.Add(this.yellowButton);
            this.topPanel.Controls.Add(this.nextbutton);
            this.topPanel.Controls.Add(this.redButton);
            this.topPanel.Controls.Add(this.backButton);
            this.topPanel.Controls.Add(this.endButton);
            this.topPanel.Controls.Add(this.startButton);
            this.topPanel.Location = new System.Drawing.Point(3, 17);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(794, 80);
            this.topPanel.TabIndex = 1;
            this.topPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topPanel_Paint);
            // 
            // calculateButton
            // 
            this.calculateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.calculateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.calculateButton.FlatAppearance.BorderSize = 0;
            this.calculateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculateButton.Font = new System.Drawing.Font("宋体", 12F);
            this.calculateButton.ForeColor = System.Drawing.Color.White;
            this.calculateButton.Location = new System.Drawing.Point(385, 30);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(80, 40);
            this.calculateButton.TabIndex = 72;
            this.calculateButton.Text = "加(F1)";
            this.calculateButton.UseVisualStyleBackColor = false;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // numberTextBox
            // 
            this.numberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberTextBox.Font = new System.Drawing.Font("宋体", 20F);
            this.numberTextBox.Location = new System.Drawing.Point(480, 31);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(300, 38);
            this.numberTextBox.TabIndex = 70;
            this.numberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberTextBox_KeyPress);
            this.numberTextBox.Leave += new System.EventHandler(this.numberTextBox_Leave);
            // 
            // Timebutton
            // 
            this.Timebutton.Location = new System.Drawing.Point(366, 6);
            this.Timebutton.Name = "Timebutton";
            this.Timebutton.Size = new System.Drawing.Size(75, 23);
            this.Timebutton.TabIndex = 47;
            this.Timebutton.Text = "button1";
            this.Timebutton.UseVisualStyleBackColor = true;
            this.Timebutton.Visible = false;
            // 
            // greenLabel
            // 
            this.greenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.greenLabel.AutoSize = true;
            this.greenLabel.Location = new System.Drawing.Point(530, 15);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(41, 12);
            this.greenLabel.TabIndex = 46;
            this.greenLabel.Text = "分拣中";
            // 
            // yellowLabel
            // 
            this.yellowLabel.AutoSize = true;
            this.yellowLabel.Location = new System.Drawing.Point(530, 15);
            this.yellowLabel.Name = "yellowLabel";
            this.yellowLabel.Size = new System.Drawing.Size(41, 12);
            this.yellowLabel.TabIndex = 45;
            this.yellowLabel.Text = "待分拣";
            // 
            // redLabel
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.Location = new System.Drawing.Point(530, 15);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(53, 12);
            this.redLabel.TabIndex = 44;
            this.redLabel.Text = "分拣结束";
            // 
            // greenButton
            // 
            this.greenButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.greenButton.Location = new System.Drawing.Point(530, 30);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(49, 32);
            this.greenButton.TabIndex = 43;
            this.greenButton.UseVisualStyleBackColor = true;
            // 
            // yellowButton
            // 
            this.yellowButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.yellowButton.Location = new System.Drawing.Point(530, 30);
            this.yellowButton.Name = "yellowButton";
            this.yellowButton.Size = new System.Drawing.Size(49, 32);
            this.yellowButton.TabIndex = 42;
            this.yellowButton.UseVisualStyleBackColor = true;
            // 
            // nextbutton
            // 
            this.nextbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.nextbutton.FlatAppearance.BorderSize = 0;
            this.nextbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextbutton.Font = new System.Drawing.Font("宋体", 12F);
            this.nextbutton.ForeColor = System.Drawing.Color.White;
            this.nextbutton.Location = new System.Drawing.Point(410, 30);
            this.nextbutton.Name = "nextbutton";
            this.nextbutton.Size = new System.Drawing.Size(100, 40);
            this.nextbutton.TabIndex = 4;
            this.nextbutton.Text = "下一个(F)";
            this.nextbutton.UseVisualStyleBackColor = false;
            this.nextbutton.Click += new System.EventHandler(this.nextbutton_Click);
            // 
            // redButton
            // 
            this.redButton.Location = new System.Drawing.Point(530, 30);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(49, 32);
            this.redButton.TabIndex = 41;
            this.redButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("宋体", 12F);
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(10, 30);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 40);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "返回(A)";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // endButton
            // 
            this.endButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.endButton.FlatAppearance.BorderSize = 0;
            this.endButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endButton.Font = new System.Drawing.Font("宋体", 12F);
            this.endButton.ForeColor = System.Drawing.Color.White;
            this.endButton.Location = new System.Drawing.Point(270, 30);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(120, 40);
            this.endButton.TabIndex = 1;
            this.endButton.Text = "结束分拣(D)";
            this.endButton.UseVisualStyleBackColor = false;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("宋体", 12F);
            this.startButton.ForeColor = System.Drawing.Color.White;
            this.startButton.Location = new System.Drawing.Point(130, 30);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(120, 40);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "开始分拣(S)";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // goodTablePanel
            // 
            this.goodTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goodTablePanel.Controls.Add(this.goodDataGridView);
            this.goodTablePanel.Location = new System.Drawing.Point(3, 162);
            this.goodTablePanel.Name = "goodTablePanel";
            this.goodTablePanel.Size = new System.Drawing.Size(794, 360);
            this.goodTablePanel.TabIndex = 0;
            // 
            // goodDataGridView
            // 
            this.goodDataGridView.AllowUserToAddRows = false;
            this.goodDataGridView.AllowUserToDeleteRows = false;
            this.goodDataGridView.AllowUserToResizeColumns = false;
            this.goodDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.goodDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.goodDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goodDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.goodDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.goodDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.goodDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 19F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.goodDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.goodDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.goodDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serialNumber,
            this.workcode,
            this.name,
            this.nums,
            this.sorteNum,
            this.goodsfile_id});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 19F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.goodDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.goodDataGridView.EnableHeadersVisualStyles = false;
            this.goodDataGridView.Location = new System.Drawing.Point(0, 0);
            this.goodDataGridView.MultiSelect = false;
            this.goodDataGridView.Name = "goodDataGridView";
            this.goodDataGridView.ReadOnly = true;
            this.goodDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.goodDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.goodDataGridView.RowHeadersWidth = 60;
            this.goodDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Transparent;
            this.goodDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.goodDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.goodDataGridView.RowTemplate.Height = 35;
            this.goodDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.goodDataGridView.ShowCellErrors = false;
            this.goodDataGridView.ShowCellToolTips = false;
            this.goodDataGridView.ShowEditingIcon = false;
            this.goodDataGridView.ShowRowErrors = false;
            this.goodDataGridView.Size = new System.Drawing.Size(794, 355);
            this.goodDataGridView.TabIndex = 0;
            this.goodDataGridView.TabStop = false;
            this.goodDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.goodDataGridView_CellContentClick);
            this.goodDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.goodDataGridView_CellValueChanged);
            this.goodDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.goodDataGridView_RowPostPaint);
            this.goodDataGridView.Paint += new System.Windows.Forms.PaintEventHandler(this.goodDataGridView_Paint);
            // 
            // serialNumber
            // 
            this.serialNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.serialNumber.DataPropertyName = "serialNumber";
            this.serialNumber.FillWeight = 0.2F;
            this.serialNumber.HeaderText = "货号";
            this.serialNumber.Name = "serialNumber";
            this.serialNumber.ReadOnly = true;
            this.serialNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // workcode
            // 
            this.workcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.workcode.DataPropertyName = "workname";
            this.workcode.FillWeight = 0.2F;
            this.workcode.HeaderText = "工位";
            this.workcode.Name = "workcode";
            this.workcode.ReadOnly = true;
            this.workcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "name";
            this.name.FillWeight = 0.3F;
            this.name.HeaderText = "商品名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nums
            // 
            this.nums.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nums.DataPropertyName = "nums";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nums.DefaultCellStyle = dataGridViewCellStyle3;
            this.nums.FillWeight = 0.15F;
            this.nums.HeaderText = "订单数量";
            this.nums.Name = "nums";
            this.nums.ReadOnly = true;
            this.nums.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sorteNum
            // 
            this.sorteNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sorteNum.DataPropertyName = "sorteNum";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sorteNum.DefaultCellStyle = dataGridViewCellStyle4;
            this.sorteNum.FillWeight = 0.15F;
            this.sorteNum.HeaderText = "分拣数量";
            this.sorteNum.Name = "sorteNum";
            this.sorteNum.ReadOnly = true;
            this.sorteNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // goodsfile_id
            // 
            this.goodsfile_id.DataPropertyName = "goodsfile_id";
            this.goodsfile_id.HeaderText = "goodsfile_id";
            this.goodsfile_id.Name = "goodsfile_id";
            this.goodsfile_id.ReadOnly = true;
            this.goodsfile_id.Visible = false;
            // 
            // messagePanel
            // 
            this.messagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(243)))));
            this.messagePanel.Controls.Add(this.textBox2);
            this.messagePanel.Controls.Add(this.label1);
            this.messagePanel.Location = new System.Drawing.Point(3, 97);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(794, 65);
            this.messagePanel.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("宋体", 20F);
            this.textBox2.Location = new System.Drawing.Point(60, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(700, 65);
            this.textBox2.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 74;
            this.label1.Text = "备注:";
            // 
            // sorteGoodList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.sorteGoodListPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "sorteGoodList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "订单商品列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.sorteGoodList_Activated);
            this.Load += new System.EventHandler(this.sorteGoodList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sorteGoodList_KeyDown);
            this.sorteGoodListPanel.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            this.logoPanel.PerformLayout();
            this.goodTableGroupBox.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.goodTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.goodDataGridView)).EndInit();
            this.messagePanel.ResumeLayout(false);
            this.messagePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sorteGoodListPanel;
        private System.Windows.Forms.GroupBox goodTableGroupBox;
        private System.Windows.Forms.Panel goodTablePanel;
        private System.Windows.Forms.DataGridView goodDataGridView;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button nextbutton;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Label branchIdLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button redButton;
        private System.Windows.Forms.Button yellowButton;
        private System.Windows.Forms.Button greenButton;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.Label yellowLabel;
        private System.Windows.Forms.Button Timebutton;
        private System.Windows.Forms.Timer pTimer;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Panel timePanel;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn workcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn nums;
        private System.Windows.Forms.DataGridViewTextBoxColumn sorteNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsfile_id;
        private System.Windows.Forms.Panel messagePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
    }
}