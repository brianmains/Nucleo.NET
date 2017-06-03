<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactInfo.ascx.cs" Inherits="Nucleo.Demos.MvpScenarios.TabbedForms.ContactInfo" %>
<%@ Register TagPrefix="sc" Namespace="Nucleo.Web.Mvp.BindingControls" Assembly="Nucleo.Mvp.WebForms" %>

<asp:Panel ID="ContactInfoPanel" runat="server">
	<table cellspacing="0">
		<thead></thead>
		<tbody>
			<tr>
				<td>Name:</td>
				<td>
					<asp:TextBox ID="Name" runat="server" />
				</td>
			</tr>
			<tr>
				<td>User Name:</td>
				<td>
					<asp:TextBox ID="UserName" runat="server" />
				</td>
			</tr>
			<tr>
				<td>Email:</td>
				<td>
					<asp:TextBox ID="Email" runat="server" />
				</td>
			</tr>
			<tr>
				<td>Is Primary Contact?</td>
				<td>
					<asp:CheckBox ID="IsPrimaryContact" runat="server" />
				</td>
			</tr>
		</tbody>
	</table>
</asp:Panel>
<div>
	<asp:Button ID="SaveCommand" runat="server" Text="Save" OnClick="SaveCommand_Click" />
	<asp:Button ID="CancelCommand" runat="server" Text="Cancel" OnClick="CancelCommand_Click" />
</div>