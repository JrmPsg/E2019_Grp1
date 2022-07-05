<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PropertyTrackingSystem.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Property Tracking System</title>
    <link rel = "stylesheet" type = "text/css" href = "dashboardstyle.css"/>
</head>
<body>
    <form id="form1" runat="server">
      <%-- Ito naman yung sa navigation sa left side gagamit ako ng unordered list ng html --%>
        <asp:Panel ID="navigation" runat="server">
            <asp:Button ID="ButtonDashboard" runat="server" Text="Dashboard" BorderStyle="None" CssClass="menubutton" OnClick="ButtonDashboard_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonRequestitem" runat="server" Text="Request Item" BorderStyle="None" CssClass="menubutton" OnClick="ButtonRequestitem_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonItemstools" runat="server" Text="Items / Tools" BorderStyle="None" CssClass="menubutton" OnClick="ButtonItemstools_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonBorrowedhistory" runat="server" Text="Borrowed History" BorderStyle="None" CssClass="menubutton" OnClick="ButtonBorrowedhistory_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonBorrowers" runat="server" Text="Borrowers" BorderStyle="None" CssClass="menubutton" OnClick="ButtonBorrowers_Click"  CausesValidation="false"/>

        </asp:Panel>
        <%-- Ito yung sa header na nasa taas --%>
        <header>
            <asp:Label ID="LabelTitle" runat="server" Text="Property Tracking System"></asp:Label>
            <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonLogout_Click" CausesValidation="false"/>
        </header>

        <asp:Label ID="LabelWelcome" runat="server" Text="Welcome"></asp:Label>

        <section id="PanelItem">
            <asp:Label ID="LabelTotalItem" runat="server" Text="Total Item / Tool"></asp:Label>
            <asp:Label ID="LabelNumItems" runat="server" Text="0"></asp:Label>
            <asp:Image ID="Image1" ImageUrl="~/Image/1.png" runat="server" />
        </section>

        <section id="PanelBorrowedItem">
            <asp:Label ID="LabelTotalBorrowedItem" runat="server" Text="Total Borrowed Item"></asp:Label>
            <asp:Label ID="LabelNumBorrowedItem" runat="server" Text="0"></asp:Label>
            <asp:Image ID="Image2" ImageUrl="~/Image/2.png" runat="server" />
        </section>

        <section id="PanelReturnedItem">
            <asp:Label ID="LabelTotalReturned" runat="server" Text="Total Returned Item"></asp:Label>
            <asp:Label ID="LabelNumReturned" runat="server" Text="0"></asp:Label>
            <asp:Image ID="Image3" ImageUrl="~/Image/3.png" runat="server" />
        </section>

        <section id="PanelBorrower">
            <asp:Label ID="LabelTotalBorrower" runat="server" Text="Total Borrower"></asp:Label>
            <asp:Label ID="LabelNumBorrower" runat="server" Text="0"></asp:Label>
            <asp:Image ID="Image4" ImageUrl="~/Image/4.png" runat="server" />
        </section>
    </form>
</body>
</html>
