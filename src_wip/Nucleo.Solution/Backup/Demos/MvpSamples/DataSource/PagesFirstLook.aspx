<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="PagesFirstLook.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.DataSource.PagesFirstLook" %>
<%@ Register TagPrefix="sc" Namespace="Nucleo.Web.Mvp.DataSourceControls" Assembly="Nucleo.Mvp.WebForms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<asp:GridView ID="gvwResults" runat="server" DataSourceID="vds" AutoGenerateColumns="false">
		<Columns>
			<asp:BoundField HeaderText="Key" DataField="Key" />
			<asp:BoundField HeaderText="Name" DataField="Name" />
		</Columns>
	</asp:GridView>

	<sc:ViewDataSource ID="vds" runat="server" SelectMethod="GetData"
		TypeName="System.Object" />

</asp:Content>
