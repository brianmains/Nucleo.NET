<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NestedControls02.ascx.cs" Inherits="Nucleo.Demos.MvpSamples.DataSource.NestedControls02" %>
<%@ Register TagPrefix="sc" Namespace="Nucleo.Web.Mvp.DataSourceControls" Assembly="Nucleo.Mvp.WebForms" %>

<asp:GridView ID="gvw" runat="server" DataSourceID="vds" />
<sc:ViewDataSource ID="vds" runat="server" DataObjectTypeName="Nucleo.Demos.MvpSamples.DataSource.TestClass,Demos.WebForms"
	SelectMethod="GetAll" />