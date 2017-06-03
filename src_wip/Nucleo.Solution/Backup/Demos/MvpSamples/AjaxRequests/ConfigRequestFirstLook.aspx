<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="ConfigRequestFirstLook.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.AjaxRequests.ConfigRequestFirstLook" %>
<%@ Register TagPrefix="uc" TagName="ConfigAjaxCallback" Src="ConfigAjaxCallback.ascx" %>
<%@ Register TagPrefix="sc" Namespace="Nucleo.Web.Scripts" Assembly="Nucleo.Web.WebForms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<uc:ConfigAjaxCallback id="ucAjax" runat="server" />

	<sc:ScriptSection ID="ssAjax" runat="server" RegionName="Presenter" />

</asp:Content>
