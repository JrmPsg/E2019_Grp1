<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PropertyTrackingSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Property Tracking System</title>
     <link rel = "stylesheet" type = "text/css" href = "Loginstyle.css">
    <script type="text/javascript" >
        function preventBack() {
            window.history.forward();
        }
        setTimeout("preventBack()", 0);
        window.onunload=function(){null};
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <%-- Ito yung sa header na nasa taas --%>
        <header>
            <asp:Label ID="LabelTitle" runat="server" Text="Property Tracking System"></asp:Label>
        </header>

        <%-- Section login --%>
        <section id="SectionLogin">
            <%-- Login Label Component --%>
            <asp:Label ID="LabelLogin" runat="server" Text="Log-in"></asp:Label>

            <%-- Username Label, TextBox, and Validator Component --%>
            <asp:Label ID="LabelUsername" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="TextBoxUsername" runat="server" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="usernameValidator" runat="server" ErrorMessage="Required" ControlToValidate="TextBoxUsername"></asp:RequiredFieldValidator>

            <%-- Password Label, TextBox, and Validator Component --%>
            <asp:Label ID="LabelPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ErrorMessage="Required" ControlToValidate="TextBoxPassword"></asp:RequiredFieldValidator>

            <%-- Register Button --%>
            <asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click" CausesValidation="false"/>

            <%-- Login Button --%>
            <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click"/>
        </section>
    </form>
</body>
</html>
