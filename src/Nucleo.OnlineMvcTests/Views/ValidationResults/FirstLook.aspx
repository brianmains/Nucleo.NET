<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	FirstLook
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
	<%= Html.NucleoControls().ValidationResults().RenderCss() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%
    	    	
		Html.NucleoControls().ValidationResults().Name("valResults").HeaderMessage("These are the following messages").Render();
		
    %>
    
    
    <br /><br />
	
	
	Name:
	<%= Html.TextBox("txtName") %>
	<br />
	
	Description:
	<%= Html.TextArea("txtDescription", "", 3, 30, null) %>
	<br />
	
	Validation type:
	<%= Html.DropDownList("ddlValidationType", new SelectListItem[]
		{
			new SelectListItem { Text = "Error", Value = "Error" },
			new SelectListItem { Text = "Warning", Value = "Warning" },
			new SelectListItem { Text = "Information", Value = "Information" }
		}) %>
	
	<input type="button" onclick="addItem();return false;" value="Add" />
	
	<script type="text/javascript">
		function addItem() {
			var name = $get("txtName").value;
			var description = $get("txtDescription").value;
			
			var dropDown = $get("ddlValidationType");
			var validationType = dropDown.options[dropDown.selectedIndex].value;

			var validator = $find("valResults")
			validator.addItem({ name: name, description: description, validationType: validationType });

			validator.refreshUI();
		}
	</script>

</asp:Content>
