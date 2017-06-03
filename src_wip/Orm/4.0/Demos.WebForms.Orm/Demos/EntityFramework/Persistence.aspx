﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="Persistence.aspx.cs" Inherits="Nucleo.Demos.EntityFramework.Persistence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<asp:ValidationSummary ID="valSummary" runat="server" HeaderText="The following errors have occurred:"
		 ValidationGroup="NewRecord" />

	<div>
		<table>
			<thead></thead>
			<tbody>
				<tr>
					<td>Culture ID:</td>
					<td>
						<asp:TextBox ID="CultureID" runat="server" />
						<asp:RequiredFieldValidator ID="rfvCultureID" runat="server" Text="*"
							ControlToValidate="CultureID" ValidationGroup="NewRecord"
							ErrorMessage="Please enter a culture."  />
					</td>
				</tr>
				<tr>
					<td>Name:</td>
					<td>
						<asp:TextBox ID="Name" runat="server" />
						<asp:RequiredFieldValidator ID="rfvName" runat="server" Text="*"
							ControlToValidate="Name" ValidationGroup="NewRecord"
							ErrorMessage="Please enter a name."  />
					</td>
				</tr>
				<tr>
					<td>Modified Date:</td>
					<td>
						<asp:TextBox ID="ModifiedDate" runat="server" />
						<asp:RequiredFieldValidator ID="rfvModifiedDate" runat="server" Text="*"
							ControlToValidate="ModifiedDate" ValidationGroup="NewRecord"
							ErrorMessage="Please enter a modified date."  />
						<asp:RegularExpressionValidator ID="revModifiedDate" runat="server" Text="*"
							ControlToValidate="ModifiedDate" ValidationGroup="NewRecord"
							ErrorMessage="Please enter a valid modified date." 
							ValidationExpression="^(([1-9])|(0[1-9])|(1[0-2]))\/(([0-9])|([0-2][0-9])|(3[0-1]))\/(([0-9][0-9])|([1-2][0,9][0-9][0-9]))$" />
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Button ID="btnSave" runat="server" Text="Save"
							OnClick="btnSave_Click" ValidationGroup="NewRecord" />
						<asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
							OnClick="btnCancel_Click" ValidationGroup="NewRecord" />
					</td>
				</tr>
			</tbody>
		</table>
	</div>

	<div>
		<asp:GridView ID="gvwCultures" runat="server" AutoGenerateSelectButton="true" 
			AutoGenerateDeleteButton="true" DataKeyNames="CultureID"
			OnRowDeleting="gvwCultures_RowDeleting"
			OnSelectedIndexChanging="gvwCultures_SelectedIndexChanging">
		</asp:GridView>
	</div>

</asp:Content>
