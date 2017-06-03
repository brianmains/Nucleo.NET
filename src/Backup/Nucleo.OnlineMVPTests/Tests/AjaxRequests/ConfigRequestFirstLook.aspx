<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConfigRequestFirstLook.aspx.cs" Inherits="Nucleo.Tests.AjaxRequests.ConfigRequestFirstLook" %>
<%@ Register TagPrefix="uc" TagName="ConfigAjaxCallback" Src="~/Tests/AjaxRequests/ConfigAjaxCallback.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<uc:ConfigAjaxCallback id="ucAjax" runat="server" />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
	<n:ScriptSection ID="ssAjax" runat="server" RegionName="Presenter" />
</asp:Content>
