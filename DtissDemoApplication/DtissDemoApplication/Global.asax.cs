﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text;
using System.Security.Cryptography;

namespace DtissDemoApplication
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            

        }

      

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            //Pass the custom Session ID to the browser.
            if (Response.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = Request.Cookies["ASP.NET_SessionId"].Value + GenerateHashKey();
            }

        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //Check If it is a new session or not , if not then do the further checks
            if (Request.Cookies["ASP.NET_SessionId"] != null && Request.Cookies["ASP.NET_SessionId"].Value != null)
            {
                string newSessionID = Request.Cookies["ASP.NET_SessionID"].Value;
                //Check the valid length of your Generated Session ID
                if (newSessionID.Length <= 24)
                {
                    //Log the attack details here
                    Response.Cookies["TriedTohack"].Value = "True";
                    throw new HttpException("Invalid Request");
                }

                //Genrate Hash key for this User,Browser and machine and match with the Entered NewSessionID
                if (GenerateHashKey() != newSessionID.Substring(24))
                {
                    //Log the attack details here
                    Response.Cookies["TriedTohack"].Value = "True";
                    throw new HttpException("Invalid Request");
                }

                //Use the default one so application will work as usual//ASP.NET_SessionId
                Request.Cookies["ASP.NET_SessionId"].Value = Request.Cookies["ASP.NET_SessionId"].Value.Substring(0, 24);
            }

        } 
        private string GenerateHashKey()
        {
            StringBuilder myStr = new StringBuilder();
            myStr.Append(Request.Browser.Browser);
            myStr.Append(Request.Browser.Platform);
            myStr.Append(Request.Browser.MajorVersion);
            myStr.Append(Request.Browser.MinorVersion);
            //myStr.Append(Request.LogonUserIdentity.User.Value);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] hashdata = sha.ComputeHash(Encoding.UTF8.GetBytes(myStr.ToString()));
            return Convert.ToBase64String(hashdata);
        }
    
    }
}
