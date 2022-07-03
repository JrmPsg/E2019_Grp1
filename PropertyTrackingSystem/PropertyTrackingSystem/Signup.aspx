<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="PropertyTrackingSystem.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Property Tracking System</title>
     <link rel = "stylesheet" type = "text/css" href = "Signupstyle.css">
</head>
<body>
    <form id="form1" runat="server">
         <%-- Ito yung sa header na nasa taas --%>
        <header>
            <asp:Label ID="LabelTitle" runat="server" Text="Property Tracking System"></asp:Label>
        </header>

        <%-- Section Sign up --%>
        <section id="SectionSignup">
            <%-- Sign up Label component --%>
            <asp:Label ID="LabelSignup" runat="server" Text="Signup"></asp:Label>

            <%-- Lastname Label, TextBox, Validator component --%>
            <asp:Label ID="LabelLastname" runat="server" Text="Lastname"></asp:Label>
            <asp:TextBox ID="TextBoxLastname" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="lastnameValidator" runat="server" ErrorMessage="Required" ControlToValidate="TextBoxLastname"></asp:RequiredFieldValidator>

            <%-- Firstname Label, TextBox, Validator component --%>
            <asp:Label ID="LabelFirstname" runat="server" Text="Firstname"></asp:Label>
            <asp:TextBox ID="TextBoxFirstname" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="firstnameValidator" runat="server" ErrorMessage="Required" ControlToValidate="TextBoxFirstname"></asp:RequiredFieldValidator>

            <%-- Username Label, TextBox, Validator component --%>
            <asp:Label ID="LabelUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="usernameValidator" runat="server" ErrorMessage="Required" ControlToValidate="TextBoxUsername"></asp:RequiredFieldValidator>

            <%-- Password Label, TextBox, Validator component --%>
            <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ErrorMessage="Required" ControlToValidate="TextBoxPassword"></asp:RequiredFieldValidator>

            <%-- Confirm Password Label, TextBox, Validator component --%>
            <asp:Label ID="LabelConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="TextBoxConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="confirmpasswordValidator" runat="server" ErrorMessage="Required" ControlToValidate="TextBoxConfirmPassword"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="comparepasswordValidator" runat="server" ErrorMessage="Password does not match" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxConfirmPassword"></asp:CompareValidator>

            <%-- Sign up or Register Button component --%>
            <asp:Button ID="ButtonRegister" runat="server" Text="Register" />

            <%-- Already Have an Account Hyperlink component --%>
            <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl="~/Login.aspx" Text="Already Have an Account?"></asp:HyperLink>
        </section>
    </form>
</body>
</html>
