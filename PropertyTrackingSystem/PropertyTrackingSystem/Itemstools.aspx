<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Itemstools.aspx.cs" Inherits="PropertyTrackingSystem.Itemstools" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Property Tracking System</title>
    <link rel = "stylesheet" type = "text/css" href = "itemstoolsstyle.css">
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

         <%-- Yung parang title dun --%>
         <asp:Label ID="LabelNewitem" runat="server" Text="New Item"></asp:Label>

         <%-- Panghawak sa mga components na need natin --%>
         <section id ="Sectioncontent">
             <%-- Item information label component --%>
             <asp:Label ID="LabelIteminfo" runat="server" Text="Item Information:"></asp:Label>

             <%-- Item name label and textbox component --%>
             <asp:Label ID="LabelItemname" runat="server" Text="Item Name"></asp:Label>
             <asp:TextBox ID="TextBoxItemname" runat="server"></asp:TextBox>

             <%-- Brand name label and textbox component --%>
             <asp:Label ID="LabelBrandname" runat="server" Text="Brand Name"></asp:Label>
             <asp:TextBox ID="TextBoxBrandname" runat="server"></asp:TextBox>

             <%-- Department label and textbox component --%>
             <asp:Label ID="LabelDepartment" runat="server" Text="Department"></asp:Label>
             <asp:TextBox ID="TextBoxDepartment" runat="server"></asp:TextBox>

             <%-- Manufacturer label and textbox component --%>
             <asp:Label ID="LabelManufacturer" runat="server" Text="Manufacturer"></asp:Label>
             <asp:TextBox ID="TextBoxManufacturer" runat="server"></asp:TextBox>

             <%-- Quantity label and dropdown list component --%>
             <asp:Label ID="LabelQuantity" runat="server" Text="Quantity*"></asp:Label>
             <asp:DropDownList ID="DropDownListQuantity" runat="server"></asp:DropDownList>
             
             <%-- Item code label and textbox component --%>
             <asp:Label ID="LabelItemcode" runat="server" Text="Item Code"></asp:Label>
             <asp:TextBox ID="TextBoxItemcode" runat="server"></asp:TextBox>

             <%-- Purchase date label and textbox date component --%>
             <asp:Label ID="LabelPurchasedate" runat="server" Text="Purchase Date"></asp:Label>
             <asp:TextBox ID="TextBoxPurchasedate" runat="server" TextMode ="Date"></asp:TextBox>

             <%-- Item cost label and textbox component --%>
             <asp:Label ID="LabelItemcost" runat="server" Text="Item Cost"></asp:Label>
             <asp:TextBox ID="TextBoxItemcost" runat="server"></asp:TextBox>

             <%-- Add item button component --%>
             <asp:Button ID="ButtonAdditem" runat="server" Text="Add Item" />

             <%-- Cancel button component --%>
             <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" />

         </section>
    </form>
</body>
</html>
