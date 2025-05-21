using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advance_School_Portal
{
    public partial class Admin : Form
    {
        int type = 0; //User Type Selection for Adding Info
        string BackgroundCheckBox="NO";//Variable for checkboxes to take Background inputs
        string ClassTeacherCheckBox;//Variable for checkbox to find class teacher or not
        string SelectClass;//Variable for Combobox for Class selection

        //Show, Hide, Clear Method START
        void AddHideButton()
        {
            AddTeacher.Hide();
            AddStudent.Hide();
            AddCanteen.Hide();
            AddAdmin.Hide();
        }
        void AddShowButton()
        {
            AddTeacher.Show();
            AddStudent.Show();
            AddCanteen.Show();
            AddAdmin.Show();
        }
        void Clear()
        {
            InputPassword.Text = null;
            InputUniversal1.Text = null;
            InputUniversal2.Text = null;
            InputUniversal3.Text = null;
            InputName.Text = null;
            InputId.Text = null;
        }

        //Show, Hide, Clear Method END
        public string UserNameInInterFace { get; set; }
        public Admin()
        {
            InitializeComponent();

        }

        AdminInfo a = new AdminInfo();
        //Admin Page Loadin When Initialized START
        private void Admin_Load(object sender, EventArgs e)
        {
            WelcomeText.Text = UserNameInInterFace;// To get UserName From input
            AddHideButton();
            ContentPanel.BackColor = Color.FromArgb(255, Color.White);
            ContentPanel.Hide();// Content Panel
            InfoView.Hide(); //Conten Info View Grid from Database
            UniversalHeader3.Hide(); //Text field in Content Panel
            InputUniversal3.Hide(); //Text field in Content Panel
            Notice_Panel.Hide(); //Notice Panel 

            //Notice Label && Notice Input Sections
            LabelNotice.Hide();
            LabelNoticeID.Hide();
            LabelNoticeTo.Hide();
            InputNoticeId.Hide();
            InputNoitceFULL.Hide();
            InputNoticeTo.Hide();
            NoticeGridView.RowTemplate.Height = 200;
        }
        //Admin Page Loadin When Initialized END
        private void SubmitShow_Click(object sender, EventArgs e)
        {
            
            
            if(Science_Background.CheckState==CheckState.Unchecked && Commerce_Background.CheckState == CheckState.Unchecked && Arts_Background.CheckState == CheckState.Unchecked && Class_Combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please Fill up required Forms");
            }

            else
            {
                a.id = InputId.Text;
                a.username = InputName.Text;
                a.password = InputPassword.Text;
                a.type = InputUserType.Text;
                a.Universal1 = InputUniversal1.Text;
                a.Universal2 = InputUniversal2.Text;
                a.Universal3 = InputUniversal3.Text;
                a.selection = type;

                if (Science_Background.CheckState == CheckState.Checked)
                {
                    BackgroundCheckBox = "Science";

                }
                else if (Commerce_Background.CheckState == CheckState.Checked)
                {
                    BackgroundCheckBox = "Commerce";

                }
                else if (Arts_Background.CheckState == CheckState.Checked)
                {
                    BackgroundCheckBox = "Arts";

                }
                else
                {
                    BackgroundCheckBox = "NO";
                }
                a.Background = BackgroundCheckBox;

                if (Class_Teacher.CheckState == CheckState.Checked)
                {
                    ClassTeacherCheckBox = "YES";
                }
                else
                {
                    ClassTeacherCheckBox = "NO";
                }
                a.Class_Teacher = ClassTeacherCheckBox;
                a.select_Class = SelectClass;
                bool success = a.Insert(a);

                if (success == true)
                {
                    MessageBox.Show("Successfully data Inserted!");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Data Insertion failed!");
                }
            }

            DataTable dataTable = a.Select(type);
            InfoView.DataSource = dataTable;

            Science_Background.Checked = false;
            Commerce_Background.Checked = false;
            Arts_Background.Checked = false;
            
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            a.id = InputId.Text;
            a.username = InputName.Text;
            a.password = InputPassword.Text;
            a.type = InputUserType.Text;
            a.Universal1 = InputUniversal1.Text;
            a.Universal2 = InputUniversal2.Text;
            a.Universal3 = InputUniversal3.Text;
            a.selection = type;
           
            if (Class_Teacher.CheckState == CheckState.Checked)
            {
                ClassTeacherCheckBox = "YES";
            }
            else
            {
                ClassTeacherCheckBox = "NO";
            }
            a.Class_Teacher = ClassTeacherCheckBox;
            a.select_Class = SelectClass;

            bool success = a.Update(a);

            if (success == true)
            {
                MessageBox.Show("Successfully data Inserted!");
                Clear();
            }
            else
            {
                MessageBox.Show("Data Insertion failed!");
            }


            DataTable dataTable = a.Select(type);
            InfoView.DataSource = dataTable;
        }
        private void ShowResults_Click(object sender, EventArgs e)
        {
            DataTable dataTable = a.Select(type);
            InfoView.DataSource = dataTable;
        }
        private void Science_Background_CheckedChanged(object sender, EventArgs e)
        {
            if (Science_Background.CheckState == CheckState.Checked)
            {
                Commerce_Background.Enabled = false;
                Arts_Background.Enabled = false;
            }
        }

        private void Arts_Background_CheckedChanged(object sender, EventArgs e)
        {
            if (Arts_Background.CheckState == CheckState.Checked)
            {
                Commerce_Background.Enabled = false;
                Science_Background.Enabled = false;
            }
        }

        private void Commerce_Background_CheckedChanged(object sender, EventArgs e)
        {
            if (Commerce_Background.CheckState == CheckState.Checked)
            {
                Arts_Background.Enabled = false;
                Science_Background.Enabled = false;
            }
        }
        private void ClosePanel_Click(object sender, EventArgs e)
        {
            ContentPanel.Hide();
            AddTeacher.Enabled = true;
            AddStudent.Enabled = true;
            AddCanteen.Enabled = true;
            AddAdmin.Enabled = true;

            AddTeacher.ForeColor = Color.White;
            AddStudent.ForeColor = Color.White;
            AddCanteen.ForeColor = Color.White;
            AddAdmin.ForeColor= Color.White;
            InfoView.Hide();
            AddHideButton();
            Update.Enabled = true;
            NewEntry.Enabled = true;
            Delete.Enabled = true;
            AddNotice.Enabled = true;

            Arts_Background.Enabled = true;
            Science_Background.Enabled = true;
            Commerce_Background.Enabled = true;
            Arts_Background.CheckState = CheckState.Unchecked;
            Science_Background.CheckState = CheckState.Unchecked;
            Commerce_Background.CheckState = CheckState.Unchecked;


        }
        private void AddAdmin_Click(object sender, EventArgs e)
        {
            UniversalHeader1.Show();
            UniversalHeader2.Show();
            UniversalHeader1.Text= "Designation:";
            UniversalHeader2.Text = "Joining Date:";
            UniversalHeader3.Hide();
            InputUniversal1.Show();
            InputUniversal2.Show();
            InputUniversal3.Hide();
            InputUserType.Text = "ADMIN";
            InputUserType.Enabled = false;
            ContentPanel.Show();
            AddTeacher.Enabled = false;
            AddStudent.Enabled = false;
            AddCanteen.Enabled = false;
            AddAdmin.ForeColor = Color.Red;
            Science_Background.Hide();
            Commerce_Background.Hide();
            Arts_Background.Hide();
            Class_Teacher.Hide();
            Select_Class.Hide();
            Class_Combo.Hide();
            InfoView.Show();
            type = 1;
            
        }

        private void AddStudent_Click(object sender, EventArgs e)
        {
            UniversalHeader1.Text = "Section:";
            UniversalHeader2.Text = "Enrollment:";
            UniversalHeader1.Show();
            UniversalHeader2.Show();
            UniversalHeader3.Hide();
            InputUniversal1.Show();
            InputUniversal2.Show();
            InputUniversal3.Hide();
            InputUserType.Text = "STUDENT";
            InputUserType.Enabled = false;
            ContentPanel.Show();
            AddAdmin.Enabled = false;
            AddTeacher.Enabled = false;
            AddCanteen.Enabled = false;
            AddStudent.ForeColor = Color.Red;
            Science_Background.Show();
            Commerce_Background.Show();
            Arts_Background.Show();
            Science_Background.Enabled = true;
            Commerce_Background.Enabled = true;
            Arts_Background.Enabled = true;
            Class_Teacher.Hide();
            Select_Class.Show();
            Class_Combo.Show();
            InfoView.Show();
            type = 2;
            
        }
        private void AddTeacher_Click(object sender, EventArgs e)
        {
            
            UniversalHeader1.Text = "Designation:";
            UniversalHeader2.Text = "Section:";
            UniversalHeader3.Text = "Join Date:";
            UniversalHeader1.Show();
            UniversalHeader2.Show();
            UniversalHeader3.Show();
            InputUniversal1.Show();
            InputUniversal2.Show();
            InputUniversal3.Show();
            InputUserType.Text = "TEACHER";
            InputUserType.Enabled = false;
            ContentPanel.Show();
            AddAdmin.Enabled = false;
            AddStudent.Enabled = false;
            AddCanteen.Enabled = false;
            AddTeacher.ForeColor = Color.Red;
            Science_Background.Show();
            Commerce_Background.Show();
            Arts_Background.Show();
            Science_Background.Enabled = false;
            Commerce_Background.Enabled = false;
            Arts_Background.Enabled = false;
            Class_Teacher.Show();
            Select_Class.Show();
            Class_Combo.Show();
            InfoView.Show();
            type = 3;
        }
        private void AddCanteen_Click(object sender, EventArgs e)
        {
            
            UniversalHeader1.Hide();
            UniversalHeader2.Hide();
            UniversalHeader3.Hide();
            UniversalHeader3.Hide();
            InputUniversal1.Hide();
            InputUniversal2.Hide();
            InputUniversal3.Hide();
            InputUserType.Text = "CANTEEN";
            InputUserType.Enabled = false;
            ContentPanel.Show();
            AddAdmin.Enabled = false;
            AddStudent.Enabled = false;
            AddTeacher.Enabled = false;
            AddCanteen.ForeColor = Color.Red;
            Science_Background.Hide();
            Commerce_Background.Hide();
            Arts_Background.Hide();
            Class_Teacher.Hide();
            Select_Class.Hide();
            Class_Combo.Hide();
            InfoView.Show();
            type = 4;
        }

        private void Class_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Class_Combo.GetItemText(Class_Combo.SelectedItem)=="Class 8")
            {
                Science_Background.Enabled = false;
                Commerce_Background.Enabled = false;
                Arts_Background.Enabled = false;
                Science_Background.Checked = false;
                Commerce_Background.Checked = false;
                Arts_Background.Checked = false;
                SelectClass = "8";
            }
            else if (Class_Combo.GetItemText(Class_Combo.SelectedItem) == "Class 9")
            {
                Science_Background.Enabled = true;
                Commerce_Background.Enabled = true;
                Arts_Background.Enabled = true;
                SelectClass = "9";
            }
            else if (Class_Combo.GetItemText(Class_Combo.SelectedItem) == "Class 10")
            {
                Science_Background.Enabled = true;
                Commerce_Background.Enabled = true;
                Arts_Background.Enabled = true;
                SelectClass = "10";
            }
        }
        private void NewEntry_Click(object sender, EventArgs e)
        {
            AddShowButton();
            HidingPanel.Hide();
            label6.Show();
            label7.Show();
            label8.Show();
            InputName.Show();
            InputPassword.Show();
            InputUserType.Show();
            Hide_Panel2.Hide();
            Update.Enabled = false;
            Delete.Enabled = false;
            UpdateButton.Enabled = false;
            SubmitShow.Enabled = true;
            DeleteButton.Enabled = false;
            AddNotice.Enabled = false;
            InputUniversal2.Enabled = true;
            Background_Selection_Panel.Hide();
            InsertUpdateDelete.Text = "Please Fill Up to INSERT";

        }
        private void Update_Click(object sender, EventArgs e)
        {
            AddShowButton();
            HidingPanel.Hide();
            label6.Show();
            label7.Show();
            label8.Show();
            InputName.Show();
            InputPassword.Show();
            InputUserType.Show();
            AddCanteen.Hide();
            Hide_Panel2.Hide();
            NewEntry.Enabled = false;
            Delete.Enabled = false;
            SubmitShow.Enabled = false;
            DeleteButton.Enabled = false;
            UpdateButton.Enabled = true;
            AddNotice.Enabled = false;
            InputUniversal3.Enabled = false;
            Background_Selection_Panel.Show();
            InsertUpdateDelete.Text = "Please Fill Up to UPDATE";

        }
        
        private void Delete_Click(object sender, EventArgs e)
        {
            AddShowButton();
            NewEntry.Enabled = false;
            Update.Enabled = false;
            HidingPanel.Show();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            UniversalHeader1.Hide();
            UniversalHeader2.Hide();
            UniversalHeader3.Hide();
            InputName.Hide();
            InputPassword.Hide();
            InputUserType.Hide();
            InputUniversal1.Hide();
            InputUniversal2.Hide();
            InputUniversal3.Hide();
            Hide_Panel2.Show();
            SubmitShow.Enabled = false;
            DeleteButton.Enabled = true;
            UpdateButton.Enabled = false;
            AddNotice.Enabled = false;
            InsertUpdateDelete.Text = "Please Fill Up to DELETE";
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            a.id = InputId.Text;
            a.selection = type;
            bool success = a.Delete(a);

            if (success == true)
            {
                MessageBox.Show("Successfully data Inserted!");
                Clear();
            }
            else
            {
                MessageBox.Show("Data Insertion failed!");
            }


            DataTable dataTable = a.Select(type);
            InfoView.DataSource = dataTable;

        }
        //Notice Section Start
        private void AddNotice_Click(object sender, EventArgs e)
        {
            Notice_Panel.Show();
            ContentPanel.Hide();
            NewEntry.Enabled = false;
            Update.Enabled = false;
            Delete.Enabled = false;
            NoticeSubmitButton.Enabled = false;
            NoticeDeleteButton.Enabled = false;
            type = 5;
            AddHideButton();

        }
        private void NewNotice_Click(object sender, EventArgs e)
        {
            DeleteNotice.Enabled = false;
            NoticeSubmitButton.Enabled = true;
            NoticeDeleteButton.Enabled = false;
            NewNotice.ForeColor = Color.Red;
            LabelNotice.Show();
            LabelNoticeID.Show();
            LabelNoticeTo.Show();
            InputNoticeId.Show();
            InputNoitceFULL.Show();
            InputNoticeTo.Show();
        }
        private void DeleteNotice_Click(object sender, EventArgs e)
        {
            NewNotice.Enabled = false;
            NoticeSubmitButton.Enabled = false;
            NoticeDeleteButton.Enabled = true;
            DeleteNotice.ForeColor = Color.Red;
            LabelNotice.Hide();
            LabelNoticeID.Show();
            LabelNoticeTo.Hide();
            InputNoticeId.Show();
            InputNoitceFULL.Hide();
            InputNoticeTo.Hide();

        }
        private void CloseNotice_Click(object sender, EventArgs e)
        {
            Notice_Panel.Hide();
            Update.Enabled = true;
            NewEntry.Enabled = true;
            Delete.Enabled = true;
            AddNotice.Enabled = true;
            DeleteNotice.Enabled = true;
            NewNotice.Enabled = true;
            NoticeSubmitButton.Enabled = true;
            NoticeDeleteButton.Enabled = true;
            LabelNotice.Hide();
            LabelNoticeID.Hide();
            LabelNoticeTo.Hide();
            InputNoticeId.Hide();
            InputNoitceFULL.Hide();
            InputNoticeTo.Hide();
            
            NewNotice.ForeColor = Color.White;
            DeleteNotice.ForeColor = Color.White;


        }
        private void NoticeSubmitButton_Click(object sender, EventArgs e)
        {
            a.NoticeId = InputNoticeId.Text;
            a.Notice = InputNoitceFULL.Text;
            a.NoticeTo = InputNoticeTo.Text;

            a.selection = type;


            bool success = a.Insert(a);

            if (success == true)
            {
                MessageBox.Show("Successfully data Inserted!");
                Clear();
            }
            else
            {
                MessageBox.Show("Data Insertion failed!");
            }


            DataTable dataTable = a.Select(type);
            NoticeGridView.DataSource = dataTable;
        }
        private void NoticeDeleteButton_Click(object sender, EventArgs e)
        {
            a.NoticeId = InputNoticeId.Text;
            a.selection = type;
            bool success = a.Delete(a);

            if (success == true)
            {
                MessageBox.Show("Successfully data Inserted!");
                Clear();
            }
            else
            {
                MessageBox.Show("Data Insertion failed!");
            }


            DataTable dataTable = a.Select(type);
            InfoView.DataSource = dataTable;
        }
        private void ShowAllnotice_Click(object sender, EventArgs e)
        {
            DataTable dataTable = a.Select(type);
            NoticeGridView.DataSource = dataTable;
            NoticeGridView.Columns[1].Width = 820;
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Notice_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
