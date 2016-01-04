using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DtissDemoApplication
{
    public partial class SuccessPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string user = Request.QueryString["UserName"];
                if (user == null)

                { user = "test"; }
            Label1.Text ="User " + user +" has been created and the email has been sent Click Back to create another account or Log out";

            
            
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAccount.aspx");
        }
    }
}