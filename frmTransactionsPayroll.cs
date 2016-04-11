using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PECS_v1
{
    public partial class frmTransactionsPayroll : Form
    {

        private readonly int PG_FACULTY = 0;
        private readonly int PG_STAFF = 1;
        private int payrollGroup = 0;

        private NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
        private ListViewColumnSorter lvwColumnSorter_lstPayroll;

        private DBConnector dbcPayroll;
        private String recordCount = "";
        //Collection for lstFunds
        private String[] arrLstFunds;

        //selected items for filtering
        //private String selFund = "";

        private DBConnector dbcTransactions = new DBConnector("SELECT * FROM Transactions", "Transactions");

        public frmTransactionsPayroll()
        {
            InitializeComponent();

            //currency formatting
            nfi = (NumberFormatInfo)nfi.Clone();
            nfi.CurrencySymbol = "";

            loadPage();


        }

        //Load Page

        public void loadPage()
        {
            loadLstPayrollMonths();
            loadLstPayrollGroup();
        }

        //Load lstPayrollGroup
        private void loadLstPayrollGroup()
        {
            ArrayList arrNew = new ArrayList();
            arrNew.Add(new ListValues(PG_FACULTY.ToString(), "FACULTY", ListValues.FORWARD));
            arrNew.Add(new ListValues(PG_STAFF.ToString(), "STAFF", ListValues.FORWARD));

            lstPayrollGroup.DataSource = arrNew;
            lstPayrollGroup.DisplayMember = "Desc";
            lstPayrollGroup.ValueMember = "ID";

            //reset selected payroll group
            payrollGroup = 0;
        }



        //Load lstUnitPayroll
        private void loadLstUnitPayroll()
        {
            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.getPayrollByUnit(txtTransDate.Text, payrollGroup == PG_FACULTY).Split('\n');

            lstUnitPayroll.BeginUpdate();
            lstUnitPayroll.Clear();
            lstUnitPayroll.Columns.Add("UNIT", 70, HorizontalAlignment.Left);
            lstUnitPayroll.Columns.Add("PAYROLL", 106, HorizontalAlignment.Left);

            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');
                if (cols.Length == 2)
                {
                    ListViewItem listItem = new ListViewItem(cols[0]);
                    listItem.Name = cols[0]; // index for record in dbConnector 
                    listItem.SubItems.Add(String.Format(nfi, "{0:c}", double.Parse(cols[1])));
                    lstUnitPayroll.Items.Add(listItem);
                }

            }
            lstUnitPayroll.EndUpdate();
        }


        //Load lstPayrollMonths
        public void loadLstPayrollMonths()
        {
            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadPayrollTransactionsByMonth(InfoLoader.PAYROLL_SALARY);

            lstPayrollMonths.BeginUpdate();
            lstPayrollMonths.Clear();
            lstPayrollMonths.Columns.Add("MONTH", 150, HorizontalAlignment.Left);
            lstPayrollMonths.Columns.Add("# TRANS", 70, HorizontalAlignment.Left);
            lstPayrollMonths.Columns.Add("MM", 0, HorizontalAlignment.Left);
            lstPayrollMonths.Columns.Add("YYYY", 0, HorizontalAlignment.Left);

            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');
                if (cols.Length == 3)
                {
                    ListViewItem listItem = new ListViewItem(UtilityDates.months[int.Parse(cols[0])] + "   " + cols[1]);
                    listItem.Name = cols[0]; // index for Month
                    listItem.SubItems.Add(cols[2]);
                    listItem.SubItems.Add(cols[0]);
                    listItem.SubItems.Add(cols[1]);
                    lstPayrollMonths.Items.Add(listItem);
                }

            }
            lstPayrollMonths.EndUpdate();
        }


        //Load lstGLPayroll
        private void loadLstGLPayroll(bool isFilterByUnit)
        {
            ArrayList arrNew = new ArrayList();
            String[] tmpArray;
            String unit = "";//Should remain empty if no unit is specified


            if (isFilterByUnit)
            {
                unit = lstUnitPayroll.SelectedItems[0].Name;
            }

            String fund = "";
            //try
            if (lstFundPayroll.SelectedItems.Count > 0) //Harry 20151029
            {
                fund = lstFundPayroll.SelectedItems[0].Name;
            }
            //catch (Exception ex)
            //{
            //    //No fund was selected for filtering
            //}


            tmpArray = InfoLoader.getPayrollByGL(txtTransDate.Text, unit, fund, payrollGroup == PG_FACULTY).Split('\n');

            lstGLPayroll.BeginUpdate();
            lstGLPayroll.Clear();
            lstGLPayroll.Columns.Add("Count", 50, HorizontalAlignment.Left);
            lstGLPayroll.Columns.Add("GL", 200, HorizontalAlignment.Left);
            lstGLPayroll.Columns.Add("Payroll", 106, HorizontalAlignment.Left);

            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');
                if (cols.Length == 5)
                {
                    ListViewItem listItem = new ListViewItem(cols[3]);
                    listItem.Name = cols[4]; // GLID for record in dbConnector 
                    listItem.SubItems.Add(cols[0] + "  " + cols[1]);
                    listItem.SubItems.Add(String.Format(nfi, "{0:c}", double.Parse(cols[2])));
                    lstGLPayroll.Items.Add(listItem);
                }

            }
            lstGLPayroll.EndUpdate();
        }

        //Load lstFundPayroll
        private void loadLstFundPayroll(bool isFilterByUnit)
        {


            String unit = "";
            if (isFilterByUnit)
            {
                unit = lstUnitPayroll.SelectedItems[0].Name;
            }

            arrLstFunds = InfoLoader.getPayrollByFund(txtTransDate.Text, unit, payrollGroup == PG_FACULTY).Split('\n');

            lstFundPayroll.BeginUpdate();
            lstFundPayroll.Clear();
            lstFundPayroll.Columns.Add("Count", 50, HorizontalAlignment.Left);
            lstFundPayroll.Columns.Add("Dept ID", 70, HorizontalAlignment.Left);
            lstFundPayroll.Columns.Add("Fund Type", 80, HorizontalAlignment.Left);
            lstFundPayroll.Columns.Add("Project", 70, HorizontalAlignment.Left);
            lstFundPayroll.Columns.Add("Class", 65, HorizontalAlignment.Left);
            lstFundPayroll.Columns.Add("Payroll", 80, HorizontalAlignment.Left);

            for (int i = 0; i < arrLstFunds.Length; i++)
            {
                String[] cols = arrLstFunds[i].Split('\t');
                if (cols.Length == 7)
                {
                    ListViewItem listItem = new ListViewItem(cols[6]);
                    listItem.Name = cols[0]; // index for record in dbConnector 
                    listItem.SubItems.Add(cols[2]);
                    listItem.SubItems.Add(cols[1]);
                    listItem.SubItems.Add(cols[3]);
                    listItem.SubItems.Add(cols[4]);
                    listItem.SubItems.Add(String.Format(nfi, "{0:c}", double.Parse(cols[5])));
                    lstFundPayroll.Items.Add(listItem);
                }

            }
            lstFundPayroll.EndUpdate();
        }









        //Methods

        //fill dbcPayroll

        private void fillDBCPayroll()
        {
            lblPendingPayrollCount.Text = "     ";
            if (!UtilityDates.isDate(txtTransDate.Text))
            {
                MessageBox.Show("The transaction date does not appear to be a valid date");
                return;
            }

            String sql = @" SELECT  Employees.EmpNameFirst, 
                                    Employees.EmpNameLast, 
                                    Employees.EmpID,
                                    Employees.UnitID, 
                                    Employees.EmpUIN, 
                                    refAppointmentType.EmpAppTypeDesc,
                                    Employees_Appointments.EmpAppointPrimaryFund, 
                                    Employees_Appointments.EmpAppointSalary, 
                                    Employees_Appointments.EmpAppointTimeBase, 
                                    Employees_Appointments.EmpAppointFTCompRate, 
                                    Employees_Appointments.JobCodeID, 
                                    CONVERT(nvarchar(10), Employees_Appointments.EmpAppointDateBegin, 101) AS EtracDateStart, 
                                    CONVERT(nvarchar(10), Employees_Appointments.EmpAppointDateEnd, 101) AS EtracDateEnd,
			                        CONVERT(nvarchar(10), Employees_Appointments.EmpAppointPayrollDateStart, 101) AS PayrollDateStart,
			                        CONVERT(nvarchar(10), Employees_Appointments.EmpAppointPayrollDateEnd,101) AS PayrollDateEnd,
                                    Employees_Appointments.EmpAppointEtrac, 
                                    Employees_Appointments.EmpAppointPositionNum,
                                    Employees_Appointments.EmpAppointID, 
                                    Employees_JobCodes.JobCodeGLID, 
                                    Employees_Appointments.TransFundID, 
                                    Employees.EmpTypeID, 
                                    refEmployeeType.EmpTypeDesc, 
                                    Transactions_Funding.DeptID,
                                    Transactions_Funding.FundType, 
                                    Transactions_Funding.FundProject + Transactions_Funding.FundClass AS FundProjClass, 
                                    Transactions_GLs.GLNumber
                            FROM    Employees_Appointments INNER JOIN
                                    Employees ON Employees_Appointments.EmpID = Employees.EmpID INNER JOIN
                                    Employees_JobCodes ON Employees_Appointments.JobCodeID = Employees_JobCodes.JobCodeID INNER JOIN
                                    refAppointmentType ON Employees_Appointments.EmpAppTypeID = refAppointmentType.EmpAppTypeID INNER JOIN
                                    refEmployeeType ON Employees.EmpTypeID = refEmployeeType.EmpTypeID INNER JOIN
                                    Transactions_Funding ON Employees_Appointments.TransFundID = Transactions_Funding.TransFundID INNER JOIN
                                    Transactions_GLs ON Employees_JobCodes.JobCodeGLID = Transactions_GLs.GLID
                            WHERE   (Employees_Appointments.EmpAppointPayrollDateStart <= CONVERT(DATETIME, '" + txtTransDate.Text + @"', 102)) AND 
                                    (Employees_Appointments.EmpAppointPayrollDateEnd >= CONVERT(DATETIME, '" + txtTransDate.Text + @"', 102)) AND 
                                    Employees_JobCodes.JobCodeHourly = 1 AND 
                                    Employees.UnitID <> 'OTHER' AND 
                                    Employees_Appointments.EmpAppTypeID <> 6 AND
                                    Employees_JobCodes.JobCodeGL <> '000000' AND 
                                    EmpAppointSalary > 0 AND
                                    Employees.EmpTypeID = " + payrollGroup;

            //Console.WriteLine("\n[283]\n [{0}]", sql);
            if (lstUnitPayroll.SelectedItems.Count > 0) //Harry 20151029
            // if (isUnitSelected())
            {
                sql += " AND Employees.UnitID = '" + lstUnitPayroll.SelectedItems[0].Name + "'";
            }
            if (lstFundPayroll.SelectedItems.Count > 0) //Harry 20151029
            // if (isFundSelected())
            {
                //If fund is provided from form, append to query to filter for specified unit
                sql += " AND Employees_Appointments.TransFundID = " + lstFundPayroll.SelectedItems[0].Name.ToString() + " ";
            }
            if (lstGLPayroll.SelectedItems.Count > 0) //Harry 20151029
            // if (isGLSelected())
            {
                //If fund is provided from form, append to query to filter for specified unit
                sql += " AND Transactions_GLs.GLID = " + lstGLPayroll.SelectedItems[0].Name.ToString() + " ";
            }


            //add order to sql
            sql += " ORDER BY Employees_JobCodes.JobCodeGL,Employees.EmpNameLast";

            dbcPayroll = new DBConnector(sql, "Appointments");

        }


        private void loadLstPayroll()
        {
            try
            {
                // Create an instance of a ListView column sorter and assign it 
                // to the ListView control.
                lvwColumnSorter_lstPayroll = new ListViewColumnSorter();
                this.lstPayroll.ListViewItemSorter = lvwColumnSorter_lstPayroll;

                fillDBCPayroll();

                lstPayroll.BeginUpdate();
                lstPayroll.Clear();
                buildLstPayrollColumns();

                int recordCount = 0;
                foreach (DataRow row in dbcPayroll.getDT().Rows)
                {
                    ListViewItem listItem = new ListViewItem(row["EmpNameFirst"].ToString() + " " + row["EmpNameLast"].ToString());
                    listItem.Name = recordCount + "!" + row["EmpAppointID"].ToString(); // index for record in dbConnector + empAppointID
                    listItem.SubItems.Add(row["UnitID"].ToString());
                    listItem.SubItems.Add(row["EmpTypeDesc"].ToString());
                    listItem.SubItems.Add(row["EmpAppTypeDesc"].ToString());
                    listItem.SubItems.Add(row["DeptID"].ToString());
                    listItem.SubItems.Add(row["FundType"].ToString());
                    listItem.SubItems.Add(row["FundProjClass"].ToString());
                    listItem.SubItems.Add(String.Format(nfi, "{0:c}", double.Parse(row["EmpAppointFTCompRate"].ToString())));
                    listItem.SubItems.Add(String.Format("{0:0.##}", row["EmpAppointTimeBase"].ToString()));
                    listItem.SubItems.Add(String.Format(nfi, "{0:c}", double.Parse(row["EmpAppointSalary"].ToString())));
                    listItem.SubItems.Add(row["JobCodeID"].ToString());
                    listItem.SubItems.Add(row["PayrollDateStart"].ToString());
                    listItem.SubItems.Add(row["PayrollDateEnd"].ToString());
                    listItem.SubItems.Add(row["EmpAppointPositionNum"].ToString());
                    listItem.SubItems.Add(row["GLNumber"].ToString());
                    listItem.SubItems.Add(row["EtracDateStart"].ToString());
                    listItem.SubItems.Add(row["EtracDateEnd"].ToString());
                    //SORT COLUMNS
                    listItem.SubItems.Add(UtilityDates.convertFormatedDateToSortableString(row["PayrollDateStart"].ToString()));
                    listItem.SubItems.Add(UtilityDates.convertFormatedDateToSortableString(row["PayrollDateEnd"].ToString()));
                    listItem.SubItems.Add(row["EmpAppointFTCompRate"].ToString().PadLeft(12, '0'));
                    listItem.SubItems.Add(row["EmpAppointSalary"].ToString().PadLeft(12, '0'));
                    listItem.SubItems.Add(row["EmpNameLast"].ToString());
                    lstPayroll.Items.Add(listItem);
                    recordCount++; // get count of records added to lstPayroll
                }

                lstPayroll.EndUpdate();
                lblPendingPayrollCount.Text = recordCount.ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }




        private void buildLstPayrollColumns()
        {
            lstPayroll.Columns.Add("Name", 200, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("Unit", 100, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("Employee", 100, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("Appt Type", 100, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("Dept ID", 70, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("Fund", 70, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("Proj/Class", 50, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("FTB", 70, HorizontalAlignment.Center);
            lstPayroll.Columns.Add("TB", 80, HorizontalAlignment.Center);
            lstPayroll.Columns.Add("Salary", 100, HorizontalAlignment.Center);
            lstPayroll.Columns.Add("Job Code", 80, HorizontalAlignment.Center);
            lstPayroll.Columns.Add("Payroll Start", 100, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("Payroll End", 100, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("Position Num", 100, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("GL", 90, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("Start Date", 100, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("End Date", 100, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("SortDateStart", 0, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("SortDateEnd", 0, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("SortCompRate", 0, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("SortSalary", 0, HorizontalAlignment.Left);
            lstPayroll.Columns.Add("SortLastName", 0, HorizontalAlignment.Left);
        }


        //Make sure all employees are registered as vendors in the database
        private void addEmpToVendors()
        {
            dbcPayroll = new DBConnector("SELECT * FROM Vendors", "Vendors");
            dbcPayroll.executeSQL(@"  INSERT INTO Vendors (VendName, EmpID)
                                                SELECT  Employees.EmpNameFirst + ' ' + 
                                                        Employees.EmpNameLast AS Expr1, Employees.EmpID
                                                FROM    Vendors AS Vendors_1 RIGHT OUTER JOIN
                                                        Employees ON Vendors_1.EmpID = Employees.EmpID
                                                WHERE     (Vendors_1.EmpID IS NULL)");
        }






        //collect all employees with active appointments spanning the supplied transaction date
        private void collectAppointments()
        {

            //Check for null payroll dates
            String[] errors = InfoLoader.getAppointmentsWithNullPayrollDates().Split('\n');
            if (int.Parse(errors[0]) != 0)
            {
                String errMsg = "The following appointments are missing payroll dates and prevent running payroll:\n\n";
                for (int i = 1; i < errors.Length; i++)
                {

                    String[] cols = errors[i].Split('\t');

                    if (cols.Length == 10)
                    {
                        errMsg += "Position Number " + cols[9] + " for employee " + cols[0] + " ( " + cols[7] + "-" + cols[8] + " Job Code: " + cols[2] + ")\n\n";
                    }

                }
                MessageBox.Show(errMsg);
                cmdRunTransactions.Enabled = true;
                return;
            }

            //Check for funding problems
            errors = InfoLoader.getAppointmentsWithNullTransFundID().Split('\n');
            if (int.Parse(errors[0]) != 0)
            {
                String errMsg = "The following appointments are missing a valid funding source and prevent running payroll:\n\n";
                for (int i = 1; i < errors.Length; i++)
                {

                    String[] cols = errors[i].Split('\t');

                    if (cols.Length == 10)
                    {
                        errMsg += "Position Number " + cols[9] + " for employee " + cols[0] + " ( " + cols[7] + "-" + cols[8] + " Job Code: " + cols[2] + ")\n\n";
                    }

                }
                MessageBox.Show(errMsg);
                cmdRunTransactions.Enabled = true;
                return;
            }



            //Clear filtering selections
            clearAllSelections();
            fillDBCPayroll();
            int recordsCreated = 0;

            //Loop through appointments to create transactions

            SqlCommandBuilder commBuilder = new SqlCommandBuilder(dbcTransactions.getDA());


            //Make sure that all TransSubTypes match
            int transTypeSubID;
            //int a = 0;
            foreach (DataRow row in dbcPayroll.getDT().Rows)
            {
                //Console.WriteLine(a++);
                transTypeSubID = InfoLoader.getTransSubTypeByGL(row["JobCodeGLID"].ToString());
                if (transTypeSubID == 0)
                {
                    MessageBox.Show("There was an error processing this payroll request. The following GL is not associated with a Transaction Sub Type:\n" +
                        InfoLoader.getGLFromID(row["JobCodeGLID"].ToString()));
                    cmdRunTransactions.Enabled = true;
                    return;
                }
            }
            //------------------------------------------------------

            //Console.WriteLine("dbcPayroll.getDT().Rows: [{0}]", dbcPayroll.getDT().Rows.Count.ToString());
            String sql = "SELECT * FROM ActivityLog";
            DBConnector log = new DBConnector(sql, "ActivityLog");
            //int b = 0;
            DateTime transDate = DateTime.Parse(txtTransDate.Text);
            String nowS = DateTime.Now.ToShortDateString();
            DateTime now = DateTime.Now;
            //[Bao] NextTransRelatedID !!!!!!!!!!!!!!!!!!!!
            int nextTransRElatedID = InfoLoader.getNextTransRelatedID();

            String userName = UserProfile.getUserName();
            int tableID = InfoLoader.TABLE_TRANSACTIONS;
            //int actRowID = InfoLoader.getLatestTransID();
            int empID = UserProfile.getUserID();
            int actTypeID = Activities.ACT_T_NEW;
            String actDesc = InfoLoader.getTransType(5) + " TRANSACTION CREATED";
            //------------------------------------------------------
            foreach (DataRow row in dbcPayroll.getDT().Rows)
            {
                //Console.WriteLine(b++);
                transTypeSubID = InfoLoader.getTransSubTypeByGL(row["JobCodeGLID"].ToString());

                // Should be INCREASE HERE !!!!!!!
                nextTransRElatedID = nextTransRElatedID + 1;

                try
                {

                    //CREATE NEW RECORD
                    DataRow newRow = dbcTransactions.getDT().NewRow();
                    int getVendID = int.Parse(InfoLoader.getVendIDFromEmpID(int.Parse(row["EmpID"].ToString())));
                    newRow["TransStatusID"] = 11;
                    newRow["refTransTypeID"] = 5;
                    newRow["refTransTypeSubID"] = transTypeSubID;
                    newRow["TransFundID"] = int.Parse(row["TransFundID"].ToString());
                    newRow["TransPayeeID"] = getVendID;
                    newRow["TransVendID"] = getVendID;
                    newRow["UnitID"] = row["UnitID"].ToString();
                    newRow["TransDatePosting"] = transDate;
                    newRow["TransDateTransaction"] = transDate;
                    newRow["TransAmount"] = double.Parse(row["EmpAppointSalary"].ToString());
                    newRow["TransAmountRemainder"] = 0;
                    newRow["GLID"] = row["JobCodeGLID"].ToString();
                    newRow["TransDesc"] = "PAYROLL";
                    newRow["TransRelatedID"] = nextTransRElatedID;
                    newRow["TransCreatedUser"] = userName;
                    newRow["TransCreatedDate"] = nowS;

                    dbcTransactions.getDT().Rows.Add(newRow);

                    //newRow["TransRelatedID"] = nextTransRElatedID;

                    //Add Creation Notice to Activity Log
                    //Activities.addActivity(InfoLoader.TABLE_TRANSACTIONS,
                    //                    InfoLoader.getLatestTransID(),
                    //                    UserProfile.getUserID(),
                    //                    Activities.ACT_T_NEW,
                    //                    InfoLoader.getTransType(5) + " TRANSACTION CREATED");
                    //Activities.addActivityTrans(tableID, actRowID++, empID, actTypeID, actDesc, log, now);
                    Activities.addActivityTrans(tableID, nextTransRElatedID, empID, actTypeID, actDesc, log, now);

                }
                catch (Exception ex) // copy transaction errors to payroll error table
                {
                    MessageBox.Show("ERROR: " + ex.ToString());
                }
                recordsCreated++;
            }

            dbcTransactions.getDA().Update(dbcTransactions.getDS(), "Transactions");

            SqlCommandBuilder commBuilder2 = new SqlCommandBuilder(log.getDA());
            //Update database with new information from data table
            log.getDA().Update(log.getDS().Tables[0]);

            MessageBox.Show(recordsCreated + " payroll transactions were created for " + lstPayrollGroup.Text);
            loadPage();
            cmdRunTransactions.Enabled = true;
        }






        //Load all basic pending payroll transactions
        private void loadPendingPayroll()
        {
            //Load Payroll by Unit
            loadLstUnitPayroll();

            //Load Payroll by GL
            loadLstGLPayroll(false);

            //Load Payroll by Fund
            loadLstFundPayroll(false);

            //Load All individual payroll entries for pending insert into transactions table
            fillDBCPayroll();
            loadLstPayroll();
        }


        //method to set payroll group
        private void setPayrollGroup(int groupIndex)
        {
            payrollGroup = groupIndex;
        }



        //check to see if various filter controls are loaded
        private bool isGLSelected()
        {
            bool isGLSelected = false;
            try
            {
                lstGLPayroll.SelectedItems[0].Name.ToString();
                isGLSelected = true;
            }
            catch (Exception ex)
            {
                //lstGLPayroll has nothing selected
            }
            return isGLSelected;
        }

        private bool isUnitSelected()
        {
            bool isUnitSelected = false;
            try
            {
                lstUnitPayroll.SelectedItems[0].Name.ToString();
                isUnitSelected = true;
            }
            catch (Exception ex)
            {
                //lstGLPayroll has nothing selected
            }
            return isUnitSelected;
        }

        private bool isFundSelected()
        {
            bool isFundSelected = false;
            try
            {
                lstFundPayroll.SelectedItems[0].Name.ToString();
                isFundSelected = true;
            }
            catch (Exception ex)
            {
                //lstGLPayroll has nothing selected
            }
            return isFundSelected;
        }

        //Clear all selections in preparation for running payroll
        private void clearAllSelections()
        {
            lstGLPayroll.SelectedItems.Clear();
            lstUnitPayroll.SelectedItems.Clear();
            lstFundPayroll.SelectedItems.Clear();

        }













        //EVENTS

        private void lstPayroll_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            int sortColumn = e.Column;
            //if user clicks on Date start column to sort, direct sort to datestartsort column 
            if (sortColumn == 11)
            {
                sortColumn = 17;
            }
            //if user clicks on Date End column  to sort, direct sort to dateendsort column 
            if (sortColumn == 12)
            {
                sortColumn = 18;
            }
            //if user clicks on FTC column to sort, direct sort to sortFTC column 
            if (sortColumn == 7)
            {
                sortColumn = 19;
            }
            //if user clicks on Salary column  to sort, direct sort to SortSalary column 
            if (sortColumn == 9)
            {
                sortColumn = 20;
            }
            //if user clicks on Name column  to sort, direct sort to SortLastName column 
            if (sortColumn == 0)
            {
                sortColumn = 21;
            }

            // Determine if clicked column is already the column that is being sorted.
            if (sortColumn == lvwColumnSorter_lstPayroll.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter_lstPayroll.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter_lstPayroll.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter_lstPayroll.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter_lstPayroll.SortColumn = sortColumn;
                lvwColumnSorter_lstPayroll.Order = System.Windows.Forms.SortOrder.Ascending;
            }



            // Perform the sort with these new sort options.
            lstPayroll.Sort();
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdRunTransactions_Click(object sender, EventArgs e)
        {
            //Make sure that a date was selected
            if (!UtilityDates.isDate(txtTransDate.Text))
            {
                MessageBox.Show("The transaction date does not appear to be a valid date");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            addEmpToVendors();
            checkBeforeRun();
            //loadLstErrors();
            this.Cursor = Cursors.Default;
        }

        private void checkBeforeRun()
        {
            if (MessageBox.Show("Record Count:" + recordCount + " \r\nDo you want to continue?", "Run Payroll",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes)
            {
                cmdRunTransactions.Enabled = false;
                collectAppointments();
            }
        }

        private void cmdViewPayroll_Click(object sender, EventArgs e)
        {
            //Make sure that a date was selected
            if (!UtilityDates.isDate(txtTransDate.Text))
            {
                MessageBox.Show("The transaction date does not appear to be a valid date");
                return;
            }
            loadPendingPayroll();
        }

        private void lstUnitPayroll_Click(object sender, EventArgs e)
        {
            //Load Payroll by GL
            loadLstGLPayroll(true);
            //load lstPayroll by selected unit

            loadLstPayroll();
            //Load Payroll by Fund
            loadLstFundPayroll(true);
        }

        private void cmdClearUnitSelection_Click(object sender, EventArgs e)
        {
            loadPendingPayroll();
        }

        private void lstPayrollGroup_Click(object sender, EventArgs e)
        {
            setPayrollGroup(int.Parse(lstPayrollGroup.SelectedValue.ToString()));
            loadPendingPayroll();
            recordCount = lblPendingPayrollCount.Text;
        }

        private void lstPayrollMonths_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ListViewItem item = ((ListView)sender).SelectedItems[0];

            //[Bao 10/08/2015]txtTransDate.Text = item.SubItems[2].Text + "/20/" + item.SubItems[3].Text; 
            //[Harry 10/29/2015]txtTransDate.Text = item.SubItems[2].Text + "/30/" + item.SubItems[3].Text;
            txtTransDate.Text = item.SubItems[2].Text + "/"
           + DateTime.DaysInMonth(Int32.Parse(item.SubItems[3].Text), Int32.Parse(item.SubItems[2].Text)) + "/"
           + item.SubItems[3].Text;

            loadPendingPayroll();
            this.Cursor = Cursors.Default;
            recordCount = lblPendingPayrollCount.Text;

        }

        private void cmdHourlyPayroll_Click(object sender, EventArgs e)
        {

            frmTransactionsPayrollHourly frmPayrollHourly = new frmTransactionsPayrollHourly();
            frmPayrollHourly.MdiParent = frmSwitchboard.frmParent;
            frmPayrollHourly.Show();
        }

        private void cmdSummerPayroll_Click(object sender, EventArgs e)
        {
            frmTransactionsPayrollSummer frmPayrollSummer = new frmTransactionsPayrollSummer();
            frmPayrollSummer.MdiParent = frmSwitchboard.frmParent;
            frmPayrollSummer.Show();
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Clipboard.SetText(UtilityRighClick.dataToCopyPasteBufferAll(dbcPayroll.getDT()));
            this.Cursor = Cursors.Default;
        }

        private void copySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String selectedIndices = "";
            for (int i = 0; i < lstPayroll.SelectedItems.Count; i++)
            {
                if (i != 0) { selectedIndices += "\t"; } //add column delimiter
                String wholeName = lstPayroll.SelectedItems[i].Name.ToString();
                selectedIndices += wholeName.Substring(0, wholeName.IndexOf('!'));
            }

            Clipboard.SetText(UtilityRighClick.dataToCopyPasteBufferSelected(dbcPayroll.getDT(), selectedIndices.Split('\t')));
        }

        private void cmsLstFundCopyAll_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ArrayList arrTemp = new ArrayList();
            arrTemp.Add("TransFundID\tFund\tDept\tProject\tClass\tSalary\tCount");
            arrTemp.AddRange(arrLstFunds);
            Clipboard.SetText(UtilityRighClick.dataToCopyPasteBufferAll(arrTemp));
            this.Cursor = Cursors.Default;
        }

        private void cmsLstFundsCopySelected_Click(object sender, EventArgs e)
        {

        }

        private void lstFundPayroll_Click(object sender, EventArgs e)
        {

            loadLstGLPayroll(isUnitSelected());
            loadLstPayroll();
        }



        private void lstGLPayroll_Click(object sender, EventArgs e)
        {
            loadLstPayroll();
        }

        private void lstPayroll_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = ((ListView)sender).SelectedItems[0];
            String[] wholeName = item.Name.ToString().Split('!');
            frmEmployee frmEmp = new frmEmployee(InfoLoader.getEmpIDfromAppointID(wholeName[1]));
            frmEmp.MdiParent = frmSwitchboard.frmParent;
            frmEmp.Show();
        }

        private void calculateSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txttemsCalc.Text = String.Format(nfi, "{0:c}", UtilityRighClick.calcSelected(lstPayroll.SelectedItems, 9));
        }

        private void cmdRunByFund_Click(object sender, EventArgs e)
        {
            if (UtilityDates.isDate(txtTransDate.Text))
            {
                frmTransactionsPayrollByApptType frmPayByFund = new frmTransactionsPayrollByApptType(txtTransDate.Text, lstPayrollGroup.SelectedValue.ToString(), this);
                //frmPayByFund.MdiParent = frmSwitchboard.frmParent;
                frmPayByFund.Show();
            }
            else
            {
                MessageBox.Show("You must first select a target month for payroll processing.");
            }
        }

        private void cmdDelPayroll_Click(object sender, EventArgs e)
        {
            frmTransactionsPayrollEdit frmPayEdit = new frmTransactionsPayrollEdit(this);
            frmPayEdit.Show();
        }


    }
}


