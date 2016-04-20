 using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PECS_v1
{
    public partial class frmTransactions : Form
    {

        private ListViewColumnSorter lvwColumnSorter;


        public static Boolean isVisible = false;
        private DBConnector dbcTransactions;
        private string baseSQL = @" SELECT TOP 500      
                                                Transactions.TransID, 
                                                refStatus.StatusDesc,  
                                                refTransactionTypes.refTransTypeDesc,  
                                                Transactions_Funding.UnitID,  
                                                Transactions_Funding.DeptID, 
                                                Transactions_Funding.FundType,  
                                                Transactions_Funding.FundProject, 
                                                Transactions_Funding.FundClass, 
                                                Transactions.TransDatePosting,  
                                                Transactions.TransDateTransaction,  
                                                Transactions.TransAmount,  
                                                Transactions.TransAmountRemainder,  
                                                Transactions.TransDesc,  
                                                refTransactionTypesSub.refTransTypeSubDesc,  
                                                Vendors.VendName,  
                                                (SELECT EmpUIN FROM Employees WHERE EmpID = Vendors.EmpID) AS EmpUIN,
                                                Transactions_GLs.GLNumber
                                    FROM        Transactions INNER JOIN
                                                refStatus ON Transactions.TransStatusID = refStatus.StatusID INNER JOIN
                                                refTransactionTypes ON Transactions.refTransTypeID = refTransactionTypes.refTransTypeID INNER JOIN
                                                Transactions_Funding ON Transactions.TransFundID = Transactions_Funding.TransFundID INNER JOIN
                                                refTransactionTypesSub ON Transactions.refTransTypeSubID = refTransactionTypesSub.refTransTypeSubID INNER JOIN
                                                Vendors ON Transactions.TransPayeeID = Vendors.VendID INNER JOIN
                                                Transactions_GLs ON Transactions.GLID = Transactions_GLs.GLID ";

        private String sortSQL = " ORDER BY Transactions.TransDatePosting DESC, Transactions_Funding.UnitID";

        private NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
        private ArrayList arrTransIDs;


        public frmTransactions()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            nfi = (NumberFormatInfo)nfi.Clone();
            nfi.CurrencySymbol = "";
            loadPage();
        }


        public void loadPage()
        {
            loadLstTransTypes();
            loadLstUnit();
            loadStatus();
            loadLstTransGL();
            buildDBConnector(false);
            loadCmboTransSearch();
            
        }


        //Load main transaction type listbox lstTransTypes
        private void loadLstTransTypes()
        {
            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadTransTypes(false).Split('\n'); //false = non-utility trans types
            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');
                if (cols.Length == 2)
                {
                    arrNew.Add(new ListValues(cols[0], cols[1], ListValues.FORWARD));
                    arrNew.Sort();
                }

            }
            if (arrNew.Count > 0)
            {
                lstTransTypes.DataSource = arrNew;
                lstTransTypes.DisplayMember = "Desc";
                lstTransTypes.ValueMember = "ID";
            }
            lstTransTypes.ClearSelected();
        }

        //Load Unit listbox lstUnitID
        private void loadLstUnit()
        {
            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadUnits(true).Split('\n');
            for (int i = 0; i < tmpArray.Length; i++)
            {
                if (tmpArray[i].ToString().Trim().Length > 0)
                {

                    arrNew.Add(new ListValues(tmpArray[i], ListValues.FORWARD));
                }

            }
            lstUnitID.DataSource = arrNew;
            lstUnitID.DisplayMember = "Desc";
            lstUnitID.ValueMember = "ID";
            lstUnitID.ClearSelected();
        }

        //load Transaction GLs - lstTransGL
        private void loadLstTransGL()
        {
            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadAllGLs().Split('\n');
            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');
                if (cols.Length ==3)
                {
                    arrNew.Add(new ListValues(cols[0], cols[1] + "    " + cols[2], ListValues.FORWARD));
                }

            }

            if (arrNew.Count > 0)
            {
                lstTransGL.DataSource = arrNew;
                lstTransGL.DisplayMember = "Desc";
                lstTransGL.ValueMember = "ID";
                lstTransGL.ClearSelected();
            }
            else
            {
                lstTransGL.DataSource = null;
            }
        }

        //Load refStatus cmboTransStatusID
        public void loadStatus()
        {
            ArrayList arrNew = new ArrayList();
            String[] tmpArray = InfoLoader.loadStatus(InfoLoader.TABLE_TRANSACTIONS).Split('\n');
            for (int i = 0; i < tmpArray.Length; i++)
            {
                String[] cols = tmpArray[i].Split('\t');
                if (cols.Length == 2)
                {
                    arrNew.Add(new ListValues(cols[0], cols[1], ListValues.FORWARD));
                }

            }

            lstStatus.DataSource = arrNew;
            lstStatus.DisplayMember = "Desc";
            lstStatus.ValueMember = "ID";
            lstStatus.ClearSelected();
        }

        private void loadCmboTransSearch()
        {
            ArrayList arrNew = new ArrayList();
            
            arrNew.Add(new ListValues("-1"," ",ListValues.FORWARD));

            arrNew.Add(new ListValues("0", "Description", ListValues.FORWARD));
            arrNew.Add(new ListValues("1", "Transaction Attachments", ListValues.FORWARD));
            arrNew.Add(new ListValues("2", "Payee", ListValues.FORWARD));

            cmboTransSearch.DataSource = arrNew;
            cmboTransSearch.DisplayMember = "Desc";
            cmboTransSearch.ValueMember = "ID";
            
        }


        private void loadlstTransactions()
        {
            if (dbcTransactions.isEmpty())
            {
                return;
            }

            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstTransactions.ListViewItemSorter = lvwColumnSorter;
            


            lstTransactions.BeginUpdate();
            lstTransactions.Clear();
            buildlstTransactionsColumns();
            int i = 0;
            foreach (DataRow row in dbcTransactions.getDT().Rows)
            {
                ListViewItem listItem = new ListViewItem(row["refTransTypeSubDesc"].ToString());
                listItem.Name = i.ToString(); // index for record in dbConnector 
                listItem.SubItems.Add(row["StatusDesc"].ToString()); // Status
                listItem.SubItems.Add(row["UnitID"].ToString() + " " +
                                      row["DeptID"].ToString() + " " +
                                      row["FundType"].ToString()); 
                listItem.SubItems.Add(row["FundProject"].ToString()); // Status
                listItem.SubItems.Add(row["FundClass"].ToString()); // Status
                listItem.SubItems.Add(row["VendName"].ToString()); // Status
                listItem.SubItems.Add(row["EmpUIN"].ToString()); // Status
                listItem.SubItems.Add(UtilityParser.parseNullDate(DateTime.Parse(row["TransDatePosting"].ToString()).ToShortDateString())); // Unit
                listItem.SubItems.Add(UtilityParser.parseNullDate(DateTime.Parse(row["TransDateTransaction"].ToString()).ToShortDateString())); // Status
                listItem.SubItems.Add(String.Format(nfi, "{0:c}", double.Parse(row["TransAmount"].ToString()))); // Unit
                listItem.SubItems.Add(String.Format(nfi, "{0:c}", double.Parse(row["TransAmountRemainder"].ToString()))); // Unit
                listItem.SubItems.Add(row["TransDesc"].ToString()); // Description
                listItem.SubItems.Add(row["GLNumber"].ToString()); // GL

                lstTransactions.Items.Add(listItem);
                i++; //increment i to track new index for next record
            }
            lstTransactions.EndUpdate();
        }


        

        private void buildlstTransactionsColumns()
        {
            
            lstTransactions.Columns.Add("Trans Sub Type", 220, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Status", 120, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Funding", 150, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Project", 55, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Class", 50, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Payee", 190, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("EmpUIN", 80, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Date Posted", 100, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Trans Date", 100, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Amount", 120, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Encumber", 90, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("Desc", 320, HorizontalAlignment.Left);
            lstTransactions.Columns.Add("GL", 80, HorizontalAlignment.Left);

            

        }



       






        private void buildDBConnector(bool isSearched)
        {
            this.Cursor = Cursors.WaitCursor; 
            String whereSQL = "";
            if (isSearched)
            {
                whereSQL += " WHERE Transactions.TransID in (";
                for (int i = 0; i < arrTransIDs.Count; i++)
                {
                    whereSQL += arrTransIDs[i] + ",";
                }
                whereSQL = whereSQL.TrimEnd(',');
                whereSQL += ")";
                Console.WriteLine("ccc  " + whereSQL);
            }
            else
            {
                if (lstTransTypes.SelectedValue != null)
                {
                    if (whereSQL.Contains("WHERE"))
                    {
                        whereSQL += " AND ";
                    }
                    else
                    {
                        whereSQL += " WHERE ";
                    }
                    whereSQL += " Transactions.refTransTypeID = " + lstTransTypes.SelectedValue.ToString();
                }

                if (lstStatus.SelectedValue != null)
                {
                    if (whereSQL.Contains("WHERE"))
                    {
                        whereSQL += " AND ";
                    }
                    else
                    {
                        whereSQL += " WHERE ";
                    }
                    whereSQL += " Transactions.TransStatusID = " + lstStatus.SelectedValue.ToString();
                }

                if (lstUnitID.SelectedValue != null)
                {
                    if (whereSQL.Contains("WHERE"))
                    {
                        whereSQL += " AND ";
                    }
                    else
                    {
                        whereSQL += " WHERE ";
                    }
                    whereSQL += " Transactions_Funding.UnitID = '" + lstUnitID.SelectedValue.ToString() + "' ";
                }

                if (lstTransGL.SelectedValue != null)
                {
                    if (whereSQL.Contains("WHERE"))
                    {
                        whereSQL += " AND ";
                    }
                    else
                    {
                        whereSQL += " WHERE ";
                    }
                    whereSQL += " Transactions.GLID = '" + lstTransGL.SelectedValue.ToString() + "' ";
                }
            }

            whereSQL += " AND Transactions.TransDatePosting >= CONVERT(DATETIME, '" + UtilityDates.getCurrentFiscalYear() + "-07-01 00:00:00', 102) AND Transactions.TransDatePosting < CONVERT(DATETIME, '" + (UtilityDates.getCurrentFiscalYear() + 1) + "-07-01 00:00:00', 102)";

            dbcTransactions = new DBConnector(baseSQL + whereSQL + sortSQL, "Transactions");
            Console.WriteLine(baseSQL + whereSQL + sortSQL);
            loadlstTransactions();
            this.Cursor = Cursors.Default; 
        }

        //Search transactions for specified criteria
        private void searchTransactions()
        {
            buildDBConnector(false);

            arrTransIDs = new ArrayList();
            String[] data;
            //Determine type of user search request

            int switchCase = int.Parse(cmboTransSearch.SelectedValue.ToString());
            switch (switchCase)
            {
                case 0:
                    data = InfoLoader.transSearchByDesc(txtTransSearch.Text).Split('\n');
                    break;

                case 1:
                    data = InfoLoader.transSearchTransDetails(txtTransSearch.Text).Split('\n');
                    break;

                case 2:
                    data = InfoLoader.transSearchPayee(txtTransSearch.Text).Split('\n');
                    break;
                case -1:
                    return;

                default:
                    return;

            }

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Length > 0)
                {
                    arrTransIDs.Add(data[i].ToString());
                }
            }

            if (arrTransIDs.Count > 0)
            {
                buildDBConnector(true); 
            }
            else
            {
                lstTransactions.Clear();
                buildlstTransactionsColumns();
            }
            /*
            //get detail element info
            String[] elementData = InfoLoader.getTransDetElement(cmboTransSearch.SelectedValue.ToString()).Split('\t');
            int itemIdex = int.Parse(elementData[2]) + 1;

            //find any relevant detail types by identifying transsubtypeid
            String[] detailData = InfoLoader.loadDetailsBySubType(elementData[1]).Split('\n');

            //look for requested data in results
            
             */
        }

        //Create Header for copy/paste
        private String makeCopyPasteHeader()
        {
            return "Trans Sub Type\tStatus\tFunding\tProject\tClass\tPayee\tDate Posting\tPeriod\tDate Trans\tAmount\tEnc\tDesc\tGL\n";
        }

        //method to take row information and put it into a string sequence
        private String dataRowToString(DataRow row)
        {
            String strReturn =  row["refTransTypeSubDesc"].ToString() + "\t" +
                                row["StatusDesc"].ToString() + "\t" +
                                row["UnitID"].ToString() + " " + row["DeptID"].ToString() + " " + row["FundType"].ToString() + "\t" +
                                row["FundProject"].ToString() + "\t" +
                                row["FundClass"].ToString() + "\t" +
                                row["VendName"].ToString() + "\t" +
                                row["EmpUIN"].ToString() + "\t" +
                                UtilityParser.parseNullDate(DateTime.Parse(row["TransDatePosting"].ToString()).ToShortDateString()) + "\t" +
                                UtilityDates.translateDateToPeriod(DateTime.Parse(row["TransDatePosting"].ToString())) + "\t" +
                                UtilityParser.parseNullDate(DateTime.Parse(row["TransDateTransaction"].ToString()).ToShortDateString()) + "\t" +
                                String.Format(nfi, "{0:c}", double.Parse(row["TransAmount"].ToString())) + "\t" +
                                String.Format(nfi, "{0:c}", double.Parse(row["TransAmountRemainder"].ToString())) + "\t" +
                                row["TransDesc"].ToString() + "\t" +
                                row["GLNumber"].ToString() + "\n";

            return strReturn;
        }

        //Copy displayed rows into paste buffer
        private void dataToCopyPasteBufferAll()
        {
            //all stored data will be copied to this string
            String data = makeCopyPasteHeader();

            //cycle through data in dbcTransactions to append to data string
            foreach (DataRow row in dbcTransactions.getDT().Rows)
            {
                data += dataRowToString(row);
            }

            Clipboard.SetText(data);
        }

        //Copy displayed rows into paste buffer
        private void dataToCopyPasteBufferSelected()
        {
            //all stored data will be copied to this string
            String data = makeCopyPasteHeader();


            for (int i = 0; i < lstTransactions.SelectedItems.Count; i++)
            {
                DataRow row = dbcTransactions.getDT().Rows[int.Parse(lstTransactions.SelectedItems[i].Name.ToString())];
                data += dataRowToString(row);
            }

            
            Clipboard.SetText(data);
        }


        //EVENTS

        private void frmTransactions_Closing(object sender, FormClosingEventArgs e)
        {
            isVisible = false;
        }

        private void cmdAccounts_Click(object sender, EventArgs e)
        {
            frmTransactionsAccounts frmAcct = new frmTransactionsAccounts();
            frmAcct.MdiParent = frmSwitchboard.frmParent;
            frmAcct.Show();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdNewTransaction_Click(object sender, EventArgs e)
        {
            frmTransactionsNew frmTransNew = new frmTransactionsNew(0); // zero means that new trans is not linked to any others
            frmTransNew.MdiParent = frmSwitchboard.frmParent;
            frmTransNew.Show();
        }

        

        private void lstTransTypes_DoubleClick(object sender, EventArgs e)
        {
            buildDBConnector(false);
        }

        private void lstUnitID_DoubleClick(object sender, EventArgs e)
        {
            buildDBConnector(false);
        }

        private void lstStatus_DoubleClick(object sender, EventArgs e)
        {
            buildDBConnector(false);
        }

        private void cmdClearSelection_Click(object sender, EventArgs e)
        {
            
            lstStatus.ClearSelected();
            lstUnitID.ClearSelected();
            lstTransTypes.ClearSelected();
            lstTransGL.ClearSelected();
            buildDBConnector(false);
            
        }

        private void cmdTransSearch_Click(object sender, EventArgs e)
        {
            searchTransactions();
        }

        private void lstTransactions_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = ((ListView)sender).SelectedItems[0];
            frmTransactionsInstance frmTransIns = new frmTransactionsInstance(int.Parse(item.Name), dbcTransactions.getDT());
            frmTransIns.MdiParent = frmSwitchboard.frmParent;
            frmTransIns.Show();
        }

        private void lstTransactions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
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
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstTransactions.Sort();

        }

        private void cmdPayroll_Click(object sender, EventArgs e)
        {
            frmTransactionsPayroll frmPayroll = new frmTransactionsPayroll();
            frmPayroll.MdiParent = frmSwitchboard.frmParent;
            frmPayroll.Show();
        }

        private void txtTransSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmsTransRightClick_Click(object sender, EventArgs e)
        {
            dataToCopyPasteBufferSelected();
        }

        private void cmsTransRightClickAll_Click(object sender, EventArgs e)
        {
            dataToCopyPasteBufferAll();
        }

        private void lstTransGL_DoubleClick(object sender, EventArgs e)
        {
            buildDBConnector(false);
        }

        private void cmdReconcile_Click(object sender, EventArgs e)
        {
            frmTransactionsReconcile frmReconcile = new frmTransactionsReconcile();
            frmReconcile.MdiParent = frmSwitchboard.frmParent;
            frmReconcile.Show();
        }
    }

}
