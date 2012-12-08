<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">LogOut</asp:LinkButton>
        <br />
    
        <asp:ListBox ID="ListBox1" runat="server" Height="309px" 
            onselectedindexchanged="ListBox1_SelectedIndexChanged" Width="183px" 
            AutoPostBack="True">
        </asp:ListBox>

        <asp:LinkButton ID="lnkAddFriend" runat="server" onclick="lnkAddFriend_Click">Add Friend</asp:LinkButton>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="5000" ontick="Timer1_Tick">
                </asp:Timer>
                <br />
                <asp:LinkButton ID="lnkMessageButton" runat="server" 
                    onclick="lnkMessageButton_Click"></asp:LinkButton>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
