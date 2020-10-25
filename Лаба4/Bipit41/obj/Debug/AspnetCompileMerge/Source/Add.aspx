<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Bipit4.Add1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Menu ID="Menu1" runat="server" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" OnMenuItemClick="Menu1_MenuItemClick" StaticSubMenuIndent="10px" style="padding: 10px; height: 500px; width: 100px;">
            <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#B5C7DE" />
            <DynamicSelectedStyle BackColor="#507CD1" />
            <DynamicItemTemplate>
            <%# Eval("Text") %>
            </DynamicItemTemplate>
            <Items>
                <asp:MenuItem Text="Список" Value="Список"></asp:MenuItem>
                <asp:MenuItem Text="Новый" Value="Новый"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#507CD1" />
        </asp:Menu>
        <div style="height: 686px; width: 545px; margin-left: 150px; margin-top: -500px;">
            <asp:Label ID="Label1" runat="server" Text="Дата выдачи"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="Введите ФИО"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox3" ErrorMessage="RequiredFieldValidator">Заполните поле ФИО</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Название книги"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Название_книги" DataValueField="Название_книги">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Library00001ConnectionString %>" SelectCommand="SELECT [Название книги] AS Название_книги FROM [Книги]"></asp:SqlDataSource>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Дата возврата"></asp:Label>
            <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Добавить" />
        </div>
        <br />
    </form>
</body>
</html>
