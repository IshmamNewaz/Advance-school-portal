using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Advance_School_Portal
{
    public partial class CanteenStaff : Form
    {
        public string UserNameInInterFace { get; set; }
        public CanteenStaff()
        {
            InitializeComponent();
        }
        CanteenStaffInfo c = new CanteenStaffInfo();
        private void CanteenStaff_Load(object sender, EventArgs e)
        {
            WelcomeText.Text = UserNameInInterFace;
            Canteen_Order_View.RowTemplate.Height = 200;
            Label_Student_Id.Hide();
            Label_Status.Hide();
            Order_Panel.Hide();
            Input_Status.Hide();
            Input_Student_Id.Hide();
            Update_Status.Hide();
            Notice_view_Panel.Hide();

            Notice_grid.RowTemplate.Height = 200;
            Input_Notice_id.Text = "";
            Input_Notice.Text = "";
            Label_Notice.Hide();
            Lable_Notice_id.Hide();
            Notice_view_Panel.Hide();
            Input_Notice_id.Hide();
            Input_Notice.Hide();
            Insert_Notice.Hide();
            Delete_Notice.Hide();
        }

        private void Order_View_Click(object sender, EventArgs e)
        {
            Order_Panel.Show();
            Notice_Checking.Enabled = false;

        }

        private void Close_Orders_Click(object sender, EventArgs e)
        {
            Order_Panel.Hide();
            Notice_Checking.Enabled = true;
            Input_Status.Text="";
            Input_Student_Id.Text="";
            Label_Student_Id.Hide();
            Label_Status.Hide();
            Order_Panel.Hide();
            Input_Status.Hide();
            Input_Student_Id.Hide();
            Update_Status.Hide();
        }

        private void Update_Order_Status_Click(object sender, EventArgs e)
        {
            Label_Student_Id.Show();
            Label_Status.Show();
            Order_Panel.Show();
            Input_Status.Show();
            Input_Student_Id.Show();
            Update_Status.Show();
        }

        private void Update_Status_Click(object sender, EventArgs e)
        {
            c.Order_id = Input_Student_Id.Text;
            c.Order_status = Input_Status.Text;


            bool success = c.Order_Update(c); ;

            if (success == true)
            {
                MessageBox.Show("Updation Done!");
            }
            else
            {
                MessageBox.Show("failed!");
            }
            Input_Student_Id.Text = "";
            Input_Status.Text = "";
            View_Current_Orders_Click(sender, e);
        }

        private void View_Current_Orders_Click(object sender, EventArgs e)
        {
            
            DataTable view_orders = c.View_All_Orders();
            Canteen_Order_View.DataSource = view_orders;
            Canteen_Order_View.Columns[1].Width = 800;

        }

        private void Clean_Everything_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Are you Sure You Wan't to Clean Everything?",
                      "Empty Order List", MessageBoxButtons.YesNo);
            switch (Result)
            {
                case DialogResult.Yes:
                    bool success = c.Delete_All_Orders();

                    if (success == true)
                    {
                        MessageBox.Show("All Deletion Done!");
                        View_Current_Orders_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("failed!");
                    }
                    break;
                case DialogResult.No:
                    View_Current_Orders_Click(sender, e);
                    break;
            }
            
        }

        private void Notice_Checking_Click(object sender, EventArgs e)
        {
            Notice_view_Panel.Show();
            Order_View.Enabled = false;
        }

        private void Close_Notice_Click(object sender, EventArgs e)
        {
            Notice_view_Panel.Show();
            Order_View.Enabled = true;
            Input_Notice_id.Text = "";
            Input_Notice.Text = "";
            Label_Notice.Hide();
            Lable_Notice_id.Hide();
            Notice_view_Panel.Hide();
            Input_Notice_id.Hide();
            Input_Notice.Hide();
            Insert_Notice.Hide();
            Delete_Notice.Hide();
            Delete_Canteen_Notice.Enabled = true;
            Add_New_Notice.Enabled = true;
        }

        private void Add_New_Notice_Click(object sender, EventArgs e)
        {
            Input_Notice_id.Text = "";
            Input_Notice.Text = "";
            Label_Notice.Show();
            Lable_Notice_id.Show();
            Notice_view_Panel.Show();
            Input_Notice_id.Show();
            Input_Notice.Show();
            Insert_Notice.Show();
            Delete_Notice.Hide();
            Delete_Canteen_Notice.Enabled = false;
        }

        private void Insert_Notice_Click(object sender, EventArgs e)
        {
            if (Input_Notice.Text==""&& Input_Notice_id.Text=="")
            {
                MessageBox.Show("Please Insert First");
            }

            else
            {
                c.Notice_id = Input_Notice_id.Text;
                c.Notice = Input_Notice.Text;
                bool success = c.Insert_Notice(c); ;

                if (success == true)
                {
                    MessageBox.Show("Insertion Done!");
                    Input_Notice_id.Text = "";
                    Input_Notice.Text = "";
                    Show_All_Notice_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("failed!");
                }
            }
        }

        private void Show_All_Notice_Click(object sender, EventArgs e)
        {
            DataTable Notice = new DataTable();
            Notice = c.View_All_Notice();
            Notice_grid.DataSource = Notice;
            Notice_grid.Columns[1].Width = 800;
        }

        private void Delete_Canteen_Notice_Click(object sender, EventArgs e)
        {
            Input_Notice_id.Text = "";
            Input_Notice.Text = "";
            Label_Notice.Hide();
            Lable_Notice_id.Show();
            Notice_view_Panel.Show();
            Input_Notice_id.Show();
            Input_Notice.Hide();
            Insert_Notice.Hide();
            Delete_Notice.Show();
            Add_New_Notice.Enabled = false;
        }

        private void Delete_Notice_Click(object sender, EventArgs e)
        {
            if(Input_Notice_id.Text == "")
            {
                MessageBox.Show("Please Insert First");
            }
            else
            {
                c.Notice_id = Input_Notice_id.Text;
                bool success = c.Delete_Notice(c);

                if (success == true)
                {
                    MessageBox.Show("Successful");
                    Show_All_Notice_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("failed!");
                }
            }
            

        }

        private void Exit_Page_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
