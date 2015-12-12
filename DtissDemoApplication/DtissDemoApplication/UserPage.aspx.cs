using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DtissDemoApplication
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String usernid = "676557733";
            Label1.Text = "Welcome User " + usernid + " to Ditiss demo portal";

            string[] label ={ " What is your fav book ?",
                               " What is your fav Cartoon Character ? ",
                               " Which City do You live in ?"
                             };
            Random r = new Random();
            int iselect = r.Next(0, 2);
            Label2.Text = label[iselect];

            string[] label2 ={ " How many Sickles are worth one Galleon? ?",
                               " What is the only spell Lockhart was good at? ",
                               " How do you get into Diagon Alley?",
                               "Which finger did Pettigrew cut off?"
                             };
            Random r2 = new Random();
            int iselect2 = r.Next(0, 3);
            Label6.Text = label2[iselect2];

            Random a = new Random();
            Random b = new Random();
            Random c= new Random();

            Label5.Text = " Enter " + a.Next(1,5).ToString() + " , " + b.Next(6,8).ToString() + " and " +c.Next(7,10).ToString() + " digit of your secret Number ";

        }
    }
}