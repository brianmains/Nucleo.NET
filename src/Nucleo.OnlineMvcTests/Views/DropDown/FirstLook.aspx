<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Nucleo.Web.DropDownControls" %>
<%@ Import Namespace="Nucleo.Web.Templates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Drop Down First Look
</asp:Content>

<asp:Content id="Content3" ContentPlaceHolderID="CssContent" runat="server">
	<%= Html.NucleoControls().DropDown().RenderCss() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	
    <%
		Html.NucleoControls().DropDown().Name("Test").Text("Test")
			.Content(() =>
    		{
				%>
					Here is my server temp.
				<%	
			}).Render();
	%>

</asp:Content>
