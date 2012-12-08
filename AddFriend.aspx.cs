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
public partial class AddFriend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtFreindID.Focus();
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string sessionId = Session.SessionID.ToString();
        string FriendId = txtFreindID.Text;
        clsDBCalls dbObj = new clsDBCalls();
        int status = Convert.ToInt32(dbObj.AddFriend(sessionId, FriendId));
        
        if (status == 0)
        {
            lblMessage.Text = "You friend is not registered with us";
        }
        else
        {
            lblMessage.Text = "Friend Added";
            
        }
    }
}