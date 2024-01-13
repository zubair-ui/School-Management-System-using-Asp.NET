<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DatabaseConnectivity.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Client Side Controls</h1>
        </div>
        <div>
            <input id="Text1" type="text" /><br />
            <input id="Radio1" type="radio" /><br />
            <input id="Button1" type="button" value="button" />
        </div>
        <div>
           <h1> Server Side Controls</h1>
        </div>
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            <asp:RadioButton ID="RadioButton1" runat="server" />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Post Back" OnClick="Button2_Click" />

            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Redirect" />

        </div>
    </form>
</body>
</html>
