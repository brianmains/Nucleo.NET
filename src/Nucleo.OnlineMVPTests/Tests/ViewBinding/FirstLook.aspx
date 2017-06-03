<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Tests.ViewBinding.FirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<asp:Panel ID="pnlFirstRegion" runat="server">
		<table border="0">
			<thead></thead>
			<tbody>
				<tr>
					<td>First Name:</td>
					<td>
						<asp:TextBox ID="FirstName" runat="server" />
					</td>
				</tr>
				<tr>
					<td>Last Name:</td>
					<td>
						<asp:TextBox ID="LastName" runat="server" />
					</td>
				</tr>
				<tr>
					<td>State:</td>
					<td>
						<asp:DropDownList ID="State" runat="server" DataTextField="Text" DataValueField="Value" />
					</td>
				</tr>
			</tbody>
		</table>
		
		<div>
			<asp:Button ID="Save" runat="server" Text="Save" />
		</div>
	</asp:Panel>
	<n:ViewBindingSource ID="vbs" runat="server" TargetControlID="pnlFirstRegion" ModelSource="FirstModelProperty" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
