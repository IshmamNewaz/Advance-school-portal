using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UITimer = System.Windows.Forms.Timer;

namespace Advance_School_Portal
{
    public partial class LoginForm : Form
    {
        //Button Colors
 
        public LoginForm()
        {
            
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");
        public static UITimer time = new UITimer();
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Pwd_Box.UseSystemPasswordChar = true;
        }

        private void Submit_Click(object sender, EventArgs e)
        {

            string query = "Select type, username from login where id='" + UName_Box.Text + "' and Password='" + Pwd_Box.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            try
            {
                if (dt.Rows[0][0].ToString() == "ADMIN")
                {
                    Admin AdminPage = new Admin();
                    AdminPage.UserNameInInterFace=dt.Rows[0][1].ToString();
                    this.Hide();
                    AdminPage.Show();
                }
                else if (dt.Rows[0][0].ToString() == "STUDENT")
                {
                    string StudentQuerry = "Select Background, Class from Student where id='" + UName_Box.Text + "'";
                    SqlDataAdapter Student_cmd = new SqlDataAdapter(StudentQuerry, con);
                    DataTable Student_Table = new DataTable();
                    Student_cmd.Fill(Student_Table);

                    StudentPage studentPage = new StudentPage();

                    studentPage.Check_Class_Background_From_Login = Student_Table.Rows[0][0].ToString();
                    studentPage.Check_Class_From_Login = Student_Table.Rows[0][1].ToString();

                    studentPage.UserNameInInterFace = dt.Rows[0][1].ToString();

                    studentPage.Get_Id_From_Login = UName_Box.Text;
                    this.Hide();
                    studentPage.Show();
                }
                else if (dt.Rows[0][0].ToString() == "CANTEEN")
                {
                    CanteenStaff CanteenPage = new CanteenStaff();
                    CanteenPage.UserNameInInterFace = dt.Rows[0][1].ToString();
                    this.Hide();
                    CanteenPage.Show();
                }
                else if (dt.Rows[0][0].ToString() == "TEACHER")
                {
                    string TeacherQuerry = "Select Teacher_Type, Background, Class from Teacher where id='" + UName_Box.Text + "'";
                    SqlDataAdapter Teacher_Cmd = new SqlDataAdapter(TeacherQuerry, con);
                    DataTable Teacher_Table = new DataTable();
                    Teacher_Cmd.Fill(Teacher_Table);
                    
                    TeacherPage teacherPage = new TeacherPage();
                    
                    teacherPage.Check_Class_Teacher_From_Login = Teacher_Table.Rows[0][0].ToString();
                    teacherPage.Check_Class_Background_From_Login = Teacher_Table.Rows[0][1].ToString();
                    teacherPage.Check_Class_From_Login = Teacher_Table.Rows[0][2].ToString();

                    teacherPage.UserNameInInterFace = dt.Rows[0][1].ToString();
                    this.Hide();
                    teacherPage.Show();
                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show("Wrong Credentials!!!\nTry again.");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Header_Text_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
