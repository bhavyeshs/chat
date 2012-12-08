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


public partial class Home : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string sessionId = Session.SessionID.ToString();
            clsDBCalls fetchFriends = new clsDBCalls();
            DataTable dtFriendList = new DataTable();
            dtFriendList = fetchFriends.fetchFriends(sessionId);
            if (dtFriendList.Rows.Count > 0)
            {
                ListBox1.DataSource = dtFriendList;
                ListBox1.DataTextField = "UserName";
                ListBox1.DataValueField = "UserId";
                ListBox1.DataBind();
            }
            else
            {
                lnkAddFriend.Text = "You do not have any friends, add some frnds and start chatting";
            }
            
        }
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string SelectedId = ListBox1.SelectedItem.ToString();
        string sessionId = Session.SessionID.ToString();
        //string UserId = null;
        clsDBCalls dbObj = new clsDBCalls();
        //UserId = dbObj.getUserName(sessionId);
        dbObj.setAlert(sessionId, SelectedId);
        Response.Write("<script>open('\\Chat.aspx?toId=" + SelectedId + "','List','scrollbars=no,resizable=no,width=600,height=400');</script>");
    }      
   
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //Check for alerts
        clsDBCalls objDBcall = new clsDBCalls();
        string sessionId = Session.SessionID.ToString();
        DataTable dtCheckAlert = new DataTable();
        dtCheckAlert = objDBcall.checkAlert(sessionId);        
        foreach(DataRow dr in dtCheckAlert.Rows)
        {
            string InviterId = dr["UserId1"].ToString();
            lnkMessageButton.Text = "You have a new message from " + InviterId;            
            lnkMessageButton.OnClientClick = "document.getElementById('lnkMessageButton').innerText=''; open('\\ResetAlert.aspx?toId=" + InviterId + "','List','scrollbars=no,resizable=no,width=600,height=400')";            
        }
       
        
    }

    protected void lnkMessageButton_Click(object sender, EventArgs e)
    {

    }
    protected void lnkAddFriend_Click(object sender, EventArgs e)
    {
        Server.Transfer("/chatsite/AddFriend.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        Response.Redirect("/ChatSite/Default.aspx");
    }
}