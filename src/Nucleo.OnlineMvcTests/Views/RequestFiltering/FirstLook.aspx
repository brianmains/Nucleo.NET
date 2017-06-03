<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detecting Requests
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<div>
		<a href="javascript:ajaxRequest();">Invoking an AJAX Request</a>
	</div>
	<div>
		<%= Html.ActionLink("Invoking an AJAX Request in Error", "AjaxRequest") %>
	</div>
	<div>
		<%= Html.ActionLink("Invoking a Standard Request", "StandardRequest") %>
	</div>
	<div>
		<a href="javascript:standardRequest();">Invoking a Standard Request in Error</a>
	</div>

	<script type="text/javascript">
		function ajaxRequest() {
			$.get('<%= Url.Action("AjaxRequest") %>', function (results) {
				alert(results);
			});
		}

		function standardRequest() {
			$.get('<%= Url.Action("StandardRequest") %>', function (results) {
				alert(results);
			});
		}
	</script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
