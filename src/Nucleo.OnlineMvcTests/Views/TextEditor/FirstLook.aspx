<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Text Editor First Look
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
	<%= Html.NucleoControls().TextEditor().RenderCss() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<p>
		<%
			Html.NucleoControls().TextEditor().Name("First")
				.CurrentState(Nucleo.Web.EditorControls.EditorCurrentState.Error)
				.Text("Initial Text")
				.Render();
		%>
	</p>
	<p>
		<%
			Html.NucleoControls().TextEditor().Name("Second")
				.CurrentState(Nucleo.Web.EditorControls.EditorCurrentState.Error)
				.Text("Initial Text")
				.ReadOnly(true)
				.Render();
		%>
	</p>
	
	<p>
		<textarea id="TraceConsole" rows="20" cols="30"></textarea>
	</p>

</asp:Content>