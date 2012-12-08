<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  
    <form id="form1" runat="server">
   
    <div>
          <table style="width: 100%; margin-bottom: 0px;">
                    <tr>
                        <td align="right" width="50%">
                            <asp:Label ID="lblEmailID" runat="server" Text="Email ID:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtEmailId" ErrorMessage="Please enter your email id"></asp:RequiredFieldValidator>
                            <asp:Label ID="lblIdAvailable" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%">
                            <asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPassword" runat="server" Height="22px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtPassword" ErrorMessage="Please enter a password"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%">
                            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm password:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" 
                                ErrorMessage="Re-enter your password"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" width="50%">
                            <asp:Button ID="btnRegister" runat="server" onclick="btnRegister_Click" 
                                Text="Register" />
                        </td>
                    </tr>
                </table>
    
    
    </div>
    </form>
</body>
</html>
