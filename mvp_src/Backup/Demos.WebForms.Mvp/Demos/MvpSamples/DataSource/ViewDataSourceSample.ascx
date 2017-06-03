<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewDataSourceSample.ascx.cs" Inherits="Nucleo.Demos.MvpSamples.DataSource.ViewDataSourceSample" %>
<%@ Register TagPrefix="sc" Namespace="Nucleo.Web.Mvp.DataSourceControls" Assembly="Nucleo.Mvp.WebForms" %>

<asp:GridView ID="gvwResults" runat="server" DataSourceID="vds" AutoGenerateColumns="false">
	<Columns>
		<asp:BoundField HeaderText="Key" DataField="Key" />
		<asp:BoundField HeaderText="Name" DataField="Name" />
	</Columns>
</asp:GridView>

<sc:ViewDataSource ID="vds" runat="server" SelectMethod="GetData"
	TypeName="System.Object" />