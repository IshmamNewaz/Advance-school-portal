using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace Advance_School_Portal
{
    public partial class StudentPage : Form
    {
        public string UserNameInInterFace { get; set; }
        public string Check_Class_From_Login { get; set; }
        public string Check_Class_Background_From_Login { get; set; }
        public string Get_Id_From_Login { get; set; }
        public string Order_Menu_String { get; set; }
        public float Order_Menu_Price { get; set; }
        public string Room_Number { get; set; }
        public int RowCount;

        string Food_List_Format = "{0, -70}{1, 0}";
        StudentInfo s = new StudentInfo();
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-00PCR32\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True");
        SqlCommand Food_Order_Command;
        SqlDataReader Food_Order_Reader;
        public StudentPage()
        {
            InitializeComponent();
        }

        private void StudentPage_Load(object sender, EventArgs e)
        {
            WelcomeText.Text = UserNameInInterFace;
            Student_Marks_view_Panel.Hide();
            Notice_Panel.Hide();
            Food_Order_Panel.Hide();
            View_Notes.Hide();
            Student_Notice_View.RowTemplate.Height = 200;
            Selected_Items_from_Menu.RowTemplate.Height = 100;
            Selected_Items_from_Menu.Columns[0].Width = 270;
            Place_Order_Food.Hide();
            Order_List.Items.Add(String.Format(Food_List_Format, "Menu", "Price(tk)"));
            Room_No.Hide();
            Input_Room_Number.Hide();
            Destination_Label.Enabled = false;
            //MessageBox.Show(Check_Class_From_Login + Check_Class_Background_From_Login);
            s.Student_id= Get_Id_From_Login;
            string Food_Status_check;
            Food_Status_check = s.Food_Order_Status_Check();
            if (Food_Status_check == "yes")
            {
                Order_Status_Check.Text = "Received!";
            }
            else
            {
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Show_All_Marks_Click(object sender, EventArgs e)
        {
            s.Class = Check_Class_From_Login;
            s.Background = Check_Class_Background_From_Login;

            DataTable dataTable = s.Student_Select();
            Students_Marks_Panel.DataSource = dataTable;
        }

        private void Marks_View_Click(object sender, EventArgs e)
        {
            Notice_Checking.Enabled = false;
            Marks_View.Enabled = false;
            Order_Food.Enabled = false;
            View_Notice_Button.Enabled = false;
            Student_Marks_view_Panel.Show();
        }
        private void Notice_Checking_Click(object sender, EventArgs e)
        {
            Notice_Checking.Enabled = false;
            Marks_View.Enabled = false;
            Order_Food.Enabled = false;
            View_Notice_Button.Enabled = false;
            Notice_Panel.Show();
        }

        private void Order_Food_Click(object sender, EventArgs e)
        {
            Notice_Checking.Enabled = false;
            Marks_View.Enabled = false;
            Order_Food.Enabled = false;
            View_Notice_Button.Enabled = false;
            Food_Order_Panel.Show();
            Food_Order_Command = new SqlCommand();
            try
            {
                connection.Open();
                Food_Order_Command.Connection = connection;
                Food_Order_Command.CommandText = "Select * from Canteen_Item_List";
                Food_Order_Reader = Food_Order_Command.ExecuteReader();
                while (Food_Order_Reader.Read())
                {
                    Order_List.Items.Add(String.Format(Food_List_Format, Food_Order_Reader["Item_Name"], Food_Order_Reader["Price(tk)"]));
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

        }

        private void Close_Marks_Panel_Click(object sender, EventArgs e)
        {
            Notice_Checking.Enabled = true;
            Marks_View.Enabled = true;
            Order_Food.Enabled = true;
            View_Notice_Button.Enabled = true;
            Student_Marks_view_Panel.Hide();
        }
        private void Food_Order_Panel_Close_Click(object sender, EventArgs e)
        {
            Notice_Checking.Enabled = true;
            Marks_View.Enabled = true;
            Order_Food.Enabled = true;
            View_Notice_Button.Enabled = true;
            Order_List.Items.Clear();
            Food_Order_Panel.Hide();
            Order_Menu_String = "";
            Order_Menu_Price = 0;
            Place_Order_Food.Hide();
            Room_No.Hide();
            Input_Room_Number.Hide();
        }
        private void Close_Notice_Click(object sender, EventArgs e)
        {
            Notice_Checking.Enabled = true;
            Marks_View.Enabled = true;
            Order_Food.Enabled = true;
            View_Notice_Button.Enabled = true;
            Notice_Panel.Hide();
        }

        private void View_Notice_Click(object sender, EventArgs e)
        {
            DataTable dataTable = s.View_Notice();
            Student_Notice_View.DataSource = dataTable;
            Student_Notice_View.Columns[1].Width = 820;
        }

        private void Add_Food_from_List_Click(object sender, EventArgs e)
        {
            if (Order_List.SelectedIndex ==-1)
            {
                MessageBox.Show("Please Select and Item");
            }
            else
            {
                
                Order_Menu_String = Order_Menu_String + Regex.Replace(Order_List.GetItemText(Order_List.SelectedItem), @"[\d-]", string.Empty).TrimEnd() + ", ";
                Order_Menu_Price+= Int32.Parse(Regex.Replace(Order_List.GetItemText(Order_List.SelectedItem), @"[^\d]", ""));
                RowCount = Selected_Items_from_Menu.Rows.Add();
                
                Selected_Items_from_Menu.Rows[0].Cells[0].Value = Order_Menu_String;
                Selected_Items_from_Menu.Rows[0].Cells[1].Value = Order_Menu_Price.ToString();
                if (RowCount>0)
                {
                    Selected_Items_from_Menu.Rows.RemoveAt(RowCount);
                }
            }
            
        }

        private void Place_Order_Food_Click(object sender, EventArgs e)
        {
            if (Order_Menu_Price > 0 && Order_Status_Check.Text== "Not Ordered")
            {
                s.Student_id = Get_Id_From_Login;
                s.Food_list = Order_Menu_String;
                s.Total_price = Order_Menu_Price;
                if (Input_Room_Number.Text == "")
                {
                    s.Room = "Self Pickup";
                }
                else
                {
                    s.Room = Input_Room_Number.Text;
                }
                
                
                bool success = s.Order_Insert(s); ;

                if (success == true)
                {
                    MessageBox.Show("Order Received! Thanks For Using Me");
                    Order_Status_Check.Text = "Received!";
                }
                else
                {
                    MessageBox.Show("failed!");
                }
                Order_Menu_String = "";
                Order_Menu_Price = 0;
                Order_Status_Check.Text = "Oredered";
            }
            else
            {
                MessageBox.Show("You Have Already Ordered!! Your Food is On the Way");
            }


        }
        private void Hand_Pay_Option_Click(object sender, EventArgs e)
        {
            if (Order_Menu_Price > 0)
            {
                Place_Order_Food.Show();
                Room_No.Show();
                Input_Room_Number.Show();
            }
            else
            {
                MessageBox.Show("Please Add Items from Food list First");
            }
        }

        private void Pay_with_QrCode_Click(object sender, EventArgs e)
        {
            if(Order_Menu_Price > 0)
            {
                QRBox.SizeMode = PictureBoxSizeMode.AutoSize;
                Zen.Barcode.CodeQrBarcodeDraw qrBarcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                QRBox.Image = qrBarcode.Draw("Student Id: " + Get_Id_From_Login+ "\nTotal Cost: " + Order_Menu_Price, 171);
                Place_Order_Food.Show();
                Room_No.Show();
                Input_Room_Number.Show();
            }
            else
            {
                MessageBox.Show("Please Add Items from Food list First");
            }


        }

        private void Food_Order_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Exit_Page_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void View_Notice_Button_Click(object sender, EventArgs e)
        {
            Notice_Checking.Enabled = false;
            Marks_View.Enabled = false;
            Order_Food.Enabled = false;
            View_Notice_Button.Enabled = false;
            View_Notes.Show();

        }

        private void Close_Notes_Panel_Click(object sender, EventArgs e)
        {
            Notice_Checking.Enabled = true;
            Marks_View.Enabled = true;
            Order_Food.Enabled = true;
            View_Notice_Button.Enabled = true;
            View_Notes.Hide();
            Notes_Listbox.ClearSelected();
        }

        private void Shoow_All_Files_Click(object sender, EventArgs e)
        {
            if (Check_Class_From_Login == "8")
            {
                
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 8";
                Notes_Listbox.Items.Clear();
                string[] Files = Directory.GetFiles(Destination_Label.Text);
                foreach(string Notes in Files)
                {
                    Notes_Listbox.Items.Add(Path.GetFileName(Notes));
                }

            }
            else if (Check_Class_Background_From_Login == "Science" && Check_Class_From_Login == "9")
            {
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 9 Science";
                Notes_Listbox.Items.Clear();
                string[] Files = Directory.GetFiles(Destination_Label.Text);
                foreach (string Notes in Files)
                {
                    Notes_Listbox.Items.Add(Path.GetFileName(Notes));
                }
            }
            else if (Check_Class_Background_From_Login == "Science" && Check_Class_From_Login == "10")
            {
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 10 Science";
                Notes_Listbox.Items.Clear();
                string[] Files = Directory.GetFiles(Destination_Label.Text);
                foreach(string Notes in Files)
                {
                    Notes_Listbox.Items.Add(Path.GetFileName(Notes));
                }
            }
            else if (Check_Class_Background_From_Login == "Commerce" && Check_Class_From_Login == "9")
            {
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 9 Commerce";
                Notes_Listbox.Items.Clear();
                string[] Files = Directory.GetFiles(Destination_Label.Text);
                foreach(string Notes in Files)
                {
                    Notes_Listbox.Items.Add(Path.GetFileName(Notes));
                }
            }
            else if (Check_Class_Background_From_Login == "Commerce" && Check_Class_From_Login == "10")
            {
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 10 Commerce";
                Notes_Listbox.Items.Clear();
                string[] Files = Directory.GetFiles(Destination_Label.Text);
                foreach(string Notes in Files)
                {
                    Notes_Listbox.Items.Add(Path.GetFileName(Notes));
                }
            }
            else if (Check_Class_Background_From_Login == "Arts" && Check_Class_From_Login == "9")
            {
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 9 Arts";
                Notes_Listbox.Items.Clear();
                string[] Files = Directory.GetFiles(Destination_Label.Text);
                foreach(string Notes in Files)
                {
                    Notes_Listbox.Items.Add(Path.GetFileName(Notes));
                }
            }
            else if (Check_Class_Background_From_Login == "Arts" && Check_Class_From_Login == "10")
            {
                Destination_Label.Text = "C:\\Users\\Farhan\\Desktop\\Project\\Advance_School_Portal\\Advance_School_Portal\\Notes\\Class 10 Arts";
                Notes_Listbox.Items.Clear();
                string[] Files = Directory.GetFiles(Destination_Label.Text);
                foreach(string Notes in Files)
                {
                    Notes_Listbox.Items.Add(Path.GetFileName(Notes));
                }
            }
        }

        private void Notes_Download_Button_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                
                
                if(Notes_Listbox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select a File to Download");
                }
                else
                {
                    try
                    {
                        string File_Name = Notes_Listbox.GetItemText(Notes_Listbox.SelectedItem);
                        string Download_Location = folderBrowserDialog1.SelectedPath.ToString();
                        MessageBox.Show(File_Name);
                        if (File.Exists(Download_Location + "\\" + File_Name))
                        {
                            MessageBox.Show("File Already Exist");
                        }
                        else
                        {
                            File.Copy(Destination_Label.Text+"\\"+ File_Name, Download_Location + "\\" + File_Name);
                            MessageBox.Show("Success!");
                        }
                    }
                    catch (Exception exp)
                    {
                     MessageBox.Show("Please Check Everything Then Download");    

                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Path For Downloading");
            }
            Notes_Listbox.ClearSelected();
        }
    }
}
