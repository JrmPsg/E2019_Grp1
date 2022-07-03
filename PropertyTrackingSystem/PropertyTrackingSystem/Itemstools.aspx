<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Itemstools.aspx.cs" Inherits="PropertyTrackingSystem.Itemstoolsmain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Property Tracking System</title>
     <link rel = "stylesheet" type = "text/css" href = "Itemstoolstyle.css"/>
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
        <%-- Yung Items info na label sa taas --%>
        <asp:Label ID="LabelItemsinfo" runat="server" Text="Items Info"></asp:Label>

        <%-- Yung Label and search and textbox component --%>
        <asp:Label ID="LabelSearch" runat="server" Text="Search Item Name"></asp:Label>
        <asp:TextBox ID="TextBoxSearch" runat="server" OnTextChanged="TextBoxSearch_TextChanged" AutoPostBack="True" autocomplete="off"></asp:TextBox>

       
        <%-- Table na need natin hayyyy buhayyyyyyyyyyyyyyyyy --%>
        <div id ="tablecontainer">
           
            <asp:GridView ID="GridViewTables" 
                runat="server" 
                CssClass ="gridview" 
                AutoGenerateColumns ="False" 
                Height="27px" 
                DataKeyNames="No"
                ShowFooter="true"
                ShowHeaderWhenEmpty="true" 
                OnRowCommand="GridViewTables_RowCommand"
                OnRowEditing="GridViewTables_RowEditing"
                OnRowCancelingEdit="GridViewTables_RowCancelingEdit"
                OnRowUpdating="GridViewTables_RowUpdating"
                OnRowDeleting="GridViewTables_RowDeleting"
                >

                <%-- Yung mga columns na need natin sa table na similar sa database natin --%>
                <Columns>
                    <%-- Item Code --%>
                    <asp:TemplateField HeaderText="Item Code">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("itemcode") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtItemCode" runat="server" Text='<%#Eval("itemcode") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                             <asp:TextBox ID="txtItemCodeFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <%-- Item Name --%>
                    <asp:TemplateField HeaderText="Item Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("itemname") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtItemName" runat="server" Text='<%#Eval("itemname") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                             <asp:TextBox ID="txtItemNameFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <%-- Quantity --%> 
                   <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("quantity") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" Text='<%#Eval("quantity") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                             <asp:TextBox ID="txtQuantityFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <%-- Department --%>
                    <asp:TemplateField HeaderText="Department">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("department") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDepartment" runat="server" Text='<%#Eval("department") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                             <asp:TextBox ID="txtDepartmentFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <%-- Yung mga buttons --%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Image/update.png" CommandName="Edit" ToolTip="Edit" runat="server"/>
                            <asp:ImageButton ImageUrl="~/Image/delete.png" CommandName="Delete" ToolTip="Delete" runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Image/save.png" CommandName="Update" ToolTip="Update" runat="server"/>
                            <asp:ImageButton ImageUrl="~/Image/close.png" CommandName="Cancel" ToolTip="Cancel" runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Image/add.png" CommandName="Addnew" ToolTip="Add" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <%-- Error or success messages dito ko nalang lagay para di hassle hayyy --%>
            <asp:Label ID="LabelError" runat="server" ForeColor="#ff0000"></asp:Label>
            <asp:Label ID="LabelSuccess" runat="server" ForeColor="#009900"></asp:Label>
        </div>
    </form>
</body>
</html>
