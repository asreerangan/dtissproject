using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Web.UI.WebControls;
using DtissEncryptorDecryptor;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

namespace DtissDemoApplication
{
    public partial class AccountLogin : System.Web.UI.Page
    {

        public static string servername { get; set; }
        public static string databasename { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }
        public static string envtype { get; set; }
        private int _output;
        private string _firstanme;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click1(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(LoginUser.UserName, false);
            //string x = EncryptorDecryptor.StringtoEncrypt(LoginUser.Password.ToString(), true);
            Databaseparameters();

            if (envtype == "Production")
            {
                using (SqlConnection netMeterConn = new SqlConnection(
              string.Format("Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;",
                                    "localhost", databasename,
                            username, password)))
                {
                    try
                    {

                        netMeterConn.Open();
                        SqlCommand command = netMeterConn.CreateCommand();
                        command.CommandText = "CheckUser";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add("@login_name", SqlDbType.NVarChar).Value = LoginUser.UserName.ToString();
                        command.Parameters.Add("@password", SqlDbType.NVarChar).Value = EncryptorDecryptor.StringtoEncrypt(LoginUser.Password.ToString(), true);
                        command.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("@firstname", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
                        command.ExecuteNonQuery();

                        _output = Convert.ToInt32(command.Parameters["@result"].Value);

                        _firstanme = Convert.ToString(command.Parameters["@firstname"].Value);




                        netMeterConn.Close();

                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }

                }

                if (_output == 1 && LoginUser.UserName.ToString() == "Admin")
                {

                    Response.Redirect("AddAccount.aspx?nmlogin=" + _firstanme + "&UserNme=" + LoginUser.UserName.ToString());
                }

                else if (_output == 1 && LoginUser.UserName.ToString() != "Admin")
                {

                    Response.Redirect("UserPage.aspx?nmlogin=" + _firstanme + "&UserNme=" + LoginUser.UserName.ToString());


                }

                else
                {

                    Response.Write("UserName or Password is incorrect");



                }
            }

            else
            {

                string user = LoginUser.UserName.ToString();
                string strSQL = "select nm_login from [user_credentials] where nm_login = '" + user + "'" + "password =" + 
                    "'" +"iTVoLTZTEqM="+"'";

                string connstring = string.Format("Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;",
                                               "localhost", "DTISS",
                                      "sa", "MetraTech1");
                using (SqlConnection cnn = new SqlConnection(connstring))
                {

                    cnn.Open();


                    SqlCommand myCommand = new SqlCommand(strSQL, cnn);

                    using (SqlDataReader reader = myCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string x = (reader["nm_login"].ToString());
                              Response.Redirect("AddAccount.aspx?nmlogin=" + x + "&UserNme=" + LoginUser.UserName.ToString());
                        }
                    }
                }
            }


        }


        private static void Databaseparameters()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(@"D:\Dtiss\servers.xml");
            servername = xmldoc.SelectSingleNode("//servername").InnerText;
            databasename = xmldoc.SelectSingleNode("//databasename").InnerText;
            username = xmldoc.SelectSingleNode("//username").InnerText;
            password = EncryptorDecryptor.StringtoDecrypt(xmldoc.SelectSingleNode("//password").InnerText, true);
            xmldoc.Load(@"D:\Dtiss\dtissconfig.xml");

            envtype = xmldoc.SelectSingleNode("//Environmenttype").InnerText;

        }
    }
}
       

        
    