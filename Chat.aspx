<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chat.aspx.cs" Inherits="Chat" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        var xPos, yPos,sHeight;
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            xPos = $get('txtChat').scrollLeft;
            yPos = $get('txtChat').scrollTop;
            sHeight = $get('txtChat').scrollHeight;

        }
        function EndRequestHandler(sender, args) {
            $get('txtChat').scrollLeft = xPos;
            if (sHeight < $get('txtChat').scrollHeight) {
                $get('txtChat').scrollTop = $get('txtChat').scrollHeight;
            }
            else {
                $get('txtChat').scrollTop = yPos;
            }

        }
     </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="txtChat" runat="server" Height="275px" ReadOnly="True" 
                TextMode="MultiLine" Width="508px"></asp:TextBox>
            <br />
            <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
            </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" DefaultButton = "btnSend">
                <asp:TextBox ID="txtMessage" runat="server" AutoCompleteType="Disabled" 
                    Height="77px" Width="444px" MaxLength="160"></asp:TextBox>
                <asp:Button ID="btnSend" runat="server" onclick="btnSend_Click" Text="Send" 
                    onclientclick="this.focus()" />
                <br />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </asp:Panel>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
