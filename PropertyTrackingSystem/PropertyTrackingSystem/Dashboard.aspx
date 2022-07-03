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
            <asp:Button ID="ButtonReports" runat="server" Text="Reports" BorderStyle="None" CssClass="menubutton" OnClick="ButtonReports_Click" CausesValidation="false"/>

        </asp:Panel>
        <%-- Ito yung sa header na nasa taas --%>
        <header>
            <asp:Label ID="LabelTitle" runat="server" Text="Property Tracking System"></asp:Label>
        </header>

        <asp:Label ID="LabelWelcome" runat="server" Text="Welcome Home"></asp:Label>

        <asp:Panel ID="PanelItem" runat="server">
            <asp:Label ID="LabelTotalItem" runat="server" Text="Total Item / Tool"></asp:Label>
            <asp:Label ID="LabelNumItems" runat="server" Text="0"></asp:Label>
            <asp:Image ID="Image1" ImageUrl="~/Image/1.png" runat="server" />
        </asp:Panel>

        <asp:Panel ID="PanelBorrowedItem" runat="server">
            <asp:Label ID="LabelTotalBorrowedItem" runat="server" Text="Total Borrowed Item"></asp:Label>
            <asp:Label ID="LabelNumBorrowedItem" runat="server" Text="11"></asp:Label>
            <asp:Image ID="Image2" ImageUrl="~/Image/2.png" runat="server" />
        </asp:Panel>

        <asp:Panel ID="PanelReturnedItem" runat="server">
            <asp:Label ID="LabelTotalReturned" runat="server" Text="Total Returned Item"></asp:Label>
            <asp:Label ID="LabelNumReturned" runat="server" Text="22"></asp:Label>
            <asp:Image ID="Image3" ImageUrl="~/Image/3.png" runat="server" />
        </asp:Panel>

        <asp:Panel ID="PanelBorrower" runat="server">
            <asp:Label ID="LabelTotalBorrower" runat="server" Text="Total Borrower"></asp:Label>
            <asp:Label ID="LabelNumBorrower" runat="server" Text="48"></asp:Label>
            <asp:Image ID="Image4" ImageUrl="~/Image/4.png" runat="server" />
        </asp:Panel>
    </form>
</body>
</html>
