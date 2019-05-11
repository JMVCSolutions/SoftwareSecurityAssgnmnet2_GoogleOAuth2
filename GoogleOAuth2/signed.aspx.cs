using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleOAuth2
{
    public partial class signed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = GoogleAuth.REFRESH_TOKEN;
            //GoogleAuth.StartService();
            //Label1.Text = GoogleAuth.GetDriveFiles().ToString();
        }
    }
}