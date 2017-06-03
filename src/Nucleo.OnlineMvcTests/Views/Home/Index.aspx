<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
	
	<p>
		<%= Html.ActionLink("Request Filtering", "FirstLook", "RequestFiltering") %>
	</p>

	<p>
		<%= Html.ActionLink("Binding Panel First Look", "FirstLook", "BindingPanel") %>
	</p>
	
	<p>
		<%= Html.ActionLink("Button First Look", "FirstLook", "Button") %>
	</p>
	
	<p>
		<%= Html.ActionLink("Check First Look", "FirstLook", "Check") %>
	</p>
	
	<p>
		<%= Html.ActionLink("Configured Actions First Look", "Test", "ConfiguredAction") %>
	</p>
	
	<p>
		<%= Html.ActionLink("Drop Down First Look", "FirstLook", "DropDown") %>
	</p>
	
	<p>
		<%= Html.ActionLink("Link First Look", "FirstLook", "Link") %>
	</p>
	
	<p>
		<%= Html.ActionLink("Nucleo Actions First Look", "FirstLook", "NucleoActions") %>
	</p>
	
	<p>
		<%= Html.ActionLink("Pageable List First Look", "FirstLook", "PageableList") %>
	</p>
	
	<p>
		<%= Html.ActionLink("Text Editor First Look", "FirstLook", "TextEditor") %>
	</p>
	
	<p>
		<%= Html.ActionLink("Validation Results First Look", "FirstLook", "ValidationResults") %>
	</p>
	
	
	<h1>Elements</h1>
	
	<p>
		<%= Html.ActionLink("Html Form Elements", "Form", "Elements") %>
	</p>
    
</asp:Content>
