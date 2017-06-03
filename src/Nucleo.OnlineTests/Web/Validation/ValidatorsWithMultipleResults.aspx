<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ValidatorsWithMultipleResults.aspx.cs" Inherits="Nucleo.Web.Validation.ValidatorsWithMultipleResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:ValidationManager ID="vm" runat="server" ClientIDMode="Static" />
	<div>
		<n:ValidationResults id="valResults" runat="server" />
	</div>

	<div>
		<asp:TextBox ID="CTL1" runat="server" />
		<n:RequiredValidator ID="RV1" runat="server" ValidatedControlID="CTL1"
			Message="Please enter a value." />
	</div>

	<div>
		<asp:TextBox ID="CTL2" runat="server" />
		<n:RequiredValidator ID="RV2" runat="server" ValidatedControlID="CTL2"
			Message="Please enter a value." DisplayText="*" />
	</div>
	<div>
		<asp:Button ID="Button1" runat="server" Text="Validate"
			 OnClientClick="n$.Validators.validate('');return false;" />
	</div>

	<div>
		<n:ValidationResults id="valResults2" runat="server" />
	</div>

</asp:Content>
