<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ChangingTemplates.aspx.cs" Inherits="Nucleo.Web.FormItemDisplay.ChangingTemplates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div>
	<n:FormItemDisplay ID="f1" runat="server" RenderingMode="ServerOnly">
		<EditTemplate>
			<Template>
				This is my edit template.
			</Template>
		</EditTemplate>	
		<InsertTemplate>
			<Template>
				This is my insert template.
			</Template>
		</InsertTemplate>
		<ReadOnlyTemplate>
			<Template>
				This is my readonly template.
			</Template>
		</ReadOnlyTemplate>
	</n:FormItemDisplay>
	</div>

	<div>
		<asp:DropDownList ID="ddlNewServerMode" runat="server" AutoPostBack="true" 
			OnSelectedIndexChanged="ddlNewServerMode_SelectedIndexChanged">
			<asp:ListItem>ReadOnly</asp:ListItem>
			<asp:ListItem>Edit</asp:ListItem>
			<asp:ListItem>Insert</asp:ListItem>
		</asp:DropDownList>
	</div>

</asp:Content>