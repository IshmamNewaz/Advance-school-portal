using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Advance_School_Portal
{
    public partial class TeacherPage : Form
    {
        public string UserNameInInterFace { get; set; }
        public string Class_Background;
        public string Check_Class_Teacher_From_Login { get; set; }
        public string Check_Class_Background_From_Login { get; set; }
        public string Check_Class_From_Login { get; set; }
        TeacherInfo t = new TeacherInfo();
        public TeacherPage()
        {
            InitializeComponent();
        }

        void Hide_Function()
        {
            Label_Bangla_1.Hide();
            Label_Bangla_2nd.Hide();
            Label_English_1st.Hide();
            Label_English_2nd.Hide();
            Label_G_Math.Hide();
            Label_H_Math.Hide();
            Label_Physics.Hide();
            Label_Biology.Hide();
            Label_Chemistry.Hide();
            Label_B_Studies.Hide();
            UniversalText1.Hide();
            UniversalText2.Hide();
            UniversalText3.Hide();
            UniversalText4.Hide();
            UniversalText5.Hide();
            UniversalText6.Hide();
            UniversalText7.Hide();
            UniversalText8.Hide();
            UniversalText9.Hide();
            UniversalText10.Hide();

            Label_Student_Id.Hide();
            Label_Section.Hide();
            Input_Student_Id.Hide();
            Input_Section.Hide();
        }
        void Show_Fucntion()
        {
            Label_Bangla_1.Show();
            Label_Bangla_2nd.Show();
            Label_English_1st.Show();
            Label_English_2nd.Show();
            Label_G_Math.Show();
            Label_H_Math.Show();
            Label_Physics.Show();
            Label_Biology.Show();
            Label_Chemistry.Show();
            Label_B_Studies.Show();
            UniversalText1.Show();
            UniversalText2.Show();
            UniversalText3.Show();
            UniversalText4.Show();
            UniversalText5.Show();
            UniversalText6.Show();
            UniversalText7.Show();
            UniversalText8.Show();
            UniversalText9.Show();
            UniversalText10.Show();

            Label_Student_Id.Show();
            Label_Section.Show();
            Input_Student_Id.Show();
            Input_Section.Show();
        }
        void Clear()
        {
            UniversalText1.Text = null;
            UniversalText2.Text = null;
            UniversalText3.Text = null;
            UniversalText4.Text = null;
            UniversalText5.Text = null;
            UniversalText6.Text = null;
            UniversalText7.Text = null;
            UniversalText8.Text = null;
            UniversalText9.Text = null;


        }
      
        private void TeacherPage_Load(object sender, EventArgs e)
        {
            WelcomeText.Text = UserNameInInterFace;
            MarksPanel.Hide();
            Hide_Function();
            Add_Update_Button.Hide();
            File_Panel.Hide();
            
            Label_Notice_Id.Hide();
            Notice.Hide();
            Input_Notice.Hide();
            Input_Notice_Id.Hide();
            Teacher_Notice_Panel.Hide();
            Notice_Add_Button.Enabled = false;
            Notice_Delete_Button.Enabled = false;
            Destination_Label.Enabled = false;

            Teacher_Notice_Grid_View.RowTemplate.Height = 200;

        }
        private void Add_Update_Marks_Click(object sender, EventArgs e)
        {
            MarksPanel.Show();
            File_Panel.Hide();
            Notes_Notice_Adding.Enabled = false;
            Add_Update_Marks.Enabled = false;
            Notice_Panel_Button.Enabled = false;

        }
        private void Close_Panel_Click(object sender, EventArgs e)
        {
            MarksPanel.Hide();
            Notes_Notice_Adding.Enabled = true;
            Add_Update_Marks.Enabled = true;
            Notice_Panel_Button.Enabled = true;

            Hide_Function();
        }
        private void Close_File_Panel_Click(object sender, EventArgs e)
        {
            File_Panel.Hide();
            Notes_Notice_Adding.Enabled = true;
            Add_Update_Marks.Enabled = true;
            Notice_Panel_Button.Enabled = true;
        }
        private void Notes_Notice_Adding_Click(object sender, EventArgs e)
        {
            File_Panel.Show();
            Notes_Notice_Adding.Enabled = false;
            Add_Update_Marks.Enabled = false;
            Notice_Panel_Button.Enabled = false;
        }
        private void Notice_Add_Button_Click(object sender, EventArgs e)
        {
            t.NoticeId = Input_Notice_Id.Text;
            t.Notice = Input_Notice.Text;
            bool success = t.Add_Notice(t);

            if (success == true)
            {
                MessageBox.Show("Successfully data Inserted!");
                Clear();
            }
            else
            {
                MessageBox.Show("failed!");
            }


            DataTable dataTable = t.View_Notice();
            Teacher_Notice_Grid_View.DataSource = dataTable;
        }
        private void Show_All_Notice_Click(object sender, EventArgs e)
        {
            DataTable dataTable = t.View_Notice();
            Teacher_Notice_Grid_View.DataSource = dataTable;
            Teacher_Notice_Grid_View.Columns[1].Width = 820;
        }
        private void Notice_Delete_Button_Click(object sender, EventArgs e)
        {

            t.NoticeId = Input_Notice_Id.Text;

            bool success = t.Delete_Notice(t);

            if (success == true)
            {
                MessageBox.Show("Successful");
                Clear();
            }
            else
            {
                MessageBox.Show("failed!");
            }


            DataTable dataTable = t.View_Notice();
            Teacher_Notice_Grid_View.DataSource = dataTable;
        }
        private void Proceed_Notice_Addition_Click(object sender, EventArgs e)
        {
            Label_Notice_Id.Show();
            Notice.Show();
            Input_Notice.Show();
            Input_Notice_Id.Show();
            Notice_Add_Button.Enabled = true;
            Notice_Delete_Button.Enabled = false;

        }
        private void Close_Notice_Panel_Click(object sender, EventArgs e)
        {
            Label_Notice_Id.Hide();
            Notice.Hide();
            Input_Notice.Hide();
            Input_Notice_Id.Hide();
            Notes_Notice_Adding.Enabled = true;
            Add_Update_Marks.Enabled = true;
            Notice_Panel_Button.Enabled = true;
            Teacher_Notice_Panel.Hide();
            Notes_Notice_Adding.Enabled = Enabled;
            Add_Update_Marks.Enabled = Enabled;
        }
        private void Notice_Panel_Button_Click(object sender, EventArgs e)
        {
            Teacher_Notice_Panel.Show();
            Notes_Notice_Adding.Enabled = false;
            Add_Update_Marks.Enabled = false;
            Notice_Panel_Button.Enabled = false;
        }
        private void Show_Marks_Click(object sender, EventArgs e)
        {
            NoticeGridView.DataSource = null;
            DataTable dataTable = t.Teacher_Select(Class_Background);
            NoticeGridView.DataSource = dataTable;
            //MessageBox.Show(Check_Class_From_Login+ Check_Class_Teacher_From_Login+ Check_Class_Background_From_Login);
        }
        private void Add_Update_Button_Click(object sender, EventArgs e)
        {
            t.Stu_Id = Input_Student_Id.Text;
            t.Sub1 = UniversalText1.Text;
            t.Sub2 = UniversalText2.Text;
            t.Sub3 = UniversalText3.Text;
            t.Sub4 = UniversalText4.Text;
            t.Sub5 = UniversalText5.Text;
            t.Sub6 = UniversalText6.Text;
            t.Sub7 = UniversalText7.Text;
            t.Sub8 = UniversalText8.Text;
            t.Sub9 = UniversalText9.Text;
            t.Sub10 = UniversalText10.Text;
            t.Class_With_Background = Class_Background;

            bool success = t.Teacher_Insert(t);

            if (success == true)
            {
                MessageBox.Show("Successfull ");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed! Please Try To enter Correctly");
            }


            DataTable dataTable = t.Teacher_Select(Class_Background);
            NoticeGridView.DataSource = dataTable;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Class_Selection_ComboBox.GetItemText(Class_Selection_ComboBox.SelectedItem)=="Class 8")
            {
                if (Check_Class_From_Login == "8" && Check_Class_Teacher_From_Login == "YES" && Check_Class_Background_From_Login == "NO")
                {
                    Show_Fucntion();
                    Label_Bangla_1.Show();
                    Label_Bangla_2nd.Show();
                    Label_English_1st.Show();
                    Label_English_2nd.Show();
                    Label_G_Math.Show();
                    Label_H_Math.Show();
                    Label_Bangla_1.Text = "Bangla:";
                    Label_Bangla_2nd.Text = "English:";
                    Label_English_1st.Text = "Math:";
                    Label_English_2nd.Text = "B Studies:";
                    Label_G_Math.Text = "Religion:";
                    Label_H_Math.Text = "Physical Ed:";
                    Label_Physics.Hide();
                    Label_Chemistry.Hide();
                    Label_Biology.Hide();
                    Label_B_Studies.Hide();
                    
                    Label_Physics.Hide();
                    Label_Chemistry.Hide();
                    Label_Biology.Hide();
                    Label_B_Studies.Hide();

                    UniversalText1.Show();
                    UniversalText2.Show();
                    UniversalText3.Show();
                    UniversalText4.Show();
                    UniversalText5.Show();
                    UniversalText6.Show();
                    UniversalText7.Hide();
                    UniversalText8.Hide();
                    UniversalText9.Hide();
                    UniversalText10.Hide();

                    Label_Student_Id.Show();
                    Label_Section.Show();
                    Input_Student_Id.Show();
                    Input_Section.Show();
                    Add_Update_Button.Show();
                }
                else
                {
                    Hide_Function();
                    Add_Update_Button.Hide();
                }

                Class_Background = "C8";
                
                DataTable dataTable = t.Teacher_Select(Class_Background);
                NoticeGridView.DataSource = dataTable;
                t.Class_With_Background = Class_Background;

            }
            else if (Class_Selection_ComboBox.GetItemText(Class_Selection_ComboBox.SelectedItem) == "Class 9 Science")
            {
                if(Check_Class_Teacher_From_Login == "YES" && Check_Class_Background_From_Login == "Science" && Check_Class_From_Login=="9")
                {
                    Show_Fucntion();
                    Label_Bangla_1.Text = "Bangla 1st:";
                    Label_Bangla_2nd.Text = "Bangla_2nd:";
                    Label_English_1st.Text = "English 1st";
                    Label_English_2nd.Text = "English 2nd";
                    Label_G_Math.Text = "G.Math:";
                    Label_H_Math.Text = "H.Math:";
                    

                    Add_Update_Button.Show();
                }
                else
                {
                    Add_Update_Button.Hide();
                    Hide_Function();
                }

                
                Class_Background = "C9S";
                
                DataTable dataTable = t.Teacher_Select(Class_Background);
                NoticeGridView.DataSource = dataTable;
                t.Class_With_Background = Class_Background;

            }
            else if (Class_Selection_ComboBox.GetItemText(Class_Selection_ComboBox.SelectedItem) == "Class 10 Science")
            {
                if (Check_Class_Teacher_From_Login == "YES" && Check_Class_Background_From_Login == "Science" && Check_Class_From_Login == "10") {
                    Show_Fucntion();
                    Label_Bangla_1.Text = "Bangla 1st:";
                    Label_Bangla_2nd.Text = "Bangla_2nd:";
                    Label_English_1st.Text = "English 1st";
                    Label_English_2nd.Text = "English 2nd";
                    Label_G_Math.Text = "G.Math:";
                    Label_H_Math.Text = "H.Math:";

                    Add_Update_Button.Show();
                }
                else
                {
                    Add_Update_Button.Hide();
                    Hide_Function();
                }
                
                Class_Background = "C10S";

                DataTable dataTable = t.Teacher_Select(Class_Background);
                NoticeGridView.DataSource = dataTable;
                t.Class_With_Background = Class_Background;
            }
            else if (Class_Selection_ComboBox.GetItemText(Class_Selection_ComboBox.SelectedItem) == "Class 9 Commerce")
            {
                if (Check_Class_Teacher_From_Login == "YES" && Check_Class_Background_From_Login == "Commerce" && Check_Class_From_Login == "9")
                {

                    Show_Fucntion();
                    Label_Bangla_1.Text = "Bangla 1st:";
                    Label_Bangla_2nd.Text = "Bangla_2nd:";
                    Label_English_1st.Text = "English 1st";
                    Label_English_2nd.Text = "English 2nd";
                    Label_G_Math.Text = "G.Math:";
                    Label_H_Math.Text = "B_Entreprenuership:";
                    Label_Physics.Text = "Economics:";
                    Label_Chemistry.Text = "Accounting:";
                    Label_Biology.Text = "Finance";

                    Show_Fucntion();
                    Add_Update_Button.Show();
                }
                else
                {
                    Add_Update_Button.Hide();
                    Hide_Function();
                }

                
                Class_Background = "C9C";

                DataTable dataTable = t.Teacher_Select(Class_Background);
                NoticeGridView.DataSource = dataTable;
                t.Class_With_Background = Class_Background;
            }
            else if (Class_Selection_ComboBox.GetItemText(Class_Selection_ComboBox.SelectedItem) == "Class 10 Commerce")
            {
                if (Check_Class_Teacher_From_Login == "YES" && Check_Class_Background_From_Login == "Commerce" && Check_Class_From_Login == "10")
                {
                    Show_Fucntion();
                    Label_Bangla_1.Text = "Bangla 1st:";
                    Label_Bangla_2nd.Text = "Bangla_2nd:";
                    Label_English_1st.Text = "English 1st";
                    Label_English_2nd.Text = "English 2nd";
                    Label_G_Math.Text = "G.Math:";
                    Label_H_Math.Text = "B_Entreprenuership:";
                    Label_Physics.Text = "Economics:";
                    Label_Chemistry.Text = "Accounting:";
                    Label_Biology.Text = "Finance";

                    Show_Fucntion();
                    Add_Update_Button.Show();
                }
                else
                {
                    Add_Update_Button.Hide();
                    Hide_Function();
                }
                
                Class_Background = "C10C";

                DataTable dataTable = t.Teacher_Select(Class_Background);
                NoticeGridView.DataSource = dataTable;
                t.Class_With_Background = Class_Background;
            }
            else if (Class_Selection_ComboBox.GetItemText(Class_Selection_ComboBox.SelectedItem) == "Class 9 Arts")
            {
                if (Check_Class_Teacher_From_Login == "YES" && Check_Class_Background_From_Login == "Arts" && Check_Class_From_Login == "9")
                {
                    Show_Fucntion();
                    Label_Bangla_1.Text = "Bangla 1st:";
                    Label_Bangla_2nd.Text = "Bangla_2nd:";
                    Label_English_1st.Text = "English 1st";
                    Label_English_2nd.Text = "English 2nd";
                    Label_G_Math.Text = "G.Math:";
                    Label_H_Math.Text = "History:";
                    Label_Physics.Text = "Economics:";
                    Label_Chemistry.Text = "Psychology:";
                    Label_Biology.Text = "Sociology";

                    Show_Fucntion();
                    Add_Update_Button.Show();
                }
                else
                {
                    Add_Update_Button.Hide();
                    Hide_Function();
                }
                
                Class_Background = "C9A";

                DataTable dataTable = t.Teacher_Select(Class_Background);
                NoticeGridView.DataSource = dataTable;
                t.Class_With_Background = Class_Background;
            }
            else if (Class_Selection_ComboBox.GetItemText(Class_Selection_ComboBox.SelectedItem) == "Class 10 Arts")
            {
                if (Check_Class_Teacher_From_Login == "YES" && Check_Class_Background_From_Login == "Arts" && Check_Class_From_Login == "10")
                {
                    Show_Fucntion();
                    Label_Bangla_1.Text = "Bangla 1st:";
                    Label_Bangla_2nd.Text = "Bangla_2nd:";
                    Label_English_1st.Text = "English 1st";
                    Label_English_2nd.Text = "English 2nd";
                    Label_G_Math.Text = "G.Math:";
                    Label_H_Math.Text = "History:";
                    Label_Physics.Text = "Economics:";
                    Label_Chemistry.Text = "Psychology:";
                    Label_Biology.Text = "Sociology";

                    Show_Fucntion();
                    Add_Update_Button.Show();
                }
                else
                {
                    Add_Update_Button.Hide();
                    Hide_Function();
                }
                
                Class_Background = "C10A";

                DataTable dataTable = t.Teacher_Select(Class_Background);
                NoticeGridView.DataSource = dataTable;
                t.Class_With_Background = Class_Background;
            }

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Label_G_Math_Click(object sender, EventArgs e)
        {

        }

        
        
        //File Handling Phase
        private void File_Selection_Button_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                File_Name.Text = Path.GetFileName(openFileDialog1.FileName);
                File_Path.Text = Path.GetFullPath(openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("Please Select a File");
            }
        }

        private void File_Destination_Click(object sender, EventArgs e)
        {
            if (Check_Class_From_Login == "8")
            {
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 8";
            }
            else if (Check_Class_Background_From_Login == "Science" && Check_Class_From_Login == "9")
            {
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 9 Science";
            }
            else if (Check_Class_Background_From_Login == "Science" && Check_Class_From_Login == "10")
            {
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 10 Science";
            }
            else if (Check_Class_Background_From_Login == "Commerce" && Check_Class_From_Login == "9")
            {
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 9 Commerce";
            }
            else if (Check_Class_Background_From_Login == "Commerce" && Check_Class_From_Login == "10")
            {
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 10 Commerce";
            }
            else if (Check_Class_Background_From_Login == "Arts" && Check_Class_From_Login == "9")
            {
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 9 Arts";
            }
            else if (Check_Class_Background_From_Login == "Arts" && Check_Class_From_Login == "10")
            {
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 10 Arts";
            }
            //folderBrowserDialog1.ShowDialog();
            //Destination_Label.Text = folderBrowserDialog1.SelectedPath.ToString();
        }

        private void Upload_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Destination_Label.Text + "\\" + File_Name.Text))
                {
                    MessageBox.Show("File Already Exist");
                }
                else
                {
                    File.Copy(File_Path.Text, Destination_Label.Text + "\\" + File_Name.Text);
                    MessageBox.Show("Success!");
                }
            }
            catch(Exception exp)
            {
                if (File.Exists(Destination_Label.Text + "\\" + File_Name.Text))
                {
                    MessageBox.Show("File Already Exist");
                }
                else
                {
                    MessageBox.Show("Please Check Everything Then Upload");
                }
                
            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
