<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="AspNetInteroperability.aspx.cs" Inherits="Nucleo.Web.Validation.AspNetInteroperability" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	<n:ValidationManager ID="vm" runat="server" ClientIDMode="Static" />

	<h1>Empty Validation Group</h1>

	<div>
		<n:ValidationResults ID="valResults" runat="server">
			<AspNetCompatibility AttachToValidators="true" />
		</n:ValidationResults>

		<div>
			First Name:
			<asp:TextBox ID="txtFirstName" runat="server" />
			<asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
				ErrorMessage="Please enter a first name.">*</asp:RequiredFieldValidator>
		</div>

		<div>
			Last Name:
			<asp:TextBox ID="txtLastName" runat="server" />
			<asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
				ErrorMessage="Please enter a last name.">*</asp:RequiredFieldValidator>
		</div>

		<div>
			State:
			<asp:TextBox ID="txtState" runat="server" />
			<asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="txtState"
				ErrorMessage="Please enter a state.">*</asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="revState" runat="server" ControlToValidate="txtState"
				ErrorMessage="Please enter a state." ValidationExpression="[A-Za-z]{2}"
				>*</asp:RegularExpressionValidator>
		</div>

		<div>
			<asp:Button ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="false" />
		</div>
	</div>

	<br /><br />

	<h1>Custom Validation Group</h1>

	<div>
		<n:ValidationResults ID="valResults2" runat="server" DefaultGroupName="Second">
			<AspNetCompatibility AttachToValidators="true" />
		</n:ValidationResults>

		<div>
			First Name:
			<asp:TextBox ID="txtFirstName2" runat="server" ValidationGroup="Second" />
			<asp:RequiredFieldValidator ID="rfvFirstName2" runat="server" ControlToValidate="txtFirstName2"
				ErrorMessage="Please enter a first name." ValidationGroup="Second">*</asp:RequiredFieldValidator>
		</div>

		<div>
			Last Name:
			<asp:TextBox ID="txtLastName2" runat="server" ValidationGroup="Second" />
			<asp:RequiredFieldValidator ID="rfvLastName2" runat="server" ControlToValidate="txtLastName2"
				ErrorMessage="Please enter a last name." ValidationGroup="Second">*</asp:RequiredFieldValidator>
		</div>

		<div>
			State:
			<asp:TextBox ID="txtState2" runat="server" ValidationGroup="Second" />
			<asp:RequiredFieldValidator ID="rfvState2" runat="server" ControlToValidate="txtState2"
				ErrorMessage="Please enter a state." ValidationGroup="Second">*</asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="revState2" runat="server" ControlToValidate="txtState2"
				ErrorMessage="Please enter a state." ValidationExpression="[A-Za-z]{2}" ValidationGroup="Second"
				>*</asp:RegularExpressionValidator>
		</div>

		<div>
			<asp:Button ID="btnSave2" runat="server" Text="Save" UseSubmitBehavior="false" ValidationGroup="Second" />
		</div>
	</div>

</asp:Content>
