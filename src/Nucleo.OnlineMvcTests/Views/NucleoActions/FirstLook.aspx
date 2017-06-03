<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Nucleo.Models.NucleoActions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	First Look
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<p>
		First Partial Using Name:<br />
		<% Html.NucleoActions().RenderPartial("FirstPartial"); %>
	</p>
	<p>
		First Partial Using Name/Model:<br />
		<% Html.NucleoActions().RenderPartial("FirstPartial", "FirstPartialLookupTest"); %>
	</p>
	<p>
		Second Partial Using Name:<br />	
		<% Html.NucleoActions().RenderPartial("SecondPartial"); %>
	</p>
	<p>
		Third Partial Using Type:<br />
		<% Html.NucleoActions().RenderPartial<ThirdPartialViewModel>("ThirdPartial"); %>
	</p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
