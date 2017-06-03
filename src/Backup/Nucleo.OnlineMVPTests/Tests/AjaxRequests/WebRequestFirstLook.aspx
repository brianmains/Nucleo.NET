<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebRequestFirstLook.aspx.cs" Inherits="Nucleo.Tests.AjaxRequests.WebRequestFirstLook" %>
<%@ Register TagPrefix="uc" TagName="AjaxCallback" Src="~/Tests/AjaxRequests/AjaxCallback.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<uc:AjaxCallback id="ucAjax" runat="server" />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
	<n:ScriptSection ID="ssAjax" runat="server" RegionName="Presenter" />
</asp:Content>
