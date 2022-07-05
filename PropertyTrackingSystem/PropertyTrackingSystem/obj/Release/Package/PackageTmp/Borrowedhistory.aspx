<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Borrowedhistory.aspx.cs" Inherits="PropertyTrackingSystem.Borrowedhistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Property Tracking System</title>
    <link rel = "stylesheet" type = "text/css" href = "Borrowedhistorystyle.css">
</head>
<body>
    <form id="form1" runat="server">
    <%-- Ito naman yung sa navigation sa left side gagamit ako ng unordered list ng html --%>
        <asp:Panel ID="navigation" runat="server">
            <asp:Button ID="ButtonDashboard" runat="server" Text="Dashboard" BorderStyle="None" CssClass="menubutton" OnClick="ButtonDashboard_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonRequestitem" runat="server" Text="Request Item" BorderStyle="None" CssClass="menubutton" OnClick="ButtonRequestitem_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonItemstools" runat="server" Text="Items / Tools" BorderStyle="None" CssClass="menubutton" OnClick="ButtonItemstools_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonBorrowedhistory" runat="server" Text="Borrowed History" BorderStyle="None" CssClass="menubutton" OnClick="ButtonBorrowedhistory_Click" CausesValidation="false" />
            <asp:Button ID="ButtonBorrowers" runat="server" Text="Borrowers" BorderStyle="None" CssClass="menubutton" OnClick="ButtonBorrowers_Click" CausesValidation="false"/>

        </asp:Panel>
        <%-- Ito yung sa header na nasa taas --%>
        <header>
            <asp:Label ID="LabelTitle" runat="server" Text="Property Tracking System"></asp:Label>
            <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonLogout_Click" CausesValidation="false"/>
        </header>

        <%-- Recent Transactions Label --%>
        <asp:Label ID="LabelRecenttransactions" runat="server" Text="Recent Transactions"></asp:Label>

        <%-- Search Transaction No Label and Textbox--%>
        <asp:Label ID="LabelSearch" runat="server" Text="Search Trans No"></asp:Label>
        <asp:TextBox ID="TextBoxSearch" runat="server" OnTextChanged="TextBoxSearch_TextChanged" AutoPostBack="True" autocomplete="off"></asp:TextBox>

        <%-- Next is yung gridview na nasa loob ng div container kasi di ko magitna ang gridview pag walang div container --%>

        <div id="tablecontainer">
            <%-- Mga columns na need natin sa ating gridview na similar sa ating database --%>
            <asp:GridView 
                ID="GridViewBorrowHistory" 
                runat="server" 
                AutoGenerateColumns="false"
                Height="27px"
                DataKeyNames="transno"
                ShowHeaderWhenEmpty="true" 
                OnRowEditing="GridViewBorrowHistory_RowEditing"
                OnRowCancelingEdit="GridViewBorrowHistory_RowCancelingEdit"
                OnRowUpdating="GridViewBorrowHistory_RowUpdating"
                OnRowDeleting="GridViewBorrowHistory_RowDeleting"
                >
                <Columns>
                <%-- Transaction Number boundfield--%>
                    <asp:BoundField DataField="transno" HeaderText="Transaction No"/>
                    

                <%-- Borrower ID boundfield--%>
                    <asp:BoundField DataField="borrowerid" HeaderText="Borrower ID"/>
                   

                <%-- Item Borrowed boundfield--%>
                    <asp:BoundField DataField="itemborrowed" HeaderText="Item Borrowed"/>
                   

                <%-- Quantity boundfield --%>
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                   

                <%-- Date Borrowed boundfield--%>
                    <asp:BoundField DataField="date_borrowed" HeaderText="Date Borrowed"/>
                  

                <%-- Date Return boundfield--%>
                    <asp:BoundField DataField="date_return" HeaderText="Expected Return"/>
                   

                <%-- Returned? dropdown item template field--%>
                    <asp:TemplateField HeaderText="Returned">
                        <ItemTemplate>
                            <asp:Label ID="lblreturn" runat="server" Text='<%#Eval("is_returned") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownReturn" runat="server">
                                <asp:ListItem Value="false">false</asp:ListItem>
                                <asp:ListItem Value="true">true</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>

                <%-- Template field para sa ating mga image button for edit item template --%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Image/update.png" CommandName="Edit" ToolTip="Edit" runat="server"/>
                            <asp:ImageButton ImageUrl="~/Image/delete.png" CommandName="Delete" ToolTip="Delete" runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Image/save.png" CommandName="Update" ToolTip="Update" runat="server"/>
                            <asp:ImageButton ImageUrl="~/Image/close.png" CommandName="Cancel" ToolTip="Cancel" runat="server"/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
