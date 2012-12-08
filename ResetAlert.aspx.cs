using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chatApp;
public partial class ResetAlert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsDBCalls objDb = new clsDBCalls();
        string sessionId = Session.SessionID.ToString();
        string toId = Request["toId"];
        objDb.resetAlert(sessionId, toId);
        Response.Redirect("\\ChatSite\\Chat.aspx?toId=" + toId);
    }
}