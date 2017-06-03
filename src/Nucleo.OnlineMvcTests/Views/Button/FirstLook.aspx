<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Nucleo.Web.Mvc" %>
<%@ Import Namespace="Nucleo.Web.Mvc.ButtonControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	FirstLook
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<h1>Standard Submit Button</h1>
	<% Html.BeginForm(); %>
		<% Html.NucleoControls().Button().Name("b1").UseButton().UseSubmitBehavior(true)
			.Text("My Submit Button").Render(); %>
	<% Html.EndForm(); %>

	<h1>Client Button</h1>

    <% Html.NucleoControls().Button().Name("Test").UseButton().UseSubmitBehavior(false)
		   .Text("My Test Button").DisablingOptions(true, 3000, true).Render(); %>
   
</asp:Content>
