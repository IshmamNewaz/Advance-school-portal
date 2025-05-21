using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Advance_School_Portal
{
    class AdminJob
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public string Gender { get; set; }
    

        public DataTable Select()
        {
            //Step 1: Database Connection
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HCJ32PK\\SQLEXPRESS;Initial Catalog=LoginDB;Persist Security Info=True;User ID=IN_Base;Password=IN123");

            DataTable dt = new DataTable();

            //Step 2: Writing SQL query

            string query = "Select * from StudentInfo";

            //Creating cmd using sql and connection string            

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            sda.Fill(dt);

            return dt;
        }

        //Inserting data into database table
        public bool Insert(AdminJob s)
        {
            
            //creating a default return type and setting its value to false
            bool isSuccess = false;

            //Step 1: Database Connection

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HCJ32PK\\SQLEXPRESS;Initial Catalog=LoginDB;Persist Security Info=True;User ID=IN_Base;Password=IN123");
            try
            {                                                         

                //Step 2: Writing SQL query

                string query = "Insert into test (id,username,password,type)values(@id,@username,@password,@type)";
                //Creating cmd using sql and connection string
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", s.id);
                cmd.Parameters.AddWithValue("@username", s.username);
                cmd.Parameters.AddWithValue("@password", s.password);
                cmd.Parameters.AddWithValue("@type", s.type);

                

                con.Open();

                if(con.State == ConnectionState.Open)
                {
                    int rows = cmd.ExecuteNonQuery();

                    if(rows>0)
                    {
                        isSuccess = true;
                    }
                }                                                               
                
            }
            catch(Exception e)
            {

            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }

        //Updating data into database table
        public bool Update(AdminJob s)
        {
            //creating a default return type and setting its value to false

            bool isSuccess = false;

            //Step 1: Database Connection
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HCJ32PK\\SQLEXPRESS;Initial Catalog=LoginDB;Persist Security Info=True;User ID=IN_Base;Password=IN123");
            try
            {
               

                //Step 2: Writing SQL query

                string query = "Update StudentInfo set FirstName=@FirstName, LastName=@LastName, Address=@Address, Gender=@Gender, DOB=@DOB where StudentId=@StudentID";
                //Creating cmd using sql and connection string
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FirstName", s.id);
                cmd.Parameters.AddWithValue("@LastName", s.username);
                cmd.Parameters.AddWithValue("@Address", s.password);
                cmd.Parameters.AddWithValue("@Gender", s.type);               
                //cmd.Parameters.AddWithValue("@StudentID", s.StudentID);

                con.Open();

                if (con.State == ConnectionState.Open)
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

            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }

        //Deleting data into database table
        public bool Delete(AdminJob s)
        {
            //creating a default return type and setting its value to false

            bool isSuccess = false;

            //Step 1: Database Connection
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HCJ32PK\\SQLEXPRESS;Initial Catalog=LoginDB;Persist Security Info=True;User ID=IN_Base;Password=IN123");
            try
            {


                //Step 2: Writing SQL query
                
                string query = "Delete from StudentInfo where StudentID=@StudentID";
                //Creating cmd using sql and connection string
                SqlCommand cmd = new SqlCommand(query, con);

                //cmd.Parameters.AddWithValue("@StudentID", s.StudentID);

                con.Open();

                if (con.State == ConnectionState.Open)
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

            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }

   
    }



   
}
