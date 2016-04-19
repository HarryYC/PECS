using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace PECS_v1
{
    public partial class frmReportsTransactionQueries : Form
    {
        private NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
        private ListViewColumnSorter lvwColumnSorter;
        private DBConnector dbcTransactions;
        bool isCmboGLFilterLoaded = false;
        bool isCmboFYLoaded = false;
       bool isLstFundTypeOnlyVisible = false;
  
        bool isLstFund2TypeOnlyVisible = false;

        //Search Criteria
        private String selectedTransType;
        private String selectedTransSubType;
        private String selectedUnitID;
        private String selectedTransFundID;
        private String selectedTransPayeeID;
        private String selectedGLID;
        private String selectedStatusID;
        private String selectedFundType;
        private String selectedFund2Type;
        public String vSql = "";
        public String vFundTypeSql = "";
        

        public frmReportsTransactionQueries()
        {
            InitializeComponent();

            //Load currency format
            nfi = (NumberFormatInfo)nfi.Clone();
            nfi.CurrencySymbol = "";

            loadPage();

            
        }

        //Find criteria for loading requested Transactions
        private void loadDBCTransactions()
        {
            this.Cursor = Cursors.WaitCursor; //Harry add Vendors.EmpID 01062016
            String sql = @" SELECT  Transactions.TransID, 
                                    Transactions_Funding.UnitID as theUnitID,
                                    CONVERT(VARCHAR(10), Transactions.TransDatePosting, 101) AS PostingDate, 
                                    CONVERT(VARCHAR(10), Transactions.TransDateTransaction, 101) AS TransactionDate, 
                                    Transactions.TransAmount, 
                                    Transactions.TransAmountRemainder, 
                                    Transactions.TransDesc,  
                                    Transactions_Funding.FundType, 
                                    Transactions_Funding.DeptID,
                                    Transactions_Funding.FundProject,
                                    Transactions_Funding.FundClass, 
                                    Transactions_GLs.GLNumber AS GL, 
                                    refTransactionTypes.refTransTypeDesc, 
                                    refTransactionTypesSub.refTransTypeSubDesc, 
                                    Transactions.TransBiReference, 
                                    refStatus.StatusDesc, 
                                    Vendors.VendName,
                                    (SELECT EmpUIN FROM Employees WHERE EmpID = Vendors.EmpID) AS EmpUIN,
									Vendors.EmpID
                            FROM    Transactions INNER JOIN
                                    refStatus ON Transactions.TransStatusID = refStatus.StatusID INNER JOIN
                                    Vendors ON Transactions.TransPayeeID = Vendors.VendID INNER JOIN
                                    refTransactionTypes ON Transactions.refTransTypeID = refTransactionTypes.refTransTypeID INNER JOIN
                                    refTransactionTypesSub ON Transactions.refTransTypeSubID = refTransactionTypesSub.refTransTypeSubID INNER JOIN
                                    Transactions_Funding ON Transactions.TransFundID = Transactions_Funding.TransFundID INNER JOIN
                                    Transactions_GLs ON Transactions.GLID = Transactions_GLs.GLID
                                    ";

            //Filter by transaction criteria

            

            if (cmboFY.SelectedValue.ToString().Length > 0)
            {
                sql += appendSQLwithWHEREorAND(sql) + " Transactions.TransDatePosting >= CONVERT(DATETIME, '" + cmboFY.SelectedValue.ToString() + @"-07-01 00:00:00', 102) AND Transactions.TransDatePosting < CONVERT(DATETIME, '" + (int.Parse(cmboFY.SelectedValue.ToString()) + 1) + @"-07-01 00:00:00', 102) "; 
            }
            
            if (cmboGLFilter.SelectedValue.ToString().Length>0)
            {
                sql += appendSQLwithWHEREorAND(sql) + " CONVERT(varchar(6),TransDatePosting,112) = '" + cmboGLFilter.SelectedValue.ToString() + "'";
            }

            if (selectedTransType.Length > 0)
            {
                sql += appendSQLwithWHEREorAND(sql) + "Transactions.refTransTypeID = " + selectedTransType;
            }

            if (selectedTransSubType.Length > 0)
            {
                sql += appendSQLwithWHEREorAND(sql) + "Transactions.refTransTypeSubID = " + selectedTransSubType;
            }

            if (selectedUnitID.Length > 0)
            {
                sql += appendSQLwithWHEREorAND(sql) + "Transactions_Funding.UnitID = '" + selectedUnitID + "'";
            }

            if (vFundTypeSql.Length > 0)
            {
                sql += appendSQLwithWHEREorAND(sql) + vFundTypeSql;
            }



 

            
            if (selectedTransPayeeID.Length > 0)
            {
                sql += appendSQLwithWHEREorAND(sql) + "Transactions.TransPayeeID = " + selectedTransPayeeID;
            }
            
            if (selectedGLID.Length > 0)
            {
                sql += appendSQLwithWHEREorAND(sql) + "Transactions.GLID = " + selectedGLID;
            }
            
            if (selectedStatusID.Length > 0)
            {
                sql += appendSQLwithWHEREorAND(sql) + "Transactions.TransStatusID = " + selectedStatusID;
            }

            
//vSql = sql;
// MessageBox.Show(vSql, "loadDBCTransactions", MessageBoxButtons.OKCancel);

            dbcTransactions = new DBConnector(sql, "Transactions");
            

            //Display new rows form dbcTransactions
            loadlstTransactions();
        }


        private String appendSQLwithWHEREorAND(String sql)
        {
            if (sql.Contains("WHERE"))
            {
                return " AND ";
            }
            else
            {
                return " WHERE ";
            }
        }

        private void loadResetPage()
        {
            loadLstTransTypes();
            loadLstTransSubTypes();
            loadLstUnits();
            loadLstTransFunding();
            loadLstGLs();
            loadLstTransPayees();
            loadLstTransStatus();
            loadLstTransFundType();
            loadLstTrans2FundType();
        }


        //Load Query Boxes
        private void loadPage()
        {
            
            loadLstTransTypes();
            loadLstTransSubTypes();
            loadLstUnits();
            loadLstTransFunding();
            loadLstGLs();
            loadLstTransPayees();
            loadLstTransStatus();
            loadCmboFY();
            loadCmboGLFilter();
            loadLstTransFundType();
            loadLstTrans2FundType();

            //display requested transactions
            loadDBCTransactions();
        }

        //Load cmboFY

        private void loadCmboFY()
        {

            ArrayList arrNew = new ArrayList();
     //       arrNew.Add(new ListValues("", "ALL FYs", ListValues.FORWARD));

            for (int i = UtilityDates.getCurrentFiscalYear(); i >= 2008; i--)
            {
                arrNew.Add(new ListValues(i.ToString(), i.ToString(), ListValues.FORWARD));
            }

            cmboFY.DataSource = arrNew;
            cmboFY.DisplayMember = "Desc";
            cmboFY.ValueMember = "ID";
            cmboFY.SelectedIndex = 0; // selects current fy which is always the second item on the list
            isCmboFYLoaded = true;
        }

        // load cmboGLFilter
        private void loadCmboGLFilter()
        {

            ArrayList arrNew = new ArrayList();
            int currentFY = UtilityDates.getCurrentFiscalYear();

            arrNew.Add(new ListValues("", "YTD", ListValues.FORWARD));
            arrNew.Add(new ListValues((int.Parse(cmboFY.SelectedValue.ToString()) + 1).ToString() + "01", "January", ListValues.FORWARD));
            arrNew.Add(new ListValues((int.Parse(cmboFY.SelectedValue.ToString()) + 1).ToString() + "02", "February", ListValues.FORWARD));
            arrNew.Add(new ListValues((int.Parse(cmboFY.SelectedValue.ToString()) + 1).ToString() + "03", "March", ListValues.FORWARD));
            arrNew.Add(new ListValues((int.Parse(cmboFY.SelectedValue.ToString()) + 1).ToString() + "04", "April", ListValues.FORWARD));
            arrNew.Add(new ListValues((int.Parse(cmboFY.SelectedValue.ToString()) + 1).ToString() + "05", "May", ListValues.FORWARD));
            arrNew.Add(new ListValues((int.Parse(cmboFY.SelectedValue.ToString()) + 1).ToString() + "06", "June", ListValues.FORWARD));
            arrNew.Add(new ListValues(cmboFY.SelectedValue.ToString() + "07", "July", ListValues.FORWARD));
            arrNew.Add(new ListValues(cmboFY.SelectedValue.ToString() + "08", "August", ListValues.FORWARD));
            arrNew.Add(new ListValues(cmboFY.SelectedValue.ToString() + "09", "September", ListValues.FORWARD));
            arrNew.Add(new ListValues(cmboFY.SelectedValue.ToString() + "10", "October", ListValues.FORWARD));
            arrNew.Add(new ListValues(cmboFY.SelectedValue.ToString() + "11", "Novermber", ListValues.FORWARD));
            arrNew.Add(new ListValues(cmboFY.SelectedValue.ToString() + "12", "December", ListValues.FORWARD));

            cmboGLFilter.DataSource = arrNew;
            cmboGLFilter.DisplayMember = "Desc";
            cmboGLFilter.ValueMember = "ID";
            cmboGLFilter.SelectedIndex = 0; // selects Fiscal year to date
            isCmboGLFilterLoaded = true;
        }

        private void loadLstTransTypes()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstTransactions.ListViewItemSorter = lvwColumnSorter;

            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadTransTypes(false).Split('\n'); //false = non-utility trans types
            selectedTransType = "";

            lstTransTypes.BeginUpdate();
            lstTransTypes.Clear();
            lstTransTypes.Columns.Add("Trans Type", 140, HorizontalAlignment.Left);
            lstTransTypes.Columns.Add("_SortTransType", 0, HorizontalAlignment.Left);

            //Add "All Trans Types" option
            ListViewItem listItem = new ListViewItem("ALL TYPES");
            listItem.Name = "";
            lstTransTypes.Items.Add(listItem);

            //Add results from TransTypes query
            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');
                if(cols.Length==2)
                {
                    listItem = new ListViewItem(cols[1]);
                    listItem.Name = cols[0];
                    lstTransTypes.Items.Add(listItem);
                }
            }
            lstTransTypes.EndUpdate();
        }

        
        //Load lstTransSubTypes
        private void loadLstTransSubTypes()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstTransSubTypes.ListViewItemSorter = lvwColumnSorter;

            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadTransSubTypes(selectedTransType, false).Split('\n'); //false = non-utility trans types
            selectedTransSubType = "";

            lstTransSubTypes.BeginUpdate();
            lstTransSubTypes.Clear();
            lstTransSubTypes.Columns.Add("Trans Sub Type", 160, HorizontalAlignment.Left);
            lstTransSubTypes.Columns.Add("_SortTransSubType", 0, HorizontalAlignment.Left);

            //Add results from TransTypes query
            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');
                if (cols.Length == 2)
                {
                    ListViewItem listItem = new ListViewItem(cols[1]);
                    listItem.Name = cols[0];
                    lstTransSubTypes.Items.Add(listItem);
                }
            }
            lstTransSubTypes.EndUpdate();
        }

        private void loadLstUnits()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstUnits.ListViewItemSorter = lvwColumnSorter;

            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadUnits(true).Split('\n'); //do not include "OTHER"
            selectedUnitID = "";

            lstUnits.BeginUpdate();
            lstUnits.Clear();
            lstUnits.Columns.Add("Units", 75, HorizontalAlignment.Left);
            lstUnits.Columns.Add("_SortUnits", 0, HorizontalAlignment.Left);

            //Add "All Units" option
                 ListViewItem listItem = new ListViewItem("ALL UNITS");
                  listItem.Name = "";
                   lstUnits.Items.Add(listItem);

                  //Add results from Units query
                    for (int i = 0; i < tmpArray.Length; i++)
                    {
                        if(tmpArray[i].Trim().Length>0)
                        {
                            listItem = new ListViewItem(tmpArray[i]);
                            listItem.Name = tmpArray[i];
                            lstUnits.Items.Add(listItem);
                        }
                    }
                    lstUnits.EndUpdate();
           
   
 

        
          }



        private void loadLstTransFunding()
        {

            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstTransFunding.ListViewItemSorter = lvwColumnSorter;


            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadTransFunding(getLstUnitsSelection()).Split('\n');
            selectedTransFundID = "";

            lstTransFunding.BeginUpdate();
            lstTransFunding.Clear();
            lstTransFunding.Columns.Add("Trans Funding", 205, HorizontalAlignment.Left);
            lstTransFunding.Columns.Add("_SortTransFund", 0, HorizontalAlignment.Left);

            //Add "All Funds" option
            ListViewItem listItem = new ListViewItem("ALL FUNDS");
            listItem.Name = "";
            lstTransFunding.Items.Add(listItem);

            //Add results from Funds query
            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');
                
                if (cols.Length == 7)
                {
                    listItem = new ListViewItem(makeFundingString(cols));
                    listItem.Name = cols[0];
                    lstTransFunding.Items.Add(listItem);
                }
            }
            lstTransFunding.EndUpdate();
        }

        private void loadLstTransFundType()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstFundType.ListViewItemSorter = lvwColumnSorter;

            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadFundTypes(10, cmboFY.SelectedValue.ToString()).Split('\n');
            lstFundType.BeginUpdate();
            lstFundType.Clear();
            lstFundType.Columns.Add("Trans Funding", 200, HorizontalAlignment.Left);
            lstFundType.Columns.Add("_SortFundType", 0, HorizontalAlignment.Left);

            //Add "All Funds" option
            ListViewItem listItem = new ListViewItem("ALL");
            listItem.Name = "";
            lstFundType.Items.Add(listItem);

            //Add results from Funds query
            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');

                if (cols[0].Length > 0)
                {
                    listItem = new ListViewItem(cols[0]);
                    listItem.Name = cols[0];
                    lstFundType.Items.Add(listItem);
                }
            }
            lstFundType.EndUpdate();
            //lstFundType.Items[0].Selected = true;
        }

        private void loadLstTrans2FundType()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstFund2Type.ListViewItemSorter = lvwColumnSorter;

            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadFundTypes(2, "2010").Split('\n');
            lstFund2Type.BeginUpdate();
            lstFund2Type.Clear();
            lstFund2Type.Columns.Add("Trans Funding", 200, HorizontalAlignment.Left);
            lstFund2Type.Columns.Add("_SortFund2type", 0, HorizontalAlignment.Left);

            //Add "All Funds" option
            ListViewItem listItem = new ListViewItem("ALL");
            listItem.Name = "";
            lstFund2Type.Items.Add(listItem);

            //Add results from Funds query
            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');

                if (cols[0].Length > 0)
                {
                    listItem = new ListViewItem(cols[0]);
                    listItem.Name = cols[0];
                    lstFund2Type.Items.Add(listItem);
                }
            }
            lstFund2Type.EndUpdate();
            //lstFund2Type.Items[0].Selected = true;
        }

        private String makeFundingString(String[] cols)
        {
            String strReturn = cols[InfoLoader.F_DATA_DeptID] + " " + cols[InfoLoader.F_DATA_FundType];
            if (cols[InfoLoader.F_DATA_FundProject].Length > 0)
            {
                strReturn += " " + cols[InfoLoader.F_DATA_FundProject];
            }
            if (cols[InfoLoader.F_DATA_FundClass].Length > 0)
            {
                strReturn += " " + cols[InfoLoader.F_DATA_FundClass];
            }
            return strReturn;
        }

        private void loadLstGLs()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstGLs.ListViewItemSorter = lvwColumnSorter;

            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadAllGLs().Split('\n'); //
            selectedGLID = "";

            lstGLs.BeginUpdate();
            lstGLs.Clear();
            lstGLs.Columns.Add("GLs", 195, HorizontalAlignment.Left);
            lstGLs.Columns.Add("_SortGLs", 0, HorizontalAlignment.Left);

            //Add "All GLs" option
            ListViewItem listItem = new ListViewItem("ALL GLs");
            listItem.Name = "";
            lstGLs.Items.Add(listItem);

            //Add results from GL query
            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');
                if (cols.Length == 3)
                {
                    listItem = new ListViewItem(cols[1] + " " + cols[2]);
                    listItem.Name = cols[0];
                    lstGLs.Items.Add(listItem);
                }
            }
            lstGLs.EndUpdate();
        }


        private void loadLstTransPayees()
        {
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstTransPayees.ListViewItemSorter = lvwColumnSorter;

            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadPayeesByTransType(selectedTransType).Split('\n'); //
            selectedTransPayeeID = "";

            lstTransPayees.BeginUpdate();
            lstTransPayees.Clear();
            lstTransPayees.Columns.Add("Payee", 120, HorizontalAlignment.Left);
            lstTransPayees.Columns.Add("_SortPayees", 0, HorizontalAlignment.Left);

            //Add "All PAYEES" option
            ListViewItem listItem = new ListViewItem(" ALL PAYEES");
            listItem.Name = "";
            lstTransPayees.Items.Add(listItem);

            //Add results from Payee query
            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');
                if (cols.Length == 3) //01062016 sort by LastName Harry.
                {
                    var names = cols[1].TrimEnd().Split(' ');
                    if (cols[2] != "")
                    {
                        string lastName;
                        if (names[names.Length - 1].IndexOf('(') != -1)
                        {
                            lastName = names[names.Length - 2];
                        }
                        else
                        {
                            lastName = names[names.Length - 1];
                        }
                        cols[1] = lastName + ", " + cols[1].Replace(lastName, "");
                        //cols[1] = names[1] + ", " + names[0];
                    }
                    listItem = new ListViewItem(cols[1]);
                    listItem.Name = cols[0];
                    lstTransPayees.Items.Add(listItem);
                }
            }
            lstTransPayees.EndUpdate();
        }

        private void loadLstTransStatus()
        {
            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadStatus(InfoLoader.TABLE_TRANSACTIONS).Split('\n'); //
            selectedStatusID = "";

            lstTransStatus.BeginUpdate();
            lstTransStatus.Clear();
            lstTransStatus.Columns.Add("Payee", 117 , HorizontalAlignment.Left);

            //Add "ANY STATUSES" option
            ListViewItem listItem = new ListViewItem("ANY STATUS");
            listItem.Name = "";
            lstTransStatus.Items.Add(listItem);

            //Add results from Payee query
            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');
                if (cols.Length == 2)
                {
                    listItem = new ListViewItem(cols[1]);
                    listItem.Name = cols[0];
                    lstTransStatus.Items.Add(listItem);
                }
            }
            lstTransStatus.EndUpdate();
        }

        //Aggregated Account Display Methods
        private void loadlstTransactions()
        {

            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstTransactions.ListViewItemSorter = lvwColumnSorter;

            lstTransactions.BeginUpdate();
            lstTransactions.Clear();
            buildlstTransactionsColumns();

            if (!dbcTransactions.isEmpty())
            {
                int recordCount = 0;
                foreach (DataRow row in dbcTransactions.getDT().Rows)
                {
                    ListViewItem listItem = new ListViewItem(row["refTransTypeDesc"].ToString());
                    listItem.Name = recordCount + "!" + row["TransID"].ToString(); // 
                    listItem.SubItems.Add(row["refTransTypeSubDesc"].ToString()); // 
                    if (row["EmpID"].ToString() != "") //Harry 01062016
                    {
                        var names = row["VendName"].ToString().TrimEnd().Split(' ');
                        string lastName;
                        if (names[names.Length - 1].IndexOf('(') != -1)
                        {
                            lastName = names[names.Length - 2];
                        }
                        else
                        {
                            lastName = names[names.Length - 1];
                        }
                        //string temp = lastName + " " + row["VendName"].ToString().Replace(lastName, "");
                        listItem.SubItems.Add(lastName + ", " + row["VendName"].ToString().Replace(lastName, ""));
                    }
                    else
                    {
                        listItem.SubItems.Add(row["VendName"].ToString());
                    }
                    listItem.SubItems.Add(row["EmpUIN"].ToString());
                    listItem.SubItems.Add(row["PostingDate"].ToString()); // 
               //     listItem.SubItems.Add(row["TransactionDate"].ToString()); // 
                    listItem.SubItems.Add(row["theUnitID"].ToString()); // 
                    listItem.SubItems.Add(row["FundType"].ToString() + " " + row["DeptID"].ToString() + " " + row["FundProject"].ToString() + " " + row["FundClass"].ToString()); // 
                    listItem.SubItems.Add(row["GL"].ToString());
                    listItem.SubItems.Add(String.Format(nfi, "{0:c}", double.Parse(UtilityParser.passEmptyNumber(row["TransAmount"].ToString())))); // 
                    listItem.SubItems.Add(String.Format(nfi, "{0:c}", double.Parse(UtilityParser.passEmptyNumber(row["TransAmountRemainder"].ToString())))); // 
                    listItem.SubItems.Add(row["TransDesc"].ToString()); // 
                    listItem.SubItems.Add(row["StatusDesc"].ToString()); // 
                    listItem.SubItems.Add(row["TransBiReference"].ToString());
                    listItem.SubItems.Add(UtilityDates.convertFormatedDateToSortableString(row["PostingDate"].ToString()));
              //      listItem.SubItems.Add(UtilityDates.convertFormatedDateToSortableString(row["TransactionDate"].ToString()));
                    listItem.SubItems.Add(row["TransAmount"].ToString().PadLeft(12, '0'));
                    listItem.SubItems.Add(row["TransAmountRemainder"].ToString().PadLeft(12, '0'));
                    lstTransactions.Items.Add(listItem);
                    recordCount++;
                }
            }
            lstTransactions.EndUpdate();
            this.Cursor = Cursors.Default;
        }

        private void buildlstTransactionsColumns()
        {
            lstTransactions.Columns.Add("Trans Type", 90, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Last Action", 90, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Payee", 150, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("EmpUIN", 80, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Posting Date", 75, HorizontalAlignment.Left);
        //    lstTransactions.Columns.Add("Transaction Date", 75, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Unit", 50, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Funding", 200, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("GL", 70, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Amount", 60, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Encumbered", 70, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Description", 150, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Status", 60, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Reference", 80, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("_SortDatePost", 0, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("_SortAmount", 0, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("_SortEncumber", 0, HorizontalAlignment.Left);
        }




        //Get Selected Values from ListViews

        private String getLstTransTypesSelection()
        {
            try
            {
                return lstTransTypes.SelectedItems[0].Name.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private String getLstUnitsSelection()
        {
            try
            {
                return lstUnits.SelectedItems[0].Name.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        //Toggle lstFunding
        private void toggleLstFunding()
        {
            if (isLstFundTypeOnlyVisible)
            {
                lstFundType.Visible = false;
                lstTransFunding.Visible = true;
                lstFund2Type.Visible = false;
                cmdToggleFundList.Text = "GROUP BY CHARTFIELD";
                


                isLstFundTypeOnlyVisible = false;
                isLstFund2TypeOnlyVisible = false;
            }

            else
            {
                if (isLstFund2TypeOnlyVisible)
                {
                    lstFundType.Visible = false;
                    lstFund2Type.Visible = true;
                    lstTransFunding.Visible = false;

                    cmdToggleFundList.Text = "GROUP BY FIRST 2 LETTERS";
                    
                    
                    isLstFundTypeOnlyVisible = true;
                    isLstFund2TypeOnlyVisible = false;



                }
                else
                {
                    lstFundType.Visible = true;
                    lstTransFunding.Visible = false;
                    lstFund2Type.Visible = false;

                    cmdToggleFundList.Text = "GROUP BY FUND TYPE";
                    

                    isLstFundTypeOnlyVisible = false;
                    isLstFund2TypeOnlyVisible = true;
                }
            }


        }



    











        //EVENTS
        private void lstTransTypes_Click(object sender, EventArgs e)
        {
            selectedTransType = getLstTransTypesSelection();
            loadLstTransSubTypes();
            loadLstTransPayees();
            
        }

  

        private void lstUnits_Click(object sender, EventArgs e)
        {
            selectedUnitID = lstUnits.SelectedItems[0].Name.ToString();
            loadLstTransFunding();
        }

    
        private void lstTransSubTypes_Click(object sender, EventArgs e)
        {
            selectedTransSubType = lstTransSubTypes.SelectedItems[0].Name.ToString();
        }

        private void lstTransFunding_Click(object sender, EventArgs e)
        {
            vFundTypeSql = "";
            selectedTransFundID = lstTransFunding.SelectedItems[0].Name.ToString();
            if (selectedTransFundID.Length > 0)
            {
                vFundTypeSql = " Transactions.TransFundID = " + selectedTransFundID;
            }
        }

        private void lstFundType_Click(object sender, EventArgs e)
        {
            vFundTypeSql = "";
            selectedFundType = lstFundType.SelectedItems[0].Name.ToString();
      //      MessageBox.Show(selectedFundType, "selectedFundType", MessageBoxButtons.OKCancel);
            if (selectedFundType.Length > 0)
            {
                vFundTypeSql = " Transactions_Funding.FundType = '" + selectedFundType + "'";
            }
        }

       private void lstFund2Type_Click(object sender, EventArgs e)
        {
            vFundTypeSql = "";
            selectedFund2Type = lstFund2Type.SelectedItems[0].Name.ToString();
    //        MessageBox.Show(selectedFund2Type, "selectedFund2Type", MessageBoxButtons.OKCancel);
            if (selectedFund2Type.Length > 0)
            {
                vFundTypeSql = " LEFT(Transactions_Funding.FundType,2) = '" + selectedFund2Type + "'";
            }
           
        }
 

        private void lstGLs_Click(object sender, EventArgs e)
        {
            selectedGLID = lstGLs.SelectedItems[0].Name.ToString();
        }

   

        private void lstTransPayees_Click(object sender, EventArgs e)
        {
            selectedTransPayeeID = lstTransPayees.SelectedItems[0].Name.ToString();
            
        }

   
        private void lstTransStatus_Click(object sender, EventArgs e)
        {
            selectedStatusID = lstTransStatus.SelectedItems[0].Name.ToString();
        }

   
        private void cmboGLFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this event should not run until the control is filled programmatically.
            if (isCmboGLFilterLoaded)
            {
    //           loadDBCTransactions();
                cmboGLFilter.SelectedValue.ToString();
                loadLstGLs();
               
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            loadResetPage();
        }

        private void cmboFY_SelectedIndexChange(object sender, EventArgs e)
        {
            if (isCmboFYLoaded)
            {
                loadCmboGLFilter();
                loadLstTransFundType();
                loadLstUnits();
 //               loadDBCTransactions();
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
   //         MessageBox.Show(vSql, "loadDBCTransactions", MessageBoxButtons.OKCancel);
            
            this.Cursor = Cursors.WaitCursor;
            loadDBCTransactions();
            loadlstTransactions();
            this.Cursor = Cursors.Default;
        }

        private void lstTransactions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int sortColumn = e.Column;
            //if user clicks on Post Date start column to sort, direct sort to datestartsort column 
            if (sortColumn == 3)
            {
                sortColumn = 12;
            }
            //if user clicks on TRansAmount column  to sort, direct sort to dateendsort column 
            if (sortColumn == 7)
            {
                sortColumn = 13;
            }
            //if user clicks on Trans Enc column to sort, direct sort to sortFTC column 
            if (sortColumn == 8)
            {
                sortColumn = 14;
            }

            // Determine if clicked column is already the column that is being sorted.
            if (sortColumn == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = sortColumn;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstTransactions.Sort();

        }

        private void lstTransactions_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = ((ListView)sender).SelectedItems[0];
            String[] wholeName = item.Name.ToString().Split('!');
            frmTransactionsInstance frmTransIns = new frmTransactionsInstance(wholeName[1]);
            frmTransIns.MdiParent = frmSwitchboard.frmParent;
            frmTransIns.Show();
        }

        //Transaction types cloumn click

        private void lstTransType_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int sortColumn = e.Column;
            //if user clicks on Post Date start column to sort, direct sort to datestartsort column 
     /*       if (sortColumn == 0)
            {
                sortColumn = 1;
            }
      */
           
            // Determine if clicked column is already the column that is being sorted.
            if (sortColumn == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = sortColumn;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstTransTypes.Sort();

        }


        private void lstTransSubType_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int sortColumn = e.Column;
            //if user clicks on Post Date start column to sort, direct sort to datestartsort column 
      /*      if (sortColumn == 1)
            {
                sortColumn = 2;
            }
       */

            // Determine if clicked column is already the column that is being sorted.
            if (sortColumn == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = sortColumn;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstTransSubTypes.Sort();

        }


        private void lstGLs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int sortColumn = e.Column;
            //if user clicks on Post Date start column to sort, direct sort to datestartsort column 
       /*    if (sortColumn == 1)
                  {
                      sortColumn = 0;
                  }
       */
       
               

            // Determine if clicked column is already the column that is being sorted.
            if (sortColumn == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = sortColumn;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstGLs.Sort();

        }

       private void lstUnits_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int sortColumn = e.Column;
            //if user clicks on Post Date start column to sort, direct sort to datestartsort column 
      //        if (sortColumn == 0)
      //            {
      //                sortColumn = 1;
      //            }

           

            // Determine if clicked column is already the column that is being sorted.
            if (sortColumn == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = sortColumn;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstUnits.Sort();

        }



               
        private void lstTransFund_ColumnClick(object sender, ColumnClickEventArgs e)
        {
           int sortColumn = e.Column;
            //if user clicks on Post Date start column to sort, direct sort to datestartsort column 
      /*      if (sortColumn == 0)
            {
                sortColumn = 1;
            }
       */

            // Determine if clicked column is already the column that is being sorted.
            if (sortColumn == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = sortColumn;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstFundType.Sort();
            this.lstTransFunding.Sort();
            this.lstFund2Type.Sort();
        }



       private void lstTransPayees_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int sortColumn = e.Column;
            //if user clicks on Post Date start column to sort, direct sort to datestartsort column 
            /*      if (sortColumn == 1)
                  {
                      sortColumn = 2;
                  }
           */

            // Determine if clicked column is already the column that is being sorted.
            if (sortColumn == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = sortColumn;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstTransPayees.Sort();

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Clipboard.SetText(UtilityRighClick.dataToCopyPastListViewItems(lstTransactions, false));
                //Clipboard.SetText(UtilityRighClick.dataToCopyPasteBufferAll(dbcTransactions.getDT()));
            this.Cursor = Cursors.Default;
        }

        private void copySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(UtilityRighClick.dataToCopyPastListViewItems(lstTransactions, true));
                    
        }

        private void calculateSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txttemsCalc.Text = String.Format(nfi, "{0:c}", UtilityRighClick.calcSelected(lstTransactions.SelectedItems, 7));
        }

        private void cmdToggleFundList_Click(object sender, EventArgs e)
        {
            toggleLstFunding();
        }


       
    }
}
