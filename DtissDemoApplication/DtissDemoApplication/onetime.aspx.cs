using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DtissDemoApplication
{
    public partial class onetime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

               // Guid x = new Guid();
                string y =  System.Guid.NewGuid().ToString();

                Label1.Text = " Your one time password is generated =" + y.Replace("-","").ToUpper() + "  the page will be destroyed in 15 seconds";
                Response.AddHeader("REFRESH", "15;URL=AccountLogin.aspx");
            
            }
        }
    }
}