<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Borrower.aspx.cs" Inherits="PropertyTrackingSystem.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Property Tracking System</title>
    <link rel = "stylesheet" type = "text/css" href = "Borrowerstyle.css">
    <script type="text/javascript" >
        function preventBack() {
            window.history.forward();
        }
        setTimeout("preventBack()", 0);
        window.onunload=function(){null};
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <%-- Ito naman yung sa navigation sa left side gagamit ako ng unordered list ng html --%>
        <asp:Panel ID="navigation" runat="server">
            <asp:Button ID="ButtonDashboard" runat="server" Text="Dashboard" BorderStyle="None" CssClass="menubutton" OnClick="ButtonDashboard_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonRequestitem" runat="server" Text="Request Item" BorderStyle="None" CssClass="menubutton" OnClick="ButtonRequestitem_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonItemstools" runat="server" Text="Items / Tools" BorderStyle="None" CssClass="menubutton" OnClick="ButtonItemstools_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonBorrowedhistory" runat="server" Text="Borrowed History" BorderStyle="None" CssClass="menubutton" OnClick="ButtonBorrowedhistory_Click" CausesValidation="false"/>
            <asp:Button ID="ButtonBorrowers" runat="server" Text="Borrowers" BorderStyle="None" CssClass="menubutton" OnClick="ButtonBorrowers_Click" CausesValidation="false"/>

        </asp:Panel>
        <%-- Ito yung sa header na nasa taas --%>
        <header>
            <asp:Label ID="LabelTitle" runat="server" Text="Property Tracking System"></asp:Label>
            <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonLogout_Click" CausesValidation="false"/>
        </header>

         <%-- Yung Items info na label sa taas --%>
        <asp:Label ID="LabelBorrowerinfo" runat="server" Text="Borrower Info"></asp:Label>

         <%-- Yung Label and search and textbox component --%>
        <asp:Label ID="LabelSearch" runat="server" Text="Search ID"></asp:Label>
        <asp:TextBox ID="TextBoxSearch" runat="server" AutoPostBack="True" autocomplete="off" OnTextChanged="TextBoxSearch_TextChanged"></asp:TextBox>

        <%-- div container na may gridview --%>
        <div id="tablecontainer">
            <%-- Gridview table kung san nasa loob yung mga borrowers info natin hahahahahhahahah--%>
            <asp:GridView 
                ID="GridViewBorrowers" 
                runat="server" 
                Height="27px"
                AutoGenerateColumns="false"
                DataKeyNames="id"
                ShowHeaderWhenEmpty="true"
                OnRowEditing="GridViewBorrowers_RowEditing"
                OnRowCancelingEdit="GridViewBorrowers_RowCancelingEdit"
                OnRowUpdating="GridViewBorrowers_RowUpdating"
                OnRowDeleting="GridViewBorrowers_RowDeleting"
                >
                <Columns>
                    <%-- id Boundfield component --%>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("id") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtid" runat="server" Text='<%#Eval("id") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <%-- lastname boundfield component --%>
                   <asp:TemplateField HeaderText="Lastname">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("lastname") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtlastname" runat="server" Text='<%#Eval("lastname") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <%-- firstname boundfield component --%>
                    <asp:TemplateField HeaderText="Firstname">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("firstname") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtfirstname" runat="server" Text='<%#Eval("firstname") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <%-- department boundfield component --%>
                    <asp:TemplateField HeaderText="Department">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("department") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtdepartment" runat="server" Text='<%#Eval("department") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <%-- contactno boundfield component --%>
                    <asp:TemplateField HeaderText="Contact">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("contactno") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtcontactno" runat="server" Text='<%#Eval("contactno") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <%-- Course / Section boundfield component --%>
                   <asp:TemplateField HeaderText="Course & Section">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("coursec") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtcoursec" runat="server" Text='<%#Eval("coursec") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <%-- gender boundfield component --%>
                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("gender") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtgender" runat="server" Text='<%#Eval("gender") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <%-- ClientType boundfield component --%>
                    <asp:TemplateField HeaderText="Type of Client">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("clienttype") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtclienttype" runat="server" Text='<%#Eval("clienttype") %>'></asp:TextBox>
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
