using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
namespace PECS_v1
{
    class InfoLoader
    {
        public static String BuildID2BuildNameShort(String BuildID)
        {
            try
            {
                makeConnection(@" SELECT BuildNameShort FROM Operations_Buildings
                              WHERE BuildID LIKE '%" + BuildID + "%'", "Operations_Buildings");
                return dtc["Operations_Buildings"].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static String switchFirstLastName(String name)
        {
            var names = name.ToString().TrimEnd().Split(' ');
            string lastName;
            if (names[names.Length - 1].IndexOf('(') != -1)
            {
                lastName = names[names.Length - 2];
            }
            else
            {
                lastName = names[names.Length - 1];
            }

            return (lastName + ", " + name.ToString().Replace(lastName, ""));
        }

        public static String searchVenderName(String name)
        {
            String strReturn = "";
            String sql = @" SELECT VendID
                            FROM    Vendors
                            WHERE   VendName LIKE '%" + name + "%' ";
            try
            {
                makeConnection(sql, "Vendors");
                foreach (DataRow row in dtc["Vendors"].Rows)
                {
                    strReturn += row[0] + ",";
                }
                return strReturn.TrimEnd(',');
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static String transSearchPayee(String name)
        {
            String strReturn = "";
            String sql = @" SELECT TOP 10000 TransID
                            FROM Transactions where TransPayeeID in ( " + searchVenderName(name) + ")";
            sql += " ORDER BY TransID DESC";

            try
            {
                makeConnection(sql, "Transactions");
                foreach (DataRow row in dtc["Transactions"].Rows)
                {
                    strReturn += row[0] + "\n";
                }
                return strReturn;
            }
            catch (Exception ex)
            {
                return "";
            }
        }


		public static String roomID2RoomNumber(String roomID)
        {
            try
            {
                makeConnection(@"  SELECT RoomNumber from Operations_Rooms2
                                   WHERE RoomId = '" + roomID + "'", "Operations_Rooms2");
                return dtc["Operations_Rooms2"].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static String roomNumber2RoomID(String BuildID, String RoomNumber)
        {
            try
            {
                makeConnection(@"  SELECT RoomId from Operations_Rooms2
                                                   WHERE RoomNumber = '" + RoomNumber + "'" +
                                                   "AND BuildID = '" + BuildID + "'"
                                                   , "Operations_Rooms2");
                return dtc["Operations_Rooms2"].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static String empID2EmpUIN(String EmpID)
        {
            try
            {
                makeConnection(@"  SELECT EmpUIN from Employees
                                   WHERE EmpID = '" + EmpID + "'", "Employees");
                return dtc["Employees"].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static String empUIN2EmpID(String empUIN)
        {
            try
            {
                makeConnection(@"  SELECT EmpID from Employees
                                   WHERE empUIN = '" + empUIN + "'", "Employees");
                return dtc["Employees"].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        public static String empID2EmpName(String empID)
        {
            try
            {
                makeConnection(@"  SELECT EmpNameFirst, EmpNameLast from Employees
                                   WHERE empID = '" + empID + "'", "Employees");
                return dtc["Employees"].Rows[0].ItemArray[0].ToString() + " " + dtc["Employees"].Rows[0].ItemArray[1].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static String BuildNameLong2BuildID(String BuildName)
        {
            try
            {
                String[] BuildNames = BuildName.Split('\'');
                //Console.WriteLine("long" + BuildNames[0]);
                makeConnection(@" SELECT BuildID FROM Operations_Buildings
                              WHERE BuildNameLong LIKE '%" + BuildNames[0].Trim() + "%'", "Operations_Buildings");
                return dtc["Operations_Buildings"].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static String BuildNameShort2BuildID(String BuildName)
        {
            try
            {
                String[] BuildNames = BuildName.Split('\'');
                //Console.WriteLine("Short " + BuildNames[0]);
                makeConnection(@" SELECT BuildID FROM Operations_Buildings
                              WHERE BuildNameShort LIKE '%" + BuildNames[0].Trim() + "%'", "Operations_Buildings");
                return dtc["Operations_Buildings"].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }





    }//END NAMESPACE
}//END CLASS
