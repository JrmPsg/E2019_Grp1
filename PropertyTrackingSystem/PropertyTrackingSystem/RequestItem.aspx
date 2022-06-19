<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestItem.aspx.cs" Inherits="PropertyTrackingSystem.RequestItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Property Tracking System</title>
    <link rel = "stylesheet" type = "text/css" href = "requestitemstyle.css">
</head>
<body>
    <form id="form1" runat="server">
    <%-- Ito naman yung sa navigation sa left side gagamit ako ng unordered list ng html --%>
        <asp:Panel ID="navigation" runat="server">
            <asp:Button ID="ButtonDashboard" runat="server" Text="Dashboard" BorderStyle="None" CssClass="menubutton" OnClick="ButtonDashboard_Click" />
            <asp:Button ID="ButtonRequestitem" runat="server" Text="Request Item" BorderStyle="None" CssClass="menubutton" OnClick="ButtonRequestitem_Click" />
            <asp:Button ID="ButtonItemstools" runat="server" Text="Items / Tools" BorderStyle="None" CssClass="menubutton" OnClick="ButtonItemstools_Click" />
            <asp:Button ID="ButtonBorrowedhistory" runat="server" Text="Borrowed History" BorderStyle="None" CssClass="menubutton" OnClick="ButtonBorrowedhistory_Click" />
            <asp:Button ID="ButtonReports" runat="server" Text="Reports" BorderStyle="None" CssClass="menubutton" OnClick="ButtonReports_Click" />

        </asp:Panel>

        <%-- Ito yung sa header na nasa taas --%>
        <header>
            <asp:Label ID="LabelTitle" runat="server" Text="Property Tracking System"></asp:Label>
        </header>
        
            <asp:Label ID="LabelRequestform" runat="server" Text="Request Form"></asp:Label>

            <%-- Dito sa section content ko ipapasok yung mga need natin dun sa form na yun similar ang section sa div pero mas gusto ko div makabago ehh--%>
            <section id ="SectionContent">
                <%-- Yung dalawang label sa left and side na magkabilaan --%>
                <asp:Label ID="LabelBorrowerinfo" runat="server" Text="Borrower Information:"></asp:Label>
                <asp:Label ID="LabelIteminfo" runat="server" Text="Item Information:"></asp:Label>

                <%-- Lastname label and textbox component --%>
                <asp:Label ID="LabelLastname" runat="server" Text="Lastname"></asp:Label>
                <asp:TextBox ID="TextBoxLastname" runat="server"></asp:TextBox>

                <%-- Requested Item label and drop down list component --%>
                <asp:Label ID="LabelRequesteditem" runat="server" Text="Requested Item"></asp:Label>
                <asp:DropDownList ID="DropDownListRequesteditem" runat="server"></asp:DropDownList>

                <%-- Firstname label and textbox component --%>
                <asp:Label ID="LabelFirstname" runat="server" Text="Firstname"></asp:Label>
                <asp:TextBox ID="TextBoxFirstname" runat="server"></asp:TextBox>

                <%-- Item code label and textbox component --%>
                <asp:Label ID="LabelItemcode" runat="server" Text="Item Code"></asp:Label>
                <asp:TextBox ID="TextBoxItemcode" runat="server"></asp:TextBox>

                <%-- Quantity label and dropdown component --%>
                <asp:Label ID="LabelQuantity" runat="server" Text="Quantity*"></asp:Label>
                <asp:DropDownList ID="DropDownListQuantity" runat="server"></asp:DropDownList>
                
                <%-- Contact No. label and textbox component --%>
                <asp:Label ID="LabelContactno" runat="server" Text="Contact No."></asp:Label>
                <asp:TextBox ID="TextBoxContactno" runat="server"></asp:TextBox>

                <%-- Return Time label and calendar component --%>
                <asp:Label ID="LabelReturntime" runat="server" Text="Return Time"></asp:Label>
                <asp:TextBox ID="TextBoxReturntime" runat="server" TextMode ="DateTimeLocal"></asp:TextBox>

                <%-- Trans No. label and textbox component --%>
                <asp:Label ID="LabelTransno" runat="server" Text="Trans No."></asp:Label>
                <asp:TextBox ID="TextBoxTransno" runat="server"></asp:TextBox>

                <%-- Request Button component--%>
                <asp:Button ID="ButtonRequest" runat="server" Text="Request" />

                <%-- Cancel Button component --%>
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" />
            </section>
      
    </form>
</body>
</html>
