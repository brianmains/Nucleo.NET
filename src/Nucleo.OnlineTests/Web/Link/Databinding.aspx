<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="Databinding.aspx.cs" Inherits="Nucleo.Web.Link.Databinding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	<br />

	<h1>Redirect Links (To Nowhere)</h1>

	<asp:Repeater ID="rpt1" runat="server">
		<ItemTemplate>
			<div>
				<n:Link runat="server" TextFormat="Link: {0}" Text='<%# Eval("Text") %>'
					NavigateUrlFormatString="find.aspx?id={0}" NavigateUrl='<%# Eval("Key") %>'
					ClickAction="Redirect" />
			</div>
		</ItemTemplate>
	</asp:Repeater>

	<h1>Postback Links (Event)</h1>

	<asp:Repeater ID="rpt2" runat="server" OnItemCommand="rpt2_ItemCommand">
		<ItemTemplate>
			<div>
				<n:Link runat="server" TextFormat="Link: {0}" Text='<%# Eval("Text") %>'
					NavigateUrlFormatString="find.aspx?id={0}" NavigateUrl='<%# Eval("Key") %>'
					ClickAction="FireEvent" />
			</div>
		</ItemTemplate>
	</asp:Repeater>

</asp:Content>
