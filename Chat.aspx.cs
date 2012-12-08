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


public partial class Chat : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Timer1_Tick(sender, e);
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        string sessionId = Session.SessionID.ToString();
        clsDBCalls objData = new clsDBCalls();
        string toId = Request["toId"];
        DataTable dtChat = new DataTable();
        dtChat = objData.getMessages(sessionId, toId);
        if (dtChat.Rows.Count > 0)
        {
            string Chats = null;
            foreach (DataRow row in dtChat.Rows)
            {
                string msender = row["Userid1"].ToString();
                string mmessage = row["messages"].ToString();
                string times = (DateTime.Parse(row["timest"].ToString())).ToShortTimeString();
                Chats = Chats + msender + ": \t" + mmessage + "\t" + times + "\n";
            }
            txtChat.Text = Chats;
        }
        
    }

   
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string Message = txtMessage.Text;
        txtMessage.Text = "";
        txtMessage.Focus();
        string sessionId = Session.SessionID.ToString();
        clsDBCalls objData = new clsDBCalls();
        string toId = Request["toId"];
        int retVal = objData.InsertMessage(sessionId, toId, Message);
        if (retVal == 1)
        {
            lblMessage.Text = "An error occurred while sending your message ";
        }
         
        
       
    }
}