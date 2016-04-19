namespace PECS_v1
{
    partial class frmReportsTransactionQueries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportsTransactionQueries));
            this.label4 = new System.Windows.Forms.Label();
            this.lstTransTypes = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.lstTransSubTypes = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.lstUnits = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.lstTransFunding = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.lstGLs = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.lstTransPayees = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.lstTransStatus = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.lstTransactions = new System.Windows.Forms.ListView();
            this.cmsRighClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.cmboFY = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmboGLFilter = new System.Windows.Forms.ComboBox();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txttemsCalc = new System.Windows.Forms.TextBox();
            this.cmdToggleFundList = new System.Windows.Forms.Button();
            this.lstFundType = new System.Windows.Forms.ListView();
            this.lstFund2Type = new System.Windows.Forms.ListView();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmsRighClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(45, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 201;
            this.label4.Text = "Transaction Type";
            // 
            // lstTransTypes
            // 
            this.lstTransTypes.AllowColumnReorder = true;
            this.lstTransTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTransTypes.FullRowSelect = true;
            this.lstTransTypes.GridLines = true;
            this.lstTransTypes.HideSelection = false;
            this.lstTransTypes.Location = new System.Drawing.Point(24, 95);
            this.lstTransTypes.Name = "lstTransTypes";
            this.lstTransTypes.Size = new System.Drawing.Size(140, 256);
            this.lstTransTypes.TabIndex = 200;
            this.lstTransTypes.UseCompatibleStateImageBehavior = false;
            this.lstTransTypes.View = System.Windows.Forms.View.Details;
            this.lstTransTypes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstTransType_ColumnClick);
            this.lstTransTypes.Click += new System.EventHandler(this.lstTransTypes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(198, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 203;
            this.label1.Text = "Transaction Sub Type";
            // 
            // lstTransSubTypes
            // 
            this.lstTransSubTypes.AllowColumnReorder = true;
            this.lstTransSubTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTransSubTypes.FullRowSelect = true;
            this.lstTransSubTypes.GridLines = true;
            this.lstTransSubTypes.HideSelection = false;
            this.lstTransSubTypes.Location = new System.Drawing.Point(170, 95);
            this.lstTransSubTypes.Name = "lstTransSubTypes";
            this.lstTransSubTypes.Size = new System.Drawing.Size(180, 256);
            this.lstTransSubTypes.TabIndex = 202;
            this.lstTransSubTypes.UseCompatibleStateImageBehavior = false;
            this.lstTransSubTypes.View = System.Windows.Forms.View.Details;
            this.lstTransSubTypes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstTransSubType_ColumnClick);
            this.lstTransSubTypes.Click += new System.EventHandler(this.lstTransSubTypes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(393, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 205;
            this.label2.Text = "Unit";
            // 
            // lstUnits
            // 
            this.lstUnits.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstUnits.AllowColumnReorder = true;
            this.lstUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstUnits.FullRowSelect = true;
            this.lstUnits.GridLines = true;
            this.lstUnits.HideSelection = false;
            this.lstUnits.HoverSelection = true;
            this.lstUnits.Location = new System.Drawing.Point(356, 95);
            this.lstUnits.Name = "lstUnits";
            this.lstUnits.Size = new System.Drawing.Size(110, 256);
            this.lstUnits.TabIndex = 204;
            this.lstUnits.UseCompatibleStateImageBehavior = false;
            this.lstUnits.View = System.Windows.Forms.View.Details;
            this.lstUnits.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstUnits_ColumnClick);
            this.lstUnits.Click += new System.EventHandler(this.lstUnits_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(567, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 207;
            this.label3.Text = "Fund";
            // 
            // lstTransFunding
            // 
            this.lstTransFunding.AllowColumnReorder = true;
            this.lstTransFunding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTransFunding.FullRowSelect = true;
            this.lstTransFunding.GridLines = true;
            this.lstTransFunding.HideSelection = false;
            this.lstTransFunding.Location = new System.Drawing.Point(472, 95);
            this.lstTransFunding.Name = "lstTransFunding";
            this.lstTransFunding.Size = new System.Drawing.Size(221, 256);
            this.lstTransFunding.TabIndex = 206;
            this.lstTransFunding.UseCompatibleStateImageBehavior = false;
            this.lstTransFunding.View = System.Windows.Forms.View.Details;
            this.lstTransFunding.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstTransFund_ColumnClick);
            this.lstTransFunding.Click += new System.EventHandler(this.lstTransFunding_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(792, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 209;
            this.label5.Text = "GL";
            // 
            // lstGLs
            // 
            this.lstGLs.AllowColumnReorder = true;
            this.lstGLs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstGLs.FullRowSelect = true;
            this.lstGLs.GridLines = true;
            this.lstGLs.HideSelection = false;
            this.lstGLs.Location = new System.Drawing.Point(699, 95);
            this.lstGLs.Name = "lstGLs";
            this.lstGLs.Size = new System.Drawing.Size(209, 256);
            this.lstGLs.TabIndex = 208;
            this.lstGLs.UseCompatibleStateImageBehavior = false;
            this.lstGLs.View = System.Windows.Forms.View.Details;
            this.lstGLs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstGLs_ColumnClick);
            this.lstGLs.Click += new System.EventHandler(this.lstGLs_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(958, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 211;
            this.label6.Text = "Payee";
            // 
            // lstTransPayees
            // 
            this.lstTransPayees.AllowColumnReorder = true;
            this.lstTransPayees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTransPayees.FullRowSelect = true;
            this.lstTransPayees.GridLines = true;
            this.lstTransPayees.HideSelection = false;
            this.lstTransPayees.Location = new System.Drawing.Point(914, 95);
            this.lstTransPayees.Name = "lstTransPayees";
            this.lstTransPayees.Size = new System.Drawing.Size(139, 256);
            this.lstTransPayees.TabIndex = 210;
            this.lstTransPayees.UseCompatibleStateImageBehavior = false;
            this.lstTransPayees.View = System.Windows.Forms.View.Details;
            this.lstTransPayees.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstTransPayees_ColumnClick);
            this.lstTransPayees.Click += new System.EventHandler(this.lstTransPayees_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(1102, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 213;
            this.label7.Text = "Status";
            // 
            // lstTransStatus
            // 
            this.lstTransStatus.AllowColumnReorder = true;
            this.lstTransStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTransStatus.FullRowSelect = true;
            this.lstTransStatus.GridLines = true;
            this.lstTransStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstTransStatus.HideSelection = false;
            this.lstTransStatus.Location = new System.Drawing.Point(1059, 95);
            this.lstTransStatus.Name = "lstTransStatus";
            this.lstTransStatus.Size = new System.Drawing.Size(131, 256);
            this.lstTransStatus.TabIndex = 212;
            this.lstTransStatus.UseCompatibleStateImageBehavior = false;
            this.lstTransStatus.View = System.Windows.Forms.View.Details;
            this.lstTransStatus.Click += new System.EventHandler(this.lstTransStatus_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(21, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 215;
            this.label8.Text = "Transactions";
            // 
            // lstTransactions
            // 
            this.lstTransactions.AllowColumnReorder = true;
            this.lstTransactions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTransactions.ContextMenuStrip = this.cmsRighClick;
            this.lstTransactions.FullRowSelect = true;
            this.lstTransactions.GridLines = true;
            this.lstTransactions.HideSelection = false;
            this.lstTransactions.Location = new System.Drawing.Point(24, 382);
            this.lstTransactions.Name = "lstTransactions";
            this.lstTransactions.Size = new System.Drawing.Size(1166, 279);
            this.lstTransactions.TabIndex = 214;
            this.lstTransactions.UseCompatibleStateImageBehavior = false;
            this.lstTransactions.View = System.Windows.Forms.View.Details;
            this.lstTransactions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstTransactions_ColumnClick);
            this.lstTransactions.DoubleClick += new System.EventHandler(this.lstTransactions_DoubleClick);
            // 
            // cmsRighClick
            // 
            this.cmsRighClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAllToolStripMenuItem,
            this.copySelectedToolStripMenuItem,
            this.calculateSelectedToolStripMenuItem});
            this.cmsRighClick.Name = "cmsRighClick";
            this.cmsRighClick.Size = new System.Drawing.Size(171, 70);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(21, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 217;
            this.label9.Text = "Fiscal Year";
            // 
            // cmboFY
            // 
            this.cmboFY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmboFY.FormattingEnabled = true;
            this.cmboFY.Location = new System.Drawing.Point(24, 39);
            this.cmboFY.Name = "cmboFY";
            this.cmboFY.Size = new System.Drawing.Size(91, 21);
            this.cmboFY.TabIndex = 216;
            this.cmboFY.SelectedValueChanged += new System.EventHandler(this.cmboFY_SelectedIndexChange);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(118, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 219;
            this.label10.Text = "Month Filter";
            // 
            // cmboGLFilter
            // 
            this.cmboGLFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmboGLFilter.FormattingEnabled = true;
            this.cmboGLFilter.Location = new System.Drawing.Point(121, 39);
            this.cmboGLFilter.Name = "cmboGLFilter";
            this.cmboGLFilter.Size = new System.Drawing.Size(100, 21);
            this.cmboGLFilter.TabIndex = 218;
            this.cmboGLFilter.SelectedIndexChanged += new System.EventHandler(this.cmboGLFilter_SelectedIndexChanged);
            // 
            // cmdReset
            // 
            this.cmdReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReset.Location = new System.Drawing.Point(249, 37);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(179, 23);
            this.cmdReset.TabIndex = 220;
            this.cmdReset.Text = "RESET CRITERIA";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.Location = new System.Drawing.Point(744, 12);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(85, 20);
            this.cmdClose.TabIndex = 221;
            this.cmdClose.Text = " CLOSE";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(133, 363);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 904;
            this.label11.Text = "Calculation:";
            // 
            // txttemsCalc
            // 
            this.txttemsCalc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttemsCalc.Location = new System.Drawing.Point(201, 361);
            this.txttemsCalc.Name = "txttemsCalc";
            this.txttemsCalc.Size = new System.Drawing.Size(110, 20);
            this.txttemsCalc.TabIndex = 903;
            this.txttemsCalc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdToggleFundList
            // 
            this.cmdToggleFundList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdToggleFundList.Location = new System.Drawing.Point(491, 53);
            this.cmdToggleFundList.Name = "cmdToggleFundList";
            this.cmdToggleFundList.Size = new System.Drawing.Size(179, 23);
            this.cmdToggleFundList.TabIndex = 905;
            this.cmdToggleFundList.Text = "GROUP BY CHARTFIELD";
            this.cmdToggleFundList.UseVisualStyleBackColor = true;
            this.cmdToggleFundList.Click += new System.EventHandler(this.cmdToggleFundList_Click);
            // 
            // lstFundType
            // 
            this.lstFundType.AllowColumnReorder = true;
            this.lstFundType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstFundType.FullRowSelect = true;
            this.lstFundType.GridLines = true;
            this.lstFundType.HideSelection = false;
            this.lstFundType.Location = new System.Drawing.Point(472, 95);
            this.lstFundType.Name = "lstFundType";
            this.lstFundType.Size = new System.Drawing.Size(221, 256);
            this.lstFundType.TabIndex = 906;
            this.lstFundType.UseCompatibleStateImageBehavior = false;
            this.lstFundType.View = System.Windows.Forms.View.Details;
            this.lstFundType.Visible = false;
            this.lstFundType.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstTransFund_ColumnClick);
            this.lstFundType.Click += new System.EventHandler(this.lstFundType_Click);
            // 
            // lstFund2Type
            // 
            this.lstFund2Type.AllowColumnReorder = true;
            this.lstFund2Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstFund2Type.FullRowSelect = true;
            this.lstFund2Type.GridLines = true;
            this.lstFund2Type.HideSelection = false;
            this.lstFund2Type.Location = new System.Drawing.Point(472, 95);
            this.lstFund2Type.Name = "lstFund2Type";
            this.lstFund2Type.Size = new System.Drawing.Size(221, 256);
            this.lstFund2Type.TabIndex = 906;
            this.lstFund2Type.UseCompatibleStateImageBehavior = false;
            this.lstFund2Type.View = System.Windows.Forms.View.Details;
            this.lstFund2Type.Visible = false;
            this.lstFund2Type.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstTransFund_ColumnClick);
            this.lstFund2Type.Click += new System.EventHandler(this.lstFund2Type_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cmdSearch.FlatAppearance.BorderSize = 5;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Location = new System.Drawing.Point(699, 12);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(163, 38);
            this.cmdSearch.TabIndex = 907;
            this.cmdSearch.Text = "RUN SEARCH";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // frmReportsTransactionQueries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(550, 700);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(1424, 685);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.cmdToggleFundList);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lstFundType);
            this.Controls.Add(this.lstFund2Type);
            this.Controls.Add(this.txttemsCalc);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmboGLFilter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmboFY);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstTransactions);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstTransStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstTransPayees);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstGLs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstTransFunding);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstUnits);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstTransSubTypes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstTransTypes);
            this.Name = "frmReportsTransactionQueries";
            this.Text = "Transaction Queries";
            this.cmsRighClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstTransTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstTransSubTypes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstUnits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lstTransFunding;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lstGLs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lstTransPayees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lstTransStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lstTransactions;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmboFY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmboGLFilter;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ContextMenuStrip cmsRighClick;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToolStripMenuItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txttemsCalc;
        private System.Windows.Forms.ToolStripMenuItem calculateSelectedToolStripMenuItem;
        private System.Windows.Forms.Button cmdToggleFundList;
        private System.Windows.Forms.ListView lstFundType;
        private System.Windows.Forms.ListView lstFund2Type;
        private System.Windows.Forms.Button cmdSearch;
    }
}