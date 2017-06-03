<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Addresses.ascx.cs" Inherits="Nucleo.Demos.MvpScenarios.TabbedForms.Addresses" %>
<%@ Register TagPrefix="sc" Namespace="Nucleo.Web.Mvp.BindingControls" Assembly="Nucleo.Mvp.WebForms" %>

<asp:Panel ID="AddressInfoPanel" runat="server">
	<table>
		<thead></thead>
		<tbody>
			<tr>
				<td>Address:</td>
				<td>
					<asp:TextBox ID="Address" runat="server" />
				</td>
			</tr>
			<tr>
				<td>City:</td>
				<td>
					<asp:TextBox ID="City" runat="server" />
				</td>
			</tr>
			<tr>
				<td>State:</td>
				<td>
					<asp:TextBox ID="State" runat="server" />
				</td>
			</tr>
			<tr>
				<td>Zip:</td>
				<td>
					<asp:TextBox ID="ZipCode" runat="server" />
				</td>
			</tr>
			<tr>
				<td>Is Primary?:</td>
				<td>
					<asp:CheckBox ID="IsPrimary" runat="server" />
				</td>
			</tr>
			<tr>
				<td>Is Mailing?:</td>
				<td>
					<asp:CheckBox ID="IsMailing" runat="server" />
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
	<asp:GridView ID="gvwAddresses" runat="server" DataKeyNames="Key" AutoGenerateColumns="false"
		OnRowCommand="gvwAddresses_RowCommand">
		<Columns>
			<asp:TemplateField>
				<ItemTemplate>
					<asp:Button ID="btnSelect" runat="server" Text="Select"
						CommandName="Select" CommandArgument='<%# Eval("Key") %>' />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField HeaderText="Address" DataField="Address" />
			<asp:BoundField HeaderText="City" DataField="City" />
			<asp:BoundField HeaderText="State" DataField="State" />
			<asp:BoundField HeaderText="Zip" DataField="ZipCode" />
		</Columns>
	</asp:GridView>
</div>