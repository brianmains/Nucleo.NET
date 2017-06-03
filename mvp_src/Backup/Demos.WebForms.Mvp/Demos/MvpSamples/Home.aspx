<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AreaHome.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Nucleo.Demos.Samples.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FrameworkDisplay" runat="server">

	<div>
		Nucleo Web Forms
	</div>
	<div>
		Samples
	</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FrameworkDescription" runat="server">

	This samples web site features Nucleo.NET controls, components, and frameworks samples
	to illustrate how the pieces actual work.  Not all samples are meant to work in a 
	multi-user fashion and can't be hosted.

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SiteMap" runat="server">

	<asp:Panel ID="pnlSitemap" runat="server">
		
	</asp:Panel>

</asp:Content>
