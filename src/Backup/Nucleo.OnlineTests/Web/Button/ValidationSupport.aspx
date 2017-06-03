<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ValidationSupport.aspx.cs" Inherits="Nucleo.Web.Button.ValidationSupport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1>Sample Validation Form With Client/Server Side Button</h1>

	<asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="Test" />

	<div>
		First Name: <asp:TextBox ID="txtFirstName" runat="server" ValidationGroup="Test"></asp:TextBox>
	</div>
	<div>
		Last Name: <asp:TextBox ID="txtLastName" runat="server" ValidationGroup="Test"></asp:TextBox>
		<asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
			ErrorMessage="Enter a last name" Text="*" ValidationGroup="Test" />
	</div>
	<div>
		<n:Button ID="btnSave" runat="server" Text="Save" Mode="Button"
			CausesValidation="true" ValidationGroup="Test" RenderingMode="ClientAndServer" />
	</div>

	<h1>Sample Validation Form With Client/Server Side Link Button</h1>

	<asp:ValidationSummary ID="valSummary2" runat="server" ValidationGroup="Test2" />

	<div>
		First Name: <asp:TextBox ID="txtFirstName2" runat="server" ValidationGroup="Test2"></asp:TextBox>
	</div>
	<div>
		Last Name: <asp:TextBox ID="txtLastName2" runat="server" ValidationGroup="Test2"></asp:TextBox>
		<asp:RequiredFieldValidator ID="rfvLastName2" runat="server" ControlToValidate="txtLastName2"
			ErrorMessage="Enter a last name" Text="*" ValidationGroup="Test2" />
	</div>
	<div>
		<n:Button ID="btnSave2" runat="server" Text="Save" Mode="Link" UseSubmitBehavior="false"
			CausesValidation="true" ValidationGroup="Test2" RenderingMode="ClientAndServer"
			PostBackAlways="true" />
	</div>

</asp:Content>
