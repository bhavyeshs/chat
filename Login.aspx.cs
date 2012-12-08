using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using chatApp;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        clsDBCalls dbObj = new clsDBCalls();
        
        if (dbObj.CheckSession(Session.SessionID.ToString()) == 1)
        {
            Response.Redirect("\\chatsite\\Home.aspx");
        }
        
        txtEmailID.Focus();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string md5Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "MD5");
        clsDBCalls objLogin = new clsDBCalls();
        string userName = (txtEmailID.Text.Trim());
        string sessionId = Session.SessionID.ToString();
        int retval = objLogin.CheckLogin(userName, md5Password, sessionId);
        if (retval == 1)
        {
            Response.Redirect("\\chatsite\\Home.aspx");
        }

        else
        {
            lblMessage.Text = "Invalid mail id or password";
        }

        
    }
}