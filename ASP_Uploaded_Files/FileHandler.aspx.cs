using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace ASP_Uploaded_Files
{
    public partial class FileHandler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ()
                {

                }
                string[] filePaths = Directory.GetFiles(Server.MapPath("~/UploadedFiles/"));
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("filename");
                foreach (string filePath in filePaths)
                {
                    //files.Add(new ListItem(Path.GetFileName(filePath), filePath));
                    dr = dt.NewRow();
                    dr["filename"] = Path.GetFileName(filePath).ToString();
                    dt.Rows.Add(dr);
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}