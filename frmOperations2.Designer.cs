namespace PECS_v1
{
    partial class frmOperations2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperations2));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblOperations = new System.Windows.Forms.Label();
            this.MainTabCtl = new System.Windows.Forms.TabControl();
            this.tabOperation = new System.Windows.Forms.TabPage();
            this.cmdUploadRooms = new System.Windows.Forms.Button();
            this.cmdProjStaff = new System.Windows.Forms.Button();
            this.cmdNewEquip = new System.Windows.Forms.Button();
            this.cmdNewBldgRoom = new System.Windows.Forms.Button();
            this.cmdNewAssignStaffToRoom = new System.Windows.Forms.Button();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbEquipments = new System.Windows.Forms.Label();
            this.lvByEquipments = new System.Windows.Forms.ListView();
            this.lbLocations = new System.Windows.Forms.Label();
            this.lvByLocations = new System.Windows.Forms.ListView();
            this.lbByStaffs = new System.Windows.Forms.Label();
            this.lvByStaffs = new System.Windows.Forms.ListView();
            this.tabDataProcesses = new System.Windows.Forms.TabPage();
            this.impNewAssignments = new System.Windows.Forms.Button();
            this.gbStaffProject = new System.Windows.Forms.GroupBox();
            this.cmdDeleteStaff = new System.Windows.Forms.Button();
            this.cmdMoveStaff = new System.Windows.Forms.Button();
            this.gbRoomProject = new System.Windows.Forms.GroupBox();
            this.cmdDeleteRoom = new System.Windows.Forms.Button();
            this.cmdMoveRoom = new System.Windows.Forms.Button();
            this.gpPECSReference = new System.Windows.Forms.GroupBox();
            this.cmdSpaceType = new System.Windows.Forms.Button();
            this.rdRefDelete = new System.Windows.Forms.RadioButton();
            this.cmdEquipType = new System.Windows.Forms.Button();
            this.rdRefEdit = new System.Windows.Forms.RadioButton();
            this.rbRefAdd = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lbBatchProcesses = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.impCampusSchedules = new System.Windows.Forms.Button();
            this.impNewEquipments = new System.Windows.Forms.Button();
            this.impHelpDeskData = new System.Windows.Forms.Button();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.lbRPITEquipType = new System.Windows.Forms.Label();
            this.cbRPITEquipType = new System.Windows.Forms.ComboBox();
            this.cbRPITEquipStatus = new System.Windows.Forms.ComboBox();
            this.lbRPITEquipStatus = new System.Windows.Forms.Label();
            this.lbRPStaffs = new System.Windows.Forms.Label();
            this.cbRPStaffs = new System.Windows.Forms.ComboBox();
            this.lbRPBuilding = new System.Windows.Forms.Label();
            this.lbRPRoom = new System.Windows.Forms.Label();
            this.cbRPBuilding = new System.Windows.Forms.ComboBox();
            this.cbRPRoom = new System.Windows.Forms.ComboBox();
            this.lvOpeReports = new System.Windows.Forms.ListView();
            this.cmdRPDownload = new System.Windows.Forms.Button();
            this.cmdRPSearch = new System.Windows.Forms.Button();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.llbClassSchedule = new System.Windows.Forms.LinkLabel();
            this.lvClassSchedule = new System.Windows.Forms.ListView();
            this.llbFastBook = new System.Windows.Forms.LinkLabel();
            this.cmdUploadAssets = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.MainTabCtl.SuspendLayout();
            this.tabOperation.SuspendLayout();
            this.tabDataProcesses.SuspendLayout();
            this.gbStaffProject.SuspendLayout();
            this.gbRoomProject.SuspendLayout();
            this.gpPECSReference.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.tabSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 85);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 238;
            this.pictureBox2.TabStop = false;
            // 
            // lblOperations
            // 
            this.lblOperations.AutoSize = true;
            this.lblOperations.BackColor = System.Drawing.Color.Transparent;
            this.lblOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperations.Location = new System.Drawing.Point(109, 17);
            this.lblOperations.Name = "lblOperations";
            this.lblOperations.Padding = new System.Windows.Forms.Padding(2);
            this.lblOperations.Size = new System.Drawing.Size(215, 46);
            this.lblOperations.TabIndex = 237;
            this.lblOperations.Text = "Operations";
            // 
            // MainTabCtl
            // 
            this.MainTabCtl.Controls.Add(this.tabOperation);
            this.MainTabCtl.Controls.Add(this.tabDataProcesses);
            this.MainTabCtl.Controls.Add(this.tabReports);
            this.MainTabCtl.Controls.Add(this.tabSchedule);
            this.MainTabCtl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTabCtl.Location = new System.Drawing.Point(12, 103);
            this.MainTabCtl.Name = "MainTabCtl";
            this.MainTabCtl.SelectedIndex = 0;
            this.MainTabCtl.Size = new System.Drawing.Size(1049, 551);
            this.MainTabCtl.TabIndex = 239;
            this.MainTabCtl.SelectedIndexChanged += new System.EventHandler(this.MainTabCtl_SelectedIndexChanged);
            // 
            // tabOperation
            // 
            this.tabOperation.Controls.Add(this.cmdUploadAssets);
            this.tabOperation.Controls.Add(this.cmdUploadRooms);
            this.tabOperation.Controls.Add(this.cmdProjStaff);
            this.tabOperation.Controls.Add(this.cmdNewEquip);
            this.tabOperation.Controls.Add(this.cmdNewBldgRoom);
            this.tabOperation.Controls.Add(this.cmdNewAssignStaffToRoom);
            this.tabOperation.Controls.Add(this.lbSearch);
            this.tabOperation.Controls.Add(this.txtSearch);
            this.tabOperation.Controls.Add(this.lbEquipments);
            this.tabOperation.Controls.Add(this.lvByEquipments);
            this.tabOperation.Controls.Add(this.lbLocations);
            this.tabOperation.Controls.Add(this.lvByLocations);
            this.tabOperation.Controls.Add(this.lbByStaffs);
            this.tabOperation.Controls.Add(this.lvByStaffs);
            this.tabOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOperation.Location = new System.Drawing.Point(4, 24);
            this.tabOperation.Name = "tabOperation";
            this.tabOperation.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperation.Size = new System.Drawing.Size(1041, 523);
            this.tabOperation.TabIndex = 0;
            this.tabOperation.Text = "Operations";
            this.tabOperation.UseVisualStyleBackColor = true;
            // 
            // cmdUploadRooms
            // 
            this.cmdUploadRooms.Location = new System.Drawing.Point(892, 228);
            this.cmdUploadRooms.Name = "cmdUploadRooms";
            this.cmdUploadRooms.Size = new System.Drawing.Size(143, 23);
            this.cmdUploadRooms.TabIndex = 265;
            this.cmdUploadRooms.Text = "Upload Rooms";
            this.cmdUploadRooms.UseVisualStyleBackColor = true;
            this.cmdUploadRooms.Click += new System.EventHandler(this.cmduploadRooms_Click);
            // 
            // cmdProjStaff
            // 
            this.cmdProjStaff.Location = new System.Drawing.Point(892, 180);
            this.cmdProjStaff.Name = "cmdProjStaff";
            this.cmdProjStaff.Size = new System.Drawing.Size(143, 23);
            this.cmdProjStaff.TabIndex = 264;
            this.cmdProjStaff.Text = "Project Staffs";
            this.cmdProjStaff.UseVisualStyleBackColor = true;
            this.cmdProjStaff.MouseClick += new System.Windows.Forms.MouseEventHandler(this.getOpeProjectStaffs);
            // 
            // cmdNewEquip
            // 
            this.cmdNewEquip.Location = new System.Drawing.Point(895, 59);
            this.cmdNewEquip.Name = "cmdNewEquip";
            this.cmdNewEquip.Size = new System.Drawing.Size(143, 23);
            this.cmdNewEquip.TabIndex = 262;
            this.cmdNewEquip.Text = "New Equipment";
            this.cmdNewEquip.UseVisualStyleBackColor = true;
            this.cmdNewEquip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.getOpeNewEquip);
            // 
            // cmdNewBldgRoom
            // 
            this.cmdNewBldgRoom.Location = new System.Drawing.Point(895, 119);
            this.cmdNewBldgRoom.Name = "cmdNewBldgRoom";
            this.cmdNewBldgRoom.Size = new System.Drawing.Size(143, 23);
            this.cmdNewBldgRoom.TabIndex = 263;
            this.cmdNewBldgRoom.Text = "New Building/Room";
            this.cmdNewBldgRoom.UseVisualStyleBackColor = true;
            this.cmdNewBldgRoom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.getOpeNewBldgRm);
            // 
            // cmdNewAssignStaffToRoom
            // 
            this.cmdNewAssignStaffToRoom.Location = new System.Drawing.Point(895, 90);
            this.cmdNewAssignStaffToRoom.Name = "cmdNewAssignStaffToRoom";
            this.cmdNewAssignStaffToRoom.Size = new System.Drawing.Size(143, 23);
            this.cmdNewAssignStaffToRoom.TabIndex = 261;
            this.cmdNewAssignStaffToRoom.Text = "New Assign Staff";
            this.cmdNewAssignStaffToRoom.UseVisualStyleBackColor = true;
            this.cmdNewAssignStaffToRoom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.getOpeNewAssign);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(12, 14);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(52, 15);
            this.lbSearch.TabIndex = 257;
            this.lbSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(70, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(356, 21);
            this.txtSearch.TabIndex = 256;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbEquipments
            // 
            this.lbEquipments.AutoSize = true;
            this.lbEquipments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEquipments.Location = new System.Drawing.Point(12, 212);
            this.lbEquipments.Name = "lbEquipments";
            this.lbEquipments.Size = new System.Drawing.Size(72, 13);
            this.lbEquipments.TabIndex = 255;
            this.lbEquipments.Text = "Equipments";
            // 
            // lvByEquipments
            // 
            this.lvByEquipments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvByEquipments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvByEquipments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvByEquipments.FullRowSelect = true;
            this.lvByEquipments.GridLines = true;
            this.lvByEquipments.Location = new System.Drawing.Point(15, 228);
            this.lvByEquipments.Name = "lvByEquipments";
            this.lvByEquipments.Size = new System.Drawing.Size(871, 219);
            this.lvByEquipments.TabIndex = 254;
            this.lvByEquipments.UseCompatibleStateImageBehavior = false;
            this.lvByEquipments.View = System.Windows.Forms.View.Details;
            this.lvByEquipments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.getOpeDetails);
            // 
            // lbLocations
            // 
            this.lbLocations.AutoSize = true;
            this.lbLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocations.Location = new System.Drawing.Point(621, 43);
            this.lbLocations.Name = "lbLocations";
            this.lbLocations.Size = new System.Drawing.Size(62, 13);
            this.lbLocations.TabIndex = 253;
            this.lbLocations.Text = "Locations";
            // 
            // lvByLocations
            // 
            this.lvByLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvByLocations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvByLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvByLocations.FullRowSelect = true;
            this.lvByLocations.GridLines = true;
            this.lvByLocations.Location = new System.Drawing.Point(499, 59);
            this.lvByLocations.Name = "lvByLocations";
            this.lvByLocations.Size = new System.Drawing.Size(387, 144);
            this.lvByLocations.TabIndex = 252;
            this.lvByLocations.UseCompatibleStateImageBehavior = false;
            this.lvByLocations.View = System.Windows.Forms.View.Details;
            this.lvByLocations.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.getOpeDetails);
            // 
            // lbByStaffs
            // 
            this.lbByStaffs.AutoSize = true;
            this.lbByStaffs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbByStaffs.Location = new System.Drawing.Point(12, 43);
            this.lbByStaffs.Name = "lbByStaffs";
            this.lbByStaffs.Size = new System.Drawing.Size(105, 13);
            this.lbByStaffs.TabIndex = 251;
            this.lbByStaffs.Text = "Staffs / Faculties";
            // 
            // lvByStaffs
            // 
            this.lvByStaffs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvByStaffs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvByStaffs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvByStaffs.FullRowSelect = true;
            this.lvByStaffs.GridLines = true;
            this.lvByStaffs.Location = new System.Drawing.Point(15, 59);
            this.lvByStaffs.Name = "lvByStaffs";
            this.lvByStaffs.Size = new System.Drawing.Size(478, 144);
            this.lvByStaffs.TabIndex = 250;
            this.lvByStaffs.UseCompatibleStateImageBehavior = false;
            this.lvByStaffs.View = System.Windows.Forms.View.Details;
            this.lvByStaffs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.getOpeDetails);
            // 
            // tabDataProcesses
            // 
            this.tabDataProcesses.Controls.Add(this.impNewAssignments);
            this.tabDataProcesses.Controls.Add(this.gbStaffProject);
            this.tabDataProcesses.Controls.Add(this.gbRoomProject);
            this.tabDataProcesses.Controls.Add(this.gpPECSReference);
            this.tabDataProcesses.Controls.Add(this.label1);
            this.tabDataProcesses.Controls.Add(this.lbBatchProcesses);
            this.tabDataProcesses.Controls.Add(this.button1);
            this.tabDataProcesses.Controls.Add(this.impCampusSchedules);
            this.tabDataProcesses.Controls.Add(this.impNewEquipments);
            this.tabDataProcesses.Controls.Add(this.impHelpDeskData);
            this.tabDataProcesses.Location = new System.Drawing.Point(4, 24);
            this.tabDataProcesses.Name = "tabDataProcesses";
            this.tabDataProcesses.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataProcesses.Size = new System.Drawing.Size(1041, 523);
            this.tabDataProcesses.TabIndex = 1;
            this.tabDataProcesses.Text = "DataProcesses";
            this.tabDataProcesses.UseVisualStyleBackColor = true;
            // 
            // impNewAssignments
            // 
            this.impNewAssignments.Location = new System.Drawing.Point(22, 66);
            this.impNewAssignments.Name = "impNewAssignments";
            this.impNewAssignments.Size = new System.Drawing.Size(218, 23);
            this.impNewAssignments.TabIndex = 275;
            this.impNewAssignments.Text = "Load Assignments";
            this.impNewAssignments.UseVisualStyleBackColor = true;
            this.impNewAssignments.Click += new System.EventHandler(this.impNewAssignments_Click);
            // 
            // gbStaffProject
            // 
            this.gbStaffProject.Controls.Add(this.cmdDeleteStaff);
            this.gbStaffProject.Controls.Add(this.cmdMoveStaff);
            this.gbStaffProject.Location = new System.Drawing.Point(339, 156);
            this.gbStaffProject.Name = "gbStaffProject";
            this.gbStaffProject.Size = new System.Drawing.Size(179, 102);
            this.gbStaffProject.TabIndex = 274;
            this.gbStaffProject.TabStop = false;
            this.gbStaffProject.Text = "Staff Project";
            this.gbStaffProject.Visible = false;
            // 
            // cmdDeleteStaff
            // 
            this.cmdDeleteStaff.Location = new System.Drawing.Point(6, 61);
            this.cmdDeleteStaff.Name = "cmdDeleteStaff";
            this.cmdDeleteStaff.Size = new System.Drawing.Size(162, 23);
            this.cmdDeleteStaff.TabIndex = 266;
            this.cmdDeleteStaff.Text = "Delete Staff/Faculty";
            this.cmdDeleteStaff.UseVisualStyleBackColor = true;
            // 
            // cmdMoveStaff
            // 
            this.cmdMoveStaff.Location = new System.Drawing.Point(6, 30);
            this.cmdMoveStaff.Name = "cmdMoveStaff";
            this.cmdMoveStaff.Size = new System.Drawing.Size(162, 23);
            this.cmdMoveStaff.TabIndex = 265;
            this.cmdMoveStaff.Text = "Move Staff/Faculty";
            this.cmdMoveStaff.UseVisualStyleBackColor = true;
            this.cmdMoveStaff.MouseClick += new System.Windows.Forms.MouseEventHandler(this.getOpeProjectStaffs);
            // 
            // gbRoomProject
            // 
            this.gbRoomProject.Controls.Add(this.cmdDeleteRoom);
            this.gbRoomProject.Controls.Add(this.cmdMoveRoom);
            this.gbRoomProject.Location = new System.Drawing.Point(339, 36);
            this.gbRoomProject.Name = "gbRoomProject";
            this.gbRoomProject.Size = new System.Drawing.Size(179, 102);
            this.gbRoomProject.TabIndex = 273;
            this.gbRoomProject.TabStop = false;
            this.gbRoomProject.Text = "Room Project";
            // 
            // cmdDeleteRoom
            // 
            this.cmdDeleteRoom.Location = new System.Drawing.Point(6, 61);
            this.cmdDeleteRoom.Name = "cmdDeleteRoom";
            this.cmdDeleteRoom.Size = new System.Drawing.Size(162, 23);
            this.cmdDeleteRoom.TabIndex = 264;
            this.cmdDeleteRoom.Text = "Delete Room";
            this.cmdDeleteRoom.UseVisualStyleBackColor = true;
            // 
            // cmdMoveRoom
            // 
            this.cmdMoveRoom.Location = new System.Drawing.Point(6, 30);
            this.cmdMoveRoom.Name = "cmdMoveRoom";
            this.cmdMoveRoom.Size = new System.Drawing.Size(162, 23);
            this.cmdMoveRoom.TabIndex = 263;
            this.cmdMoveRoom.Text = "Move Room";
            this.cmdMoveRoom.UseVisualStyleBackColor = true;
            // 
            // gpPECSReference
            // 
            this.gpPECSReference.Controls.Add(this.cmdSpaceType);
            this.gpPECSReference.Controls.Add(this.rdRefDelete);
            this.gpPECSReference.Controls.Add(this.cmdEquipType);
            this.gpPECSReference.Controls.Add(this.rdRefEdit);
            this.gpPECSReference.Controls.Add(this.rbRefAdd);
            this.gpPECSReference.Location = new System.Drawing.Point(603, 36);
            this.gpPECSReference.Name = "gpPECSReference";
            this.gpPECSReference.Size = new System.Drawing.Size(218, 167);
            this.gpPECSReference.TabIndex = 272;
            this.gpPECSReference.TabStop = false;
            this.gpPECSReference.Text = "PECS Reference Data";
            // 
            // cmdSpaceType
            // 
            this.cmdSpaceType.Location = new System.Drawing.Point(20, 107);
            this.cmdSpaceType.Name = "cmdSpaceType";
            this.cmdSpaceType.Size = new System.Drawing.Size(169, 23);
            this.cmdSpaceType.TabIndex = 265;
            this.cmdSpaceType.Text = "Space Type";
            this.cmdSpaceType.UseVisualStyleBackColor = true;
            // 
            // rdRefDelete
            // 
            this.rdRefDelete.AutoSize = true;
            this.rdRefDelete.Location = new System.Drawing.Point(20, 82);
            this.rdRefDelete.Name = "rdRefDelete";
            this.rdRefDelete.Size = new System.Drawing.Size(67, 19);
            this.rdRefDelete.TabIndex = 271;
            this.rdRefDelete.TabStop = true;
            this.rdRefDelete.Text = "Delete";
            this.rdRefDelete.UseVisualStyleBackColor = true;
            // 
            // cmdEquipType
            // 
            this.cmdEquipType.Location = new System.Drawing.Point(20, 136);
            this.cmdEquipType.Name = "cmdEquipType";
            this.cmdEquipType.Size = new System.Drawing.Size(169, 23);
            this.cmdEquipType.TabIndex = 266;
            this.cmdEquipType.Text = "Equipment Type";
            this.cmdEquipType.UseVisualStyleBackColor = true;
            // 
            // rdRefEdit
            // 
            this.rdRefEdit.AutoSize = true;
            this.rdRefEdit.Location = new System.Drawing.Point(20, 57);
            this.rdRefEdit.Name = "rdRefEdit";
            this.rdRefEdit.Size = new System.Drawing.Size(67, 19);
            this.rdRefEdit.TabIndex = 270;
            this.rdRefEdit.TabStop = true;
            this.rdRefEdit.Text = "Modify";
            this.rdRefEdit.UseVisualStyleBackColor = true;
            // 
            // rbRefAdd
            // 
            this.rbRefAdd.AutoSize = true;
            this.rbRefAdd.Location = new System.Drawing.Point(20, 32);
            this.rbRefAdd.Name = "rbRefAdd";
            this.rbRefAdd.Size = new System.Drawing.Size(81, 19);
            this.rbRefAdd.TabIndex = 269;
            this.rbRefAdd.TabStop = true;
            this.rbRefAdd.Text = "Add New";
            this.rbRefAdd.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 15);
            this.label1.TabIndex = 268;
            this.label1.Text = "Others !!!!!!!!!!!!!!!!";
            // 
            // lbBatchProcesses
            // 
            this.lbBatchProcesses.AutoSize = true;
            this.lbBatchProcesses.Location = new System.Drawing.Point(22, 17);
            this.lbBatchProcesses.Name = "lbBatchProcesses";
            this.lbBatchProcesses.Size = new System.Drawing.Size(113, 15);
            this.lbBatchProcesses.TabIndex = 267;
            this.lbBatchProcesses.Text = "Batch Processes";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 23);
            this.button1.TabIndex = 264;
            this.button1.Text = "Load Data From Facility";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // impCampusSchedules
            // 
            this.impCampusSchedules.Location = new System.Drawing.Point(25, 166);
            this.impCampusSchedules.Name = "impCampusSchedules";
            this.impCampusSchedules.Size = new System.Drawing.Size(218, 23);
            this.impCampusSchedules.TabIndex = 263;
            this.impCampusSchedules.Text = "Load Campus Schedules";
            this.impCampusSchedules.UseVisualStyleBackColor = true;
            // 
            // impNewEquipments
            // 
            this.impNewEquipments.Location = new System.Drawing.Point(22, 36);
            this.impNewEquipments.Name = "impNewEquipments";
            this.impNewEquipments.Size = new System.Drawing.Size(218, 23);
            this.impNewEquipments.TabIndex = 262;
            this.impNewEquipments.Text = "Load Equipments";
            this.impNewEquipments.UseVisualStyleBackColor = true;
            this.impNewEquipments.Click += new System.EventHandler(this.impNewEquipments_Click);
            // 
            // impHelpDeskData
            // 
            this.impHelpDeskData.Location = new System.Drawing.Point(25, 137);
            this.impHelpDeskData.Name = "impHelpDeskData";
            this.impHelpDeskData.Size = new System.Drawing.Size(218, 23);
            this.impHelpDeskData.TabIndex = 261;
            this.impHelpDeskData.Text = "Load HelpDesk Data";
            this.impHelpDeskData.UseVisualStyleBackColor = true;
            this.impHelpDeskData.Click += new System.EventHandler(this.cmdImpHelpDeskData);
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.lbRPITEquipType);
            this.tabReports.Controls.Add(this.cbRPITEquipType);
            this.tabReports.Controls.Add(this.cbRPITEquipStatus);
            this.tabReports.Controls.Add(this.lbRPITEquipStatus);
            this.tabReports.Controls.Add(this.lbRPStaffs);
            this.tabReports.Controls.Add(this.cbRPStaffs);
            this.tabReports.Controls.Add(this.lbRPBuilding);
            this.tabReports.Controls.Add(this.lbRPRoom);
            this.tabReports.Controls.Add(this.cbRPBuilding);
            this.tabReports.Controls.Add(this.cbRPRoom);
            this.tabReports.Controls.Add(this.lvOpeReports);
            this.tabReports.Controls.Add(this.cmdRPDownload);
            this.tabReports.Controls.Add(this.cmdRPSearch);
            this.tabReports.Location = new System.Drawing.Point(4, 24);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabReports.Size = new System.Drawing.Size(1041, 523);
            this.tabReports.TabIndex = 2;
            this.tabReports.Text = "Reports";
            this.tabReports.UseVisualStyleBackColor = true;
            // 
            // lbRPITEquipType
            // 
            this.lbRPITEquipType.AutoSize = true;
            this.lbRPITEquipType.Location = new System.Drawing.Point(282, 17);
            this.lbRPITEquipType.Name = "lbRPITEquipType";
            this.lbRPITEquipType.Size = new System.Drawing.Size(93, 15);
            this.lbRPITEquipType.TabIndex = 285;
            this.lbRPITEquipType.Text = "Filter By Type";
            // 
            // cbRPITEquipType
            // 
            this.cbRPITEquipType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbRPITEquipType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbRPITEquipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRPITEquipType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRPITEquipType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRPITEquipType.FormattingEnabled = true;
            this.cbRPITEquipType.Location = new System.Drawing.Point(288, 35);
            this.cbRPITEquipType.MaxDropDownItems = 12;
            this.cbRPITEquipType.Name = "cbRPITEquipType";
            this.cbRPITEquipType.Size = new System.Drawing.Size(131, 21);
            this.cbRPITEquipType.TabIndex = 284;
            this.cbRPITEquipType.SelectedIndexChanged += new System.EventHandler(this.cbRPITEquipType_SelectedIndexChanged);
            // 
            // cbRPITEquipStatus
            // 
            this.cbRPITEquipStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbRPITEquipStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbRPITEquipStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRPITEquipStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRPITEquipStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRPITEquipStatus.FormattingEnabled = true;
            this.cbRPITEquipStatus.Location = new System.Drawing.Point(288, 74);
            this.cbRPITEquipStatus.Name = "cbRPITEquipStatus";
            this.cbRPITEquipStatus.Size = new System.Drawing.Size(132, 21);
            this.cbRPITEquipStatus.TabIndex = 287;
            this.cbRPITEquipStatus.SelectedIndexChanged += new System.EventHandler(this.cbRPITEquipStatus_SelectedIndexChanged);
            // 
            // lbRPITEquipStatus
            // 
            this.lbRPITEquipStatus.AutoSize = true;
            this.lbRPITEquipStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbRPITEquipStatus.Location = new System.Drawing.Point(285, 58);
            this.lbRPITEquipStatus.Name = "lbRPITEquipStatus";
            this.lbRPITEquipStatus.Size = new System.Drawing.Size(103, 15);
            this.lbRPITEquipStatus.TabIndex = 286;
            this.lbRPITEquipStatus.Text = "Filter By Status";
            // 
            // lbRPStaffs
            // 
            this.lbRPStaffs.AutoSize = true;
            this.lbRPStaffs.Location = new System.Drawing.Point(24, 77);
            this.lbRPStaffs.Name = "lbRPStaffs";
            this.lbRPStaffs.Size = new System.Drawing.Size(85, 15);
            this.lbRPStaffs.TabIndex = 283;
            this.lbRPStaffs.Text = "Staff/Faculty";
            // 
            // cbRPStaffs
            // 
            this.cbRPStaffs.AllowDrop = true;
            this.cbRPStaffs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbRPStaffs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbRPStaffs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRPStaffs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRPStaffs.FormattingEnabled = true;
            this.cbRPStaffs.Location = new System.Drawing.Point(115, 73);
            this.cbRPStaffs.Name = "cbRPStaffs";
            this.cbRPStaffs.Size = new System.Drawing.Size(146, 21);
            this.cbRPStaffs.TabIndex = 282;
            this.cbRPStaffs.SelectedValueChanged += new System.EventHandler(this.cbRPStaffs_SelectedValueChanged);
            // 
            // lbRPBuilding
            // 
            this.lbRPBuilding.AutoSize = true;
            this.lbRPBuilding.Location = new System.Drawing.Point(49, 18);
            this.lbRPBuilding.Name = "lbRPBuilding";
            this.lbRPBuilding.Size = new System.Drawing.Size(60, 15);
            this.lbRPBuilding.TabIndex = 281;
            this.lbRPBuilding.Text = "Building";
            // 
            // lbRPRoom
            // 
            this.lbRPRoom.AutoSize = true;
            this.lbRPRoom.Location = new System.Drawing.Point(49, 44);
            this.lbRPRoom.Name = "lbRPRoom";
            this.lbRPRoom.Size = new System.Drawing.Size(45, 15);
            this.lbRPRoom.TabIndex = 279;
            this.lbRPRoom.Text = "Room";
            // 
            // cbRPBuilding
            // 
            this.cbRPBuilding.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbRPBuilding.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbRPBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRPBuilding.FormattingEnabled = true;
            this.cbRPBuilding.Location = new System.Drawing.Point(115, 17);
            this.cbRPBuilding.Name = "cbRPBuilding";
            this.cbRPBuilding.Size = new System.Drawing.Size(90, 21);
            this.cbRPBuilding.TabIndex = 280;
            this.cbRPBuilding.SelectedValueChanged += new System.EventHandler(this.cbRPBuilding_SelectedValueChanged);
            // 
            // cbRPRoom
            // 
            this.cbRPRoom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbRPRoom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbRPRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRPRoom.FormattingEnabled = true;
            this.cbRPRoom.Location = new System.Drawing.Point(115, 44);
            this.cbRPRoom.Name = "cbRPRoom";
            this.cbRPRoom.Size = new System.Drawing.Size(90, 21);
            this.cbRPRoom.TabIndex = 278;
            this.cbRPRoom.SelectedValueChanged += new System.EventHandler(this.cbRPRoom_SelectedValueChanged);
            // 
            // lvOpeReports
            // 
            this.lvOpeReports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvOpeReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvOpeReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvOpeReports.FullRowSelect = true;
            this.lvOpeReports.GridLines = true;
            this.lvOpeReports.Location = new System.Drawing.Point(17, 108);
            this.lvOpeReports.Name = "lvOpeReports";
            this.lvOpeReports.Size = new System.Drawing.Size(982, 388);
            this.lvOpeReports.TabIndex = 276;
            this.lvOpeReports.UseCompatibleStateImageBehavior = false;
            this.lvOpeReports.View = System.Windows.Forms.View.Details;
            // 
            // cmdRPDownload
            // 
            this.cmdRPDownload.Location = new System.Drawing.Point(837, 74);
            this.cmdRPDownload.Name = "cmdRPDownload";
            this.cmdRPDownload.Size = new System.Drawing.Size(162, 23);
            this.cmdRPDownload.TabIndex = 1;
            this.cmdRPDownload.Text = "Download";
            this.cmdRPDownload.UseVisualStyleBackColor = true;
            this.cmdRPDownload.Click += new System.EventHandler(this.cmdRPDownload_Click);
            // 
            // cmdRPSearch
            // 
            this.cmdRPSearch.Location = new System.Drawing.Point(837, 14);
            this.cmdRPSearch.Name = "cmdRPSearch";
            this.cmdRPSearch.Size = new System.Drawing.Size(162, 23);
            this.cmdRPSearch.TabIndex = 0;
            this.cmdRPSearch.Text = "Search";
            this.cmdRPSearch.UseVisualStyleBackColor = true;
            this.cmdRPSearch.Visible = false;
            // 
            // tabSchedule
            // 
            this.tabSchedule.Controls.Add(this.llbClassSchedule);
            this.tabSchedule.Controls.Add(this.lvClassSchedule);
            this.tabSchedule.Controls.Add(this.llbFastBook);
            this.tabSchedule.Location = new System.Drawing.Point(4, 24);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabSchedule.Size = new System.Drawing.Size(1041, 523);
            this.tabSchedule.TabIndex = 3;
            this.tabSchedule.Text = "Schedule";
            this.tabSchedule.UseVisualStyleBackColor = true;
            // 
            // llbClassSchedule
            // 
            this.llbClassSchedule.AutoSize = true;
            this.llbClassSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbClassSchedule.Location = new System.Drawing.Point(16, 22);
            this.llbClassSchedule.Name = "llbClassSchedule";
            this.llbClassSchedule.Size = new System.Drawing.Size(307, 26);
            this.llbClassSchedule.TabIndex = 2;
            this.llbClassSchedule.TabStop = true;
            this.llbClassSchedule.Text = "Classes Schedule (Intranet)";
            this.llbClassSchedule.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbClassSchedule_LinkClicked);
            // 
            // lvClassSchedule
            // 
            this.lvClassSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvClassSchedule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvClassSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvClassSchedule.FullRowSelect = true;
            this.lvClassSchedule.GridLines = true;
            this.lvClassSchedule.Location = new System.Drawing.Point(21, 64);
            this.lvClassSchedule.Name = "lvClassSchedule";
            this.lvClassSchedule.Size = new System.Drawing.Size(1000, 441);
            this.lvClassSchedule.TabIndex = 1;
            this.lvClassSchedule.UseCompatibleStateImageBehavior = false;
            this.lvClassSchedule.View = System.Windows.Forms.View.Details;
            // 
            // llbFastBook
            // 
            this.llbFastBook.AutoSize = true;
            this.llbFastBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbFastBook.Location = new System.Drawing.Point(902, 22);
            this.llbFastBook.Name = "llbFastBook";
            this.llbFastBook.Size = new System.Drawing.Size(119, 26);
            this.llbFastBook.TabIndex = 0;
            this.llbFastBook.TabStop = true;
            this.llbFastBook.Text = "Fast Book";
            this.llbFastBook.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbFastBook_LinkClicked);
            // 
            // cmdUploadAssets
            // 
            this.cmdUploadAssets.Location = new System.Drawing.Point(892, 257);
            this.cmdUploadAssets.Name = "cmdUploadAssets";
            this.cmdUploadAssets.Size = new System.Drawing.Size(143, 23);
            this.cmdUploadAssets.TabIndex = 266;
            this.cmdUploadAssets.Text = "Upload Assets";
            this.cmdUploadAssets.UseVisualStyleBackColor = true;
            this.cmdUploadAssets.Click += new System.EventHandler(this.cmdupAssets_Click);

            // 
            // frmOperations2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(172)))), ((int)(((byte)(198)))));
            this.ClientSize = new System.Drawing.Size(1073, 666);
            this.Controls.Add(this.MainTabCtl);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblOperations);
            this.Name = "frmOperations2";
            this.Text = "Operations";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.MainTabCtl.ResumeLayout(false);
            this.tabOperation.ResumeLayout(false);
            this.tabOperation.PerformLayout();
            this.tabDataProcesses.ResumeLayout(false);
            this.tabDataProcesses.PerformLayout();
            this.gbStaffProject.ResumeLayout(false);
            this.gbRoomProject.ResumeLayout(false);
            this.gpPECSReference.ResumeLayout(false);
            this.gpPECSReference.PerformLayout();
            this.tabReports.ResumeLayout(false);
            this.tabReports.PerformLayout();
            this.tabSchedule.ResumeLayout(false);
            this.tabSchedule.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblOperations;
        private System.Windows.Forms.TabControl MainTabCtl;
        private System.Windows.Forms.TabPage tabOperation;
        private System.Windows.Forms.TabPage tabDataProcesses;
        private System.Windows.Forms.Label lbEquipments;
        private System.Windows.Forms.ListView lvByEquipments;
        private System.Windows.Forms.Label lbLocations;
        private System.Windows.Forms.ListView lvByLocations;
        private System.Windows.Forms.Label lbByStaffs;
        private System.Windows.Forms.ListView lvByStaffs;
        //private System.Windows.Forms.Label lbSearch;
        //private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button impCampusSchedules;
        private System.Windows.Forms.Button impNewEquipments;
        private System.Windows.Forms.Button impHelpDeskData;
        private System.Windows.Forms.Button cmdNewEquip;
        private System.Windows.Forms.Button cmdNewAssignStaffToRoom;
        private System.Windows.Forms.Button cmdNewBldgRoom;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.RadioButton rdRefDelete;
        private System.Windows.Forms.RadioButton rdRefEdit;
        private System.Windows.Forms.RadioButton rbRefAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbBatchProcesses;
        private System.Windows.Forms.Button cmdEquipType;
        private System.Windows.Forms.Button cmdSpaceType;
        private System.Windows.Forms.ListView lvClassSchedule;
        private System.Windows.Forms.LinkLabel llbFastBook;
        private System.Windows.Forms.GroupBox gpPECSReference;
        private System.Windows.Forms.Button cmdProjStaff;
        private System.Windows.Forms.GroupBox gbStaffProject;
        private System.Windows.Forms.Button cmdDeleteStaff;
        private System.Windows.Forms.Button cmdMoveStaff;
        private System.Windows.Forms.GroupBox gbRoomProject;
        private System.Windows.Forms.Button cmdDeleteRoom;
        private System.Windows.Forms.Button cmdMoveRoom;
        private System.Windows.Forms.Button cmdRPDownload;
        private System.Windows.Forms.Button cmdRPSearch;
        private System.Windows.Forms.Button impNewAssignments;
        private System.Windows.Forms.ListView lvOpeReports;
        private System.Windows.Forms.Label lbRPBuilding;
        private System.Windows.Forms.Label lbRPRoom;
        private System.Windows.Forms.ComboBox cbRPBuilding;
        private System.Windows.Forms.ComboBox cbRPRoom;
        private System.Windows.Forms.Label lbRPStaffs;
        private System.Windows.Forms.ComboBox cbRPStaffs;
        private System.Windows.Forms.Label lbRPITEquipType;
        private System.Windows.Forms.ComboBox cbRPITEquipType;
        private System.Windows.Forms.ComboBox cbRPITEquipStatus;
        private System.Windows.Forms.Label lbRPITEquipStatus;
        private System.Windows.Forms.LinkLabel llbClassSchedule;
        private System.Windows.Forms.Button cmdUploadRooms;
        private System.Windows.Forms.Button cmdUploadAssets;
    }
}