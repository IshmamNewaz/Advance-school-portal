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
    class AdminInfo
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public string Universal1 { get; set; }
        public string Universal2 { get; set; }
        public string Universal3 { get; set; }

        public string NoticeId { get; set; }
        public string Notice { get; set; }
        public string NoticeTo { get; set; }
        public string Background { get; set; }
        public string Class_Teacher { get; set; }
        public string select_Class { get; set; }

        public int selection { get; set; }


        public DataTable Select(int x)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");

            DataTable dataTable = new DataTable();
            
            if (x == 1)
            {
                string query = "Select login.id, login.username, login.password, login.type, admin.designation, admin.joining from login , admin where login.id = admin.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(dataTable);
            }
            else if (x == 2)
            {
                string query = "Select login.id, login.username, login.password, login.type, student.section, student.Class, student.enrollment, student.Background from login , student where login.id = student.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(dataTable);
            }
            else if (x == 3)
            {
                string query = "Select login.id, login.username, login.password, login.type, teacher.designation, teacher.section, teacher.Class, teacher.join_date, teacher.Background, teacher.Teacher_Type from login, teacher where login.id = teacher.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(dataTable);
            }
            else if (x == 4)
            {
                string query = "Select id, username, password, type from login where type='canteen'";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(dataTable);
            }
            else if (x == 5)
            {
                string query = "Select Notice_ID, Notice, Notice_To, Time from AdminNotice";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(dataTable);
            }

            return dataTable;
        }
        public bool Insert(AdminInfo s)
        {
           //int rows=0;
            //int rows2=0;
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");

            try
            {
                
                connection.Open();
                if (s.selection == 1)
                {
                    string query = "Insert into login (id,username,password,type)values(@Id,@UN,@Pw,@Tp)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    int rows, rows2, rows3, rows4;
                    cmd.Parameters.AddWithValue("@Id", s.id);
                    cmd.Parameters.AddWithValue("@UN", s.username);
                    cmd.Parameters.AddWithValue("@Pw", s.password);
                    cmd.Parameters.AddWithValue("@Tp", s.type);

                    string query2 = "Insert into admin (id,Admin_Name,Designation,Joining)values(@AdminID,@AdminName,@AdminDes,@AdminJoining)";
                    SqlCommand cmd2 = new SqlCommand(query2, connection);
                    cmd2.Parameters.AddWithValue("@AdminID", s.id);
                    cmd2.Parameters.AddWithValue("@AdminName", s.username);
                    cmd2.Parameters.AddWithValue("@AdminDes", s.Universal1);
                    cmd2.Parameters.AddWithValue("@AdminJoining", s.Universal2);
                    rows2 = cmd2.ExecuteNonQuery();
                    rows = cmd.ExecuteNonQuery();

                    if (connection.State == ConnectionState.Open)
                    {

                        if (rows > 0 && rows2 > 0)
                        {
                            isSuccess = true;
                            //MessageBox.Show(s.selection.ToString());
                            // MessageBox.Show(rows2.ToString());
                        }
                    }

                }
                else if (s.selection==2)
                {
                    string query = "Insert into login (id,username,password,type)values(@Id,@UN,@Pw,@Tp)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    int rows, rows2, rows3, rows4;
                    cmd.Parameters.AddWithValue("@Id", s.id);
                    cmd.Parameters.AddWithValue("@UN", s.username);
                    cmd.Parameters.AddWithValue("@Pw", s.password);
                    cmd.Parameters.AddWithValue("@Tp", s.type);

                    string student = "Insert into Student (id,Name,Section,Enrollment, Background, Class)values(@StudentId,@StudentName,@StudentSec,@StudentEn, @StudentBackground, @StudentClass)";
                    SqlCommand cmd3 = new SqlCommand(student, connection);
                    cmd3.Parameters.AddWithValue("@StudentId", s.id);
                    cmd3.Parameters.AddWithValue("@StudentName", s.username);
                    cmd3.Parameters.AddWithValue("@StudentSec", s.Universal1);
                    cmd3.Parameters.AddWithValue("@StudentEn", s.Universal2);
                    cmd3.Parameters.AddWithValue("@StudentBackground", s.Background);
                    cmd3.Parameters.AddWithValue("@StudentClass", s.select_Class);
                    rows3 = cmd3.ExecuteNonQuery();
                    
                    rows = cmd.ExecuteNonQuery();

                    if (s.select_Class == "8")
                    {
                        string class_8 = "Insert into Class_8 (id,Section)values(@MarksId,@MarksSection)";
                        SqlCommand cmd_class_8 = new SqlCommand(class_8, connection);
                        cmd_class_8.Parameters.AddWithValue("@MarksId", s.id);
                        cmd_class_8.Parameters.AddWithValue("@MarksSection", s.Universal1);
                        rows2 = cmd_class_8.ExecuteNonQuery();
                        if (connection.State == ConnectionState.Open)
                        {

                            if (rows > 0 && rows3 > 0 && rows2>0)
                            {
                                isSuccess = true;
                            }
                        }
                    }
                    else if (s.select_Class == "9" && s.Background=="Science")
                    {
                        string class_9_Science = "Insert into Class_9_Science (id,Section)values(@MarksId,@MarksSection)";
                        SqlCommand cmd_class_9_Science = new SqlCommand(class_9_Science, connection);
                        cmd_class_9_Science.Parameters.AddWithValue("@MarksId", s.id);
                        cmd_class_9_Science.Parameters.AddWithValue("@MarksSection", s.Universal1);
                        rows2 = cmd_class_9_Science.ExecuteNonQuery();
                        if (connection.State == ConnectionState.Open)
                        {

                            if (rows > 0 && rows3 > 0 && rows2 > 0)
                            {
                                isSuccess = true;
                            }
                        }
                    }
                    else if (s.select_Class == "10" && s.Background=="Science")
                    {
                        string class_10_Science = "Insert into Class_10_Science (id,Section)values(@MarksId,@MarksSection)";
                        SqlCommand cmd_class_10_Science = new SqlCommand(class_10_Science, connection);
                        cmd_class_10_Science.Parameters.AddWithValue("@MarksId", s.id);
                        cmd_class_10_Science.Parameters.AddWithValue("@MarksSection", s.Universal1);
                        rows2 = cmd_class_10_Science.ExecuteNonQuery();
                        if (connection.State == ConnectionState.Open)
                        {

                            if (rows > 0 && rows3 > 0 && rows2 > 0)
                            {
                                isSuccess = true;
                            }
                        }
                    }
                    else if (s.select_Class == "9" && s.Background == "Commerce")
                    {
                        string class_9_Commerce = "Insert into Class_9_Commerce (id,Section)values(@MarksId,@MarksSection)";
                        SqlCommand cmd_Class_9_Commerce = new SqlCommand(class_9_Commerce, connection);
                        cmd_Class_9_Commerce.Parameters.AddWithValue("@MarksId", s.id);
                        cmd_Class_9_Commerce.Parameters.AddWithValue("@MarksSection", s.Universal1);
                        rows2 = cmd_Class_9_Commerce.ExecuteNonQuery();
                        if (connection.State == ConnectionState.Open)
                        {

                            if (rows > 0 && rows3 > 0 && rows2 > 0)
                            {
                                isSuccess = true;
                            }
                        }
                    }
                    else if (s.select_Class == "10" && s.Background == "Commerce")
                    {
                        string class_10_Commerce = "Insert into Class_10_Commerce (id,Section)values(@MarksId,@MarksSection)";
                        SqlCommand cmd_Class_10_Commerce = new SqlCommand(class_10_Commerce, connection);
                        cmd_Class_10_Commerce.Parameters.AddWithValue("@MarksId", s.id);
                        cmd_Class_10_Commerce.Parameters.AddWithValue("@MarksSection", s.Universal1);
                        rows2 = cmd_Class_10_Commerce.ExecuteNonQuery();
                        if (connection.State == ConnectionState.Open)
                        {

                            if (rows > 0 && rows3 > 0 && rows2 > 0)
                            {
                                isSuccess = true;
                            }
                        }
                    }
                    else if (s.select_Class == "9" && s.Background == "Arts")
                    {
                        string class_9_Arts = "Insert into Class_9_Arts (id,Section)values(@MarksId,@MarksSection)";
                        SqlCommand cmd_Class_9_Arts = new SqlCommand(class_9_Arts, connection);
                        cmd_Class_9_Arts.Parameters.AddWithValue("@MarksId", s.id);
                        cmd_Class_9_Arts.Parameters.AddWithValue("@MarksSection", s.Universal1);
                        rows2 = cmd_Class_9_Arts.ExecuteNonQuery();
                        if (connection.State == ConnectionState.Open)
                        {

                            if (rows > 0 && rows3 > 0 && rows2 > 0)
                            {
                                isSuccess = true;
                            }
                        }
                    }
                    else if (s.select_Class == "10" && s.Background == "Arts")
                    {
                        string class_10_Arts = "Insert into Class_10_Arts (id,Section)values(@MarksId,@MarksSection)";
                        SqlCommand cmd_Class_10_Arts = new SqlCommand(class_10_Arts, connection);
                        cmd_Class_10_Arts.Parameters.AddWithValue("@MarksId", s.id);
                        cmd_Class_10_Arts.Parameters.AddWithValue("@MarksSection", s.Universal1);
                        rows2 = cmd_Class_10_Arts.ExecuteNonQuery();
                        if (connection.State == ConnectionState.Open)
                        {

                            if (rows > 0 && rows3 > 0 && rows2 > 0)
                            {
                                isSuccess = true;
                            }
                        }
                    }


                }
                else if (s.selection == 3)
                {
                    string query = "Insert into login (id,username,password,type)values(@Id,@UN,@Pw,@Tp)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    int rows, rows2, rows3, rows4;
                    cmd.Parameters.AddWithValue("@Id", s.id);
                    cmd.Parameters.AddWithValue("@UN", s.username);
                    cmd.Parameters.AddWithValue("@Pw", s.password);
                    cmd.Parameters.AddWithValue("@Tp", s.type);
                    string teacher = "Insert into teacher (id,Name,Designation,Section,Join_Date,Background,Teacher_Type,Class )values(@TeacherId,@TeacherName,@TeacherDesignation,@TeacherSection,@TeacherJoinDate,@TeacherBackground, @TeacherType,@TeacherClass)";
                    SqlCommand cmd4 = new SqlCommand(teacher, connection);
                    cmd4.Parameters.AddWithValue("@TeacherId", s.id);
                    cmd4.Parameters.AddWithValue("@TeacherName", s.username);
                    cmd4.Parameters.AddWithValue("@TeacherDesignation", s.Universal1);
                    cmd4.Parameters.AddWithValue("@TeacherSection", s.Universal2);
                    cmd4.Parameters.AddWithValue("@TeacherJoinDate", s.Universal3);
                    cmd4.Parameters.AddWithValue("@TeacherBackground", s.Background);
                    cmd4.Parameters.AddWithValue("@TeacherType", s.Class_Teacher);
                    cmd4.Parameters.AddWithValue("@TeacherClass", s.select_Class);

                    rows4 = cmd4.ExecuteNonQuery();

                    rows = cmd.ExecuteNonQuery();

                    if (connection.State == ConnectionState.Open)
                    {

                        if (rows > 0 && rows4 > 0)
                        {
                            isSuccess = true;
                        }
                    }
                }
                else if (s.selection == 4)
                {
                    string query = "Insert into login (id,username,password,type)values(@Id,@UN,@Pw,@Tp)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    int rows, rows2, rows3, rows4;
                    cmd.Parameters.AddWithValue("@Id", s.id);
                    cmd.Parameters.AddWithValue("@UN", s.username);
                    cmd.Parameters.AddWithValue("@Pw", s.password);
                    cmd.Parameters.AddWithValue("@Tp", s.type);
                    rows = cmd.ExecuteNonQuery();

                    if (connection.State == ConnectionState.Open)
                    {

                        if (rows > 0)
                        {
                            isSuccess = true;
                        }
                    }
                }
                else if (s.selection == 5)
                {
                    string query = "Insert into AdminNotice (Notice_ID,Notice,Notice_To)values(@Id,@UN,@Pw)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    int rows, rows2, rows3, rows4;
                    cmd.Parameters.AddWithValue("@Id", s.NoticeId);
                    cmd.Parameters.AddWithValue("@UN", s.Notice);
                    cmd.Parameters.AddWithValue("@Pw", s.NoticeTo);
                    //cmd.Parameters.AddWithValue("@Tp", s.type);
                    rows = cmd.ExecuteNonQuery();

                    if (connection.State == ConnectionState.Open)
                    {

                        if (rows > 0)
                        {
                            isSuccess = true;
                        }
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

        public bool Update(AdminInfo s)
        {
            //int rows=0;
            //int rows2=0;
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");

            try
            {

                connection.Open();
                if (s.selection == 1)
                {
                    string query = "Update login set username=@UN, password=@Pw, type=@Tp where id=@Id";

                    
                    SqlCommand cmd = new SqlCommand(query, connection);
                    int rows, rows2, rows3, rows4;
                    cmd.Parameters.AddWithValue("@Id", s.id);
                    cmd.Parameters.AddWithValue("@UN", s.username);
                    cmd.Parameters.AddWithValue("@Pw", s.password);
                    cmd.Parameters.AddWithValue("@Tp", s.type);
                    
                    string query2 = "Update admin set Admin_Name=@AdminName, Designation=@AdminDes where id=@AdminID";

                    
                    SqlCommand cmd2 = new SqlCommand(query2, connection);
                    cmd2.Parameters.AddWithValue("@AdminID", s.id);
                    cmd2.Parameters.AddWithValue("@AdminName", s.username);
                    cmd2.Parameters.AddWithValue("@AdminDes", s.Universal1);
                    //cmd2.Parameters.AddWithValue("@AdminJoining", s.Universal2);
                    rows2 = cmd2.ExecuteNonQuery();
                    rows = cmd.ExecuteNonQuery();

                    if (connection.State == ConnectionState.Open)
                    {

                        if (rows > 0 && rows2 > 0)
                        {
                            isSuccess = true;
                            //MessageBox.Show(s.selection.ToString());
                            // MessageBox.Show(rows2.ToString());
                        }
                    }

                }
                else if (s.selection == 2)
                {
                    string query = "Update login set username=@UN, password=@Pw, type=@Tp where id=@Id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    int rows, rows2, rows3, rows4;
                    cmd.Parameters.AddWithValue("@Id", s.id);
                    cmd.Parameters.AddWithValue("@UN", s.username);
                    cmd.Parameters.AddWithValue("@Pw", s.password);
                    cmd.Parameters.AddWithValue("@Tp", s.type);

                    string student = "Update Student set Name=@StudentName, Section=@StudentSec where id=@StudentId";
                    SqlCommand cmd3 = new SqlCommand(student, connection);
                    cmd3.Parameters.AddWithValue("@StudentId", s.id);
                    cmd3.Parameters.AddWithValue("@StudentName", s.username);
                    cmd3.Parameters.AddWithValue("@StudentSec", s.Universal1);
                    rows3 = cmd3.ExecuteNonQuery();
                    rows = cmd.ExecuteNonQuery();

                    if (connection.State == ConnectionState.Open)
                    {

                        if (rows > 0 && rows3 > 0)
                        {
                            isSuccess = true;
                            //MessageBox.Show(s.selection.ToString());
                            // MessageBox.Show(rows2.ToString());
                        }
                    }

                }
                else if (s.selection == 3)
                {
                    string query = "Update login set username=@UN, password=@Pw, type=@Tp where id=@Id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    int rows, rows2, rows3, rows4;
                    cmd.Parameters.AddWithValue("@Id", s.id);
                    cmd.Parameters.AddWithValue("@UN", s.username);
                    cmd.Parameters.AddWithValue("@Pw", s.password);
                    cmd.Parameters.AddWithValue("@Tp", s.type);
                    string teacher = "update teacher set Name=@TeacherName,Designation=@TeacherDesignation,Section=@TeacherSection, Teacher_Type=@TeacherType, Class=@TeacherClass where id=@TeacherId";
                    SqlCommand cmd4 = new SqlCommand(teacher, connection);
                    cmd4.Parameters.AddWithValue("@TeacherId", s.id);
                    cmd4.Parameters.AddWithValue("@TeacherName", s.username);
                    cmd4.Parameters.AddWithValue("@TeacherDesignation", s.Universal1);
                    cmd4.Parameters.AddWithValue("@TeacherSection", s.Universal2);
                    cmd4.Parameters.AddWithValue("@TeacherType", s.Class_Teacher);
                    cmd4.Parameters.AddWithValue("@TeacherClass", s.select_Class);

                    rows4 = cmd4.ExecuteNonQuery();

                    rows = cmd.ExecuteNonQuery();

                    if (connection.State == ConnectionState.Open)
                    {

                        if (rows > 0 && rows4 > 0)
                        {
                            isSuccess = true;
                        }
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
        public bool Delete(AdminInfo s)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");
            try
            {
                if (s.selection == 1)
                {
                    string query = "Delete from login where id=@id";
                    string admin = "Delete from admin where id=@adminId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlCommand cmd2 = new SqlCommand(admin, connection);
                    
                    cmd.Parameters.AddWithValue("@id", s.id);
                    cmd2.Parameters.AddWithValue("@adminId", s.id);

                    connection.Open();

                    if (connection.State == ConnectionState.Open)
                    {
                        int rows = cmd.ExecuteNonQuery();
                        int rows2 = cmd2.ExecuteNonQuery();

                        if (rows > 0&& rows2 >0)
                        {
                            isSuccess = true;
                        }
                    }
                }
                else if (s.selection == 2)
                {
                    string query = "Delete from login where id=@id";
                    string student = "Delete from student where id=@StudentId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlCommand cmd2 = new SqlCommand(student, connection);

                    cmd.Parameters.AddWithValue("@id", s.id);
                    cmd2.Parameters.AddWithValue("@StudentId", s.id);

                    connection.Open();

                    if (connection.State == ConnectionState.Open)
                    {
                        int rows = cmd.ExecuteNonQuery();
                        int rows2 = cmd2.ExecuteNonQuery();

                        if (rows > 0 && rows2 > 0)
                        {
                            isSuccess = true;
                        }
                    }
                }
                else if (s.selection == 3)
                {
                    string query = "Delete from login where id=@id";
                    string teacher = "Delete from teacher where id=@Teacherid";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlCommand cmd2 = new SqlCommand(teacher, connection);

                    cmd.Parameters.AddWithValue("@id", s.id);
                    cmd2.Parameters.AddWithValue("@Teacherid", s.id);

                    connection.Open();

                    if (connection.State == ConnectionState.Open)
                    {
                        int rows = cmd.ExecuteNonQuery();
                        int rows2 = cmd2.ExecuteNonQuery();

                        if (rows > 0 && rows2 > 0)
                        {
                            isSuccess = true;
                        }
                    }

                }
                else if (s.selection == 4)
                {
                    string query = "Delete from login where id=@id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", s.id);
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
                else if (selection == 5)
                {
                    string query = "Delete from AdminNotice where Notice_ID=@NoticeId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@NoticeId", s.NoticeId);
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
