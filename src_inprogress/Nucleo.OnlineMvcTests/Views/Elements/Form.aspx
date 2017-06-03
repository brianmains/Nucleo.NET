<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Form
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<xmp>
		<%= Html.NucleoElements().BeginForm().Render() %>
	
		<%= Html.NucleoElements().EndForm() %>
	
		<%= Html.NucleoElements().BeginForm().Action("FirstLook", "Button", null).Render() %>
	
		<%= Html.NucleoElements().EndForm() %>

		<%= Html.NucleoElements().BeginForm().Form((f) =>
			{
				f.ActionName = "FirstLook";
				f.ControllerName = "Button";

				f.RouteValues.Add("Name", "Test");
			}).Render() %>

		<%= Html.NucleoElements().EndForm() %>
	</xmp>

</asp:Content>
