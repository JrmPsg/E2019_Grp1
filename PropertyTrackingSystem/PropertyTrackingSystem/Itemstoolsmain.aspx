<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Itemstoolsmain.aspx.cs" Inherits="PropertyTrackingSystem.Itemstoolsmain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Property Tracking System</title>
     <link rel = "stylesheet" type = "text/css" href = "Itemstoolsmainstyle.css"/>
     <style type="text/css">
         .gridview {}
     </style>
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
        <%-- Yung Items info na label sa taas --%>
        <asp:Label ID="LabelItemsinfo" runat="server" Text="Items Info"></asp:Label>

        <%-- Yung Label and search and textbox component --%>
        <asp:Label ID="LabelSearch" runat="server" Text="Search Item"></asp:Label>
        <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>

        <%-- Table na need natin hayyyy buhayyyyyyyyyyyyyyyyy --%>
        <div id ="tablecontainer">
            <asp:GridView ID="GridViewTables" runat="server" CssClass ="gridview" AutoGenerateColumns ="false" Visible ="true" Height="27px" OnSelectedIndexChanged="GridViewTables_SelectedIndexChanged" Width="833px">
                <Columns>
                    <asp:BoundField HeaderText ="No." />
                    <asp:BoundField HeaderText ="Item Code" />
                    <asp:BoundField HeaderText ="Item Name" />
                    <asp:BoundField HeaderText ="Quantity" />
                    <asp:BoundField HeaderText ="Date Purchase" />
                    <asp:BoundField HeaderText ="Departments" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
