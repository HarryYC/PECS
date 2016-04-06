using System.Windows.Forms;
namespace PECS_v1
{
    partial class frmOperationsProjectStaffs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperationsProjectStaffs));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblOperations = new System.Windows.Forms.Label();
            this.lstBuildings = new System.Windows.Forms.ListView();
            this.lstRooms = new System.Windows.Forms.ListView();
            this.lstStaffs = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelBuilding = new System.Windows.Forms.Label();
            this.labelRoom = new System.Windows.Forms.Label();
            this.labelStaff = new System.Windows.Forms.Label();
            this.labelEquip = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvEquips = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewEquipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assingNewStaffToRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editBuildingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stFloorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ndFloorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtITEquipNotes = new System.Windows.Forms.TextBox();
            this.lstDocs = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip5 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUploadRoom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquips)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.contextMenuStrip4.SuspendLayout();
            this.contextMenuStrip5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(30, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 85);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 236;
            this.pictureBox2.TabStop = false;
            // 
            // lblOperations
            // 
            this.lblOperations.AutoSize = true;
            this.lblOperations.BackColor = System.Drawing.Color.Transparent;
            this.lblOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperations.Location = new System.Drawing.Point(127, 26);
            this.lblOperations.Name = "lblOperations";
            this.lblOperations.Padding = new System.Windows.Forms.Padding(2);
            this.lblOperations.Size = new System.Drawing.Size(215, 46);
            this.lblOperations.TabIndex = 235;
            this.lblOperations.Text = "Operations";
            // 
            // lstBuildings
            // 
            this.lstBuildings.AllowColumnReorder = true;
            this.lstBuildings.AllowDrop = true;
            this.lstBuildings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstBuildings.FullRowSelect = true;
            this.lstBuildings.GridLines = true;
            this.lstBuildings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstBuildings.HideSelection = false;
            this.lstBuildings.Location = new System.Drawing.Point(83, 124);
            this.lstBuildings.MultiSelect = false;
            this.lstBuildings.Name = "lstBuildings";
            this.lstBuildings.Size = new System.Drawing.Size(75, 466);
            this.lstBuildings.TabIndex = 5;
            this.lstBuildings.UseCompatibleStateImageBehavior = false;
            this.lstBuildings.View = System.Windows.Forms.View.Details;
            this.lstBuildings.Click += new System.EventHandler(this.lstBuildings_Click);
            this.lstBuildings.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstBuildings_DragDrop);
            this.lstBuildings.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstDragEnter);
            this.lstBuildings.DragOver += new System.Windows.Forms.DragEventHandler(this.lstDragOver);
            this.lstBuildings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstBuildings_MouseDown);
            // 
            // lstRooms
            // 
            this.lstRooms.AllowColumnReorder = true;
            this.lstRooms.AllowDrop = true;
            this.lstRooms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRooms.FullRowSelect = true;
            this.lstRooms.GridLines = true;
            this.lstRooms.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstRooms.HideSelection = false;
            this.lstRooms.Location = new System.Drawing.Point(158, 124);
            this.lstRooms.MultiSelect = false;
            this.lstRooms.Name = "lstRooms";
            this.lstRooms.Size = new System.Drawing.Size(100, 466);
            this.lstRooms.TabIndex = 6;
            this.lstRooms.UseCompatibleStateImageBehavior = false;
            this.lstRooms.View = System.Windows.Forms.View.Details;
            this.lstRooms.Click += new System.EventHandler(this.lstRooms_Click);
            this.lstRooms.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstRooms_DragDrop);
            this.lstRooms.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstDragEnter);
            this.lstRooms.DragOver += new System.Windows.Forms.DragEventHandler(this.lstDragOver);
            this.lstRooms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstRooms_MouseDown);
            // 
            // lstStaffs
            // 
            this.lstStaffs.AllowColumnReorder = true;
            this.lstStaffs.AllowDrop = true;
            this.lstStaffs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstStaffs.FullRowSelect = true;
            this.lstStaffs.GridLines = true;
            this.lstStaffs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstStaffs.HideSelection = false;
            this.lstStaffs.Location = new System.Drawing.Point(258, 124);
            this.lstStaffs.MultiSelect = false;
            this.lstStaffs.Name = "lstStaffs";
            this.lstStaffs.Size = new System.Drawing.Size(200, 466);
            this.lstStaffs.TabIndex = 7;
            this.lstStaffs.UseCompatibleStateImageBehavior = false;
            this.lstStaffs.View = System.Windows.Forms.View.Details;
            this.lstStaffs.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstStaffs_DragDrop);
            this.lstStaffs.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstDragEnter);
            this.lstStaffs.DragOver += new System.Windows.Forms.DragEventHandler(this.lstDragOver);
            this.lstStaffs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstStaffs_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMenuItem,
            this.deleteMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuStripItemClicked);
            // 
            // editMenuItem
            // 
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(168, 22);
            this.editMenuItem.Text = "Edit Equipment";
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(168, 22);
            this.deleteMenuItem.Text = "Delete Equipment";
            // 
            // labelBuilding
            // 
            this.labelBuilding.AutoSize = true;
            this.labelBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuilding.Location = new System.Drawing.Point(86, 108);
            this.labelBuilding.Name = "labelBuilding";
            this.labelBuilding.Size = new System.Drawing.Size(0, 13);
            this.labelBuilding.TabIndex = 9;
            // 
            // labelRoom
            // 
            this.labelRoom.AutoSize = true;
            this.labelRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoom.Location = new System.Drawing.Point(161, 108);
            this.labelRoom.Name = "labelRoom";
            this.labelRoom.Size = new System.Drawing.Size(0, 13);
            this.labelRoom.TabIndex = 10;
            // 
            // labelStaff
            // 
            this.labelStaff.AutoSize = true;
            this.labelStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStaff.Location = new System.Drawing.Point(261, 108);
            this.labelStaff.Name = "labelStaff";
            this.labelStaff.Size = new System.Drawing.Size(0, 13);
            this.labelStaff.TabIndex = 11;
            // 
            // labelEquip
            // 
            this.labelEquip.AutoSize = true;
            this.labelEquip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEquip.Location = new System.Drawing.Point(462, 108);
            this.labelEquip.Name = "labelEquip";
            this.labelEquip.Size = new System.Drawing.Size(0, 13);
            this.labelEquip.TabIndex = 237;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 239;
            this.pictureBox1.TabStop = false;
            // 
            // dgvEquips
            // 
            this.dgvEquips.AllowUserToAddRows = false;
            this.dgvEquips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquips.Location = new System.Drawing.Point(457, 124);
            this.dgvEquips.MultiSelect = false;
            this.dgvEquips.Name = "dgvEquips";
            this.dgvEquips.ReadOnly = true;
            this.dgvEquips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquips.Size = new System.Drawing.Size(774, 466);
            this.dgvEquips.TabIndex = 240;
            this.dgvEquips.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquips_CellEndEdit);
            this.dgvEquips.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvEquips_MouseDown);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewEquipToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(166, 48);
            // 
            // addNewEquipToolStripMenuItem
            // 
            this.addNewEquipToolStripMenuItem.Name = "addNewEquipToolStripMenuItem";
            this.addNewEquipToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addNewEquipToolStripMenuItem.Text = "Add New Equip...";
            this.addNewEquipToolStripMenuItem.Click += new System.EventHandler(this.getOpeNewEquip);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.deleteToolStripMenuItem.Text = "Delete Staff";
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRoomToolStripMenuItem,
            this.editRoomToolStripMenuItem,
            this.deleteRoomToolStripMenuItem,
            this.assingNewStaffToRoomToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(186, 92);
            // 
            // newRoomToolStripMenuItem
            // 
            this.newRoomToolStripMenuItem.Name = "newRoomToolStripMenuItem";
            this.newRoomToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.newRoomToolStripMenuItem.Text = "New Room...";
            // 
            // editRoomToolStripMenuItem
            // 
            this.editRoomToolStripMenuItem.Name = "editRoomToolStripMenuItem";
            this.editRoomToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.editRoomToolStripMenuItem.Text = "Edit Room";
            // 
            // deleteRoomToolStripMenuItem
            // 
            this.deleteRoomToolStripMenuItem.Name = "deleteRoomToolStripMenuItem";
            this.deleteRoomToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.deleteRoomToolStripMenuItem.Text = "Delete Room";
            // 
            // assingNewStaffToRoomToolStripMenuItem
            // 
            this.assingNewStaffToRoomToolStripMenuItem.Name = "assingNewStaffToRoomToolStripMenuItem";
            this.assingNewStaffToRoomToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.assingNewStaffToRoomToolStripMenuItem.Text = "Assign Staff to Room";
            this.assingNewStaffToRoomToolStripMenuItem.Click += new System.EventHandler(this.getOpeNewAssign);
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editBuildingToolStripMenuItem,
            this.viewMapsToolStripMenuItem});
            this.contextMenuStrip4.Name = "contextMenuStrip4";
            this.contextMenuStrip4.Size = new System.Drawing.Size(142, 48);
            // 
            // editBuildingToolStripMenuItem
            // 
            this.editBuildingToolStripMenuItem.Name = "editBuildingToolStripMenuItem";
            this.editBuildingToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.editBuildingToolStripMenuItem.Text = "Edit Building";
            // 
            // viewMapsToolStripMenuItem
            // 
            this.viewMapsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stFloorToolStripMenuItem,
            this.ndFloorToolStripMenuItem});
            this.viewMapsToolStripMenuItem.Name = "viewMapsToolStripMenuItem";
            this.viewMapsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.viewMapsToolStripMenuItem.Text = "View Maps";
            // 
            // stFloorToolStripMenuItem
            // 
            this.stFloorToolStripMenuItem.Name = "stFloorToolStripMenuItem";
            this.stFloorToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.stFloorToolStripMenuItem.Text = "1st Floor";
            // 
            // ndFloorToolStripMenuItem
            // 
            this.ndFloorToolStripMenuItem.Name = "ndFloorToolStripMenuItem";
            this.ndFloorToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.ndFloorToolStripMenuItem.Text = "2nd Floor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1231, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 241;
            this.label1.Text = "Memo";
            // 
            // txtITEquipNotes
            // 
            this.txtITEquipNotes.Location = new System.Drawing.Point(1231, 124);
            this.txtITEquipNotes.Multiline = true;
            this.txtITEquipNotes.Name = "txtITEquipNotes";
            this.txtITEquipNotes.Size = new System.Drawing.Size(350, 211);
            this.txtITEquipNotes.TabIndex = 242;
            this.txtITEquipNotes.LostFocus += new System.EventHandler(this.txtITEquipNotes_LostFocus);
            // 
            // lstDocs
            // 
            this.lstDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDocs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDocs.FullRowSelect = true;
            this.lstDocs.GridLines = true;
            this.lstDocs.Location = new System.Drawing.Point(1231, 364);
            this.lstDocs.Name = "lstDocs";
            this.lstDocs.Size = new System.Drawing.Size(350, 226);
            this.lstDocs.TabIndex = 288;
            this.lstDocs.UseCompatibleStateImageBehavior = false;
            this.lstDocs.View = System.Windows.Forms.View.Details;
            this.lstDocs.DoubleClick += new System.EventHandler(this.lstDocs_DoubleClick);
            this.lstDocs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstDocs_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1234, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 289;
            this.label2.Text = "Documents";
            // 
            // contextMenuStrip5
            // 
            this.contextMenuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDocumentToolStripMenuItem,
            this.uploadDocumentToolStripMenuItem,
            this.deleteDocumentToolStripMenuItem});
            this.contextMenuStrip5.Name = "contextMenuStrip5";
            this.contextMenuStrip5.Size = new System.Drawing.Size(172, 70);
            this.contextMenuStrip5.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuStripItemClicked);
            // 
            // viewDocumentToolStripMenuItem
            // 
            this.viewDocumentToolStripMenuItem.Name = "viewDocumentToolStripMenuItem";
            this.viewDocumentToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.viewDocumentToolStripMenuItem.Text = "View Document";
            this.viewDocumentToolStripMenuItem.Visible = false;
            // 
            // uploadDocumentToolStripMenuItem
            // 
            this.uploadDocumentToolStripMenuItem.Name = "uploadDocumentToolStripMenuItem";
            this.uploadDocumentToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.uploadDocumentToolStripMenuItem.Text = "Upload Document";
            // 
            // deleteDocumentToolStripMenuItem
            // 
            this.deleteDocumentToolStripMenuItem.Name = "deleteDocumentToolStripMenuItem";
            this.deleteDocumentToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteDocumentToolStripMenuItem.Text = "Delete Document";
            // 
            // btnUploadRoom
            // 
            this.btnUploadRoom.Location = new System.Drawing.Point(374, 48);
            this.btnUploadRoom.Name = "btnUploadRoom";
            this.btnUploadRoom.Size = new System.Drawing.Size(88, 24);
            this.btnUploadRoom.TabIndex = 290;
            this.btnUploadRoom.Text = "Upload Rooms";
            this.btnUploadRoom.UseVisualStyleBackColor = true;
            this.btnUploadRoom.Click += new System.EventHandler(this.uploadRoom_Click);
            // 
            // frmOperationsProjectStaffs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(172)))), ((int)(((byte)(198)))));
            this.ClientSize = new System.Drawing.Size(1814, 648);
            this.Controls.Add(this.btnUploadRoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstDocs);
            this.Controls.Add(this.txtITEquipNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEquips);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelEquip);
            this.Controls.Add(this.labelStaff);
            this.Controls.Add(this.labelRoom);
            this.Controls.Add(this.labelBuilding);
            this.Controls.Add(this.lstStaffs);
            this.Controls.Add(this.lstRooms);
            this.Controls.Add(this.lstBuildings);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblOperations);
            this.Name = "frmOperationsProjectStaffs";
            this.Text = "frmOperationsProjectStaffs";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquips)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.contextMenuStrip4.ResumeLayout(false);
            this.contextMenuStrip5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListView lstBuildings;
        private System.Windows.Forms.Label lblOperations;
        private System.Windows.Forms.ListView lstRooms;
        private System.Windows.Forms.ListView lstStaffs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private Label labelBuilding;
        private Label labelRoom;
        private Label labelStaff;
        private Label labelEquip;
        private PictureBox pictureBox1;
        private DataGridView dgvEquips;
        private ToolStripMenuItem editMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem addNewEquipToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem newRoomToolStripMenuItem;
        private ToolStripMenuItem editRoomToolStripMenuItem;
        private ToolStripMenuItem deleteRoomToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip4;
        private ToolStripMenuItem editBuildingToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem viewMapsToolStripMenuItem;
        private ToolStripMenuItem stFloorToolStripMenuItem;
        private ToolStripMenuItem ndFloorToolStripMenuItem;
        private Label label1;
        private TextBox txtITEquipNotes;
        private ListView lstDocs;
        private Label label2;
        private ContextMenuStrip contextMenuStrip5;
        private ToolStripMenuItem viewDocumentToolStripMenuItem;
        private ToolStripMenuItem uploadDocumentToolStripMenuItem;
        private ToolStripMenuItem deleteDocumentToolStripMenuItem;
        private ToolStripMenuItem assingNewStaffToRoomToolStripMenuItem;
        private Button btnUploadRoom;
    }
}