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
    </form>
</body>
</html>
