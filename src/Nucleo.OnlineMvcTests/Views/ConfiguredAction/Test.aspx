<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Test
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<ul>
		<li>
			<%= Html.ConfiguredActionLink("ConfiguredIndex", "Configured Index test") %>
		</li>
		<li>
			<%= Html.ConfiguredActionLink("ConfiguredIndex", "Configured Index text with attributes", new { target = "_blank" }) %>
		</li>
		<li>
			<%= Html.ConfiguredActionLink("ConfiguredIndex", new RouteValueDictionary(new { id = 2 }), "Configured Index text with attributes", new { target = "_blank" })%>
		</li>
	</ul>
	
</asp:Content>
