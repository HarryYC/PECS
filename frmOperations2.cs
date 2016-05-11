using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace PECS_v1
{
    public partial class frmOperations2 : Form
    {

        // initial  class Operations2, InfoLoader, Templates
        Operations2 Ope2 = new Operations2();
        InfoLoader info = new InfoLoader();
        Templates tpl = new Templates();

        // 0 is default value
        //		        "0"	     "1"	 "2"     "3"	"4"     "5"		      "6"   	  "7"	       "8"    "9"  		"10"       "11"       "12"	  "13"	       "14"      	     "15"   "16"  "17"
        // IDSetCtl: [#BuildingID:RoomID:EmpID:EquipID:EmpRoomID:EquipStatusID:EquipTypeID:SpaceTypeID:UnitID:cus_id:BuildNameShort:RoomNumber:EmpUIN:OrderByEmpID:EmpAppointStatusID:DocID:LogID:CSXID&]
        int[] arIDsetCtl = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        String[] IDSetCtl = new String[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
        public Dictionary<string, string> dicIDsCtl = new Dictionary<string, string>();
        String[] ReportIDs = new String[] { "0", "0", "0", "0", "0", "0" };

        //Declare Sub Forms
        private frmOperationsProjectStaffs frmOpePrjStaffs;
        //private frmOperationsLocOffices2 frmOpeLocations;
        //private frmOperationsEquipment2 frmOpeEquipments;
        private frmOperationsDetails frmOpeDetails;
        private frmOperationsNewEquipment2 frmOpeNewEquip2;
        private frmOperationsNewBuildRoom2 frmOpeNewBldgRm2;
        private frmOperationsNewAssign2 frmOpeNewAssign2;
        

        // Declare DBConnector
        DBConnector dbcOpeMain;
        DBConnector dbcSearchText;
        //DBConnector dbcLocations;

        //List<String> sItems;
        //ArrayList colSelected = new ArrayList();
        //BuildID,BuildNameShort,RoomID,RoomNumber,EmpID,UnitID,EquipID
        // if 0 list all
        //ArrayList activeIDWorking = new ArrayList();

        //String activeWorking = "";
        //List<String> lstIDSets = new List<String>();

        /*
        String sqlBase = @" SELECT DISTINCT EmpID
                              ,RoomEmpID
                              ,EquipID
                              ,RoomID
                              ,BuildingsRoomsTab
                              ,SEARCHTEXT
                          FROM vOPE_SearchText
                            ";
         */ 
        String sqlBase = @"SELECT DISTINCT 
	                           EmpAppointStatusID
                              ,SpaceTypeID
                              ,EquipStatusID
                              ,Category
                              ,setIDs
                              ,Operations_Buildings
                              ,Operations_Rooms2
                              ,(BuildRoomSearchResult+'$'+Operations_Buildings+Operations_Rooms2+setIDs) AS BuildingsRoomsTab
                              ,(EmployeeSearchResult+'$'+Operations_Buildings+Operations_Rooms2+Employee+Operations_Rooms_Employees2+setIDs) AS EmployeeTab
                              ,(EquipmentSearchResult+'$'+Operations_Buildings+Operations_Rooms2+Equipment+setIDs) AS EquipmentTab
                              ,SearchText
                          FROM vOpeSearchText2
                           ";

        String SlqFilter = "";
        String sqlReportDownload = "";

        public frmOperations2()
        {
            InitializeComponent();
            dbcOpeMain = new DBConnector(sqlBase, "OpeMain");
            

            // REPORT TAB
            InitTabReports();
            

            // SCHEDULE TAB
            loadLSchedule();

        }

        public frmOperations2(String SlqFilter)
        {
            InitializeComponent();
            dbcOpeMain = new DBConnector(sqlBase + SlqFilter, "OpeMain");
            //Console.WriteLine("\n 45# _sql [{0}]\n", SlqFilter);

        }

        private void frmOperations2_Load(object sender, EventArgs e)
        {
            //ArrayList searchItems = new ArrayList();           
        }


        //////////////////////////////////////////////////////////////////////////
        ///
        ///
        /////////////////////////////////////////////////////
        //MainTabCtl_SelectedIndexChanged
        private void MainTabCtl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            TabControl tc = (TabControl)sender;
            String s = tc.Name;

            TabPage tp = tc.TabPages[tc.SelectedIndex];
            String p = tp.Name;

            tp = this.MainTabCtl.SelectedTab;
            String myPage = tp.Name;

            Console.WriteLine("\n 131 MainTabCtl_SelectedIndexChanged \n[{0}]\n[{1}]\n[{1}]\n", s, p, myPage);
        }










        /***********************************************************
         * * Operations Main - Searching
         * 
         * 
         ***********************************************************/

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            String _sql = "";
            
            if (txtSearch.Text.Trim().Length < 1)
            {
                SlqFilter = "";
            }
            else
            {
                /// Build WHERE filter
               //searchTxt = txtSearch.Text.Replace(" ", "%");               
                if (txtSearch.Text.IndexOf(" ") > 0) {
                    // Split keysearch by a space
                    Array arrSearch = txtSearch.Text.Split(' ');
                    foreach (String s in arrSearch) {                        
                        if (!s.Equals(""))
                        {
                            _sql += " (SEARCHTEXT LIKE '%" + s + "%') AND";
                        }
                    }
                    
                } else {
                    _sql += " (SEARCHTEXT LIKE '%" + txtSearch.Text + "%')";
                }

                _sql += ")";
                SlqFilter = _sql.Replace("AND)", ")");
                SlqFilter = " WHERE (" + SlqFilter;  
                //SlqFilter = " WHERE EmpAppointStatusID = 3 \n AND (" + SlqFilter;  
               
            }

            /// Set 4 sources for 1=>SetIDs & 3=> display ListViews: Staff, Location, Equipments
            if (txtSearch.Text.Length > 1) {
                setOpeSource(SlqFilter); 
            }
        }

        public void setOpeSource(String SlqFilter)
        {
            String SqlSearchText = sqlBase + SlqFilter;
            List<String> listIDs = new List<String>();
            List<String> listEmpl = new List<String>();
            List<String> listLoc = new List<String>();
            List<String> listEquip = new List<String>();

            Console.WriteLine("\n 200# _setOpeSource sql [{0}]\n[{1}]\n", SqlSearchText, SlqFilter);
            /// if no searching text get default basesql
            if (SqlSearchText.Length > 0)
            {
                dbcSearchText = new DBConnector(SqlSearchText, "SearchText");
            }
            else
            {
                dbcSearchText = new DBConnector(sqlBase, "SearchText");
            }

            if (dbcSearchText.getDT().Rows.Count > 0)
            {
                int recordCount = 0;

                var Cols = (from DataColumn dCol in dbcSearchText.getDT().Columns select dCol.ColumnName);
                // basesql fields from View vOpeSearchText2
                foreach (DataRow row in dbcSearchText.getDT().Rows)
                {
                    
                    // Each field of vOPE_SearchText
                    String[] arrItemData = row["SEARCHTEXT"].ToString().Split('#');
                    // get unique setID
                   if (!listIDs.Contains(row["setIDs"].ToString()))
                   {
                        listIDs.Add(row["setIDs"].ToString());
                   }


                   if (!listLoc.Contains(row["BuildingsRoomsTab"].ToString()))
                   {
                       //listLoc.Add(row["RoomEmpID"].ToString());
                       listLoc.Add(row["BuildingsRoomsTab"].ToString());

                       //Console.WriteLine("\n 222 listLoc [" + row["BuildingsRoomsTab"].ToString() + "][" + row["setIDs"].ToString() + "]");
                   }

                    //String dupEmp = (!String.IsNullOrEmpty(row["EmployeeTab"].ToString()))? row["EmployeeTab"].ToString().Substring(0, row["EmployeeTab"].ToString().LastIndexOf('#')) : "0";
                   // if (!listEmpl.Contains(dupEmp))  + row["setIDs"].ToString()
                   if (!listEmpl.Contains(row["EmployeeTab"].ToString()))
                    {
                        listEmpl.Add(row["EmployeeTab"].ToString());
                        //Console.WriteLine("\n 246 EmployeeTab [" + row["EmployeeTab"].ToString() + "]");
                    }

                   if (!listEquip.Contains(row["EquipmentTab"].ToString()) && row["EquipmentTab"].ToString().Length > 0)
                    {
                        listEquip.Add(row["EquipmentTab"].ToString());
                        //Console.WriteLine("\n 253 EquipmentTab" + row["EquipmentTab"].ToString() + "]");
                    }

                   recordCount++;
                }

            }

            //Console.WriteLine("\nListID [{0}]\tListID [{1}]\tListID [{2}]\tListID [{3}]", listIDs.Count(), listEmpl.Count(), listLoc.Count(), listEquip.Count());

            loadLstStaffs(listEmpl);
            loadLstLocations(listLoc);
            loadLstEquipments(listEquip);

        }                

        public void loadLstStaffs(List<String> _dataSource)
        {
             //Console.WriteLine("\n 270 _dataSource [{0}]", _dataSource.Count());
            //lvByStaffs
            ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
            lvByStaffs.ListViewItemSorter = lvwColumnSorter;

            lvByStaffs.BeginUpdate();
            lvByStaffs.Clear();

            //lvByStaffs.Columns.Add("Info", 0, HorizontalAlignment.Left);            
            lvByStaffs.Columns.Add("EmpID", 0, HorizontalAlignment.Left);
            lvByStaffs.Columns.Add("FirstName", 80, HorizontalAlignment.Left);
            lvByStaffs.Columns.Add("LastName", 80, HorizontalAlignment.Left);
            //lvByStaffs.Columns.Add("UnitDesc", 0, HorizontalAlignment.Left);
            lvByStaffs.Columns.Add("UnitID", 50, HorizontalAlignment.Left);
            //lvByStaffs.Columns.Add("DeptDesc", 0, HorizontalAlignment.Left);
            //lvByStaffs.Columns.Add("DeptID", 0, HorizontalAlignment.Left); 
            //lvByStaffs.Columns.Add("EmpUIN", 0, HorizontalAlignment.Left);
            //lvByStaffs.Columns.Add("EmpTypeDesc", 60, HorizontalAlignment.Left);
            lvByStaffs.Columns.Add("Email", 100, HorizontalAlignment.Left);
            lvByStaffs.Columns.Add("Phone", 60, HorizontalAlignment.Left);
            lvByStaffs.Columns.Add("CellPhone", 100, HorizontalAlignment.Left);

            if (_dataSource.Count() > 0)
            {
                String _duplicate = "";
                int listStaffIdx = 0;

                foreach (String _dataItem in _dataSource.Distinct())
                {
                    //Console.WriteLine("\n299 _dataItem ByStaff[" + _dataItem.ToString() + "]\t");
                    String[] arItem = _dataItem.Split('$');
                    if (arItem[0].Length > 0 && arItem[1].Length > 0)
                    {
                        String _resultSearch = arItem[0];
                        String _passValue = arItem[1];
                        //Console.WriteLine("\n 308_resultSearch = arItem[0] [{0}]\t[{1}]\t\n", _duplicate, _resultSearch);
                        if (_duplicate != _resultSearch)
                        {
                            //Console.WriteLine("\n293 Emp _dataItem.Split('$') [{0}]\t [{1}]\t[{2}]\t\n", _resultSearch, _passValue, listStaffIdx.ToString());
                            ListViewItem listItem = getListViewItem3(listStaffIdx, _resultSearch, _passValue);
                            lvByStaffs.Items.Add(listItem);
                            listStaffIdx++;

                            _duplicate = _resultSearch;
                        }
                    }
                }                
            }
            
            //Console.WriteLine("\n202 INS recordCount[" + recordCount.ToString() + "]\t");
            lvByStaffs.EndUpdate();

        }

        public void loadLstLocations(List<String> _dataSource)
        {
            //Console.WriteLine("\n_dataSource [{0}]", _dataSource.Count());

            //lvByLocations
            ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
            lvByLocations.ListViewItemSorter = lvwColumnSorter;

            lvByLocations.BeginUpdate();
            lvByLocations.Clear();
            
            lvByLocations.Columns.Add("LocID", 0, HorizontalAlignment.Left);
            //lvByLocations.Columns.Add("BuildID", 0, HorizontalAlignment.Left);
            lvByLocations.Columns.Add("Build", 60, HorizontalAlignment.Left);
            //lvByLocations.Columns.Add("BuildNameLong", 0, HorizontalAlignment.Left);
            //lvByLocations.Columns.Add("RoomID", 0, HorizontalAlignment.Left);
            lvByLocations.Columns.Add("RoomNumber", 60, HorizontalAlignment.Left);
            lvByLocations.Columns.Add("RoomDesc", 80, HorizontalAlignment.Left);
            lvByLocations.Columns.Add("SpaceTypeDesc", 200, HorizontalAlignment.Left);
            //lvByLocations.Columns.Add("BuildNameLong", 0, HorizontalAlignment.Left);
            //lvByLocations.Columns.Add("RoomNote", 0, HorizontalAlignment.Left);
            //lvByLocations.Columns.Add("Locations Info", 50, HorizontalAlignment.Left);
            //lvByLocations.Columns.Add("Locations Info", 50, HorizontalAlignment.Left);

            //int recordCount = 0;

            if (_dataSource.Count() > 0)
            {
                String _duplicate = "";
                int listlocIdx = 0;
                foreach (String _dataItem in _dataSource.Distinct())
                {
                    //Console.WriteLine("\n252 ByLocation[" + _dataItem.ToString() + "]\t");
                    String[] arItem = _dataItem.Split('$');
                    if (arItem[0].Length > 0 && arItem[1].Length > 0)
                    {
                        String _resultSearch = arItem[0];
                        String _passValue = arItem[1];

                        if (_duplicate != _resultSearch) {
                            //Console.WriteLine("\n362 _dataItem.Split('$') [{0}]\t [{1}]\t[{2}]\t\n", _resultSearch, _passValue, listlocIdx.ToString());
                            ListViewItem listItem = getListViewItem3(listlocIdx, _resultSearch, _passValue);
                            lvByLocations.Items.Add(listItem);
                            listlocIdx++;

                            _duplicate = _resultSearch;
                        } 
                    }
                }
            }
             
            //Console.WriteLine("\n202 INS recordCount[" + recordCount.ToString() + "]\t");
            lvByLocations.EndUpdate();

        }

        public void loadLstEquipments(List<String> _dataSource)
        {
            
            //lvByEquipments
            ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
            lvByEquipments.ListViewItemSorter = lvwColumnSorter;

            lvByEquipments.BeginUpdate();
            lvByEquipments.Clear();

            lvByEquipments.Columns.Add("EquipID", 0, HorizontalAlignment.Left);
            //lvByEquipments.Columns.Add("EquipmentTab", 0, HorizontalAlignment.Left);
            //lvByEquipments.Columns.Add("EquipTypeID", 100, HorizontalAlignment.Left);
            //lvByEquipments.Columns.Add("EquipTypeDesc", 100, HorizontalAlignment.Left);
            //lvByEquipments.Columns.Add("RoomID", 100, HorizontalAlignment.Left);
            //lvByEquipments.Columns.Add("EmpID", 100, HorizontalAlignment.Left);
            //lvByEquipments.Columns.Add("AssignedTo", 90, HorizontalAlignment.Left);
            //lvByEquipments.Columns.Add("OrderByEmpID", 100, HorizontalAlignment.Left);
            //lvByEquipments.Columns.Add("OrderBy", 90, HorizontalAlignment.Left);
            lvByEquipments.Columns.Add("EquipName", 140, HorizontalAlignment.Left);
            lvByEquipments.Columns.Add("Make", 60, HorizontalAlignment.Left);
            lvByEquipments.Columns.Add("Model", 120, HorizontalAlignment.Left);
            lvByEquipments.Columns.Add("Serial", 90, HorizontalAlignment.Left);
            lvByEquipments.Columns.Add("AssetTag", 90, HorizontalAlignment.Left);
            lvByEquipments.Columns.Add("ESN", 180, HorizontalAlignment.Left);


            // lvByEquipments.Columns.Add("AssignedTo", 80, HorizontalAlignment.Left);

            int recordCount = 0;
            //String _test = "";
            if (_dataSource.Count() > 0)
            {
                String _duplicate = "";
                int listEquipIdx = 0;

                foreach (String _dataItem in _dataSource.Distinct())
                {
                    //Console.WriteLine("\n 446 loadLstEquipments _dataItem [{0}]", _dataItem);

                    String[] arItem = _dataItem.Split('$');
                    if (arItem[0].Length > 0 && arItem[1].Length > 0)
                    {
                        String _resultSearch = arItem[0];
                        String _passValue = arItem[1];

                        if (_duplicate != _resultSearch)
                        {
                            //Console.WriteLine("\n475 Emp _dataItem.Split('$') [{0}]\t [{1}]\t[{2}]\t\n", _resultSearch, _passValue, listEquipIdx.ToString());
                            ListViewItem listItem = getListViewItem3(listEquipIdx, _resultSearch, _passValue);
                            lvByEquipments.Items.Add(listItem);
                            listEquipIdx++;

                            _duplicate = _resultSearch;
                        }
                    }                    
                }
            }
            //Console.WriteLine("\n327 Equip[" + _test.ToString() + "]\n");
            lvByEquipments.EndUpdate();

        }


        private void getOpeDetails(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = ((ListView)sender).SelectedItems[0];

            Console.WriteLine("\n 448- Pass ((ListView)sender).Name.ToString(), selectedItem.Text [{0}]\t[{1}]", ((ListView)sender).Name.ToString(), selectedItem.Text);

            frmOpeDetails = new frmOperationsDetails(selectedItem.Text, ((ListView)sender).Name.ToString());
            frmOpeDetails.MdiParent = frmSwitchboard.frmParent;
            frmOpeDetails.Show();
            frmOpeDetails.Activate();

        }

        private void getOpeNewEquip(object sender, MouseEventArgs e)
        {
            String selectedCmdButton = ((Button)sender).Name.ToString();
            //String wokingTab = "";
            //String ItemVal = "";

            frmOpeNewEquip2 = new frmOperationsNewEquipment2();
            frmOpeNewEquip2.Show();
            frmOpeNewEquip2.Activate();

        }

        private void getOpeNewBldgRm(object sender, MouseEventArgs e)
        {
            String selectedCmdButton = ((Button)sender).Name.ToString();
            //String wokingTab = "";
            //String ItemVal = "";

            frmOpeNewBldgRm2 = new frmOperationsNewBuildRoom2();
            frmOpeNewBldgRm2.Show();
            frmOpeNewBldgRm2.Activate();

        }

        private void getOpeNewAssign(object sender, MouseEventArgs e)
        {
            String selectedCmdButton = ((Button)sender).Name.ToString();
            //String wokingTab = "";
            //String ItemVal = "";

            frmOpeNewAssign2 = new frmOperationsNewAssign2();
            frmOpeNewAssign2.Show();
            frmOpeNewAssign2.Activate();

        }




        /***********************************************************
         * * Data Processes Tab
         * 
         * 
         ***********************************************************/

        /// <summary>
        /// Import Helpdesk data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void cmdImpHelpDeskData(object sender, EventArgs e)
        {
            String _sql = @"
		        MERGE HelpdeskCustomers AS T
		        USING vOpeLink_Helpdesk_wd_customers AS S
		        ON (T.cus_id = S.cus_id) 
		        WHEN NOT MATCHED BY TARGET
		            THEN INSERT(cus_id ,cus_username ,cus_first_name ,cus_last_name ,cus_email ,cus_phone ,cus_cell_phone ,cus_business_phone ,cus_fax ,cus_category ,cus_bldg ,cus_dept ,cus_temp_room ,cus_room) 
		            VALUES(S.cus_id, S.cus_username, S.cus_first_name, S.cus_last_name, S.cus_email, S.cus_phone, S.cus_cell_phone, S.cus_business_phone, S.cus_fax, S.cus_category, S.cus_bldg, S.cus_dept, S.cus_temp_room, S.cus_room)
		        WHEN MATCHED 
		            THEN UPDATE SET 
		              T.cus_id = S.cus_id
		            , T.cus_username = S.cus_username
		            , T.cus_first_name = S.cus_first_name
		            , T.cus_last_name = S.cus_last_name
		            , T.cus_email = S.cus_email
		            , T.cus_phone = S.cus_phone
		            , T.cus_cell_phone = S.cus_cell_phone
		            , T.cus_business_phone = S.cus_business_phone
		            , T.cus_fax = S.cus_fax
		            , T.cus_category = S.cus_category
		            , T.cus_bldg = S.cus_bldg
		            , T.cus_dept = S.cus_dept
		            , T.cus_temp_room = S.cus_temp_room
		            , T.cus_room = S.cus_room
		        WHEN NOT MATCHED BY SOURCE
		            THEN DELETE 
		        OUTPUT $action, inserted.*, deleted.* ; 		
		        "; // NOTE: Need ; to termination for MERGE process on line OUTPUT

            DBConnector dbcHelpdeskCustomers = new DBConnector("SELECT * FROM HelpdeskCustomers", "tbHelpdeskCustomers");

            int insHCNumb = 0;
            try
            {
                insHCNumb = dbcHelpdeskCustomers.executeSQL(_sql);
                //Console.WriteLine("\n 535 inssqlCS [{0}] => {1}\n", insHCNumb, _sql);
                MessageBox.Show("Success Update!!");

            }
            catch
            {
                MessageBox.Show("Fail Update!!\n Please contact Administrator.");
                return;
            }
        }

        /// <summary>
        /// Import New Equipments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void impNewEquipments_Click(object sender, EventArgs e)
        {
            DialogResult result;
            Boolean processOK = false;


            String fullPathName = Ope2.openFileDialog();

            Console.Write("\nfullPathName [{0}]\t\n", fullPathName);

            if ((fullPathName.Length > 5) && (fullPathName.Contains(".csv")))
            {

                result = UtilityDialogs.askYesNo("CONFIRM:\n" + fullPathName
                    + "\n Do you want to continue?", "WARNING");

                if (result == DialogResult.No)
                {
                    //do not overwrite data. Exit this process.
                    return;
                }
                else
                {
                    Ope2.importNewEquip(fullPathName);
                    processOK = true;
                }
            }
            else
            {
                MessageBox.Show("Invalid Path OR Invalid File Tpye (MUST be .csv)\n" + fullPathName);
                processOK = false;
                return;
            }

            if (processOK)
            {
                //MessageBox.Show("DONE IMPORT PROCESS................ ");
                // Close the Browser to force user open again            
                this.Close();
            }
        }

        /// <summary>
        /// Import New Equipments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void impNewAssignments_Click(object sender, EventArgs e)
        {
            DialogResult result;
            Boolean processOK = false;


            String fullPathName = Ope2.openFileDialog();

            Console.Write("\nfullPathName [{0}]\t\n", fullPathName);

            if ((fullPathName.Length > 5) && (fullPathName.Contains(".csv")))
            {

                result = UtilityDialogs.askYesNo("CONFIRM:\n" + fullPathName
                    + "\n Do you want to continue?", "WARNING");

                if (result == DialogResult.No)
                {
                    //do not overwrite data. Exit this process.
                    return;
                }
                else
                {
                    //Ope2.importNewAssignments(fullPathName);
                    processOK = true;
                }
            }
            else
            {
                MessageBox.Show("Invalid Path OR Invalid File Tpye (MUST be .csv)\n" + fullPathName);
                processOK = false;
                return;
            }

            if (processOK)
            {
                //MessageBox.Show("DONE IMPORT PROCESS................ ");
                // Close the Browser to force user open again            
                //this.Close();





            }
        }



















        ////////////////////////////////////////////////////
        /// REPORTS TAB //////////////////////////////////
        /// 
        //////////////////////////////////////////////////////
        private void InitTabReports()
        {


            loadcbRPBuilding();
            loadcbRPRoom("");
            loadcbRPStaffs();
            loadcbRPITEquipType();
            loadcbRPITEquipStatus();


            loadlvOpeReports("", "", "EquipDetails");

        }

        private void loadcbRPBuilding()
        {
            String _sql = @"SELECT BuildID, BuildNameShort
	    				            FROM Operations_Buildings
	                                ORDER BY BuildNameShort
	                                ";
            String _dbTableName = "cbRPBuilding";
            String _selectedCol = "BuildID|BuildNameShort";
            String _fisrtItem = "";
            Ope2.tplLoadCombo2(_sql, _dbTableName, _selectedCol, _fisrtItem, cbRPBuilding);
        }

        private void cbRPBuilding_SelectedValueChanged(object sender, EventArgs e)
        {

            String selectedVal = "0";
            try
            {
                selectedVal = cbRPBuilding.SelectedValue.ToString().Replace("-", "").Trim();
            }
            catch
            {
                selectedVal = "0";
            }
            ReportIDs[0] = selectedVal;

           // Console.WriteLine("\n679 cbRPBuilding [{0}]\t[{1}]\t \n", cbRPBuilding.SelectedIndex.ToString(), cbRPBuilding.SelectedValue.ToString());

            loadcbRPRoom(selectedVal);
            loadlvOpeReports("", "", "EquipDetails"); 

        }


        private void loadcbRPRoom(String _BuildID)
        {
            String BuildID = _BuildID;
            if ((_BuildID.Length < 1) && (!_BuildID.Contains("0"))) { 
                BuildID = "0"; 
            }

            String _sql = @"SELECT RoomID, RoomNumber, BuildID
	    			                FROM Operations_Rooms
	    			                WHERE BuildID = " + BuildID
                        + " ORDER BY RoomNumber";

            String _dbTableName = "cbStffRoom";
            String _selectedCol = "RoomID|RoomNumber|BuildID";
            String _fisrtItem = "";
            Ope2.tplLoadCombo2(_sql, _dbTableName, _selectedCol, _fisrtItem, cbRPRoom);
        }

        private void cbRPRoom_SelectedValueChanged(object sender, EventArgs e)
        {
            String selectedVal = "0";
            try
            {
                selectedVal = cbRPRoom.SelectedValue.ToString().Replace("-", "").Trim();
            }
            catch
            {
                selectedVal = "0";
            }
            ReportIDs[1] = selectedVal;

            //Console.WriteLine("\n751 cbRPBuilding [{0}]\t[{1}]\t \n", cbRPRoom.SelectedIndex.ToString(), cbRPRoom.SelectedValue.ToString());

            loadlvOpeReports("", "", "EquipDetails");

        }

        private void loadcbRPStaffs()
        {
            String _sql = @"SELECT DISTINCT EmpID , EmpNameFirst + '  ' + EmpNameLast AS EmpName
                            FROM vEmpByAppointments ve
                            WHERE EmpID = (SELECT MAX(EmpID) FROM vEmpByAppointments WHERE EmpUIN = ve.EmpUIN)
                            AND EmpAppointStatusID = 3
                            ORDER BY EmpName
                            ";
            String _dbTableName = "cbcbRPStaffs";
            String _selectedCol = "EmpID|EmpName";
            String _fisrtItem = "";
            Ope2.tplLoadCombo2(_sql, _dbTableName, _selectedCol, _fisrtItem, cbRPStaffs);
        }

        private void cbRPStaffs_SelectedValueChanged(object sender, EventArgs e)
        {
            String selectedVal = "0";
            try
            {
                selectedVal = cbRPStaffs.SelectedValue.ToString().Replace("-", "").Trim();
            }
            catch
            {
                selectedVal = "0";
            }
            ReportIDs[2] = selectedVal;

           // Console.WriteLine("\n785 cbRPBuilding [{0}]\t[{1}]\t \n", cbRPStaffs.SelectedIndex.ToString(), cbRPStaffs.SelectedValue.ToString());

            loadlvOpeReports("", "", "EquipDetails");

        }

        private void loadcbRPITEquipStatus()
        {
            String _sql = @"SELECT EquipStatusID
				                   ,EquipStatusDesc
			                    FROM refOperations_Equipment_Status
			                    ORDER BY EquipStatusDesc
                            ";
            String _dbTableName = "cbRPITEquipStatus";
            String _selectedCol = "EquipStatusID|EquipStatusDesc";
            String _fisrtItem = "";
            Ope2.tplLoadCombo2(_sql, _dbTableName, _selectedCol, _fisrtItem, cbRPITEquipStatus);
        }

        private void cbRPITEquipStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Console.WriteLine("\n805 cbITEquipStatus.SelectedIndex.ToString() [{0}]\t[{1}]\t \n", cbRPITEquipStatus.SelectedIndex.ToString(), cbRPITEquipStatus.SelectedValue);
            String selectedVal = "0";
            try
            {
                selectedVal = cbRPITEquipStatus.SelectedValue.ToString().Replace("-", "").Trim();
            }
            catch
            {
                selectedVal = "0";
            }
            ReportIDs[3] = selectedVal;
            loadlvOpeReports("", "", "EquipDetails");
        }

        private void loadcbRPITEquipType()
        {
            String _sql = @"SELECT EquipTypeID
			                      ,EquipTypeDesc
			                      ,Category
			                    FROM refOperations_Equipment_Type2
                                WHERE Category = 'IT'
			                    ORDER BY EquipTypeDesc
                            ";
            String _dbTableName = "cbRPITEquipType";
            String _selectedCol = "EquipTypeID|EquipTypeDesc";
            String _fisrtItem = "";
            
            Ope2.tplLoadCombo2(_sql, _dbTableName, _selectedCol, _fisrtItem, cbRPITEquipType);
        }

        private void cbRPITEquipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("\n831 cbRPITEquipType.SelectedIndex.ToString() [{0}]\t[{1}]\t \n", cbRPITEquipType.SelectedIndex.ToString(), cbRPITEquipType.SelectedValue);
            String selectedVal = "0";
            try
            {
                selectedVal = cbRPITEquipType.SelectedValue.ToString().Replace("-", "").Trim();
            }
            catch
            {
                selectedVal = "0";
            }
            ReportIDs[4] = selectedVal;
            loadlvOpeReports("", "", "EquipDetails");
        }

        private void loadlvOpeReports(String varDetail, String _sqlFilter, String _sqlSort)
        {
            //String _dbTableName = "Equips";
            //String _idxField = "EquipID";
            //String _SelectedColNames = "EquipID:0|EquipName:160|Make:80|Model:140|Serial:100|AssetTag:100|ESN:200";

            /*
            String _sql = @"SELECT CAST(q.EquipID AS varchar) + '|' + q.EquipDetails AS EquipDetails
                        FROM Operations_Equipment2 q, refOperations_Equipment_Type2 qt
                        WHERE q.EquipTypeID = qt.EquipTypeID
                        ";
            */
            String _whereAnd = "";
            String sqlDownload = @"
                                SELECT 
                                q.BuildNameShort,
                                r.RoomNumber,
                                e.EmpNameFirst + ' ' + e.EmpNameLast,
                                q.EquipStatus,
                                REPLACE(q.EquipDetails, '|',',')
                                FROM Operations_Equipment2 q, refOperations_Equipment_Type2 qt, 
                                Operations_Rooms2 r, Employees e
                                WHERE q.EquipTypeID = qt.EquipTypeID
                                AND q.RoomID = r.RoomID
                                AND q.BuildID = r.BuildID
                                AND q.EmpID = e.EmpID
                            ";

            String _SelectedColNames = "EquipID:0|BuildID:0|BuildNameShort:40|RoomID:0|RoomNumber:40|EmpID:0|EmpName:100|EquipStatus:80|EquipName:150|Make:60|Model:130|Serial:80|AssetTag:90|ESN:180";
            String _sql = @"
                            SELECT (CAST(q.EquipID AS varchar) + '|' + 
                            CAST(q.BuildID AS varchar) + '|' +
                            q.BuildNameShort + '|' +
                            CAST(q.RoomID AS varchar) + '|' +
                            r.RoomNumber  + '|' +
                            CAST(q.EmpID AS varchar) + '|' +
                            e.EmpNameFirst + ' ' + e.EmpNameLast + '|' +
                            q.EquipStatus+ '|' +
                            q.EquipDetails ) AS EquipDetails
                            FROM Operations_Equipment2 q, refOperations_Equipment_Type2 qt, Operations_Rooms2 r, Employees e
                            WHERE q.EquipTypeID = qt.EquipTypeID
                            AND q.RoomID = r.RoomID
                            AND q.EmpID = e.EmpID
                            ";

            if (_sqlFilter.Length > 0)
            {
                _sql += _sqlFilter;
            }

            if (ReportIDs[0] != "0")
            {
                _whereAnd += " AND q.BuildID = " + ReportIDs[0];
            }

            if (ReportIDs[1] != "0")
            {
                _whereAnd += " AND q.RoomID = " + ReportIDs[1];
            }

            if (ReportIDs[2] != "0")
            {
                _whereAnd += " AND q.EmpID = " + ReportIDs[2];
            }

            if (ReportIDs[3] != "0")
            {
                _whereAnd += " AND q.EquipStatusID = " + ReportIDs[3];
            }

            if (ReportIDs[4] != "0")
            {
                _whereAnd += " AND q.EquipTypeID = " + ReportIDs[4];
            }

            //if (_sqlSort.Length > 2)
            //{
                _sql += _whereAnd + " ORDER BY q.BuildNameShort, r.RoomNumber, e.EmpNameFirst";
            //}

                sqlDownload += _whereAnd;

            if (_sql.Length <= 0)
            {
                MessageBox.Show("Conection Fail");
                return;
            }

            //Console.WriteLine("\n 1333 _sql Equip [{0}] \n", _sql);
            DBConnector dbclv = new DBConnector(_sql, "Equipments");
            DataTable dt = dbclv.getDT();
            sqlReportDownload = sqlDownload + " ORDER BY q.BuildNameShort, r.RoomNumber, e.EmpNameFirst"; 

            // Emplty lvITEquips 
            lvOpeReports.Clear();

            List<String> lstEquips = new List<String>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    lstEquips.Add(row["EquipDetails"].ToString());
                }

                Ope2.loadlistViewTemplate(lstEquips, 0, _SelectedColNames, lvOpeReports);
            }

        }

        private void cmdRPDownload_Click(object sender, EventArgs e)
        {

            //_sqllv = tp.filterANDSql(_sqllv, "UnitID", sqlFilterCol, "text");
            //Console.WriteLine("\nSQL {0}\n", sqlFilter);

            tplDownLoadToCSV("OperationReport", sqlReportDownload, "Operations");

        }












        //////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        ///  Support Functions
        ///
        //////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////
        // Download to csv Template
        ////////////////////////////////////////////////////////////////
        public void tplDownLoadToCSV(String _fileName, String _sql, String _dbTable)
        {

            _fileName = _fileName + "_" + DateTime.Now.ToShortDateString().Replace("/", "-");
            try
            {

                String _pathFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + _fileName + ".csv";
                String _sourceData = InfoLoader.getReport(_sql, _dbTable);

                // Console.WriteLine("DownLoadToCSV\n {0}\n{1}\n", _pathFileName, InfoLoader.getReport(_sql, _dbTable));

                UtilityFiles.writeFile(_pathFileName, _sourceData);
                System.Diagnostics.Process.Start(_pathFileName);

                MessageBox.Show("\nDONE - Down load to \n" + _pathFileName);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("It appears that this file is already open. Please close it before continuing.\n\n" + ex.ToString());
            }

        }

        public ListViewItem getListViewItem3(int _lvIdx, String _source, String _passValues)
        {

            // init ListView[0] with _passValues
            ListViewItem listViewItem = new ListViewItem(_passValues);

            String[] arrItems = _source.Split('|');
            arrItems.Distinct();

            int recordCount = 0;
            //listViewItem.Name = recordCount + "!" + arrItems[1]; // arrItems[0] ColHeader arrItems[1] ID

            for (int i = 1; i < arrItems.Length; i++)
            {
                // _passValues: setIDs, tableValues, tableValues, tableValues....
                // _passValues: #setIDs, #Operations_Buildings, #Operations_Rooms2
                listViewItem.Name = recordCount + "!" + arrItems[i].ToString(); // arrItems[0] ColHeader arrItems[1] ID
                listViewItem.SubItems.Add(arrItems[i].ToString());
                recordCount++;
            }

            
            return listViewItem;
        }
        /*
        public ListViewItem getListViewItem2(String _source)
        {
            
            String[] arrItems = _source.Split('|');
            int recordCount = 0;
            ListViewItem listViewItem = new ListViewItem(_source.ToString());
            for (int i = 0; i < arrItems.Length; i++)
            {
                
                if (i > 0)
                {
                    //Console.WriteLine("\n528 getListViewItem2 [{0}]\t[{1}]", _source.ToString(), arrItems[i].ToString());
                    String[] arrVal = arrItems[i].ToString().Split(':');
                    listViewItem.SubItems.Add(arrVal[2].ToString());
                    //Console.WriteLine("\n535 getListViewItem2 [{0}]\t[{1}]\t[{2}]\t[{3}]\n", arrVal[0], arrVal[1], arrVal[2], arrVal[2]);
                }
                else {

                    //listViewItem.Name = recordCount + "!" + arrItems[0].Replace("#", "");
                    listViewItem.Name = recordCount + "!" + arrItems[i];
                }
                recordCount++;
            }

            return listViewItem;
        }

        public ListViewItem getListViewItem(String _source)
        {

            String[] arrItems = _source.Split('|');
            int recordCount = 0;
            ListViewItem listViewItem = new ListViewItem(_source.ToString());
            for (int i = 1; i < arrItems.Length; i++)
            {
                listViewItem.Name = recordCount + "!" + arrItems[1]; // arrItems[0] ColHeader arrItems[1] ID
                listViewItem.SubItems.Add(arrItems[i].ToString());
                recordCount++;
            }

            return listViewItem;
        }
        
        //public ListView SetListViewDataSource(ListView lv, DataTable dataTable, ArrayList columnsToShow)
        public void SetListViewDataSource(ListView lv, DataTable dataTable, ArrayList columnsToShow)
        {
            //ListView lv = new ListView();

            try
            {
                lv.Clear();

                for (int i = 0; i < columnsToShow.Count; i++)
                {
                    System.Windows.Forms.ColumnHeader columnHeader = new ColumnHeader();
                    columnHeader.Text = dataTable.Columns[columnsToShow[i].ToString()].Caption;
                    lv.Columns.Add(columnHeader);
                }

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    System.Windows.Forms.ListViewItem listViewItem = new ListViewItem();
                    listViewItem.SubItems[0].Text = dataTable.Rows[i][columnsToShow[0].ToString()].ToString();
                    for (int j = 1; j < columnsToShow.Count; j++)
                    {
                        listViewItem.SubItems.Add(dataTable.Rows[i][columnsToShow[j].ToString()].ToString());
                    }
                    lv.Items.Add(listViewItem);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            // return lv;
        }




        */

















        //////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        ///  Schedule Tab
        ///
        //////////////////////////////////////////////////////////////////////////////////////////////////

        private void llbClassSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Add a link to the LinkLabel.
            LinkLabel.Link link = new LinkLabel.Link();
            // Specify that the link was visited. 
            //this.llbClassSchedule.LinkVisited = true;

            //link.LinkData = " https://intranet.chss.sfsu.edu/PECSweb/CHHS/ ";
            //llbClassSchedule.Links.Add(link);

            try
            {
                // Send the URL to the operating system.
                Process.Start("https://intranet.chss.sfsu.edu/PECSweb/CHHS/reportsCourseSchedule.php");
            }
            catch
            {

            }
        }

        private void llbFastBook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Add a link to the LinkLabel.
            LinkLabel.Link link = new LinkLabel.Link();
            // Specify that the link was visited. 
            //this.llbClassSchedule.LinkVisited = true;

            //link.LinkData = " https://apps.chss.sfsu.edu/schedule/ ";
            //llbClassSchedule.Links.Add(link);

            try
            {
                // Send the URL to the operating system.
                Process.Start("https://apps.chss.sfsu.edu/schedule/");
            }
            catch
            {

            }
        }

        public void loadLSchedule()
        {
            String _sql = @"
                    SELECT CSXID
                          ,SemID
                          ,Term
                          ,Subject
                          ,Catalog
                          ,CourseID
                          ,ID
                          ,LastName
                          ,FirstName
                          ,MtgStart
                          ,MtgEnd
                          ,FacilID
                          ,BuildShort
                          ,RoomNumber
                      FROM vOpeCourseSchedule
                      ";
            String _dbTableName = "ClassSchedule";
            String _idxField = "CSXID";
            String _SelectedColNameSize = "";

            Ope2.loadlistViewTemplate(_sql, _dbTableName, _idxField, _SelectedColNameSize, lvClassSchedule);

        }



        //////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        ///  Projects - Batch Process
        ///
        //////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void getOpeProjectStaffs(object sender, MouseEventArgs e)
        {
            String selectedCmdButton = ((Button)sender).Name.ToString();
            //String wokingTab = "";
            //String ItemVal = "";

            frmOpePrjStaffs = new frmOperationsProjectStaffs();
            frmOpePrjStaffs.Show();
            frmOpePrjStaffs.Activate();

        }


        //Harry new

        private void cmduploadRooms_Click(object sender, EventArgs e)
        {
            //ImportDataFromExcel("");
            String path = UtilityDialogs.openFileDialog();
            //Console.WriteLine(path);
            if (path.Length > 0)
            {
                importRooms(path);
            }
        }


        public void importRooms(string excelFilePath)
        {
            string myexceldataquery = String.Format("select * from [Space$A1:H291]");
            string sexcelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";
            //string ssexcelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ycao2\Downloads\Inventory.xlsx;Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";
            string ssqlconnectionstring = DBPath.connString;
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
            DataTable DT_Excel = new DataTable();
            DataTable DT_DataBase = new DataTable();
            DBConnector DT_DataBaseConn = new DBConnector("SELECT * FROM Operations_Spaces_Temp", "Operations_Spaces_Temp");
            SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
            //SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
            sqlconn.Open();
            //sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            oledbconn.Open();
            OleDbDataReader dr = oledbcmd.ExecuteReader();
            DT_Excel.Load(dr);
            DT_DataBase = DT_DataBaseConn.getDT();
            String truncateSql = @" TRUNCATE TABLE Operations_Spaces_Temp";
            new DBConnector(truncateSql, "Operations_Spaces_Temp");
            foreach (DataRow excelDtRow in DT_Excel.Rows)
            {
                if (excelDtRow["Room Number"].ToString().Length != 0)
                {
                    String sql = @" INSERT INTO Operations_Spaces_Temp (Building,Department," + "\"" + "Room Number" + "\"" + ",Description,HEGIS," + "\"" + "Space Type" + "\"" + ",SqFt, DeptID) " +
                            "VALUES (('" +
                        //InfoLoader.BuildName2BuildID(excelDtRow["Building"].ToString()) + "'), ('" +
                            excelDtRow["Building"].ToString() + "'), ('" +
                            InfoLoader.cleanDeptName(excelDtRow["Department"].ToString()) + "'), ('" +
                            excelDtRow["Room Number"].ToString() + "'), ('" +
                            excelDtRow["Description"].ToString().Replace("'", "''") + "'), ('" +
                            excelDtRow["HEGIS"].ToString() + "'), ('" +
                            excelDtRow["Space Type"].ToString() + "'), ('" +
                            excelDtRow["SqFt"].ToString() + "'), ('" +
                            excelDtRow["DeptID"].ToString() + "'))";
                            //Console.WriteLine(sql);
                    new DBConnector(sql, "Operations_Spaces_Temp");
                }
            }
            dr.Close();
            oledbconn.Close();
            MessageBox.Show("File imported into sql server.");


        }


        private void cmdupAssets_Click(object sender, EventArgs e)
        {
            //ImportDataFromExcel("");
            String path = UtilityDialogs.openFileDialog();
            //Console.WriteLine(path);
            if (path.Length > 0)
            {
                importAssets(path);
            }
        }

        public void importAssets(string excelFilePath)
        {
            string myexceldataquery = String.Format("select * from [Sheet1$A1:L1200]");
            string sexcelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";
            //string ssexcelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ycao2\Downloads\Inventory.xlsx;Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";
            string ssqlconnectionstring = DBPath.connString;
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
            DataTable DT_Excel = new DataTable();
            DataTable DT_DataBase = new DataTable();
            DBConnector DT_DataBaseConn = new DBConnector("SELECT * FROM Operations_Assets_Temp", "Operations_Assets_Temp");
            SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
            //SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
            sqlconn.Open();
            //sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            oledbconn.Open();
            OleDbDataReader dr = oledbcmd.ExecuteReader();
            DT_Excel.Load(dr);
            DT_DataBase = DT_DataBaseConn.getDT();
            String truncateSql = @" TRUNCATE TABLE Operations_Assets_Temp";
            new DBConnector(truncateSql, "Operations_Assets_Temp");
            foreach (DataRow excelDtRow in DT_Excel.Rows)
            {
                if (excelDtRow["Asset Tag #"].ToString().Length != 0)
                {
                    String sql = @" INSERT INTO Operations_Assets_Temp (" + "\"" + "Asset Tag #" + "\"" + ",Status," + "\"" + "Current Location" + "\"," +
                        "\"" + "Asset Description" + "\"" + ",Model," + "\"" + "Serial #" + "\"," + "\"" + "Dept Number" + "\"," +
                        "\"" + "Department Name" + "\"," +"\"" + "PO Number" + "\"," + "\"" + "Acquisition Date" + "\"," + "Cost) " + "VALUES (('" +
                        //InfoLoader.BuildName2BuildID(excelDtRow["Building"].ToString()) + "'), ('" +
                            excelDtRow["Asset Tag #"].ToString() + "'), ('" +
                            excelDtRow["Status"].ToString() + "'), ('" +
                            excelDtRow["Current Location"].ToString() + "'), ('" +
                            excelDtRow["Asset Description"].ToString().Replace("'", "''") + "'), ('" +
                            excelDtRow["Model"].ToString().Replace("'", "''") + "'), ('" +
                            excelDtRow["Serial #"].ToString().Replace("'", "''") + "'), ('" +
                            excelDtRow["Dept Number"].ToString() + "'), ('" +
                            excelDtRow["Department Name"].ToString().Replace("'", "''") + "'), ('" +
                            excelDtRow["PO Number"].ToString() + "'), ('" +
                            excelDtRow["Acquisition Date"].ToString() + "'), ('" +
                            excelDtRow["Cost"].ToString() + "'))";
                    //Console.WriteLine(sql);
                    new DBConnector(sql, "Operations_Assets_Temp");
                }
            }
            dr.Close();
            oledbconn.Close();
            MessageBox.Show("File imported into sql server.");


        }


    }
}
