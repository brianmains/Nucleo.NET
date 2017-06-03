<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="SampleQueries.aspx.cs" Inherits="Nucleo.Demos.LinqToSql.SampleQueries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<asp:GridView ID="gvwProducts" runat="server" AutoGenerateColumns="false" DataKeyNames="ProductID"
		AllowPaging="true" PageSize="20" OnPageIndexChanging="gvwProducts_PageIndexChanging">
		<Columns>
			<asp:BoundField HeaderText="Product" DataField="Name" />
			<asp:BoundField HeaderText="#" DataField="ProductNumber" />
			<asp:BoundField HeaderText="Color" DataField="Color" />
		</Columns>
	</asp:GridView>

</asp:Content>
