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


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string md5Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "MD5");
        string userName = txtEmailId.Text.Trim();
        clsDBCalls dbObj = new clsDBCalls();
        int retVal = dbObj.RegisterUser(userName, md5Password);
        if (retVal == 1)
        {
            lblIdAvailable.Text = "User Id already taken";
        }
        else if(retVal == 2) 
        {
            lblIdAvailable.Text = "DB Error";
        }
        else if (retVal == 0)
        {
            lblIdAvailable.Text = "User Registered. Please login";
        }

        
    }
}