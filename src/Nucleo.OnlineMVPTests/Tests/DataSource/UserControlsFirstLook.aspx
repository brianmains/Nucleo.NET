<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserControlsFirstLook.aspx.cs" Inherits="Nucleo.Tests.DataSource.UserControlsFirstLook" %>
<%@ Register Src="~/Tests/DataSource/ViewDataSourceSample.ascx" TagName="ViewDataSourceSample" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<uc:ViewDataSourceSample ID="uc" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
