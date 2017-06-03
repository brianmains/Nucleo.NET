<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ValidationResultsFirstLook.aspx.cs" Inherits="Nucleo.Web.Validation.ValidationResultsFirstLook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	<n:ValidationManager ID="vm" runat="server" ClientIDMode="Static" />

	<n:ValidationResults id="valResults" runat="server" HeaderMessage="Errors occurred:" />
	
	<br /><br />
	
	
	Name: <asp:TextBox ID="txtName" runat="server" />
	<br />
	
	Description:
	<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" Columns="30" />
	<br />
	
	Validation type:
	<asp:DropDownList ID="ddlValidationType" runat="server">
		<asp:ListItem>Error</asp:ListItem>
		<asp:ListItem>Warning</asp:ListItem>
		<asp:ListItem>Information</asp:ListItem>
	</asp:DropDownList>
	
	<asp:Button ID="btnAdd" runat="server" Text="Add" OnClientClick="addItem();return false;"
		UseSubmitBehavior="false" />
	
	<script type="text/javascript">
		function addItem() {
			var name = $get("<%= txtName.ClientID %>").value;
			var description = $get("<%= txtDescription.ClientID %>").value;
			
			var dropDown = $get("<%= ddlValidationType.ClientID %>");
			var validationType = dropDown.options[dropDown.selectedIndex].value;

			var validator = $find("<%= valResults.ClientID %>");
			if (validationType == "Error")
				validator.addItem({ key: name, message: description, category: n$.CategoryDefinitions.get_error() });
			else if (validationType == "Warning")
				validator.addItem({ key: name, message: description, category: n$.CategoryDefinitions.get_warning() });
			else if (validationType == "Information")
				validator.addItem({ key: name, message: description, category: n$.CategoryDefinitions.get_information() });

			validator.refreshUI();
		}
	</script>

</asp:Content>
