using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace PECS_v1
{
    public partial class frmOperationsProjectStaffs : Form
    {
        private DBConnector dbcBuildings;
        private DBConnector dbcRooms;
        private DBConnector dbcStaffs;
        private DBConnector dbcEquips;

        Operations2 Ope2 = new Operations2();
        private frmOperationsNewEquipment2 frmOpeNewEquip2;
        private frmOperationsNewAssign2 frmOpeNewAssign2;
        private String BuildID;
        private String BuildNameShort;
        private String RoomID;
        private String RoomNumber;
        private String EmpName;
        private String EmpID;
        private String EquipID;
        private bool isDraged;
        private bool isBuildingChanged;
        private bool isRoomChanged;
        private bool isEquip;
        private bool editing = false;
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        ListViewItem previousItem;
        System.Drawing.Point coordinate;

        private BindingSource bsEquip = new BindingSource();
        private DBConnector dbcEquip;

        public const String sqlBase = "SELECT * from Operations_Equipment2 mt " +
                " cross apply ( SELECT str = mt.[EquipDetails] + '||' ) temp1 " +
                " cross apply ( SELECT p1 = CHARINDEX( '|', str ) ) EquipName " +
                " cross apply ( SELECT p2 = CHARINDEX( '|', str, p1 + 1 ) ) Make " +
                " cross apply ( SELECT p3 = CHARINDEX( '|', str, p2 + 1 ) ) Model " +
                " cross apply ( SELECT p4 = CHARINDEX( '|', str, p3 + 1 ) ) Serial " +
                " cross apply ( SELECT p5 = CHARINDEX( '|', str, p4 + 1 ) ) assetTage " +
                " cross apply ( SELECT p6 = CHARINDEX( '|', str, p5 + 1 ) ) ESN " +
                " cross apply ( SELECT EquipName = SUBSTRING( str, 1, p1 - 1 ) " +
                " , Make = SUBSTRING( str, p1+1, p2 - p1 -1 ) " +
                " , Model = SUBSTRING( str, p2+1, p3 - p2 -1 ) " +
                " , Serial = SUBSTRING( str, p3+1, p4 - p3 -1) " +
                " , assetTage = SUBSTRING( str, p4+1, p5 - p4 -1) " +
                " , ESN = SUBSTRING( str, p5+1, p6 - p5 -1)" +
                ") ParsedData ";

        public frmOperationsProjectStaffs()
        {
            InitializeComponent();
            loadLstBuildings();


        }
        private void loadLstBuildings()
        {
            lstBuildings.BeginUpdate();
            lstBuildings.Clear();
            lstBuildings.Columns.Add("Buildings", 75, HorizontalAlignment.Left);
            String sql = @"select * from Operations_Buildings";
            dbcBuildings = new DBConnector(sql, "Operations_Buildings");
            DataTable eaDT = dbcBuildings.getDT();
            foreach (DataRow row in eaDT.Rows)
            {
                ListViewItem listItem = new ListViewItem(row["BuildNameShort"].ToString());
                listItem.SubItems.Add(row["BuildID"].ToString());
                lstBuildings.Items.Add(listItem);
            }
            lstBuildings.EndUpdate();
        }
        private void loadlstRooms()
        {
            lstRooms.BeginUpdate();
            lstRooms.Clear();
            lstRooms.Columns.Add("Rooms", 75, HorizontalAlignment.Left);
            String sql = @"SELECT * from Operations_Rooms2
                        WHERE BuildID = " + BuildID + "ORDER BY RoomNumber";

            dbcRooms = new DBConnector(sql, "Operations_Rooms2");
            DataTable eaDT = dbcRooms.getDT();
            foreach (DataRow row in eaDT.Rows)
            {
                ListViewItem listItem = new ListViewItem(row["RoomNumber"].ToString());
                listItem.SubItems.Add(row["RoomID"].ToString());
                lstRooms.Items.Add(listItem);
            }
            lstRooms.EndUpdate();
        }
        private void loadStaffs()
        {
            lstStaffs.BeginUpdate();
            lstStaffs.Clear();
            lstStaffs.Columns.Add("Staffs", 150, HorizontalAlignment.Left);
            String sql = @"SELECT * from Operations_Rooms_Employees2
                            WHERE RoomID = '" + InfoLoader.roomNumber2RoomID(BuildID, RoomNumber) + "'";
            dbcStaffs = new DBConnector(sql, "Operations_Rooms_Employees2");
            DataTable eaDT = dbcStaffs.getDT();
            foreach (DataRow row in eaDT.Rows)
            {
                ListViewItem listItem = new ListViewItem(InfoLoader.empID2EmpName(row["EmpID"].ToString()));
                listItem.SubItems.Add(row["EmpID"].ToString());
                lstStaffs.Items.Add(listItem);
            }
            lstStaffs.EndUpdate();
        }
        private void dgvloadEquips(String sql, String table)
        {


            dbcEquips = new DBConnector(sql, table);
            //Console.WriteLine(dbcEquips.getDT().Columns.Add(comboBoxColumn));
            bsEquip.DataSource = dbcEquips.getDT();
            dgvEquips.DataSource = bsEquip;

            //dgEquip.ReadOnly = true;
            //dgEquip.MultiSelect = true;
            dgvEquips.Columns["EquipID"].Visible = false;
            dgvEquips.Columns["EquipTypeID"].Visible = false;
            dgvEquips.Columns["RoomID"].Visible = false;
            dgvEquips.Columns["EmpID"].Visible = false;
            dgvEquips.Columns["EquipDetails"].Visible = false;
            //dgvEquips.Columns["EquipDetails"].Width = 200;
            //dgvEquips.Columns["EquipDetails"].HeaderText = "EquipDetails";
            dgvEquips.Columns["OrderByEmpID"].Visible = false;
            dgvEquips.Columns["EquipStatus"].Visible = false;
            dgvEquips.Columns["EquipStatusID"].Visible = false;
            dgvEquips.Columns["BuildID"].Visible = false;
            dgvEquips.Columns["ModifiedDate"].Visible = false;
            dgvEquips.Columns["BuildNameShort"].Visible = false;
            dgvEquips.Columns["EquipNote"].Visible = false;
            dgvEquips.Columns["str"].Visible = false;
            dgvEquips.Columns["p1"].Visible = false;
            dgvEquips.Columns["p2"].Visible = false;
            dgvEquips.Columns["p3"].Visible = false;
            dgvEquips.Columns["p4"].Visible = false;
            dgvEquips.Columns["p5"].Visible = false;
            dgvEquips.Columns["p6"].Visible = false;
            dgvEquips.Columns["ESN"].Width = 200;

        }
        private void clearStaffs()
        {
            lstStaffs.Items.Clear();
            labelStaff.Text = "";
        }
        private void lstBuildings_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(lstBuildings.SelectedItems[0].SubItems[1].Text);
            BuildNameShort = lstBuildings.SelectedItems[0].SubItems[0].Text;
            labelBuilding.Text = BuildNameShort;
            BuildID = lstBuildings.SelectedItems[0].SubItems[1].Text;
            RoomID = "0";
            EmpID = "0";
            EquipID = "0";
            labelRoom.Text = "";
            loadlstRooms();
            clearStaffs();
            //String sql = @"SELECT * from Operations_Equipment2 WHERE BuildID = " + BuildID +
            //    " AND RoomNumber IS NULL";
            String sql = @sqlBase +
                " WHERE BuildID = " + BuildID +
                //" AND RoomNumber IS NULL";
                " AND RoomID IS NULL";
            //Console.WriteLine(sql);
            dgvloadEquips(sql, "Operations_Equipment2");
            labelEquip.Text = "Equipments belong to Building";
            loadDocuments(lstBuildings.SelectedItems[0].SubItems[1].Text, "buildings");
            txtITEquipNotes.Text = "";
            dgvEquips.ClearSelection();
            //Console.WriteLine("global test: " + BuildID + RoomID + EmpID + EquipID);
        }
        private void lstBuildings_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ListViewItem building = lstBuildings.GetItemAt(e.X, e.Y);
                if (building != null)
                {
                    building.Selected = true;
                    contextMenuStrip4.Show(lstBuildings, e.Location);
                }
            }
        }
        private void lstRooms_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(lstRooms.SelectedItems[0].SubItems[0].Text);
            //BuildID = lstBuildings.SelectedItems[0].SubItems[1].Text;
            RoomID = lstRooms.SelectedItems[0].SubItems[1].Text;
            EmpID = "0";
            EquipID = "0";
            RoomNumber = InfoLoader.roomID2RoomNumber(lstRooms.SelectedItems[0].SubItems[1].Text);
            labelRoom.Text = RoomNumber;
            labelStaff.Text = "";
            loadStaffs();
            //String sql = @"SELECT * from Operations_Equipment2 WHERE BuildID = " + BuildID +
            //    " AND RoomNumber = '" + RoomNumber + "'";
            String sql = @sqlBase +
                " WHERE BuildID = " + BuildID +
                " AND RoomID = '" + InfoLoader.roomNumber2RoomID(BuildID, RoomNumber) + "' AND EmpID is null";
            //Console.WriteLine(sql2);
            dgvloadEquips(sql, "Operations_Equipment2");
            labelEquip.Text = "Equipments belong to Room";
            txtITEquipNotes.Text = "";
            loadDocuments(lstRooms.SelectedItems[0].SubItems[1].Text, "rooms");
            dgvEquips.ClearSelection();
            //Console.WriteLine("global test: " + BuildID + RoomID + EmpID + EquipID);
        }
        private void lstRooms_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ListViewItem equip = lstRooms.GetItemAt(e.X, e.Y);
                if (equip != null)
                {
                    equip.Selected = true;
                    contextMenuStrip3.Show(lstRooms, e.Location);
                }
            }
        }
        private void lstStaffs_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //BuildID = lstBuildings.SelectedItems[0].SubItems[1].Text;
            //RoomID = "0";
            //EmpID = "0";
            EquipID = "0";
            lstStaffs.AllowDrop = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ListViewItem staff = lstStaffs.GetItemAt(e.X, e.Y);
                //Console.WriteLine(e.X.ToString(), " ", e.Y.ToString());
                if (staff != null)
                {
                    lstStaffs.DoDragDrop(staff.SubItems[1].Text, DragDropEffects.Copy |
                        DragDropEffects.Move);
                    if (isDraged)
                    {
                        isDraged = false;
                    }
                    else
                    {
                        EmpName = staff.SubItems[0].Text;
                        labelStaff.Text = EmpName;
                        EmpID = staff.SubItems[1].Text;
                        //String sql = @"SELECT * from Operations_Equipment2 WHERE EmpID = " + EmpID;
                        String sql = @sqlBase +
                        " WHERE EmpID = " + EmpID;

                        dgvloadEquips(sql, "Operations_Equipment2");
                        loadDocuments(EmpID, "employees");
                    }
                }
                labelEquip.Text = "Equipments belong to Staff";
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ListViewItem equip = lstStaffs.GetItemAt(e.X, e.Y);
                if (equip != null)
                {
                    equip.Selected = true;
                    contextMenuStrip2.Show(lstStaffs, e.Location);
                }
            }
            txtITEquipNotes.Text = "";
            dgvEquips.ClearSelection();
            //Console.WriteLine("global test: " + BuildID + RoomID + EmpID + EquipID);
        }
        private void dgvEquips_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            lstStaffs.AllowDrop = true;
            isEquip = true;
            //Console.Write("editing" + editing);
            if (!editing)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
                {
                    DataGridView.HitTestInfo hit = dgvEquips.HitTest(e.X, e.Y);
                    //Console.WriteLine(hit.ToString());
                    //Console.WriteLine(hit.ColumnIndex);
                    if (hit.ColumnIndex > -1 && hit.RowIndex > -1)
                    {


                        EquipID = dgvEquips[0, hit.RowIndex].Value.ToString();
                        EmpID = "0";
                        txtITEquipNotes.Text = dgvEquips[11, hit.RowIndex].Value.ToString();
                        loadDocuments(dgvEquips[0, hit.RowIndex].Value.ToString(), "equipments_it");

                        dgvEquips.DoDragDrop(dgvEquips[0, hit.RowIndex].Value.ToString(), DragDropEffects.Copy |
                        DragDropEffects.Move);
                    }
                }
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                //ListViewItem equip = lstEquips.GetItemAt(e.X, e.Y);
                //if (equip != null)
                //{
                //equip.Selected = true;
                //    contextMenuStrip1.Show(lstEquips, e.Location);
                //}
                DataGridView.HitTestInfo hit = dgvEquips.HitTest(e.X, e.Y);
                //Console.WriteLine(hit.ToString());
                if (hit.ColumnIndex > -1 && hit.RowIndex > -1)
                {

                    dgvEquips.CurrentCell = dgvEquips[hit.ColumnIndex, hit.RowIndex];
                    contextMenuStrip1.Show(dgvEquips, e.Location);
                }
            }
            //Console.WriteLine("global test: " + BuildID + RoomID + EmpID + EquipID);
        }
        private void lstDocs_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ListViewItem doc = lstDocs.GetItemAt(e.X, e.Y);
                if (doc != null)
                {
                    viewDocumentToolStripMenuItem.Visible = true;
                    deleteDocumentToolStripMenuItem.Visible = true;
                    doc.Selected = true;
                    contextMenuStrip5.Show(lstDocs, e.Location);
                }
                else
                {
                    viewDocumentToolStripMenuItem.Visible = false;
                    deleteDocumentToolStripMenuItem.Visible = false;
                    contextMenuStrip5.Show(lstDocs, e.Location);
                }
            }
        }
        private void lstBuildings_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            var pos = lstBuildings.PointToClient(new Point(e.X, e.Y));
            var hit = lstBuildings.HitTest(pos);
            if (hit.Item != null)
            {
                String sql = @" UPDATE Operations_Equipment2 SET EmpID = NULL " +
                         ", RoomID =  NULL" +
                         ", BuildID = " + "'" + (string)hit.Item.SubItems[1].Text + "'" +
                         ", BuildNameShort = " + "'" + (string)hit.Item.SubItems[0].Text + "'" +
                          " WHERE EquipID = " + e.Data.GetData(DataFormats.Text).ToString();
                //Console.WriteLine(sql);
                new DBConnector(sql, "Operations_Equipment2");
                checkLabelEquip();
            }
        }
        private void lstRooms_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            var pos = lstRooms.PointToClient(new Point(e.X, e.Y));
            var hit = lstRooms.HitTest(pos);
            if (hit.Item != null)
            {
                if (isEquip)
                {
                    //Console.WriteLine((string)hit.Item.SubItems[0].Text);
                    String sql = @" UPDATE Operations_Equipment2 SET EmpID = NULL " +
                             ", RoomID =  " + "'" + InfoLoader.roomNumber2RoomID(BuildID, (string)hit.Item.SubItems[0].Text) + "'" +
                             ", BuildID = " + "'" + BuildID + "'" +
                             ", BuildNameShort = " + "'" + BuildNameShort + "'" +
                              " WHERE EquipID = " + e.Data.GetData(DataFormats.Text).ToString();
                    //Console.WriteLine(sql);
                    new DBConnector(sql, "Operations_Equipment2");
                    checkLabelEquip();
                }
                else
                {

                    String sql = @" UPDATE Operations_Rooms_Employees2 SET RoomID = " + "'" + InfoLoader.roomNumber2RoomID(BuildID, (string)hit.Item.SubItems[0].Text) + "'" +
                                  ", BuildID = " + BuildID +
                                  ", RoomNumber = " + "'" + (string)hit.Item.SubItems[0].Text + "'" +
                                   " WHERE EmpID = " + e.Data.GetData(DataFormats.Text).ToString();
                    //Console.WriteLine(sql);
                    new DBConnector(sql, "Operations_Rooms_Employees2");
                    loadStaffs();
                    isDraged = true;
                    if (isBuildingChanged)
                    {
                        clearStaffs();
                    }
                }
            }
            isEquip = false;
        }
        private void lstStaffs_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            var pos = lstStaffs.PointToClient(new Point(e.X, e.Y));
            var hit = lstStaffs.HitTest(pos);
            //Console.WriteLine(e.Data.GetData(DataFormats.Text).ToString());
            if (hit.Item != null)
            {

                String sql = @" UPDATE Operations_Equipment2 SET EmpID = " + (string)hit.Item.SubItems[1].Text +
                              ", RoomID = NULL, BuildID = NULL, BuildNameShort = NULL" +
                               " WHERE EquipID = " + e.Data.GetData(DataFormats.Text).ToString();
                //Console.WriteLine(sql);
                new DBConnector(sql, "Operations_Equipment2");
                checkLabelEquip();
            }
            isEquip = false;

        }
        private void lstDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            //Console.WriteLine("e.effect: " + e.Effect);
        }
        private void lstDragOver(object sender, DragEventArgs e)
        {
            ListView ctrl = (ListView)sender;
            var pos = ctrl.PointToClient(new Point(e.X, e.Y));
            var hit = ctrl.HitTest(pos);

            if (hit.Item != null && coordinate != pos)
            {
                coordinate = pos;
                ctrl.Select();
                ctrl.SelectedItems.Clear();
                hit.Item.Selected = true;
            }
            if (ctrl == lstBuildings)
            {
                if (hit.Item != null)
                {
                    if (previousItem != hit.Item)
                    {
                        stopwatch.Reset();
                        isBuildingChanged = false;
                    }
                    else
                    {
                        stopwatch.Start();
                    }

                    //Console.WriteLine(stopwatch.ElapsedMilliseconds);
                    if (stopwatch.ElapsedMilliseconds > 1500 && stopwatch.ElapsedMilliseconds < 1600)
                    {
                        //Console.WriteLine("refreshhhhhhhh");
                        isBuildingChanged = true;
                        lstBuildings_Click(sender, e);
                    }
                }
                previousItem = hit.Item;
            }
            if (ctrl == lstRooms)
            {
                if (hit.Item != null)
                {
                    if (previousItem != hit.Item)
                    {
                        stopwatch.Reset();
                        isRoomChanged = false;
                    }
                    else
                    {
                        stopwatch.Start();
                    }

                    //Console.WriteLine(stopwatch.ElapsedMilliseconds);
                    if (stopwatch.ElapsedMilliseconds > 1500 && stopwatch.ElapsedMilliseconds < 1600)
                    {
                        //Console.WriteLine("refreshhhhhhhh");
                        isRoomChanged = true;
                        lstRooms_Click(sender, e);
                    }
                }
                previousItem = hit.Item;
            }
        }
        private void checkLabelEquip()
        {
            String sql = "";
            if (labelEquip.Text == "Equipments belong to Building")
            {
                //   sql = @"SELECT * from Operations_Equipment2 WHERE BuildID = " + BuildID +
                //" AND RoomNumber IS NULL"; 
                sql = @sqlBase +
                " WHERE BuildID = " + BuildID +
                " AND RoomID IS NULL";
                dgvloadEquips(sql, "Operations_Equipment2");
            }
            if (labelEquip.Text == "Equipments belong to Room")
            {
                //  sql = @"SELECT * from Operations_Equipment2 WHERE BuildID = " + BuildID +
                //" AND RoomNumber = '" + RoomNumber + "'"; 
                sql = @sqlBase +
                " WHERE BuildID = " + BuildID +
                " AND RoomID = '" + InfoLoader.roomNumber2RoomID(BuildID, RoomNumber) + "'" +
                " AND EmpID IS NULL";
                //Console.WriteLine(sql);
                dgvloadEquips(sql, "Operations_Equipment2");

            }
            if (labelEquip.Text == "Equipments belong to Staff")
            {
                //sql = @"SELECT * from Operations_Equipment2 WHERE EmpID = " + EmpID;
                sql = @sqlBase +
                " WHERE EmpID = " + lstStaffs.SelectedItems[0].SubItems[1].Text;
                //Console.WriteLine(lstStaffs.SelectedItems[0].SubItems[1].Text);
                labelStaff.Text = lstStaffs.SelectedItems[0].SubItems[0].Text;
                dgvloadEquips(sql, "Operations_Equipment2");
            }
            //Console.WriteLine(sql);
        }
        private void ContextMenuStripItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == deleteMenuItem)
            {
                //int rowindex = dgvEquips.CurrentCell.RowIndex;
                //int columnindex= = dgvEquips.CurrentCell.ColumnIndex
                //dgvEquips.Rows[rowindex].Cells[columnindex].Value.ToString();
                //DataGridViewCell cell = dgvEquips.Rows[dgvEquips.CurrentCell.RowIndex].Cells[0];
                //Console.WriteLine(dgvEquips.Rows[dgvEquips.CurrentCell.RowIndex].Cells[0].Value.ToString());
                //Console.WriteLine(dgvEquips.Rows[dgvEquips.CurrentCell.RowIndex].Cells[1].Value.ToString());
                //Console.WriteLine(dgvEquips.Rows[dgvEquips.CurrentCell.RowIndex].Cells[4].Value.ToString());
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this equipment:\n"
                    + dgvEquips.Rows[dgvEquips.CurrentCell.RowIndex].Cells[4].Value.ToString(), "Delete Equipment", MessageBoxButtons.YesNo);

                String sql;
                if (dialogResult == DialogResult.Yes)
                {
                    sql = @" DELETE FROM Operations_Equipment2 " +
                                  " WHERE EquipID = " + dgvEquips.Rows[dgvEquips.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    //Console.WriteLine(sql);
                    new DBConnector(sql, "Operations_Equipment2");
                    checkLabelEquip();
                }
                else if (dialogResult == DialogResult.No)
                {
                }
                //Console.WriteLine(lstEquips.SelectedItems[0].SubItems[1].Text);
                //record time, db, analyst, time category, note, alarm, customize category, focus mode,
            }
            if (e.ClickedItem == editMenuItem)
            {
                dgvEquips.ReadOnly = false;
                DataGridViewCell cell = dgvEquips.Rows[dgvEquips.CurrentCell.RowIndex].Cells[dgvEquips.CurrentCell.ColumnIndex];
                dgvEquips.CurrentCell = cell;
                dgvEquips.BeginEdit(true);
                editing = true;
            }
            if (e.ClickedItem == viewDocumentToolStripMenuItem)
            {
                ListViewItem selectedDoc = lstDocs.SelectedItems[0];
                String _docName = selectedDoc.SubItems[0].Text;
                String _subPath = selectedDoc.SubItems[1].Text;
                //_delDocParam = _EquipID + "|" + _docName + "|" + _subPath;

                String defaultFilePath = "\\\\130.212.36.153\\share\\chhs\\administrative\\partners\\PECS_docs\\Operations\\";
                String path = defaultFilePath + _subPath + _docName;

                //Console.WriteLine("\n 2994 lvITEquipDocs_DoubleClick [{0}]\t[{1}]\n[{2}]\t\n", _docName, _subPath, path);

                if (path.Length > 0)
                {
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    MessageBox.Show("The specified document was not found. Please consult system administator.");
                    return;
                }
            }
            if (e.ClickedItem == uploadDocumentToolStripMenuItem)
            {
                docUpload(sender, e);
            }
            if (e.ClickedItem == deleteDocumentToolStripMenuItem)
            {

                String[] arDelDocParam = new String[] { "", "", "" };
                arDelDocParam[0] = lstDocs.SelectedItems[0].SubItems[2].Text;
                arDelDocParam[1] = lstDocs.SelectedItems[0].SubItems[0].Text;
                arDelDocParam[2] = lstDocs.SelectedItems[0].SubItems[1].Text;
                deleteDocument(arDelDocParam);
            }
        }

        private void dgvEquips_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updatedgvEquips(e);
            editing = false;
            //dgvEquips.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquips.ReadOnly = true;

        }
        private void updatedgvEquips(DataGridViewCellEventArgs e)
        {
            DataRow row = dbcEquips.getDT().Rows[e.RowIndex];
            try
            {

                row.BeginEdit();
                row.EndEdit();
                row["EquipDetails"] = row["EquipName"] + "|" + row["Make"] + "|" + row["Model"] + "|" + row["Serial"] + "|" + row["assetTage"] + "|" + row["ESN"] + "|";
                //Console.WriteLine(row.ToString()); 
                //Console.WriteLine(row.Table.Columns[0].ToString());

                SqlCommandBuilder commBuilder = new SqlCommandBuilder(dbcEquips.getDA());
                //Console.WriteLine(dbcEquips.getDA());
                //Console.WriteLine(commBuilder);
                //dbcEquips.getDS().Tables[0].Columns[4]. = dbcEquips.getDS().Tables[0].Columns[19];
                //dbcEquips.getDS().Tables[0].Columns.Remove("p1");
                //dbcEquips.getDS().Tables[0].Columns.Remove("p2");
                //dbcEquips.getDS().Tables[0].Columns.Remove("p3");
                //dbcEquips.getDS().Tables[0].Columns.Remove("p4");
                //dbcEquips.getDS().Tables[0].Columns.Remove("p5");
                //dbcEquips.getDS().Tables[0].Columns.Remove("p6");

                dbcEquips.getDA().Update(dbcEquips.getDS().Tables[0]);


            }
            catch (Exception ex)
            {


            }

        }
        private void txtITEquipNotes_LostFocus(object sender, System.EventArgs e)
        {

            //DialogResult dialogResult = MessageBox.Show("Changed, do you want to save?" + dgvEquips.CurrentRow.ToString(), "Edit Memo", MessageBoxButtons.YesNo);
            //Console.WriteLine(dgvEquips.CurrentCell.RowIndex);
            //Console.WriteLine(dgvEquips[0, dgvEquips.CurrentCell.RowIndex].Value.ToString());
            String sql = @"UPDATE Operations_Equipment2 SET EquipNote = " + "'" + txtITEquipNotes.Text + "'" +
                " WHERE EquipID = " + dgvEquips[0, dgvEquips.CurrentCell.RowIndex].Value.ToString();
            //Console.WriteLine(sql);
            new DBConnector(sql, "Operations_Equipment2");
            //sql = @sqlBase +
            //" WHERE EmpID = " + EmpID;
            //dgvloadEquips(sql, "Operations_Equipment2");
            checkLabelEquip();
        }
        private void loadDocuments(String ID, String _DocType)
        {
            String _sql = @"SELECT DocID
                                ,BuildID
                                ,RoomID
                                ,EmpID
                                ,EquipID
                                ,DocType
                                ,DocSubPath
                                ,DocName
                                ,LastModified   
                            FROM Operations_Docs 
                            WHERE DocType = '" + _DocType + "'"
                            ;
            if (_DocType == "buildings")
            {
                _sql += " AND  BuildID = " + ID +
                     " AND  RoomID = 0 " +
                     " AND  EmpID = 0 " +
                     " AND  EquipID = 0 ";
            }
            if (_DocType == "rooms")
            {
                _sql += //" AND  BuildID = 0 " +
                    " AND  RoomID = " + ID +
                    " AND  EmpID = 0 " +
                    " AND  EquipID = 0 ";
            }
            if (_DocType == "employees")
            {
                _sql += //" AND  BuildID = 0" + 
                    //" AND  RoomID = 0 " +
                    " AND  EmpID = " + ID +
                    " AND  EquipID = 0 ";
            }
            if (_DocType == "equipments_it")
            {
                _sql += //" AND  BuildID = 0 " + 
                    // " AND  RoomID = 0 " +
                    // " AND  EmpID = 0 " +
                    " AND  EquipID = " + ID;
            }


            DBConnector dbcOpeDoc = new DBConnector(_sql, "OpeDocs");
            //Console.WriteLine(_sql);
            lstDocs.BeginUpdate();
            lstDocs.Clear();
            lstDocs.Columns.Add("DocName", 200, HorizontalAlignment.Left);
            lstDocs.Columns.Add("DocSubPath", 200, HorizontalAlignment.Left);

            DataTable eaDT = dbcOpeDoc.getDT();
            foreach (DataRow row in eaDT.Rows)
            {
                //Console.WriteLine(row["DocName"].ToString(), row["DocSubPath"].ToString());
                ListViewItem listItem = new ListViewItem(row["DocName"].ToString());
                listItem.SubItems.Add(row["DocSubPath"].ToString());
                listItem.SubItems.Add(row["DocID"].ToString());
                lstDocs.Items.Add(listItem);
            }
            lstDocs.EndUpdate();
        }

        private void loadDocuments()
        {
            String _DocType = "";
            if (EmpID.Equals("0") && EquipID.Equals("0") && RoomID.Equals("0"))
            {
                _DocType = "buildings";

            }
            else if (EmpID.Equals("0") && EquipID.Equals("0"))
            {
                _DocType = "rooms";

            }
            else if (EquipID.Equals("0"))
            {
                _DocType = "employees";

            }
            else if (EmpID.Equals("0"))
            {
                _DocType = "equipments_it";

            }
            else
            {
                _DocType = "buildings";

            }
            String _sql = @"SELECT DocID
                                ,BuildID
                                ,RoomID
                                ,EmpID
                                ,EquipID
                                ,DocType
                                ,DocSubPath
                                ,DocName
                                ,LastModified   
                            FROM Operations_Docs 
                            WHERE DocType = '" + _DocType + "'"
                            ;
            if (_DocType == "buildings")
            {
                _sql += " AND  BuildID = " + BuildID +
                     " AND  RoomID = 0 " +
                     " AND  EmpID = 0 " +
                     " AND  EquipID = 0 ";
            }
            if (_DocType == "rooms")
            {
                _sql += //" AND  BuildID = 0 " +
                    " AND  RoomID = " + RoomID +
                    " AND  EmpID = 0 " +
                    " AND  EquipID = 0 ";
            }
            if (_DocType == "employees")
            {
                _sql += //" AND  BuildID = 0" + 
                    //" AND  RoomID = 0 " +
                    " AND  EmpID = " + EmpID +
                    " AND  EquipID = 0 ";
            }
            if (_DocType == "equipments_it")
            {
                _sql += //" AND  BuildID = 0 " + 
                    // " AND  RoomID = 0 " +
                    // " AND  EmpID = 0 " +
                    " AND  EquipID = " + EquipID;
            }


            DBConnector dbcOpeDoc = new DBConnector(_sql, "OpeDocs");
            //Console.WriteLine(_sql);
            lstDocs.BeginUpdate();
            lstDocs.Clear();
            lstDocs.Columns.Add("DocName", 200, HorizontalAlignment.Left);
            lstDocs.Columns.Add("DocSubPath", 200, HorizontalAlignment.Left);

            DataTable eaDT = dbcOpeDoc.getDT();
            foreach (DataRow row in eaDT.Rows)
            {
                //Console.WriteLine(row["DocName"].ToString(), row["DocSubPath"].ToString());
                ListViewItem listItem = new ListViewItem(row["DocName"].ToString());
                listItem.SubItems.Add(row["DocSubPath"].ToString());
                listItem.SubItems.Add(row["DocID"].ToString());
                lstDocs.Items.Add(listItem);
            }
            lstDocs.EndUpdate();
        }
        private void lstDocs_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedDoc = ((ListView)sender).SelectedItems[0];
            // String _EquipID = selectedDoc.SubItems[1].Text;
            String _docName = selectedDoc.SubItems[0].Text;
            String _subPath = selectedDoc.SubItems[1].Text;
            //_delDocParam = _EquipID + "|" + _docName + "|" + _subPath;

            String defaultFilePath = "\\\\130.212.36.153\\share\\chhs\\administrative\\partners\\PECS_docs\\Operations\\";
            String path = defaultFilePath + _subPath + _docName;

            //Console.WriteLine("\n 2994 lvITEquipDocs_DoubleClick [{0}]\t[{1}]\n[{2}]\t\n", _docName, _subPath, path);

            if (path.Length > 0)
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                MessageBox.Show("The specified document was not found. Please consult system administator.");
                return;
            }
        }
        private void docUpload(object sender, EventArgs e)
        {
            //defaultFilePath = "C:\\tmp_pecs\\"
            // _subPath: Operatons\\ -> input_files\\, documents\\ : [buildings\\ equipments_it\\ equipments_op\\ rooms\\ employees\\]
            String _subPath = "";
            String _fileName = "";
            if (EmpID.Equals("0") && EquipID.Equals("0") && RoomID.Equals("0"))
            {
                _subPath = "documents\\buildings\\";
                _fileName = CopyDocTo(_subPath);
                if (_fileName.Length > 0)
                {

                    addAttachedDocToDB(_subPath, _fileName);
                    loadDocuments(BuildID, "buildings");
                }
            }
            else if (EmpID.Equals("0") && EquipID.Equals("0"))
            {
                _subPath = "documents\\rooms\\";
                _fileName = CopyDocTo(_subPath);
                if (_fileName.Length > 0)
                {

                    addAttachedDocToDB(_subPath, _fileName);
                    loadDocuments(RoomID, "rooms");
                }
            }
            else if (EquipID.Equals("0"))
            {
                _subPath = "documents\\employees\\";
                _fileName = CopyDocTo(_subPath);
                if (_fileName.Length > 0)
                {

                    addAttachedDocToDB(_subPath, _fileName);
                    loadDocuments(EmpID, "employees");
                }
            }
            else if (EmpID.Equals("0"))
            {
                _subPath = "documents\\equipments_it\\";
                _fileName = CopyDocTo(_subPath);
                if (_fileName.Length > 0)
                {

                    addAttachedDocToDB(_subPath, _fileName);
                    loadDocuments(EquipID, "equipments_it");
                }
            }
            else
            {
                _subPath = "documents\\buildings\\";
                _fileName = CopyDocTo(_subPath);
                if (_fileName.Length > 0)
                {

                    addAttachedDocToDB(_subPath, _fileName);
                    loadDocuments(BuildID, "buildings");
                }
            }
            //CopyDocTo(String _subPath)


        }
        private String CopyDocTo(String _subPath)
        {
            String _ret = "";
            // Variables.defaultFilePath
            String defaultFilePath = "\\\\130.212.36.153\\share\\chhs\\administrative\\partners\\PECS_docs\\Operations\\";
            // _subPath: input_files\\, documents\\ : [buildings\\ equipments_it\\ equipments_op\\ rooms\\ staffs_faculties\\]

            //defaultFilePath = "C:\\tmp_pecs\\Operations\\";

            String fileToMove = UtilityDialogs.openFileDialog();
            if (fileToMove.Trim().Length == 0)
            {
                MessageBox.Show("No file was selected for attachment");
                return _ret;
            }

            String fileExt = Path.GetExtension(fileToMove);
            //This creates a unique date/time identifier so that files with multiple names will not overwrite
            String dateFileName = UtilityDates.makeDateFilename();
            String FileName = Path.GetFileNameWithoutExtension(fileToMove) + "." + dateFileName + fileExt;
            //String newPath = Variables.defaultFilePath +
            String newPath = defaultFilePath + _subPath + FileName;

            //Console.WriteLine("\n ** CopyDocTo [{0}]\t[{1}]\t[{2}]\t[{3}]\t[{4}]\t\n", _subPath, defaultFilePath + _subPath, fileToMove, newPath, dateFileName);

            File.Copy(fileToMove, newPath);
            //addAttachedDocToDB(Path.GetFileNameWithoutExtension(fileToMove), dateFileName + fileExt);
            //loadLstDocs();
            return _ret = FileName;

        }
        private void addAttachedDocToDB(String subPath, String fileName) //from Ope2
        {
            /*
                         int _buildid = int.Parse(dicIDsCtl["BuildID"]);
            int _roomid = int.Parse(dicIDsCtl["RoomID"]);
            int _empid = int.Parse(dicIDsCtl["EmpID"]);
            int _equipid = int.Parse(dicIDsCtl["EquipID"]);
             */

            String _DocType = subPath.Split('\\')[1];

            //String _DocSubPath = "Buildings";
            //[IDSetCtl] BuildingID, RoomID, EmpID, EquipID, EmpRoomID
            //int[] arIDsetCtl = { 0, 0, 0, 0, 0 };
            //
            // _DocType: buildings, rooms, employees, equipments_it, equipments_op
            //if (_DocType.Contains("buildings"))
            //{
            //    _buildid = (dicIDsCtl["BuildID"] == null) ? 0 : int.Parse(dicIDsCtl["BuildID"]);
            //    int[] arIDsetCtl = { _buildid, 0, 0, 0, 0 };
            //}
            //else if (_DocType.Contains("rooms"))
            //{
            //    _buildid = (dicIDsCtl["BuildID"] == null) ? 0 : int.Parse(dicIDsCtl["BuildID"]);
            //    _roomid = (dicIDsCtl["RoomID"] == null) ? 0 : int.Parse(dicIDsCtl["RoomID"]);
            //    int[] arIDsetCtl = { _buildid, _roomid, 0, 0, 0 };
            //}
            //else if (_DocType.Contains("employees"))
            //{
            //    _buildid = (dicIDsCtl["BuildID"] == null) ? 0 : int.Parse(dicIDsCtl["BuildID"]);
            //    _roomid = (dicIDsCtl["RoomID"] == null) ? 0 : int.Parse(dicIDsCtl["RoomID"]);
            //    _empid = (dicIDsCtl["EmpID"] == null) ? 0 : int.Parse(dicIDsCtl["EmpID"]);
            //    _emproomid = (dicIDsCtl["EmpRoomID"] == null) ? 0 : int.Parse(dicIDsCtl["EmpRoomID"]);
            //    int[] arIDsetCtl = { _buildid, _roomid, _empid, 0, _emproomid };
            //}
            //else if (_DocType.Contains("equipments_it"))
            //{
            //    _buildid = (dicIDsCtl["BuildID"] == null) ? 0 : int.Parse(dicIDsCtl["BuildID"]);
            //    _roomid = (dicIDsCtl["RoomID"] == null) ? 0 : int.Parse(dicIDsCtl["RoomID"]);
            //    _empid = (dicIDsCtl["EmpID"] == null) ? 0 : int.Parse(dicIDsCtl["EmpID"]);
            //    _equipid = (dicIDsCtl["EquipID"] == null) ? 0 : int.Parse(dicIDsCtl["EquipID"]);
            //    _emproomid = (dicIDsCtl["EmpRoomID"] == null) ? 0 : int.Parse(dicIDsCtl["EmpRoomID"]);
            //    int[] arIDsetCtl = { _buildid, _roomid, _empid, _equipid, _emproomid };
            //}
            //else if (_DocType.Contains("equipments_op"))
            //{
            //}
            //else
            //{

            //}

            DBConnector dbcInsDoc = new DBConnector("SELECT * FROM Operations_Docs", "insDocs");

            String sql = @"INSERT INTO Operations_Docs  (BuildID, RoomID, EmpID, EquipID, DocType , DocSubPath , DocName )
                          VALUES (" + BuildID + "," + RoomID + "," + EmpID + "," + EquipID
                                    + ",'" + _DocType + "', '" + subPath + "', '" + fileName + "')";
            //Console.WriteLine("\n 2877 addAttachedDocToDB\t [{0}]\t[{1}]\t[{2}]\t\n", sql, subPath, fileName);

            int numb = 0;
            numb = dbcInsDoc.executeSQL(sql);

            String msg = "New " + fileName;
            if (numb > 0)
            {
                msg += " [OK] ";
            }
            else
            {
                msg += " [FAIL]";
            }
            //Ope2.InsertLogs (String[] _arIDsetCtl, String _ActionType, String _OnTable, String _Message)

            //Ope2.InsertLogs(IDSetCtl, "INSERT", "Operations_Docs", msg);


        }
        private void deleteDocument(String[] arDelDocParam)
        {


            if (int.Parse(arDelDocParam[0]) > 0)
            {
                DialogResult result = UtilityDialogs.askYesNo("Are you sure you want to delete this attachment?\n  - " + arDelDocParam[2] + "\\" + arDelDocParam[1], "WARNING");

                if (result == DialogResult.No)
                {
                    //do not overwrite data. Exit this process.
                    return;
                }
                else
                {
                    removeAttachment(arDelDocParam);

                }
            }


            // NEED load equip tab ???
            loadDocuments();
            // LOGS

        }
        private String removeAttachment(String[] arDelDocParam) //from Ope2
        {
            //cmdITEquipDelDoc
            // ??????????
            // should UPDATE DocType => DELETE
            // and move to BACKUP folder
            // Record in log
            //String _sql = "DELETE FROM Operations_Docs WHERE ID = " + _EquipID;
            String _ret = "0";
            String defaultFilePath = "\\\\130.212.36.153\\share\\chhs\\administrative\\partners\\PECS_docs\\Operations\\";
            //defaultFilePath = "C:\\tmp_pecs\\Operations\\";

            //String fileToMove = defaultFilePath + "documents\\" + arDelDocParam[2] + "\\" + arDelDocParam[1];
            String fileToMove = defaultFilePath + arDelDocParam[2] + arDelDocParam[1];
            String fileExt = Path.GetExtension(fileToMove);
            String dateFileName = UtilityDates.makeDateFilename();
            String FileName = Path.GetFileNameWithoutExtension(fileToMove) + "." + dateFileName + fileExt;
            String newDirectory = arDelDocParam[2].Replace("documents", "backup");
            String newPath = defaultFilePath + newDirectory + FileName;

            // Move delete file to backup directory
            File.Move(fileToMove, newPath);
            // Update table Operations_Docs? should DELETE
            DBConnector dbcDelDocs = new DBConnector("SELECT * FROM Operations_Docs", "insDocs");
            String _updSql = "UPDATE Operations_Docs SET DocType = 'DELETE' WHERE DocID = " + arDelDocParam[0];
            String _delSql = "DELETE FROM Operations_Docs WHERE DocID = " + arDelDocParam[0];

            //Console.WriteLine("\n 514 deleteAttachment [{0}]\t[{1}]\t[{2}]\t\t[{3}]\n", _delSql, _updSql, fileToMove, newPath);
            // Delete file
            int _status = 0;
            if (arDelDocParam[0].Length > 0)
            {
                //_status = dbcDelDocs.executeSQL(_updSql);
                _status = dbcDelDocs.executeSQL(_delSql);

                // Add to activity Log 
                String[] arIDAssign = { "0", "0", "0", arDelDocParam[0], "0" };
                String msg = " - Document: " + FileName;
                //InsertLogs(arIDAssign, "DELETE", "Operations_Docs", msg);
            }


            return _ret = _status.ToString();
            //return _ret;
        }
        private void getOpeNewEquip(object sender, EventArgs e)
        {
            //String selectedCmdButton = ((Button)sender).Name.ToString();
            //String wokingTab = "";
            //String ItemVal = "";

            frmOpeNewEquip2 = new frmOperationsNewEquipment2();
            frmOpeNewEquip2.Show();
            frmOpeNewEquip2.Activate();

        }
        private void getOpeNewAssign(object sender, EventArgs e)
        {
            //String selectedCmdButton = ((Button)sender).Name.ToString();
            //String wokingTab = "";
            //String ItemVal = "";

            frmOpeNewAssign2 = new frmOperationsNewAssign2();
            frmOpeNewAssign2.Show();
            frmOpeNewAssign2.Activate();

        }

        public void ImportDataFromExcel_temp(string excelFilePath)
        {
            string myexceldataquery = "select student,rollno,course from [Sheet1$]";
            string sexcelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ycao2\Downloads\Book1.xlsx;Extended Properties=" + "\"Excel 12.0 Xml;HDR=NO;IMEX=1;\"";
            string ssqlconnectionstring = "Data Source=130.212.17.139;Initial Catalog=PECS_20151023;Integrated Security=True";
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
            DataTable DT_Excel = new DataTable();
            DataTable DT_DataBase = new DataTable();
            DBConnector DT_DataBaseConn = new DBConnector("SELECT * FROM Table1", "Table1");

            //Console.WriteLine(DBPath.connString.Replace("server", "Data Source").Replace("database", "Initial Catalog"));
            SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
            //SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
            sqlconn.Open();
            //sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            oledbconn.Open();
            OleDbDataReader dr = oledbcmd.ExecuteReader();
            //SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
            //bulkcopy.DestinationTableName = ssqltable;

            DT_Excel.Load(dr);
            DT_DataBase = DT_DataBaseConn.getDT();
            foreach (DataRow dtRow in DT_Excel.Rows)
            {
                //Console.WriteLine(dtRow["student"].ToString());
                //Console.WriteLine(dtRow["rollno"].ToString());
                //Console.WriteLine(dtRow["course"].ToString());
                if (dtRow["student"].ToString().Length != 0)
                {
                    DataRow[] foundRow;
                    foundRow = DT_DataBase.Select("student Like '%" + dtRow["student"].ToString() + "%' AND rollno = " + dtRow["rollno"].ToString());
                    if (foundRow.Length > 0)
                    {
                        //Console.WriteLine("{0},{1},{2}", foundRow[0]["student"].ToString(), foundRow[0]["rollno"].ToString(), foundRow[0]["course"].ToString());
                        if (!(dtRow["course"].ToString().Equals(foundRow[0]["course"].ToString())))
                        {
                            DialogResult dialogResult = MessageBox.Show(@"Record has changed, do you want to update?" + "\n" +
                            "Database:    " + foundRow[0]["student"].ToString() + ", " + foundRow[0]["rollno"].ToString() + ", " + foundRow[0]["course"].ToString() + "\n" +
                            "Excel:    " + dtRow["student"].ToString() + ", " + dtRow["rollno"].ToString() + ", " + dtRow["course"].ToString() + "\n"
                            , "Record changed", MessageBoxButtons.YesNo);
                            String sql;
                            if (dialogResult == DialogResult.Yes)
                            {
                                sql = @"   UPDATE Table1 SET course =  " + "'" + dtRow["course"] + "'" + " WHERE student Like '%" + dtRow["student"].ToString() + "%' AND rollno = " + dtRow["rollno"].ToString();
                                //Console.WriteLine(sql);
                                new DBConnector(sql, "Table1");
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                            }
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show(@"Record does not exist, do you want to add the new record?" + "\n" +
                        "New Record from Excel:   " + dtRow["student"].ToString() + ", " + dtRow["rollno"].ToString() + ", " + dtRow["course"].ToString() + "\n"
                        , "New Record", MessageBoxButtons.YesNo);
                        String sql;
                        if (dialogResult == DialogResult.Yes)
                        {
                            sql = @" INSERT INTO Table1 (Student,rollno,course) " +
                            "VALUES ('" + dtRow["student"].ToString() + "', '" + dtRow["rollno"].ToString() + "', '" + dtRow["course"].ToString() + "')";
                            //Console.WriteLine(sql);
                            new DBConnector(sql, "Table1");
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                        }
                    }
                }
            }
            dr.Close();
            oledbconn.Close();
            MessageBox.Show("File imported into sql server.");


        }

        public void ImportDataFromExcel(string excelFilePath)
        {
            string myexceldataquery = String.Format("select * from [Inventory$A2:G291]");
            string sexcelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";
            //string ssexcelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ycao2\Downloads\Inventory.xlsx;Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";
            string ssqlconnectionstring = DBPath.connString;
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
            DataTable DT_Excel = new DataTable();
            DataTable DT_DataBase = new DataTable();
            DBConnector DT_DataBaseConn = new DBConnector("SELECT * FROM Operations_Rooms3", "Operations_Rooms3");
            SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
            //SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
            sqlconn.Open();
            //sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            oledbconn.Open();
            OleDbDataReader dr = oledbcmd.ExecuteReader();
            //SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
            //bulkcopy.DestinationTableName = ssqltable;
            DT_Excel.Load(dr);
            DT_DataBase = DT_DataBaseConn.getDT();
            //foreach (DataColumn column in DT_Excel.Columns)
            //{
            //    Console.Write("Item: ");  
            //    Console.Write(column.ColumnName);
            //    Console.Write(" ");
            //}
            //foreach (DataRow dataRow in DT_Excel.Rows)
            //{
            //    foreach (var item in dataRow.ItemArray)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            foreach (DataRow excelDtRow in DT_Excel.Rows)
            {
                if (excelDtRow["Room Number"].ToString().Length != 0)
                {
                    DataRow[] DBfoundRow;
                    DBfoundRow = DT_DataBase.Select("BuildID Like '%" + InfoLoader.BuildName2BuildID(excelDtRow["Building"].ToString().Trim()) + "%' AND UnitID Like '%" +
                        excelDtRow["Department"].ToString().Trim() + "%' AND RoomNumber Like '" + excelDtRow["Room Number"].ToString().Trim() + "'");
                    if (DBfoundRow.Length > 0)
                    {

                        if ((!(excelDtRow["Department"].ToString().Trim().Equals(DBfoundRow[0]["UnitID"].ToString().Trim()))) ||
                            (!(excelDtRow["Description"].ToString().Trim().Equals(DBfoundRow[0]["RoomDesc"].ToString().Trim()))) ||
                            (!(excelDtRow["HEGIS"].ToString().Trim().Equals(DBfoundRow[0]["HEGIS"].ToString().Trim()))) ||
                            (!(excelDtRow["Space Type"].ToString().Trim().Equals(DBfoundRow[0]["SpaceType"].ToString().Trim()))) ||
                            (!(excelDtRow["SqFt"].ToString().Trim().Equals(DBfoundRow[0]["RoomSQft"].ToString().Trim())))
                            )
                        {
                            DialogResult dialogResult = MessageBox.Show(@"Record has changed, do you want to update?" + "\n" +
                            "Database:    " +
                            InfoLoader.BuildID2BuildNameShort(DBfoundRow[0]["BuildID"].ToString()) + ", " + DBfoundRow[0]["UnitID"].ToString() + ", " +
                            DBfoundRow[0]["RoomNumber"].ToString() + ", " + DBfoundRow[0]["RoomDesc"].ToString() + ", " +
                            DBfoundRow[0]["HEGIS"].ToString() + ", " + DBfoundRow[0]["SpaceType"].ToString() + ", " +
                            DBfoundRow[0]["RoomSQft"].ToString() + "\n" +
                            "Excel:    " +
                            excelDtRow["Building"].ToString() + ", " + excelDtRow["Department"].ToString() + ", " +
                            excelDtRow["Room Number"].ToString() + ", " + excelDtRow["Description"].ToString() + ", " +
                            excelDtRow["HEGIS"].ToString() + ", " + excelDtRow["Space Type"].ToString() + ", " +
                            excelDtRow["SqFt"].ToString() + "\n"
                            , "Record changed", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                String sql = @"   UPDATE Operations_Rooms3 " +
                                       "SET UnitID =  " + "'" + excelDtRow["Department"] + "'" +
                                       ", RoomDesc =  " + "'" + excelDtRow["Description"] + "'" +
                                       ", HEGIS =  " + "'" + excelDtRow["HEGIS"] + "'" +
                                       ", SpaceType =  " + "'" + excelDtRow["Space Type"] + "'" +
                                       ", RoomSQft =  " + "'" + excelDtRow["SqFt"] + "'" +
                                       " WHERE BuildID Like '%" + InfoLoader.BuildName2BuildID(excelDtRow["Building"].ToString()) + "%' AND UnitID Like '%" +
                                       excelDtRow["Department"].ToString() + "%' AND RoomNumber Like '" + excelDtRow["Room Number"].ToString() + "'";
                                //Console.WriteLine(sql);
                                new DBConnector(sql, "Operations_Rooms3");
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                            }
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show(@"Record does not exist, do you want to add the new record?" + "\n" +
                        "New Record from Excel:    " +
                            excelDtRow["Building"].ToString() + ", " + excelDtRow["Department"].ToString() + ", " +
                            excelDtRow["Room Number"].ToString() + ", " + excelDtRow["Description"].ToString().Replace("'", "''") + ", " +
                            excelDtRow["HEGIS"].ToString() + ", " + excelDtRow["Space Type"].ToString() + ", " +
                            excelDtRow["SqFt"].ToString() + "\n"
                        , "New Record", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            String sql = @" INSERT INTO Operations_Rooms3 (BuildID,UnitID,RoomNumber,RoomDesc,HEGIS,SpaceType,RoomSQft) " +
                            "VALUES ('" +
                            InfoLoader.BuildName2BuildID(excelDtRow["Building"].ToString()) + "', '" + excelDtRow["Department"].ToString() + "', '" +
                            excelDtRow["Room Number"].ToString() + "', '" + excelDtRow["Description"].ToString().Replace("'", "''") + "', '" +
                            excelDtRow["HEGIS"].ToString() + "', '" + excelDtRow["Space Type"].ToString() + "', '" +
                            excelDtRow["SqFt"].ToString() + "')";
                            //Console.WriteLine(sql);
                            new DBConnector(sql, "Operations_Rooms3");
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                        }
                    }
                }
            }
            dr.Close();
            oledbconn.Close();
            MessageBox.Show("File imported into sql server.");


        }
        private void uploadRoom_Click(object sender, EventArgs e)
        {
            //ImportDataFromExcel("");
            String path = UtilityDialogs.openFileDialog();
            //Console.WriteLine(path);
            if (path.Length > 0)
            {
                ImportDataFromExcel(path);
            }
        }
    }
}
