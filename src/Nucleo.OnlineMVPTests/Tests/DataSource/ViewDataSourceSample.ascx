<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewDataSourceSample.ascx.cs" Inherits="Nucleo.Tests.DataSource.ViewDataSourceSample" %>

<asp:GridView ID="gvwResults" runat="server" DataSourceID="vds" AutoGenerateColumns="false">
	<Columns>
		<asp:BoundField HeaderText="Key" DataField="Key" />
		<asp:BoundField HeaderText="Name" DataField="Name" />
	</Columns>
</asp:GridView>

<n:ViewDataSource ID="vds" runat="server" SelectMethod="GetData"
	TypeName="System.Object" />