<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="LoginSample.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.StateSamples.LoginSample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<table cellspacing="0" border="0">
		<thead></thead>
		<tbody>
			<tr>
				<td>User ID:</td>
				<td>
					<asp:TextBox ID="txtUserID" runat="server" />
					<asp:RequiredFieldValidator ID="rfvUserID" runat="server" ControlToValidate="txtUserID"
						ErrorMessage="Please enter a user ID" />
				</td>
			</tr>
			<tr>
				<td>Password:</td>
				<td>
					<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
					<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
						ErrorMessage="Please enter a password" />
				</td>
			</tr>
			<tr>
				<td colspan="2">
					<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
				</td>
			</tr>
		</tbody>
	</table>

</asp:Content>
