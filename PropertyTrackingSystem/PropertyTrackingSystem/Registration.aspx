<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PropertyTrackingSystem.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Property Tracking System</title>
    <link rel = "stylesheet" type = "text/css" href = "Registrationstyle.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <%-- Ito naman yung sa navigation sa left side gagamit ako ng unordered list ng html --%>
        <asp:Panel ID="navigation" runat="server">
            <asp:Button ID="ButtonDashboard" runat="server" Text="Dashboard" BorderStyle="None" CssClass="menubutton" OnClick="ButtonDashboard_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonRequestitem" runat="server" Text="Request Item" BorderStyle="None" CssClass="menubutton" OnClick="ButtonRequestitem_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonItemstools" runat="server" Text="Items / Tools" BorderStyle="None" CssClass="menubutton" OnClick="ButtonItemstools_Click" CausesValidation="false" />
            <asp:Button ID="ButtonBorrowedhistory" runat="server" Text="Borrowed History" BorderStyle="None" CssClass="menubutton" OnClick="ButtonBorrowedhistory_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonBorrowers" runat="server" Text="Borrowers" BorderStyle="None" CssClass="menubutton" OnClick="ButtonBorrowers_Click" CausesValidation="false"/>

        </asp:Panel>

        <%-- Ito yung sa header na nasa taas --%>
        <header>
            <asp:Label ID="LabelTitle" runat="server" Text="Property Tracking System"></asp:Label>
            <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonLogout_Click" CausesValidation="false"/>
        </header>

        <%-- Yung ating Registration form label --%>

        <asp:Label ID="LabelRegistrationform" runat="server" Text="Registration Form"></asp:Label>

        <%-- Then yung sections nila since di naman gridview dito though sana gridview nalang noh? --%>
        <section id="SectionContent">
            <%-- Personal Information Label --%>
            <asp:Label ID="LabelPersonalInfo" runat="server" Text="Personal Information:"></asp:Label>

            <%-- Lastname Label and Textbox --%>
            <asp:Label ID="LabelLastname" runat="server" Text="Lastname*"></asp:Label>
            <asp:TextBox ID="TextBoxLastname" runat="server" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="lastnameValidator" runat="server" ErrorMessage="Required" EnableClientScript="false" ControlToValidate="TextBoxLastname"></asp:RequiredFieldValidator>

            <%-- Type of Client Label and Textbox --%>
            <asp:Label ID="LabelClienttype" runat="server" Text="Type of Client*"></asp:Label>
            <asp:TextBox ID="TextBoxClienttype" runat="server" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="clienttypeValidator" runat="server" ErrorMessage="Required" EnableClientScript="false" ControlToValidate="TextBoxClienttype"></asp:RequiredFieldValidator>

            <%-- ID Number Label and Textbox --%>
            <asp:Label ID="LabelId" runat="server" Text="ID No*"></asp:Label>
            <asp:TextBox ID="TextBoxId" runat="server" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="idValidator" runat="server" ErrorMessage="Required" EnableClientScript="false" ControlToValidate="TextBoxId"></asp:RequiredFieldValidator>

            <%-- Firstname Label and Textbox --%>
            <asp:Label ID="LabelFirstname" runat="server" Text="Firstname*"></asp:Label>
            <asp:TextBox ID="TextBoxFirstname" runat="server" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="firstnameValidator" runat="server" ErrorMessage="Required" EnableClientScript="false" ControlToValidate="TextBoxFirstname"></asp:RequiredFieldValidator>

            <%-- Department Label and Textbox --%>
            <asp:Label ID="LabelDepartment" runat="server" Text="Department*"></asp:Label>
            <asp:TextBox ID="TextBoxDepartment" runat="server" autocomplete="off"></asp:TextBox>

            <%-- Contact Number Label and Textbox --%>
            <asp:Label ID="LabelContactno" runat="server" Text="Contact Number*"></asp:Label>
            <asp:TextBox ID="TextBoxContactno" runat="server" autocomplete="off" TextMode="Phone"></asp:TextBox>
            <asp:RegularExpressionValidator ID="regexValidator" runat="server" ErrorMessage="Required" EnableClientScript="false" ControlToValidate="TextBoxContactno" ValidationExpression="[0-9]{11}"></asp:RegularExpressionValidator>

            <%-- Course / Section  Label and Textbox--%>
            <asp:Label ID="LabelCourse" runat="server" Text="Course / Section*"></asp:Label>
            <asp:TextBox ID="TextBoxCourse" runat="server" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="courseValidator" runat="server" ErrorMessage="Required" EnableClientScript="false" ControlToValidate="TextBoxCourse"></asp:RequiredFieldValidator>

            <%-- Gender --%>
            <asp:Label ID="LabelGender" runat="server" Text="Gender*"></asp:Label>
            <asp:DropDownList ID="DropDownListGender" runat="server">
                <asp:ListItem Value="none">--Select Gender--</asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="genderValidator" runat="server" ErrorMessage="Required" EnableClientScript="false" ControlToValidate="DropDownListGender" InitialValue="none"></asp:RequiredFieldValidator>

             <%-- Already Registered using hyperlink of asp --%>
            <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl="~/RequestItem.aspx" Text="Already Registered?"></asp:HyperLink>

            <%-- Register Button pag clinick ito magregister ng bagong user sa database--%>
            <asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click"/>

            <%-- Cancel Button pag clinick ito magclear nalang siguro lahat ng mga text na nasa ating mga textbox and dropdown list ano????? --%>
            <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="ButtonCancel_Click" />

        </section>


    </form>
</body>
</html>
