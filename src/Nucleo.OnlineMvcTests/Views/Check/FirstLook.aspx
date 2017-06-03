<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Check First Look
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
	<%= Html.NucleoControls().Check().RenderCss() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<p>
		<%
			Html.NucleoControls().Check().Name("Test").Checked(true).AllowEmptyCheckState(true)
				.UseDefaultImageOptions().Content("Testing Check").Render();	
		%>
    </p>
    
    <p>
		<%
			Html.NucleoControls().Check().Name("DisabledTrue").Checked(true)
				.UseDefaultImageOptions().Disable()
				.Content("This should show the disabled true image").Render();
		%>
    </p>
    
    <p>
		<%
			Html.NucleoControls().Check().Name("DisabledFalse").Checked(false)
				.UseDefaultImageOptions().Disable()
				.Content("This should show the disabled false image").Render();
		%>
    </p>
    
    <p>
		<%
			Html.NucleoControls().Check().Name("DisabledEmpty").Checked(null)
				.UseDefaultImageOptions().Disable()
				.Content("This should show the disabled empty image").Render();
		%>
    </p>

</asp:Content>
