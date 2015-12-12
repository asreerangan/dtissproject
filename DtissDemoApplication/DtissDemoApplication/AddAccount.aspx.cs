using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DtissEncryptorDecryptor;
using System.Data;

namespace DtissDemoApplication
{
    public partial class AddAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox7.Text = "";
        }

        private string _result;
        private string _nmlogin;

        private string _password = "dtiss1";
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection netMeterConn = new SqlConnection(
          string.Format("Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;",
                                "localhost", AccountLogin.databasename,
                        AccountLogin.username, AccountLogin.password)))
            {
                try
                {

                    netMeterConn.Open();
                    SqlCommand command = netMeterConn.CreateCommand();
                    command.CommandText = "CreateUser";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@Firstname", SqlDbType.NVarChar).Value = TextBox1.Text;
                    command.Parameters.Add("@Lastname", SqlDbType.NVarChar).Value = TextBox4.Text;
                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value = TextBox12.Text;
                    command.Parameters.Add("@address1", SqlDbType.NVarChar).Value = TextBox2.Text;
                    command.Parameters.Add("@address2", SqlDbType.NVarChar).Value = TextBox5.Text;
                    command.Parameters.Add("@city", SqlDbType.NVarChar).Value = TextBox6.Text;
                    command.Parameters.Add("@state", SqlDbType.NVarChar).Value = DropDownList2.Text;
                    command.Parameters.Add("@debitcard", SqlDbType.NVarChar).Value = EncryptorDecryptor.StringtoEncrypt(TextBox3.Text, true);
                    command.Parameters.Add("@cvv", SqlDbType.Int).Value = Convert.ToInt32(TextBox7.Text);
                    command.Parameters.Add("@expiry", SqlDbType.NVarChar).Value = TextBox8.Text;
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
    }
}