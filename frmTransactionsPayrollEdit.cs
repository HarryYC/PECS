using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PECS_v1
{
    public partial class frmTransactionsPayrollEdit : Form
    {
        private DBConnector dbcTransac;
        private BindingSource bsTransac = new BindingSource();
        private String month = "";
        private Boolean firstLoop = true;
        public frmTransactionsPayrollEdit()
        {
            InitializeComponent();
            
            comboMonth.DataSource = System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames;
  
        }

        private void loadDgvTransac()
        {
            bsTransac.DataSource = dbcTransac.getDT();
            dgvTransaction.DataSource = bsTransac;
            dgvTransaction.ReadOnly = true;
            dgvTransaction.MultiSelect = true;
            dgvTransaction.Columns["TransID"].Visible = false;
            dgvTransaction.Columns["UnitID"].Width = 80;
            dgvTransaction.Columns["TransDesc"].Width = 100;
        }

        private void loadDBCPayrolls(String month)
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
                            WHERE TransDesc = 'PAYROLL'
                            AND refTransTypeID = 5
                            AND TransStatusID = 11
                            AND YEAR(TransDatePosting) = YEAR(GETDATE())
                            --AND MONTH(TransDatePosting) = MONTH('2016-02-29 00:00:00.000')
                            AND MONTH(TransDatePosting) BETWEEN DATEPART(MM,'" + month + @"') AND MONTH(GETDATE())
                            ORDER BY TransDatePosting";
            dbcTransac = new DBConnector(sql, "Transactions");

        }

        private void comboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            month = comboMonth.SelectedValue.ToString();
            if (month != "")
            {
                month = month + " 1 " + DateTime.Today.Year;
                loadDBCPayrolls(month);
                loadDgvTransac();
            }
        }

        private void dgvTransaction_UserDeletingRow(object sender,
         DataGridViewRowCancelEventArgs e)
        {

            List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
            if (firstLoop)
            {
                foreach (DataGridViewRow row in dgvTransaction.SelectedRows)
                {
                    String sql = "DELETE FROM Transactions WHERE TransID = " + row.Cells[0].Value.ToString();
                    //Console.WriteLine(sql);
                    dbcTransac.executeSQL(sql);
                }
                firstLoop = false;
            }
            if (dgvTransaction.SelectedRows.Count == 1)
            {
                firstLoop = true;
            }


        }
    }
}
