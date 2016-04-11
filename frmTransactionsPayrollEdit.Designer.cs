namespace PECS_v1
{
    partial class frmTransactionsPayrollEdit
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
            this.cmsEmpHours = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAllcmsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvTransaction = new System.Windows.Forms.DataGridView();
            this.cmdClose = new System.Windows.Forms.Button();
            this.comboMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsEmpHours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsEmpHours
            // 
            this.cmsEmpHours.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAllcmsMenuItem});
            this.cmsEmpHours.Name = "cmsEmpHours";
            this.cmsEmpHours.Size = new System.Drawing.Size(120, 26);
            // 
            // copyAllcmsMenuItem
            // 
            this.copyAllcmsMenuItem.Name = "copyAllcmsMenuItem";
            this.copyAllcmsMenuItem.Size = new System.Drawing.Size(119, 22);
            this.copyAllcmsMenuItem.Text = "Copy All";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(98, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 42);
            this.label8.TabIndex = 256;
            this.label8.Text = "Edit Payroll";
            // 
            // dgvTransaction
            // 
            this.dgvTransaction.AllowUserToAddRows = false;
            this.dgvTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaction.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvTransaction.Location = new System.Drawing.Point(105, 168);
            this.dgvTransaction.Name = "dgvTransaction";
            this.dgvTransaction.Size = new System.Drawing.Size(1036, 594);
            this.dgvTransaction.TabIndex = 259;
            this.dgvTransaction.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvTransaction_UserDeletingRow);

            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(1099, 35);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(85, 20);
            this.cmdClose.TabIndex = 260;
            this.cmdClose.Text = " CLOSE";
            this.cmdClose.UseVisualStyleBackColor = false;
            // 
            // comboMonth
            // 
            this.comboMonth.FormattingEnabled = true;
            this.comboMonth.Location = new System.Drawing.Point(105, 120);
            this.comboMonth.Name = "comboMonth";
            this.comboMonth.Size = new System.Drawing.Size(211, 21);
            this.comboMonth.TabIndex = 261;
            this.comboMonth.SelectionChangeCommitted += new System.EventHandler(this.comboMonth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 262;
            this.label1.Text = "From Month:";
            // 
            // frmTransactionsPayrollEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(173)))), ((int)(((byte)(174)))));
            this.ClientSize = new System.Drawing.Size(1214, 774);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboMonth);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dgvTransaction);
            this.Controls.Add(this.label8);
            this.Name = "frmTransactionsPayrollEdit";
            this.Text = "Hourly Payroll Transactions";
            this.cmsEmpHours.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip cmsEmpHours;
        private System.Windows.Forms.ToolStripMenuItem copyAllcmsMenuItem;
        private System.Windows.Forms.DataGridView dgvTransaction;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ComboBox comboMonth;
        private System.Windows.Forms.Label label1;

    }
}