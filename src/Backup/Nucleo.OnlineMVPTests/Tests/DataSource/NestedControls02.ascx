<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NestedControls02.ascx.cs" Inherits="Nucleo.Tests.DataSource.NestedControls02" %>


<asp:GridView ID="gvw" runat="server" DataSourceID="vds" />
<n:ViewDataSource ID="vds" runat="server" DataObjectTypeName="Nucleo.Tests.DataSource.TestClass,Nucleo.OnlineMVPTests"
	SelectMethod="GetAll" />