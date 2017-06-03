<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="PostDataServiceFirstLook.aspx.cs" Inherits="Nucleo.Web.Context.PostDataServiceFirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div>
		Post Data
		<div>
			<asp:TextBox ID="TextBox1" runat="server" /><br />
			<asp:TextBox ID="TextBox2" runat="server" /><br />
			<asp:TextBox ID="TextBox3" runat="server" /><br />
			<asp:TextBox ID="TextBox4" runat="server" /><br />
		</div>
	</div>

	<asp:Button ID="btnPostback" runat="server" Text="Postback" />
	
	<br /><br />
	
	<asp:Label ID="lblOutput" runat="server" EnableViewState="false" />
</asp:Content>
