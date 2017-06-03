<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhoneNumbers.ascx.cs" Inherits="Nucleo.Demos.MvpScenarios.TabbedForms.PhoneNumbers" %>
<%@ Register TagPrefix="sc" Namespace="Nucleo.Web.Mvp.BindingControls" Assembly="Nucleo.Mvp.WebForms" %>

<asp:Panel ID="PhoneInfoPanel" runat="server">
	<table>
		<thead></thead>
		<tbody>
			<tr>
				<td>Phone:</td>
				<td>
					<asp:TextBox ID="Phone" runat="server" />
				</td>
			</tr>
			<tr>
				<td>Type:</td>
				<td>
					<asp:TextBox ID="Type" runat="server" />
				</td>
			</tr>
			<tr>
				<td>Is Primary:</td>
				<td>
					<asp:CheckBox ID="IsPrimary" runat="server" />
				</td>
			</tr>
			<tr>
				<td>Effective:</td>
				<td>
					<asp:TextBox ID="Effective" runat="server" />
				</td>
			</tr>
			<tr>
				<td>Ends:</td>
				<td>
					<asp:TextBox ID="Ends" runat="server" />
				</td>
			</tr>
		</tbody>
	</table>
</asp:Panel>
<div>
	<asp:Button ID="SaveCommand" runat="server" Text="Save" OnClick="SaveCommand_Click" />
	<asp:Button ID="CancelCommand" runat="server" Text="Cancel" OnClick="CancelCommand_Click" />
</div>
<br />
<div>
	<asp:GridView ID="gvwPhoneNumbers" runat="server" DataKeyNames="Key" AutoGenerateColumns="false"
		OnRowCommand="gvwPhoneNumbers_RowCommand">
		<Columns>
			<asp:TemplateField>
				<ItemTemplate>
					<asp:Button ID="btnSelect" runat="server" Text="Select"
						CommandName="Select" CommandArgument='<%# Eval("Key") %>' />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField HeaderText="Phone" DataField="Phone" />
			<asp:BoundField HeaderText="Type" DataField="Type" />
			<asp:BoundField HeaderText="Effective" DataField="Effective" />
			<asp:BoundField HeaderText="Ends" DataField="Ends" />
		</Columns>
	</asp:GridView>
</div>