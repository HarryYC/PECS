using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PECS_v1
{
    public partial class frmTransactionsPayrollHourlyEdit : Form
    {
        public frmTransactionsPayrollHourly frmTransPayrollHourly;
        private DBConnector dbcTransac;
        private BindingSource bsTransac = new BindingSource();
        private String month = null;
<<<<<<< HEAD
=======
		
>>>>>>> a7ee49726bc261177a8938e3268901ae6aaf6aa4
        public frmTransactionsPayrollHourlyEdit(String selectedMonth, frmTransactionsPayrollHourly frmTransPRH)
        {
            frmTransPayrollHourly = frmTransPRH;
            month = selectedMonth;
            InitializeComponent();
            loadDBCFacDetails();
            loadDgvTransac();
        }

<<<<<<< HEAD

=======
		//load binding data from database
>>>>>>> a7ee49726bc261177a8938e3268901ae6aaf6aa4
        private void loadDBCFacDetails()
        {
            String sql = @" SELECT TransID,
	                        (SELECT VendName FROM Vendors WHERE VendID = trans.TransPayeeID) AS Name,
	                        UnitID,
	                        (SELECT FundType FROM Transactions_Funding WHERE TransFundID = trans.TransFundID) AS FundType,
	                        (SELECT GLDesc FROM refTransactionTypesSub_GLs WHERE GLID = 15 AND ISNUMERIC(GLDesc) = 1) AS GLDesc,
	                        TransAmount,
	                        TransDesc,
	                        TransCreatedUser,
	                        TransDatePosting,
	                        TransDateTransaction
                            FROM Transactions trans
                            WHERE refTransTypeID = 5
                            AND TransStatusID = 11
                            AND TransDesc = '" + month + "'";
            dbcTransac = new DBConnector(sql, "Transactions");

        }

<<<<<<< HEAD
        // dgv: DataGridView
=======
        // dgv: DataGridView, delete selected Transactions
>>>>>>> a7ee49726bc261177a8938e3268901ae6aaf6aa4
        private void dgvTransaction_UserDeletingRow(object sender,
            DataGridViewRowCancelEventArgs e)
        {

            List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvTransaction.SelectedRows)
            {
                selectedRows.Add(row);
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                String sql = "DELETE FROM Transactions WHERE TransID = " + row.Cells[0].Value.ToString();
                dbcTransac.executeSQL(sql);
            }
<<<<<<< HEAD

        }

=======
        }

		//load data to DataGridView
>>>>>>> a7ee49726bc261177a8938e3268901ae6aaf6aa4
        private void loadDgvTransac()
        {
            bsTransac.DataSource = dbcTransac.getDT();
            dgvTransaction.DataSource = bsTransac;
            dgvTransaction.ReadOnly = true; 
            dgvTransaction.MultiSelect = true; 

            dgvTransaction.Columns["TransID"].Visible = false;
            dgvTransaction.Columns["UnitID"].Width = 80;
            dgvTransaction.Columns["TransDesc"].Width = 200;

<<<<<<< HEAD

=======
>>>>>>> a7ee49726bc261177a8938e3268901ae6aaf6aa4
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            frmTransactionsPayrollHourly PayrollHour = new frmTransactionsPayrollHourly();
            frmTransPayrollHourly.loadLstPayrollMonths();
            frmTransPayrollHourly.Refresh();

=======
            frmTransPayrollHourly.loadLstPayrollMonths();
            frmTransPayrollHourly.Refresh();
>>>>>>> a7ee49726bc261177a8938e3268901ae6aaf6aa4
            this.Close();
            
        }

    }
}
