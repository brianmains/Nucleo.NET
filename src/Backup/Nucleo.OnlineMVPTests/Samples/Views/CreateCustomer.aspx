<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateCustomer.aspx.cs" Inherits="Nucleo.OnlineMVPTests.Views.CreateCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<p>
		<asp:Label ID="lblMessage" runat="server" EnableViewState="false" />
	</p>

	<table cellspacing="0" border="0">
		<thead></thead>
		<tbody>
			<tr>
				<td>First Name:</td>
				<td><asp:TextBox ID="txtFirstName" runat="server" /></td>
			</tr>
			<tr>
				<td>Last Name:</td>
				<td><asp:TextBox ID="txtLastName" runat="server" /></td>
			</tr>
			<tr>
				<td>Account #:</td>
				<td><asp:TextBox ID="txtAccountNumber" runat="server" /></td>
			</tr>
			<tr>
				<td colspan="2">
					<asp:Button ID="btnSave" runat="server" Text="Save" />
					<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
					<asp:Button ID="btnLoad" runat="server" Text="Load" />
					<asp:Button ID="btnViewAll" runat="server" Text="View All Customers" />
				</td>
			</tr>
		</tbody>
	</table>

</asp:Content>
