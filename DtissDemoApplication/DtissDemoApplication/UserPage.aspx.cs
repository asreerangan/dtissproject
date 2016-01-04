using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DtissEncryptorDecryptor;

namespace DtissDemoApplication
{
    public partial class UserPage : System.Web.UI.Page
    {
        private int select;
        private int aa;
        private int bb;
        private int cc;
        private int _result = 1;
        private string _mesage = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            Output.Visible = false;
            if (!IsPostBack)
            {
                select = 0;
                String usernid = "676557733";

                usernid = Request.QueryString["nmlogin"];

                if (usernid == null)
                {

                    usernid = "test";

                }
                Label1.Text = "Welcome  " + usernid + " to Ditiss demo portal";

                string[] label ={ " What is your fav book ?",
                               " What is your fav Cartoon Character ? ",
                               " Which City do You live in ?"
                             };
                Random r = new Random();
                int iselect = r.Next(0, 3);
                Response.Write(iselect);
                select = iselect;
                ViewState["select"] = iselect;
                Response.Write(select);
                Label2.Text = label[iselect];

                string[] label2 ={ " How many Sickles are worth one Galleon? ?",
                               " What is the only spell Lockhart was good at? ",
                               " How do you get into Diagon Alley?",
                               "Which finger did Pettigrew cut off?"
                             };
                Random r2 = new Random();
                int iselect2 = r.Next(0, 4);
                Label6.Text = label2[iselect2];

                Random a = new Random();
                Random b = new Random();
                Random c = new Random();
                aa = 0;
                bb = 0;
                cc = 0;
                aa = a.Next(1, 5);
                bb = b.Next(6, 8);
                cc = c.Next(7, 10);
                ViewState["aa"] = aa;
                ViewState["bb"] = bb;
                ViewState["cc"] = cc;
                Response.Write(aa.ToString() + bb.ToString() + cc.ToString());
                Label5.Text = " Enter " + aa.ToString() + " , " + bb.ToString() + " and " + cc.ToString() + " digit of your secret Number ";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string x = cvv.Text;
            Response.Write(select);
            select = (int)ViewState["select"];
            aa = (int)ViewState["aa"];
            bb = (int)ViewState["bb"];
            cc = (int)ViewState["cc"];

            using (SqlConnection netMeterConn = new SqlConnection(
         string.Format("Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;",
                               "localhost", "DTISS",
                      "dtiss", "dtiss1")))
            {

                {
                    try
                    {

                        netMeterConn.Open();
                        SqlCommand command = netMeterConn.CreateCommand();
                        command.CommandText = "FindUserInfo";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add("@Userid", SqlDbType.NVarChar).Value = Request.QueryString["UserNme"];
                        command.Parameters.Add("@cvv", SqlDbType.Int).Value = Convert.ToInt32(cvv.Text.ToString());
                        command.Parameters.Add("@question", SqlDbType.Int).Value = select;
                        command.Parameters.Add("@expirdate", SqlDbType.NVarChar).Value = Convert.ToDateTime(TextBox8.Text);
                        command.Parameters.Add("@result", SqlDbType.Int, 255).Direction = ParameterDirection.Output;
                        command.Parameters.Add("@message", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
                        command.Parameters.Add("@secretnumber", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
                        command.Parameters.Add("@answer", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
                        command.Parameters.Add("@ccnumber", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
                        command.ExecuteNonQuery();

                        _result = Convert.ToInt32(command.Parameters["@result"].Value);
                        _mesage = Convert.ToString(command.Parameters["@message"].Value);
                        if (_result == -1)
                        {
                            Output.Visible = true;
                            Output.Text = _mesage;
                            return;
                            //  Response.Write(_mesage);


                        }
                        string secret = EncryptorDecryptor.StringtoDecrypt (Convert.ToString(command.Parameters["@secretnumber"].Value),true);
                        string answer = "";
                        if (select != 2)
                        {
                             answer = EncryptorDecryptor.StringtoDecrypt(Convert.ToString(command.Parameters["@answer"].Value), true);
                        }
                        else
                        {
                             answer = Convert.ToString(command.Parameters["@answer"].Value);
                        
                        }
                        string ccnumber =  EncryptorDecryptor.StringtoDecrypt( Convert.ToString(command.Parameters["@ccnumber"].Value),true);
                        netMeterConn.Close();
                        if (_result == -1)
                        {
                            Output.Visible = true;
                            Output.Text = _mesage;
                          //  Response.Write(_mesage);
                        

                        }

                        else
                        {
                       
                            CheckCCParameters(  secret, answer, ccnumber);

                            Response.Redirect("/onetime.aspx");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);


                    }


                }
            }
        }

        private void CheckCCParameters(  string secret, string answer, string ccnumber)
        {
            
            
            bool results;

            results = StringCompare(TextBox1.Text.Replace(" ", ""), answer.Replace(" ", ""));
            if (!results)
            {

                Output.Visible = true;
                Output.Text =" The Security answers do not match please resubmit";
                return;
            }
        
            ccnumber = ccnumber.Substring(ccnumber.Length - 4, 4);
       

           results =StringCompare(debit.Text,ccnumber);

           if (!results)
           {

               Output.Visible = true;
               Output.Text = " The Debit card numbers do not match please resubmit";
               return;
           }
           char firstui = secret[aa-1];
           char secui = secret[bb - 1];
           char thirui = secret[cc - 1];

           string final = firstui.ToString() + secui.ToString() + thirui.ToString();

           results = StringCompare(TextBox6.Text.ToString(), final);
           if (!results)
           {

               Output.Visible = true;
               Output.Text = " The Secret answers do not match please resubmit";
               return;
           }



        }

        private bool StringCompare(string a, string b)
        {

            bool i = String.Equals(a, b, StringComparison.OrdinalIgnoreCase);

            return i;
        
        }
    }
}