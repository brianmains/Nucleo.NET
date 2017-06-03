<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="WebRequestFirstLook.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.AjaxRequests.WebRequestFirstLook" %>
<%@ Register TagPrefix="uc" TagName="AjaxCallback" Src="AjaxCallback.ascx" %>
<%@ Register TagPrefix="sc" Namespace="Nucleo.Web.Scripts" Assembly="Nucleo.Web.WebForms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<uc:AjaxCallback id="ucAjax" runat="server" />


	<sc:ScriptSection ID="ssAjax" runat="server" RegionName="Presenter" />

</asp:Content>
