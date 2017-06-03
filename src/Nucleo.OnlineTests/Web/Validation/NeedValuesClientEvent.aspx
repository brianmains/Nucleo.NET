<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="NeedValuesClientEvent.aspx.cs" Inherits="Nucleo.Web.Validation.NeedValuesClientEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	<n:ValidationManager ID="vm" runat="server" ClientIDMode="Static" />

	<div>
		<asp:TextBox ID="CTL1" runat="server" />
		<n:RequiredValidator ID="RV1" runat="server" OnClientNeedValues="RV1_NeedValues"
			Message="Please enter a value." />
	</div>

	<div>
		<asp:TextBox ID="CTL2" runat="server" />
		<n:RequiredValidator ID="RV2" runat="server" OnClientNeedValues="RV2_NeedValues"
			Message="Please enter a value." DisplayText="*" />
	</div>
	<div>
		<asp:Button ID="Button1" runat="server" Text="Validate"
			 OnClientClick="n$.Validators.validate('');return false;" />
	</div>

	<script type="text/javascript">
		function RV1_NeedValues(sender, e) {
			e.data = [$get("<%= CTL1.ClientID %>").value];
		}

		function RV2_NeedValues(sender, e) {
			e.data = [$get("<%= CTL2.ClientID %>").value];
		}
	</script>

</asp:Content>
