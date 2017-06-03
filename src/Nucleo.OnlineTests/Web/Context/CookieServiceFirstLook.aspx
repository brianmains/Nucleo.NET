<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="CookieServiceFirstLook.aspx.cs" Inherits="Nucleo.Web.Context.CookieServiceFirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	
	<div>
		<div>
			Name: <asp:TextBox ID="txtNameGet" runat="server" />
			<asp:Button ID="btnGet" runat="server" Text="Get" UseSubmitBehavior="false"
				OnClick="btnGet_Click" />
			
			<asp:Label ID="lblValue" runat="server" />
		</div>
	</div>
	<br />
	
	<div>
		Or Add:
	</div>
	
	<div>
		Name: <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
	</div>
	<div>
		Value: <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
	</div>
	<div>
		<asp:Button ID="btnAdd" runat="server" Text="Add" UseSubmitBehavior="false"
			OnClick="btnAdd_Click" />
	</div>
	
	<br />
	
	<asp:Label ID="lblOutput" runat="server" />

</asp:Content>
