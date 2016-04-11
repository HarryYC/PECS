namespace PECS_v1
{
    partial class frmTransactionsPayroll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransactionsPayroll));
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtTransDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdRunTransactions = new System.Windows.Forms.Button();
            this.lstPayroll = new System.Windows.Forms.ListView();
            this.cmsLstPayroll = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdViewPayroll = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.lstUnitPayroll = new System.Windows.Forms.ListView();
            this.cmdClearUnitSelection = new System.Windows.Forms.Button();
            this.lstGLPayroll = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.lstFundPayroll = new System.Windows.Forms.ListView();
            this.cmsLstFunds = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsLstFundCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstPayrollGroup = new System.Windows.Forms.ListBox();
            this.cmdSummerPayroll = new System.Windows.Forms.Button();
            this.cmdHourlyPayroll = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lstPayrollMonths = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPendingPayrollCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txttemsCalc = new System.Windows.Forms.TextBox();
            this.cmdRunByFund = new System.Windows.Forms.Button();
            this.cmdDelPayroll = new System.Windows.Forms.Button();
            this.cmsLstPayroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.cmsLstFunds.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.Location = new System.Drawing.Point(780, 21);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(85, 20);
            this.cmdClose.TabIndex = 18;
            this.cmdClose.Text = " CLOSE";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtTransDate
            // 
            this.txtTransDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransDate.Location = new System.Drawing.Point(38, 126);
            this.txtTransDate.Name = "txtTransDate";
            this.txtTransDate.Size = new System.Drawing.Size(104, 20);
            this.txtTransDate.TabIndex = 178;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(35, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 179;
            this.label1.Text = "Posting Date";
            // 
            // cmdRunTransactions
            // 
            this.cmdRunTransactions.BackColor = System.Drawing.Color.Transparent;
            this.cmdRunTransactions.FlatAppearance.BorderSize = 0;
            this.cmdRunTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRunTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRunTransactions.Image = ((System.Drawing.Image)(resources.GetObject("cmdRunTransactions.Image")));
            this.cmdRunTransactions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRunTransactions.Location = new System.Drawing.Point(324, 165);
            this.cmdRunTransactions.Name = "cmdRunTransactions";
            this.cmdRunTransactions.Size = new System.Drawing.Size(130, 30);
            this.cmdRunTransactions.TabIndex = 180;
            this.cmdRunTransactions.Text = "RUN PAYROLL";
            this.cmdRunTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRunTransactions.UseVisualStyleBackColor = false;
            this.cmdRunTransactions.Click += new System.EventHandler(this.cmdRunTransactions_Click);
            // 
            // lstPayroll
            // 
            this.lstPayroll.AllowColumnReorder = true;
            this.lstPayroll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPayroll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPayroll.ContextMenuStrip = this.cmsLstPayroll;
            this.lstPayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPayroll.FullRowSelect = true;
            this.lstPayroll.GridLines = true;
            this.lstPayroll.Location = new System.Drawing.Point(38, 531);
            this.lstPayroll.Name = "lstPayroll";
            this.lstPayroll.Size = new System.Drawing.Size(853, 143);
            this.lstPayroll.TabIndex = 181;
            this.lstPayroll.UseCompatibleStateImageBehavior = false;
            this.lstPayroll.View = System.Windows.Forms.View.Details;
            this.lstPayroll.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstPayroll_ColumnClick);
            this.lstPayroll.DoubleClick += new System.EventHandler(this.lstPayroll_DoubleClick);
            // 
            // cmsLstPayroll
            // 
            this.cmsLstPayroll.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAllToolStripMenuItem,
            this.copySelectedToolStripMenuItem,
            this.calculateSelectedToolStripMenuItem});
            this.cmsLstPayroll.Name = "cmsLstPayroll";
            this.cmsLstPayroll.Size = new System.Drawing.Size(171, 70);
            // 
            // copyAllToolStripMenuItem
            // 
            this.copyAllToolStripMenuItem.Name = "copyAllToolStripMenuItem";
            this.copyAllToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.copyAllToolStripMenuItem.Text = "Copy All";
            this.copyAllToolStripMenuItem.Click += new System.EventHandler(this.copyAllToolStripMenuItem_Click);
            // 
            // copySelectedToolStripMenuItem
            // 
            this.copySelectedToolStripMenuItem.Name = "copySelectedToolStripMenuItem";
            this.copySelectedToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.copySelectedToolStripMenuItem.Text = "Copy Selected";
            this.copySelectedToolStripMenuItem.Click += new System.EventHandler(this.copySelectedToolStripMenuItem_Click);
            // 
            // calculateSelectedToolStripMenuItem
            // 
            this.calculateSelectedToolStripMenuItem.Name = "calculateSelectedToolStripMenuItem";
            this.calculateSelectedToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.calculateSelectedToolStripMenuItem.Text = "Calculate Selected";
            this.calculateSelectedToolStripMenuItem.Click += new System.EventHandler(this.calculateSelectedToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 515);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 13);
            this.label2.TabIndex = 182;
            this.label2.Text = "Pending Payroll Transactions";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 705);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(943, 83);
            this.pictureBox1.TabIndex = 187;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(20, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 85);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 189;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(103, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(377, 42);
            this.label8.TabIndex = 192;
            this.label8.Text = "Payroll Transactions";
            // 
            // cmdViewPayroll
            // 
            this.cmdViewPayroll.BackColor = System.Drawing.Color.Transparent;
            this.cmdViewPayroll.FlatAppearance.BorderSize = 0;
            this.cmdViewPayroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdViewPayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdViewPayroll.Image = ((System.Drawing.Image)(resources.GetObject("cmdViewPayroll.Image")));
            this.cmdViewPayroll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdViewPayroll.Location = new System.Drawing.Point(324, 116);
            this.cmdViewPayroll.Name = "cmdViewPayroll";
            this.cmdViewPayroll.Size = new System.Drawing.Size(130, 30);
            this.cmdViewPayroll.TabIndex = 234;
            this.cmdViewPayroll.TabStop = false;
            this.cmdViewPayroll.Text = "VIEW PAYROLL";
            this.cmdViewPayroll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdViewPayroll.UseVisualStyleBackColor = false;
            this.cmdViewPayroll.Click += new System.EventHandler(this.cmdViewPayroll_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(290, 215);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 236;
            this.label15.Text = "Unit";
            // 
            // lstUnitPayroll
            // 
            this.lstUnitPayroll.AllowColumnReorder = true;
            this.lstUnitPayroll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstUnitPayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstUnitPayroll.FullRowSelect = true;
            this.lstUnitPayroll.GridLines = true;
            this.lstUnitPayroll.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstUnitPayroll.HideSelection = false;
            this.lstUnitPayroll.Location = new System.Drawing.Point(293, 231);
            this.lstUnitPayroll.Name = "lstUnitPayroll";
            this.lstUnitPayroll.Size = new System.Drawing.Size(201, 261);
            this.lstUnitPayroll.TabIndex = 237;
            this.lstUnitPayroll.UseCompatibleStateImageBehavior = false;
            this.lstUnitPayroll.View = System.Windows.Forms.View.Details;
            this.lstUnitPayroll.Click += new System.EventHandler(this.lstUnitPayroll_Click);
            // 
            // cmdClearUnitSelection
            // 
            this.cmdClearUnitSelection.BackColor = System.Drawing.Color.Transparent;
            this.cmdClearUnitSelection.FlatAppearance.BorderSize = 0;
            this.cmdClearUnitSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClearUnitSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClearUnitSelection.Image = ((System.Drawing.Image)(resources.GetObject("cmdClearUnitSelection.Image")));
            this.cmdClearUnitSelection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClearUnitSelection.Location = new System.Drawing.Point(518, 116);
            this.cmdClearUnitSelection.Name = "cmdClearUnitSelection";
            this.cmdClearUnitSelection.Size = new System.Drawing.Size(121, 30);
            this.cmdClearUnitSelection.TabIndex = 238;
            this.cmdClearUnitSelection.TabStop = false;
            this.cmdClearUnitSelection.Text = "CLEAR";
            this.cmdClearUnitSelection.UseVisualStyleBackColor = false;
            this.cmdClearUnitSelection.Click += new System.EventHandler(this.cmdClearUnitSelection_Click);
            // 
            // lstGLPayroll
            // 
            this.lstGLPayroll.AllowColumnReorder = true;
            this.lstGLPayroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGLPayroll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstGLPayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGLPayroll.FullRowSelect = true;
            this.lstGLPayroll.GridLines = true;
            this.lstGLPayroll.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstGLPayroll.Location = new System.Drawing.Point(960, 231);
            this.lstGLPayroll.Name = "lstGLPayroll";
            this.lstGLPayroll.Size = new System.Drawing.Size(0, 261);
            this.lstGLPayroll.TabIndex = 240;
            this.lstGLPayroll.UseCompatibleStateImageBehavior = false;
            this.lstGLPayroll.View = System.Windows.Forms.View.Details;
            this.lstGLPayroll.Click += new System.EventHandler(this.lstGLPayroll_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(957, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 239;
            this.label4.Text = "GLs";
            // 
            // lstFundPayroll
            // 
            this.lstFundPayroll.AllowColumnReorder = true;
            this.lstFundPayroll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstFundPayroll.ContextMenuStrip = this.cmsLstFunds;
            this.lstFundPayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFundPayroll.FullRowSelect = true;
            this.lstFundPayroll.GridLines = true;
            this.lstFundPayroll.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstFundPayroll.Location = new System.Drawing.Point(500, 230);
            this.lstFundPayroll.Name = "lstFundPayroll";
            this.lstFundPayroll.Size = new System.Drawing.Size(454, 261);
            this.lstFundPayroll.TabIndex = 242;
            this.lstFundPayroll.UseCompatibleStateImageBehavior = false;
            this.lstFundPayroll.View = System.Windows.Forms.View.Details;
            this.lstFundPayroll.Click += new System.EventHandler(this.lstFundPayroll_Click);
            // 
            // cmsLstFunds
            // 
            this.cmsLstFunds.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsLstFundCopyAll});
            this.cmsLstFunds.Name = "cmsLstFunds";
            this.cmsLstFunds.Size = new System.Drawing.Size(120, 26);
            // 
            // cmsLstFundCopyAll
            // 
            this.cmsLstFundCopyAll.Name = "cmsLstFundCopyAll";
            this.cmsLstFundCopyAll.Size = new System.Drawing.Size(119, 22);
            this.cmsLstFundCopyAll.Text = "Copy All";
            this.cmsLstFundCopyAll.Click += new System.EventHandler(this.cmsLstFundCopyAll_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(497, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 241;
            this.label3.Text = "Funds";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(157, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 244;
            this.label5.Text = "Select Group";
            // 
            // lstPayrollGroup
            // 
            this.lstPayrollGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPayrollGroup.FormattingEnabled = true;
            this.lstPayrollGroup.Location = new System.Drawing.Point(160, 116);
            this.lstPayrollGroup.Name = "lstPayrollGroup";
            this.lstPayrollGroup.Size = new System.Drawing.Size(130, 67);
            this.lstPayrollGroup.TabIndex = 243;
            this.lstPayrollGroup.Click += new System.EventHandler(this.lstPayrollGroup_Click);
            // 
            // cmdSummerPayroll
            // 
            this.cmdSummerPayroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSummerPayroll.BackColor = System.Drawing.Color.Transparent;
            this.cmdSummerPayroll.FlatAppearance.BorderSize = 0;
            this.cmdSummerPayroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSummerPayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSummerPayroll.Image = ((System.Drawing.Image)(resources.GetObject("cmdSummerPayroll.Image")));
            this.cmdSummerPayroll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSummerPayroll.Location = new System.Drawing.Point(732, 73);
            this.cmdSummerPayroll.Name = "cmdSummerPayroll";
            this.cmdSummerPayroll.Size = new System.Drawing.Size(159, 30);
            this.cmdSummerPayroll.TabIndex = 245;
            this.cmdSummerPayroll.TabStop = false;
            this.cmdSummerPayroll.Text = "SUMMER PAYROLL";
            this.cmdSummerPayroll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSummerPayroll.UseVisualStyleBackColor = false;
            this.cmdSummerPayroll.Click += new System.EventHandler(this.cmdSummerPayroll_Click);
            // 
            // cmdHourlyPayroll
            // 
            this.cmdHourlyPayroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdHourlyPayroll.BackColor = System.Drawing.Color.Transparent;
            this.cmdHourlyPayroll.FlatAppearance.BorderSize = 0;
            this.cmdHourlyPayroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdHourlyPayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdHourlyPayroll.Image = ((System.Drawing.Image)(resources.GetObject("cmdHourlyPayroll.Image")));
            this.cmdHourlyPayroll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdHourlyPayroll.Location = new System.Drawing.Point(732, 110);
            this.cmdHourlyPayroll.Name = "cmdHourlyPayroll";
            this.cmdHourlyPayroll.Size = new System.Drawing.Size(154, 30);
            this.cmdHourlyPayroll.TabIndex = 246;
            this.cmdHourlyPayroll.TabStop = false;
            this.cmdHourlyPayroll.Text = "HOURLY PAYROLL";
            this.cmdHourlyPayroll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdHourlyPayroll.UseVisualStyleBackColor = false;
            this.cmdHourlyPayroll.Click += new System.EventHandler(this.cmdHourlyPayroll_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 248;
            this.label6.Text = "Select Month";
            // 
            // lstPayrollMonths
            // 
            this.lstPayrollMonths.AllowColumnReorder = true;
            this.lstPayrollMonths.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPayrollMonths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPayrollMonths.FullRowSelect = true;
            this.lstPayrollMonths.GridLines = true;
            this.lstPayrollMonths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstPayrollMonths.HideSelection = false;
            this.lstPayrollMonths.Location = new System.Drawing.Point(38, 231);
            this.lstPayrollMonths.Name = "lstPayrollMonths";
            this.lstPayrollMonths.Size = new System.Drawing.Size(249, 261);
            this.lstPayrollMonths.TabIndex = 249;
            this.lstPayrollMonths.UseCompatibleStateImageBehavior = false;
            this.lstPayrollMonths.View = System.Windows.Forms.View.Details;
            this.lstPayrollMonths.Click += new System.EventHandler(this.lstPayrollMonths_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(257, 515);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 250;
            this.label7.Text = "Record Count:";
            // 
            // lblPendingPayrollCount
            // 
            this.lblPendingPayrollCount.AutoSize = true;
            this.lblPendingPayrollCount.BackColor = System.Drawing.Color.Transparent;
            this.lblPendingPayrollCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingPayrollCount.Location = new System.Drawing.Point(339, 515);
            this.lblPendingPayrollCount.Name = "lblPendingPayrollCount";
            this.lblPendingPayrollCount.Size = new System.Drawing.Size(13, 13);
            this.lblPendingPayrollCount.TabIndex = 251;
            this.lblPendingPayrollCount.Text = "  ";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(699, 507);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 904;
            this.label9.Text = "Calculation:";
            // 
            // txttemsCalc
            // 
            this.txttemsCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttemsCalc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttemsCalc.Location = new System.Drawing.Point(780, 505);
            this.txttemsCalc.Name = "txttemsCalc";
            this.txttemsCalc.Size = new System.Drawing.Size(111, 20);
            this.txttemsCalc.TabIndex = 903;
            this.txttemsCalc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdRunByFund
            // 
            this.cmdRunByFund.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRunByFund.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRunByFund.Location = new System.Drawing.Point(518, 150);
            this.cmdRunByFund.Name = "cmdRunByFund";
            this.cmdRunByFund.Size = new System.Drawing.Size(142, 23);
            this.cmdRunByFund.TabIndex = 905;
            this.cmdRunByFund.Text = "RUN BY FUND";
            this.cmdRunByFund.UseVisualStyleBackColor = true;
            this.cmdRunByFund.Click += new System.EventHandler(this.cmdRunByFund_Click);
            // 
            // cmdDelPayroll
            // 
            this.cmdDelPayroll.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelPayroll.FlatAppearance.BorderSize = 0;
            this.cmdDelPayroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDelPayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelPayroll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelPayroll.Location = new System.Drawing.Point(324, 140);
            this.cmdDelPayroll.Name = "cmdDelPayroll";
            this.cmdDelPayroll.Size = new System.Drawing.Size(130, 30);
            this.cmdDelPayroll.TabIndex = 906;
            this.cmdDelPayroll.TabStop = false;
            this.cmdDelPayroll.Text = "DEL PAYROLL";
            this.cmdDelPayroll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDelPayroll.UseVisualStyleBackColor = false;
            this.cmdDelPayroll.Click += new System.EventHandler(this.cmdDelPayroll_Click);
            // 
            // frmTransactionsPayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1096, 800);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(173)))), ((int)(((byte)(174)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1282, 749);
            this.Controls.Add(this.cmdDelPayroll);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txttemsCalc);
            this.Controls.Add(this.lblPendingPayrollCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstPayrollMonths);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdRunByFund);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdHourlyPayroll);
            this.Controls.Add(this.cmdSummerPayroll);
            this.Controls.Add(this.lstPayrollGroup);
            this.Controls.Add(this.lstGLPayroll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstFundPayroll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmdViewPayroll);
            this.Controls.Add(this.cmdClearUnitSelection);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lstUnitPayroll);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstPayroll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTransDate);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdRunTransactions);
            this.Name = "frmTransactionsPayroll";
            this.Text = "Payroll Transactions";
            this.cmsLstPayroll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.cmsLstFunds.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TextBox txtTransDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdRunTransactions;
        private System.Windows.Forms.ListView lstPayroll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdViewPayroll;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListView lstUnitPayroll;
        private System.Windows.Forms.Button cmdClearUnitSelection;
        private System.Windows.Forms.ListView lstGLPayroll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstFundPayroll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstPayrollGroup;
        private System.Windows.Forms.Button cmdSummerPayroll;
        private System.Windows.Forms.Button cmdHourlyPayroll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lstPayrollMonths;
        private System.Windows.Forms.ContextMenuStrip cmsLstPayroll;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsLstFunds;
        private System.Windows.Forms.ToolStripMenuItem cmsLstFundCopyAll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPendingPayrollCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txttemsCalc;
        private System.Windows.Forms.ToolStripMenuItem calculateSelectedToolStripMenuItem;
        private System.Windows.Forms.Button cmdRunByFund;
        private System.Windows.Forms.Button cmdDelPayroll;
    }
}