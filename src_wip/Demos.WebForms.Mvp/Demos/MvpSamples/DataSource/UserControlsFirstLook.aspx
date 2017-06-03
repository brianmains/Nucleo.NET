<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="UserControlsFirstLook.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.DataSource.UserControlsFirstLook" %>
<%@ Register Src="ViewDataSourceSample.ascx" TagName="ViewDataSourceSample" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<uc:ViewDataSourceSample ID="uc" runat="server" />

</asp:Content>
