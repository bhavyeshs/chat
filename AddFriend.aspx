<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddFriend.aspx.cs" Inherits="AddFriend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 70px;
        }
        .style2
        {
            width: 268435456px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table style="width: 37%; height: 149px;">
            <tr>
                <td align="right" class="style1">
        <asp:Label ID="lblFriendId" runat="server" Text="Friend's Id : "></asp:Label>
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtFreindID" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtFreindID" ErrorMessage="*">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" 
                        style="margin-left: 0px" Text="Add" Width="114px" />
                    <br />
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
