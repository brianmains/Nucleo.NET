<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ValidatorsFirstLook.aspx.cs" Inherits="Nucleo.Web.Validation.ValidatorsFirstLook" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	<n:ValidationManager ID="vm" runat="server" ClientIDMode="Static" />

	<n:ValidationResults ID="vr" runat="server" HeaderMessage="The following validations occurred:" />

	<div>
		<h1>Required Validation</h1>

		<asp:TextBox ID="txt1" runat="server" />


		<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"
			UseSubmitBehavior="false" OnClientClick="return validate();" />
	</div>
	<div>
		<asp:Label ID="lblOutput" runat="server" EnableViewState="false" />
	</div>

	<script type="text/javascript">
		function validate() {
			debugger;
			var result = n$.Validators.validate('');

			alert(result);
			return false;
		}
	</script>

</asp:Content>
