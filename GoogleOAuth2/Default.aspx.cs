using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using GoogleOAuth2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleOAuth2
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_submit_Click1(object sender, EventArgs e)
        {
            GoogleAuth.GetService_v2();
            GoogleAuth.StartService();
            List<GoogleDriveFile> fileList = GoogleAuth.GetDriveFiles();
            if (fileList.Count > 0)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = "<b>Name</b>";
                row.Cells.Add(cell1);
                TableCell cell2 = new TableCell();
                cell2.Text = "<b>Size</b>";
                row.Cells.Add(cell2);
                TableCell cell3 = new TableCell();
                cell3.Text = "<b>Version</b>";
                row.Cells.Add(cell3);
                TableCell cell4 = new TableCell();
                cell4.Text = "<b>Created Date & Time</b>";
                row.Cells.Add(cell4);
                Table1.Rows.Add(row);

                foreach(GoogleDriveFile googleDriveFile in fileList)
                {
                    row = new TableRow();
                    cell1 = new TableCell();
                    cell1.Text = googleDriveFile.name;
                    row.Cells.Add(cell1);
                    cell2 = new TableCell();
                    cell2.Text = Convert.ToString(googleDriveFile.size);
                    row.Cells.Add(cell2);
                    cell3 = new TableCell();
                    cell3.Text = Convert.ToString(googleDriveFile.version);
                    row.Cells.Add(cell3);
                    cell4 = new TableCell();
                    cell4.Text = Convert.ToString(googleDriveFile.createdTime);
                    row.Cells.Add(cell4);
                    Table1.Rows.Add(row);
                }
            }
        }
    }
}