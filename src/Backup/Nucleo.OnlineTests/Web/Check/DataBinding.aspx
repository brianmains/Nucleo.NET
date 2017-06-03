<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="DataBinding.aspx.cs" Inherits="Nucleo.Web.Check.DataBinding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<asp:Repeater ID="rpt1" runat="server">
		<ItemTemplate>
			<div>
				<n:Check runat="server" Checked='<%# Eval("Checked") %>' AllowEmptyCheckState="true"
					TextFormat="This is a {0}" Text='<%# Eval("Text") %>' />
			</div>
		</ItemTemplate>
	</asp:Repeater>

</asp:Content>
