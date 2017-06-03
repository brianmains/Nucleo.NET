<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="LargeResultSet.aspx.cs" Inherits="Nucleo.Demos.EntityFramework.LargeResultSet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<p>
		<asp:RadioButtonList ID="rbl" runat="server">
			<asp:ListItem Text="All Items" Value="A" />
			<asp:ListItem Text="Top 100 Items" Value="T" Selected='True' />
		</asp:RadioButtonList>

		<asp:Button ID="btn" runat="server" Text="Refresh" OnClick="btn_Click" />
	</p>
	<p>
		<asp:GridView ID="gvw" runat="server" PageSize="25" AllowPaging="True" OnPageIndexChanging="gvw_PageIndexChanging">
		</asp:GridView>
	</p>

</asp:Content>
