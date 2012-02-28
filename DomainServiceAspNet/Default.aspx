<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DomainServiceAspNet.Default" %>

<%@ Register Assembly="Microsoft.Web.DomainServices.WebControls" Namespace="Microsoft.Web.UI.WebControls"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:DomainDataSource ID="DomainDataSource1" runat="server" DomainServiceTypeName="DomainServiceAspNet.AdventureWorksDomainService"
            EnableDelete="True" EnableInsert="True" EnableUpdate="True" QueryName="GetProducts">
        </cc1:DomainDataSource>
    </div>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <cc1:DomainValidator ID="DomainValidator1" runat="server" ControlToValidate="GridView1" />

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" AutoGenerateEditButton="True" DataKeyNames="ProductID,ProductNumber,StandardCost,Size,Weight,ProductCategoryID,ProductModelID,SellStartDate,SellEndDate,DiscontinuedDate,ThumbNailPhotoFileName,rowguid"
        DataSourceID="DomainDataSource1">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Delete"
                        ForeColor="#333333" OnClientClick='return confirm("Are you sure you want to delete this row?");' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:TemplateField>
                <HeaderTemplate>
                    Color</HeaderTemplate>
                <ItemTemplate>
                    <%# Eval("Color") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="ColorID" runat="server" Text='<%# Bind("Color") %>' />
                    <cc1:DomainValidator ID="DomainValidator2" runat="server" DataField="Color" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    ListPrice</HeaderTemplate>
                <ItemTemplate>
                    <%# Eval("ListPrice")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="ListPriceID" runat="server" Text='<%# Bind("ListPrice") %>' />
                    <cc1:DomainValidator ID="DomainValidator3" runat="server" DataField="ListPrice" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
