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
    class TeacherInfo
    {
        public string Class_With_Background { get; set; }
        public string Stu_Id { get; set; }
        public string Sub1 { get; set; }
        public string Sub2 { get; set; }
        public string Sub3 { get; set; }
        public string Sub4 { get; set; }
        public string Sub5 { get; set; }
        public string Sub6 { get; set; }
        public string Sub7 { get; set; }
        public string Sub8 { get; set; }
        public string Sub9 { get; set; }
        public string Sub10 { get; set; }

        public string Check_Class_Teacher { get; set; }
        public string Check_Class {get; set;}

        public string NoticeId { get; set; }
        public string Notice { get; set; }


        public DataTable Teacher_Select(string class_bg)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");
            DataTable TeacherDataTable = new DataTable();
            if (class_bg=="C8")
            {
                string query = "Select Class_8.id, Student.Name,  Class_8.Bangla, Class_8.English, Class_8.Math, Class_8.Bangladesh_Studies, Class_8.Religion, Class_8.Physical_Education,Class_8.Section, CASE When  Bangla>39 and English>39 and Math>39 and Bangladesh_Studies>39 and Religion>39 and Physical_Education>39 Then 'Pass' Else 'FAIL' END as Status from Class_8, Student where Class_8.id = Student.id ";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(TeacherDataTable);
            }
            else if(class_bg == "C9S")
            {
                string query = "Select Class_9_Science.id , Student.Name, Class_9_Science.Bangla_1st, Class_9_Science.Bangla_2nd, Class_9_Science.English_1st, Class_9_Science.English_2nd, Class_9_Science.G_Math, Class_9_Science.H_Math, Class_9_Science.Biology, Class_9_Science.Physics, Class_9_Science.Chemistry, Class_9_Science.Bangladesh_Studies, Class_9_Science.Section, CASE WHEN Bangla_1st>39 and Bangla_2nd>39 and English_1st>39 and English_2nd>39 and G_Math >39 and H_Math >39 and Biology>39 and Physics>0 and Chemistry>39 and Bangladesh_Studies>39 Then  'PASS' ELSE 'FAIL' END AS STATUS from Class_9_Science, Student  where Class_9_Science.id=Student.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(TeacherDataTable);
            }
            else if(class_bg == "C10S")
            {
                string query = "Select Class_10_Science.id , Student.Name, Class_10_Science.Bangla_1st, Class_10_Science.Bangla_2nd, Class_10_Science.English_1st, Class_10_Science.English_2nd, Class_10_Science.G_Math, Class_10_Science.H_Math, Class_10_Science.Biology, Class_10_Science.Physics, Class_10_Science.Chemistry, Class_10_Science.Bangladesh_Studies, Class_10_Science.Section, CASE WHEN Bangla_1st>39 and Bangla_2nd>39 and English_1st>39 and English_2nd>39 and G_Math >39 and H_Math >39 and Biology>39 and Physics>0 and Chemistry>39 and Bangladesh_Studies>39 Then  'PASS' ELSE 'FAIL' END AS STATUS from Class_10_Science, Student  where Class_10_Science.id=Student.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(TeacherDataTable);
            }
            else if (class_bg == "C9C")
            {
                string query = "Select Class_9_Commerce.id , Student.Name, Class_9_Commerce.Bangla_1st, Class_9_Commerce.Bangla_2nd, Class_9_Commerce.English_1st, Class_9_Commerce.English_2nd, Class_9_Commerce.G_Math, Class_9_Commerce.Economics, Class_9_Commerce.Business_Entrepreneurship, Class_9_Commerce.Finance, Class_9_Commerce.Accounting, Class_9_Commerce.Bangladesh_Studies, Class_9_Commerce.Section, CASE When Bangla_1st>39 and Bangla_2nd>39 and English_1st>39 and English_2nd>39 and G_Math>39 and Economics>39 and Business_Entrepreneurship>39 and Finance>39 and Accounting>39 and Bangladesh_Studies>39 Then 'Pass' Else 'FAIL' END as Status from Class_9_Commerce,  Student where Class_9_Commerce.id = Student.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(TeacherDataTable);
            }
            else if (class_bg == "C10C")
            {
                string query = "Select Class_10_Commerce.id , Student.Name, Class_10_Commerce.Bangla_1st, Class_10_Commerce.Bangla_2nd, Class_10_Commerce.English_1st, Class_10_Commerce.English_2nd, Class_10_Commerce.G_Math, Class_10_Commerce.Economics, Class_10_Commerce.Business_Entrepreneurship, Class_10_Commerce.Finance, Class_10_Commerce.Accounting, Class_10_Commerce.Bangladesh_Studies, Class_10_Commerce.Section, CASE When Bangla_1st>39 and Bangla_2nd>39 and English_1st>39 and English_2nd>39 and G_Math>39 and Economics>39 and Business_Entrepreneurship>39 and Finance>39 and Accounting>39 and Bangladesh_Studies>39 Then 'Pass' Else 'FAIL' END as Status from Class_10_Commerce, Student where Class_10_Commerce.id = Student.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(TeacherDataTable);
            }
            else if (class_bg == "C9A")
            {
                string query = "Select Class_9_Arts.id , Student.Name, Class_9_Arts.Bangla_1st, Class_9_Arts.Bangla_2nd, Class_9_Arts.English_1st, Class_9_Arts.English_2nd, Class_9_Arts.G_Math, Class_9_Arts.Economics, Class_9_Arts.History, Class_9_Arts.Psychology, Class_9_Arts.Sociology, Class_9_Arts.Bangladesh_Studies, Class_9_Arts.Section, CASE When Bangla_1st>39 and Bangla_2nd>39 and English_1st>39 and English_2nd>39 and G_Math>39 and Economics>39 and History>39 and Psychology>39  and Sociology> 39 and Bangladesh_Studies>39 Then 'Pass' Else 'FAIL' END as Status from Class_9_Arts, Student where Class_9_Arts.id = student.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(TeacherDataTable);
            }
            else if (class_bg == "C10A")
            {
                string query = "Select Class_10_Arts.id , Student.Name, Class_10_Arts.Bangla_1st, Class_10_Arts.Bangla_2nd, Class_10_Arts.English_1st, Class_10_Arts.English_2nd, Class_10_Arts.G_Math, Class_10_Arts.Economics, Class_10_Arts.History, Class_10_Arts.Psychology, Class_10_Arts.Sociology, Class_10_Arts.Bangladesh_Studies, Class_10_Arts.Section, CASE When Bangla_1st>39 and Bangla_2nd>39 and English_1st>39 and English_2nd>39 and G_Math>39 and Economics>39 and History>39 and Psychology>39  and Sociology> 39 and Bangladesh_Studies>39 Then 'Pass' Else 'FAIL' END as Status from Class_10_Arts, Student where Class_10_Arts.id = student.id";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.Fill(TeacherDataTable);
            }
            return TeacherDataTable;
        }
        public bool Teacher_Insert(TeacherInfo t)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");

            try
            {
                connection.Open();
                if (t.Class_With_Background=="C8")
                {
                    string Class_8 = "Update Class_8 set Bangla=@TBangla, English=@TEnglish, Math=@TMath, Bangladesh_Studies=@TBStudies, Religion=@TReligion, Physical_Education=@TPE  where Class_8.id=@TId";
                    SqlCommand cmd_Class_8 = new SqlCommand(Class_8, connection);
                    cmd_Class_8.Parameters.AddWithValue("@TId", t.Stu_Id);
                    cmd_Class_8.Parameters.AddWithValue("@TBangla", t.Sub1);
                    cmd_Class_8.Parameters.AddWithValue("@TEnglish", t.Sub2);
                    cmd_Class_8.Parameters.AddWithValue("@TMath", t.Sub3);
                    cmd_Class_8.Parameters.AddWithValue("@TBStudies", t.Sub4);
                    cmd_Class_8.Parameters.AddWithValue("@TReligion", t.Sub5);
                    cmd_Class_8.Parameters.AddWithValue("@TPE", t.Sub6);
                    int rows;

                    rows = cmd_Class_8.ExecuteNonQuery();

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
                else if (t.Class_With_Background == "C9S")
                {
                    string Class_8 = "Update Class_9_Science set Bangla_1st=@TBangla_1st, Bangla_2nd=@TBangla_2nd, English_1st=@TEnglish_1st, English_2nd=@TEnglish_2nd, G_Math=@TGMath, H_Math=@THMath, Biology=@TBiology, Physics=@TPhysics, Chemistry=@TChemistry, Bangladesh_Studies=@TB_S  where Class_9_Science.id=@TId";
                    SqlCommand cmd_Class_8 = new SqlCommand(Class_8, connection);
                    cmd_Class_8.Parameters.AddWithValue("@TId", t.Stu_Id);
                    cmd_Class_8.Parameters.AddWithValue("@TBangla_1st", t.Sub1);
                    cmd_Class_8.Parameters.AddWithValue("@TBangla_2nd", t.Sub2);
                    cmd_Class_8.Parameters.AddWithValue("@TEnglish_1st", t.Sub3);
                    cmd_Class_8.Parameters.AddWithValue("@TEnglish_2nd", t.Sub4);
                    cmd_Class_8.Parameters.AddWithValue("@TGMath", t.Sub5);
                    cmd_Class_8.Parameters.AddWithValue("@THMath", t.Sub6);
                    cmd_Class_8.Parameters.AddWithValue("@TBiology", t.Sub7);
                    cmd_Class_8.Parameters.AddWithValue("@TPhysics", t.Sub8);
                    cmd_Class_8.Parameters.AddWithValue("@TChemistry", t.Sub9);
                    cmd_Class_8.Parameters.AddWithValue("@TB_S", t.Sub10);
                   
                    int rows;

                    rows = cmd_Class_8.ExecuteNonQuery();

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
                else if (t.Class_With_Background == "C10S")
                {
                    string Class_8 = "Update Class_10_Science set Bangla_1st=@TBangla_1st, Bangla_2nd=@TBangla_2nd, English_1st=@TEnglish_1st, English_2nd=@TEnglish_2nd, G_Math=@TGMath, H_Math=@THMath, Biology=@TBiology, Physics=@TPhysics, Chemistry=@TChemistry, Bangladesh_Studies=@TB_S  where Class_10_Science.id=@TId";
                    SqlCommand cmd_Class_8 = new SqlCommand(Class_8, connection);
                    cmd_Class_8.Parameters.AddWithValue("@TId", t.Stu_Id);
                    cmd_Class_8.Parameters.AddWithValue("@TBangla_1st", t.Sub1);
                    cmd_Class_8.Parameters.AddWithValue("@TBangla_2nd", t.Sub2);
                    cmd_Class_8.Parameters.AddWithValue("@TEnglish_1st", t.Sub3);
                    cmd_Class_8.Parameters.AddWithValue("@TEnglish_2nd", t.Sub4);
                    cmd_Class_8.Parameters.AddWithValue("@TGMath", t.Sub5);
                    cmd_Class_8.Parameters.AddWithValue("@THMath", t.Sub6);
                    cmd_Class_8.Parameters.AddWithValue("@TBiology", t.Sub7);
                    cmd_Class_8.Parameters.AddWithValue("@TPhysics", t.Sub8);
                    cmd_Class_8.Parameters.AddWithValue("@TChemistry", t.Sub9);
                    cmd_Class_8.Parameters.AddWithValue("@TB_S", t.Sub10);

                    int rows;

                    rows = cmd_Class_8.ExecuteNonQuery();

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
                else if (t.Class_With_Background == "C9C")
                {
                    string Class_8 = "Update Class_9_Commerce set Bangla_1st=@TBangla_1st, Bangla_2nd=@TBangla_2nd, English_1st=@TEnglish_1st, English_2nd=@TEnglish_2nd, G_Math=@TGMath, Economics=@TEconomics, Accounting=@TAcc, Business_Entrepreneurship=@TB_Entre, Finance=@TFinance, Bangladesh_Studies=@TB_S  where Class_9_Commerce.id=@TId";
                    SqlCommand cmd_Class_8 = new SqlCommand(Class_8, connection);
                    cmd_Class_8.Parameters.AddWithValue("@TId", t.Stu_Id);
                    cmd_Class_8.Parameters.AddWithValue("@TBangla_1st", t.Sub1);
                    cmd_Class_8.Parameters.AddWithValue("@TBangla_2nd", t.Sub2);
                    cmd_Class_8.Parameters.AddWithValue("@TEnglish_1st", t.Sub3);
                    cmd_Class_8.Parameters.AddWithValue("@TEnglish_2nd", t.Sub4);
                    cmd_Class_8.Parameters.AddWithValue("@TGMath", t.Sub5);
                    cmd_Class_8.Parameters.AddWithValue("@TB_Entre", t.Sub6);
                    cmd_Class_8.Parameters.AddWithValue("@TEconomics", t.Sub7);
                    cmd_Class_8.Parameters.AddWithValue("@TAcc", t.Sub8);
                    cmd_Class_8.Parameters.AddWithValue("@TFinance", t.Sub9);
                    cmd_Class_8.Parameters.AddWithValue("@TB_S", t.Sub10);

                    int rows;

                    rows = cmd_Class_8.ExecuteNonQuery();

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
                else if (t.Class_With_Background == "C10C")
                {
                    string Class_8 = "Update Class_10_Commerce set Bangla_1st=@TBangla_1st, Bangla_2nd=@TBangla_2nd, English_1st=@TEnglish_1st, English_2nd=@TEnglish_2nd, G_Math=@TGMath, Economics=@TEconomics, Accounting=@TAcc, Business_Entrepreneurship=@TB_Entre, Finance=@TFinance, Bangladesh_Studies=@TB_S  where Class_10_Commerce.id=@TId";
                    SqlCommand cmd_Class_8 = new SqlCommand(Class_8, connection);
                    cmd_Class_8.Parameters.AddWithValue("@TId", t.Stu_Id);
                    cmd_Class_8.Parameters.AddWithValue("@TBangla_1st", t.Sub1);
                    cmd_Class_8.Parameters.AddWithValue("@TBangla_2nd", t.Sub2);
                    cmd_Class_8.Parameters.AddWithValue("@TEnglish_1st", t.Sub3);
                    cmd_Class_8.Parameters.AddWithValue("@TEnglish_2nd", t.Sub4);
                    cmd_Class_8.Parameters.AddWithValue("@TGMath", t.Sub5);
                    cmd_Class_8.Parameters.AddWithValue("@TB_Entre", t.Sub6);
                    cmd_Class_8.Parameters.AddWithValue("@TEconomics", t.Sub7);
                    cmd_Class_8.Parameters.AddWithValue("@TAcc", t.Sub8);
                    cmd_Class_8.Parameters.AddWithValue("@TFinance", t.Sub9);
                    cmd_Class_8.Parameters.AddWithValue("@TB_S", t.Sub10);

                    int rows;

                    rows = cmd_Class_8.ExecuteNonQuery();

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
                else if (t.Class_With_Background == "C9A")
                {
                    string Class_8 = "Update Class_9_Arts set Bangla_1st=@TBangla_1st, Bangla_2nd=@TBangla_2nd, English_1st=@TEnglish_1st, English_2nd=@TEnglish_2nd, G_Math=@TGMath, Economics=@TEconomics, History=@THistory, Psychology=@TPsychology, Sociology=@TSciology, Bangladesh_Studies=@TB_S  where Class_9_Arts.id=@TId";
                    SqlCommand cmd_Class_8 = new SqlCommand(Class_8, connection);
                    cmd_Class_8.Parameters.AddWithValue("@TId", t.Stu_Id);
                    cmd_Class_8.Parameters.AddWithValue("@TBangla_1st", t.Sub1);
                    cmd_Class_8.Parameters.AddWithValue("@TBangla_2nd", t.Sub2);
                    cmd_Class_8.Parameters.AddWithValue("@TEnglish_1st", t.Sub3);
                    cmd_Class_8.Parameters.AddWithValue("@TEnglish_2nd", t.Sub4);
                    cmd_Class_8.Parameters.AddWithValue("@TGMath", t.Sub5);
                    cmd_Class_8.Parameters.AddWithValue("@THistory", t.Sub6);
                    cmd_Class_8.Parameters.AddWithValue("@TEconomics", t.Sub7);
                    cmd_Class_8.Parameters.AddWithValue("@TPsychology", t.Sub8);
                    cmd_Class_8.Parameters.AddWithValue("@TSciology", t.Sub9);
                    cmd_Class_8.Parameters.AddWithValue("@TB_S", t.Sub10);

                    int rows;

                    rows = cmd_Class_8.ExecuteNonQuery();

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
                else if (t.Class_With_Background == "C10A")
                {
                    string Class_8 = "Update Class_10_Arts set Bangla_1st=@TBangla_1st, Bangla_2nd=@TBangla_2nd, English_1st=@TEnglish_1st, English_2nd=@TEnglish_2nd, G_Math=@TGMath, Economics=@TEconomics, History=@THistory, Psychology=@TPsychology, Sociology=@TSciology, Bangladesh_Studies=@TB_S  where Class_10_Arts.id=@TId";
                    SqlCommand cmd_Class_8 = new SqlCommand(Class_8, connection);
                    cmd_Class_8.Parameters.AddWithValue("@TId", t.Stu_Id);
                    cmd_Class_8.Parameters.AddWithValue("@TBangla_1st", t.Sub1);
                    cmd_Class_8.Parameters.AddWithValue("@TBangla_2nd", t.Sub2);
                    cmd_Class_8.Parameters.AddWithValue("@TEnglish_1st", t.Sub3);
                    cmd_Class_8.Parameters.AddWithValue("@TEnglish_2nd", t.Sub4);
                    cmd_Class_8.Parameters.AddWithValue("@TGMath", t.Sub5);
                    cmd_Class_8.Parameters.AddWithValue("@THistory", t.Sub6);
                    cmd_Class_8.Parameters.AddWithValue("@TEconomics", t.Sub7);
                    cmd_Class_8.Parameters.AddWithValue("@TPsychology", t.Sub8);
                    cmd_Class_8.Parameters.AddWithValue("@TSciology", t.Sub9);
                    cmd_Class_8.Parameters.AddWithValue("@TB_S", t.Sub10);

                    int rows;

                    rows = cmd_Class_8.ExecuteNonQuery();

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
        
        public DataTable View_Notice()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");
            DataTable dataTable = new DataTable();
            string query = "Select Notice_ID, Notice, Notice_To, Time from AdminNotice where Notice_To = 'Teacher' or Notice_To='All' or Notice_To='Student'";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            sda.Fill(dataTable);
            return dataTable;
        }
        public bool Add_Notice(TeacherInfo t)
        {
            //int rows=0;
            //int rows2=0;
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");

            try
            {
                connection.Open();
                string query = "Insert into AdminNotice (Notice_ID,Notice,Notice_To)values(@Id,@UN,@Pw)";
                SqlCommand cmd = new SqlCommand(query, connection);
                int rows, rows2, rows3, rows4;
                cmd.Parameters.AddWithValue("@Id", t.NoticeId);
                cmd.Parameters.AddWithValue("@UN", t.Notice);
                cmd.Parameters.AddWithValue("@Pw", "Student");
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
        public bool Delete_Notice(TeacherInfo t)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");
            try
            {

                    string query = "Delete from AdminNotice where Notice_ID=@NoticeId and Notice_To='Student'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@NoticeId", t.NoticeId);
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
