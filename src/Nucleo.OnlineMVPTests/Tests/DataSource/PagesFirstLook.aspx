<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagesFirstLook.aspx.cs" Inherits="Nucleo.Tests.DataSource.PagesFirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<asp:GridView ID="gvwResults" runat="server" DataSourceID="vds" AutoGenerateColumns="false">
		<Columns>
			<asp:BoundField HeaderText="Key" DataField="Key" />
			<asp:BoundField HeaderText="Name" DataField="Name" />
		</Columns>
	</asp:GridView>

	<n:ViewDataSource ID="vds" runat="server" SelectMethod="GetData"
		TypeName="System.Object" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
