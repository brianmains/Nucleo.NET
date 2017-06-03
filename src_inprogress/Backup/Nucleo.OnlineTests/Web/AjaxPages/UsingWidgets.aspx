<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="UsingWidgets.aspx.cs" Inherits="Nucleo.Web.AjaxPages.UsingWidgets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1>Sample Widget</h1>

	<div>
		<table cellspacing="0" border="0">
			<thead></thead>
			<tbody>
				<tr>
					<td>
						User Name:
					</td>
					<td>
						<asp:TextBox ID="txtUserName" runat="server" />
					</td>
				</tr>
				<tr>
					<td>
						Password:
					</td>
					<td>
						<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Button ID="btnSubmit" runat="server" Text="Submit" />
					</td>
				</tr>
			</tbody>
		</table>
	</div>

</asp:Content>
