<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

	<p>An Error Has Occured</p>
	
	<p>
		<% if (Model != null && Model is Exception) { %>
			<%= ((Exception)Model).ToString() %>
		<% } else { %>
			An error has occurred and it has been logged.
		<% } %>
	</p>

</asp:Content>
