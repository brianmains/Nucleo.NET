<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ValidationGroups.aspx.cs" Inherits="Nucleo.Web.Validation.ValidationGroups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	<n:ValidationManager ID="vm" runat="server" ClientIDMode="Static" />

	<div>
		<asp:TextBox ID="CTL1" runat="server" />
		<n:RequiredValidator ID="RV1" runat="server" ValidatedControlID="CTL1"
			Message="Please enter a value." DefaultGroupName="G1" />
	</div>

	<div>
		<asp:TextBox ID="CTL2" runat="server" />
		<n:RequiredValidator ID="RV2" runat="server" ValidatedControlID="CTL2"
			Message="Please enter a value." DisplayText="*"  DefaultGroupName="G2" />
	</div>
	<div>
		<asp:Button runat="server" Text="Validate Default"
			 OnClientClick="n$.Validators.validate('');return false;" />
		<asp:Button runat="server" Text="Validate Group 1"
			 OnClientClick="n$.Validators.validate('G1');return false;" />
		<asp:Button runat="server" Text="Validate Group 2"
			 OnClientClick="n$.Validators.validate('G2');return false;" />
	</div>

</asp:Content>
