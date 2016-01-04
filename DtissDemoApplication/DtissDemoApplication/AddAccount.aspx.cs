using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DtissEncryptorDecryptor;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Globalization;

namespace DtissDemoApplication
{
    public partial class AddAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cvv.Text = "";
        }

        private string _result;
        private string _nmlogin;
        private string _email = "";

        private string _password = "dtiss1";
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string x = Cvv.Text;
            using (SqlConnection netMeterConn = new SqlConnection(
          string.Format("Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;",
                                "localhost", "DTISS",
                       "dtiss", "dtiss1")))
            {
                try
                {
                    string xx = EncryptorDecryptor.StringtoEncrypt(TextBox3.Text, true);
                    netMeterConn.Open();
                    SqlCommand command = netMeterConn.CreateCommand();
                    command.CommandText = "CreateUser";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@Firstname", SqlDbType.NVarChar).Value = TextBox1.Text;
                    command.Parameters.Add("@Lastname", SqlDbType.NVarChar).Value = TextBox4.Text;
                    _email = TextBox12.Text;
                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value = TextBox12.Text;
                    command.Parameters.Add("@address1", SqlDbType.NVarChar).Value = TextBox2.Text;
                    command.Parameters.Add("@address2", SqlDbType.NVarChar).Value = TextBox5.Text;
                    command.Parameters.Add("@city", SqlDbType.NVarChar).Value = TextBox6.Text;
                    command.Parameters.Add("@state", SqlDbType.NVarChar).Value = DropDownList2.Text;
                    command.Parameters.Add("@debitcard", SqlDbType.NVarChar).Value = EncryptorDecryptor.StringtoEncrypt(TextBox3.Text, true);
                    int cvv = Convert.ToInt32(Cvv.Text);
                    command.Parameters.Add("@cvv", SqlDbType.Int).Value = cvv;
                    //DateTime dt = DateTime.ParseExact(TextBox8.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                   // command.Parameters.Add("@expiry", SqlDbType.NVarChar).Value =  DateTime.ParseExact("2012-09-24", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    command.Parameters.Add("@cardtype", SqlDbType.NVarChar).Value = DropDownList1.Text;
                    command.Parameters.Add("@cartoon", SqlDbType.NVarChar).Value = EncryptorDecryptor.StringtoEncrypt(TextBox9.Text, true);
                    command.Parameters.Add("@book", SqlDbType.NVarChar).Value = EncryptorDecryptor.StringtoEncrypt(TextBox10.Text, true);
                    command.Parameters.Add("@secret", SqlDbType.NVarChar).Value = EncryptorDecryptor.StringtoEncrypt(TextBox11.Text, true);

                    command.Parameters.Add("@password", SqlDbType.NVarChar).Value = EncryptorDecryptor.StringtoEncrypt(_password, true);

                    command.Parameters.Add("@nmlogin", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@result", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();

                    _result = Convert.ToString(command.Parameters["@result"].Value);
                    _nmlogin = Convert.ToString(command.Parameters["@nmlogin"].Value);

                    netMeterConn.Close();

                    if (_result == "Success")
                    {
                        SendEmail(TextBox1.Text, _nmlogin, _password);

                        Response.Redirect("SuccessPage.aspx?UserName=" + _nmlogin);

                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }


        }

        private bool ValidateCreditCard(string cardNumber)
        {
            cardNumber = TextBox3.Text;
            int digitSum = 0;
            string digits = "";
            string reversedCardNumber = "";

            //removes spaces and reverse string 
            cardNumber = cardNumber.Replace(" ", null);
            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                reversedCardNumber += cardNumber[i];
            }

            //double the digits in even-numbered positions
            for (int i = 0; i < reversedCardNumber.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    digits += Convert.ToInt32(reversedCardNumber.Substring(i, 1)) * 2;
                }
                else
                {
                    digits += reversedCardNumber.Substring(i, 1);
                }
            }

            //add the digits
            for (int i = 0; i < digits.Length; i++)
            {
                digitSum += Convert.ToInt32(digits.Substring(i, 1));
            }

            //Check that the sum is divisible by 10
            if ((digitSum % 10) == 0)
                return true;
            else
                return false;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ValidateCreditCard(args.Value);
        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                System.Threading.Thread.Sleep(3000);
                smtp.Send(mailMessage);
                System.Threading.Thread.Sleep(3000);
                
            }
        }

        protected void SendEmail( string firstname, string username, string password)
        {
            string body = this.PopulateBody(firstname, username, password
              );
            this.SendHtmlFormattedEmail(_email, "Dtiss Information!", body);
        }

        private string PopulateBody(string firstname, string username, string password)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplate.htm")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{firstname}", firstname);

            body = body.Replace("{Username}", username);

            body = body.Replace("{Password}", password);
            return body;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.TextBox1.Text = "";
            this.TextBox10.Text = "";
            this.TextBox11.Text = "";
            this.TextBox12.Text = "";
            this.TextBox2.Text = "";
            this.TextBox3.Text = "";
            this.TextBox4.Text = "";
            this.TextBox5.Text = "";
            this.TextBox6.Text = "";
            this.TextBox8.Text = "";
            this.TextBox9.Text = "";
            this.Cvv.Text = "";

        }
    }
}