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
    class StudentInfo
    {
        public string Class { get; set; }
        public string Background { get; set; }
        public string Student_id { get; set; }
        public string Food_list { get; set; }
        public float Total_price { get; set; }
        public string Room { get; set; }
        public DataTable Student_Select()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");
            DataTable StudentTable = new DataTable();
            if (Class == "8" && Background=="NO")
            {
                string query = "Select Class_8.id, Student.Name,  Class_8.Bangla, Class_8.English, Class_8.Math, Class_8.Bangladesh_Studies, Class_8.Religion, Class_8.Physical_Education,Class_8.Section, CASE When  Bangla>39 and English>39 and Math>39 and Bangladesh_Studies>39 and Religion>39 and Physical_Education>39 Then 'Pass' Else 'FAIL' END as Status from Class_8, Student where Class_8.id = Student.id ";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(StudentTable);
            }
            else if (Class == "9" && Background == "Science")
            {
                string query = "Select Class_9_Science.id , Student.Name, Class_9_Science.Bangla_1st, Class_9_Science.Bangla_2nd, Class_9_Science.English_1st, Class_9_Science.English_2nd, Class_9_Science.G_Math, Class_9_Science.H_Math, Class_9_Science.Biology, Class_9_Science.Physics, Class_9_Science.Chemistry, Class_9_Science.Bangladesh_Studies, Class_9_Science.Section, CASE WHEN Bangla_1st>39 and Bangla_2nd>39 and English_1st>39 and English_2nd>39 and G_Math >39 and H_Math >39 and Biology>39 and Physics>0 and Chemistry>39 and Bangladesh_Studies>39 Then  'PASS' ELSE 'FAIL' END AS STATUS from Class_9_Science, Student  where Class_9_Science.id=Student.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(StudentTable);
            }
            else if (Class == "10" && Background == "Science")
            {
                string query = "Select Class_10_Science.id , Student.Name, Class_10_Science.Bangla_1st, Class_10_Science.Bangla_2nd, Class_10_Science.English_1st, Class_10_Science.English_2nd, Class_10_Science.G_Math, Class_10_Science.H_Math, Class_10_Science.Biology, Class_10_Science.Physics, Class_10_Science.Chemistry, Class_10_Science.Bangladesh_Studies, Class_10_Science.Section, CASE WHEN Bangla_1st>39 and Bangla_2nd>39 and English_1st>39 and English_2nd>39 and G_Math >39 and H_Math >39 and Biology>39 and Physics>0 and Chemistry>39 and Bangladesh_Studies>39 Then  'PASS' ELSE 'FAIL' END AS STATUS from Class_10_Science, Student  where Class_10_Science.id=Student.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(StudentTable);
            }
            else if (Class == "9" && Background == "Commerce")
            {
                string query = "Select Class_9_Commerce.id , Student.Name, Class_9_Commerce.Bangla_1st, Class_9_Commerce.Bangla_2nd, Class_9_Commerce.English_1st, Class_9_Commerce.English_2nd, Class_9_Commerce.G_Math, Class_9_Commerce.Economics, Class_9_Commerce.Business_Entrepreneurship, Class_9_Commerce.Finance, Class_9_Commerce.Accounting, Class_9_Commerce.Bangladesh_Studies, Class_9_Commerce.Section, CASE When Bangla_1st>39 and Bangla_2nd>39 and English_1st>39 and English_2nd>39 and G_Math>39 and Economics>39 and Business_Entrepreneurship>39 and Finance>39 and Accounting>39 and Bangladesh_Studies>39 Then 'Pass' Else 'FAIL' END as Status from Class_9_Commerce,  Student where Class_9_Commerce.id = Student.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(StudentTable);
            }
            else if (Class == "10" && Background == "Commerce")
            {
                string query = "Select Class_10_Commerce.id , Student.Name, Class_10_Commerce.Bangla_1st, Class_10_Commerce.Bangla_2nd, Class_10_Commerce.English_1st, Class_10_Commerce.English_2nd, Class_10_Commerce.G_Math, Class_10_Commerce.Economics, Class_10_Commerce.Business_Entrepreneurship, Class_10_Commerce.Finance, Class_10_Commerce.Accounting, Class_10_Commerce.Bangladesh_Studies, Class_10_Commerce.Section, CASE When Bangla_1st>39 and Bangla_2nd>39 and English_1st>39 and English_2nd>39 and G_Math>39 and Economics>39 and Business_Entrepreneurship>39 and Finance>39 and Accounting>39 and Bangladesh_Studies>39 Then 'Pass' Else 'FAIL' END as Status from Class_10_Commerce, Student where Class_10_Commerce.id = Student.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(StudentTable);
            }
            else if (Class == "9" && Background == "Arts")
            {
                string query = "Select Class_9_Arts.id , Student.Name, Class_9_Arts.Bangla_1st, Class_9_Arts.Bangla_2nd, Class_9_Arts.English_1st, Class_9_Arts.English_2nd, Class_9_Arts.G_Math, Class_9_Arts.Economics, Class_9_Arts.History, Class_9_Arts.Psychology, Class_9_Arts.Sociology, Class_9_Arts.Bangladesh_Studies, Class_9_Arts.Section, CASE When Bangla_1st>39 and Bangla_2nd>39 and English_1st>39 and English_2nd>39 and G_Math>39 and Economics>39 and History>39 and Psychology>39  and Sociology> 39 and Bangladesh_Studies>39 Then 'Pass' Else 'FAIL' END as Status from Class_9_Arts, Student where Class_9_Arts.id = student.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(StudentTable);
            }
            else if (Class == "10" && Background == "Arts")
            {
                string query = "Select Class_10_Arts.id , Student.Name, Class_10_Arts.Bangla_1st, Class_10_Arts.Bangla_2nd, Class_10_Arts.English_1st, Class_10_Arts.English_2nd, Class_10_Arts.G_Math, Class_10_Arts.Economics, Class_10_Arts.History, Class_10_Arts.Psychology, Class_10_Arts.Sociology, Class_10_Arts.Bangladesh_Studies, Class_10_Arts.Section, CASE When Bangla_1st>39 and Bangla_2nd>39 and English_1st>39 and English_2nd>39 and G_Math>39 and Economics>39 and History>39 and Psychology>39  and Sociology> 39 and Bangladesh_Studies>39 Then 'Pass' Else 'FAIL' END as Status from Class_10_Arts, Student where Class_10_Arts.id = student.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(StudentTable);
            }
            return StudentTable;
        }
        public DataTable View_Notice()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");
            DataTable dataTable = new DataTable();
            string query = "Select Notice_ID, Notice, Notice_To, Time from AdminNotice where Notice_To='All' or Notice_To='Student'";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            sda.Fill(dataTable);
            return dataTable;
        }

        public bool Order_Insert(StudentInfo s)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");

            try
            {
                connection.Open();
               
                    string Order_Entry = "Insert into Canteen_Order (id, Order_Menu, Price,Room_No) values(@id, @Om, @P,@r) ";
                    SqlCommand cmd_Order_Entry = new SqlCommand(Order_Entry, connection);
                    cmd_Order_Entry.Parameters.AddWithValue("@id", s.Student_id);
                    cmd_Order_Entry.Parameters.AddWithValue("@Om", s.Food_list);
                    cmd_Order_Entry.Parameters.AddWithValue("@P", s.Total_price);
                    cmd_Order_Entry.Parameters.AddWithValue("@r", s.Room);
                    int rows;
               
                    rows = cmd_Order_Entry.ExecuteNonQuery();

                    if (connection.State == ConnectionState.Open)
                    {

                        if (rows > 0)
                        {
                            isSuccess = true;
                            //MessageBox.Show(s.selection.ToString());
                            // MessageBox.Show(rows2.ToString());
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

        public string Food_Order_Status_Check()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");
            DataTable Order_Table = new DataTable();
            string query = "Select Status from Canteen_Order where id='"+Student_id+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            sda.Fill(Order_Table);
            string x;
            try
            {
                x=Order_Table.Rows[0][0].ToString().TrimEnd().TrimStart().ToLower();
            }
            catch(Exception e)
            {
                x = "";
            }
            finally
            {

            }
            
            return x;
        }


    }
}
