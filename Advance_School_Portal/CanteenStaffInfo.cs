using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Advance_School_Portal
{
    class CanteenStaffInfo
    {
        public string Order_id { get; set; }
        public string Order_status { get; set; }
        public string Notice_id { get; set; }
        public string Notice { get; set; }
        public bool Order_Update(CanteenStaffInfo c)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");

            try
            {
                connection.Open();
                string Order_Entry = "Update Canteen_Order set Status=@stat where id=@id ";
                SqlCommand cmd_Order_Entry = new SqlCommand(Order_Entry, connection);
                cmd_Order_Entry.Parameters.AddWithValue("@id", c.Order_id);
                cmd_Order_Entry.Parameters.AddWithValue("@stat", c.Order_status);
                int rows;
                rows = cmd_Order_Entry.ExecuteNonQuery();
                if (connection.State == ConnectionState.Open)
                {

                    if (rows > 0)
                    {
                        isSuccess = true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return isSuccess;
        }
        public DataTable View_All_Orders()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");
            DataTable Order_Table = new DataTable();
            string query = "Select * from Canteen_Order ";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            sda.Fill(Order_Table);
            return Order_Table;
        }
        public bool Delete_All_Orders()
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");
            try
            {
                string query = "Delete from Canteen_Order";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        isSuccess = true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return isSuccess;

        }

        public bool Insert_Notice(CanteenStaffInfo s)
        {

            bool isSuccess = false;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");

            try
            {
                connection.Open();
                string query = "Insert into AdminNotice (Notice_ID,Notice,Notice_To)values(@Id,@UN,@Pw)";
                SqlCommand cmd = new SqlCommand(query, connection);
                int rows, rows2, rows3, rows4;
                cmd.Parameters.AddWithValue("@Id", s.Notice_id);
                cmd.Parameters.AddWithValue("@UN", s.Notice);
                cmd.Parameters.AddWithValue("@Pw", "All");
                rows = cmd.ExecuteNonQuery();

                if (connection.State == ConnectionState.Open)
                {

                    if (rows > 0)
                    {
                        isSuccess = true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }

            return isSuccess;

        }

        public DataTable View_All_Notice()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");
            DataTable Notice_Table = new DataTable();
            string query = "Select * from AdminNotice where Notice_To='All' or Notice_To='Canteen' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            sda.Fill(Notice_Table);
            return Notice_Table;
        }

        public bool Delete_Notice(CanteenStaffInfo c)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");
            try
            {
                    string query = "Delete from AdminNotice where Notice_ID=@id and Notice_To = 'All' or  Notice_To='Canteen'";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@id", c.Notice_id);

                    connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        isSuccess = true;
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return isSuccess;
        }
    }
}
