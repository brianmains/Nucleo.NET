<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Link First Look
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%
		Html.NucleoControls().Link().Name("Test1").ClickAction(Nucleo.Web.Controls.LinkClickAction.Redirect)
			.Navigation("http://www.google.com").Content("Link to Google").Render();
    %>
    
    <%
		Html.NucleoControls().Link().Name("Test2").ClickAction(Nucleo.Web.Controls.LinkClickAction.Redirect)
			.Navigation("http://www.google.com").Target(Nucleo.Web.Controls.LinkTargetOptions.NewWindow)
			.Content("Link to Google in New Window").Render();
    %>
    
    <%
		Html.NucleoControls().Link().Name("Test3").ClickAction(Nucleo.Web.Controls.LinkClickAction.FireEvent)
			.Content("Firing Event").RenderingMode(RenderMode.ClientOnly).Render();
    %>
    
	<textarea id="TraceConsole" rows="20" cols="30"></textarea>
    
    <script type="text/javascript">
    	function pageLoad() {
    		var link = $find("Test3");
    		
    		link.add_clicked(function() {
    			n$.Debug.write("Link has been clicked");
    		});
    	}
    </script>

</asp:Content>
