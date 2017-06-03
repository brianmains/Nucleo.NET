<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="PerGlobal.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.ModelCachingSamples.PerGlobal" %>
<%@ Register src="PerGlobalChild.ascx" tagname="PerGlobalChild" tagprefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1>Per Global</h1>

	<asp:Repeater ID="rpt" runat="server">
		<ItemTemplate>
			<div>
				<uc:PerGlobalChild runat="server" />
			</div>
		</ItemTemplate>
	</asp:Repeater>

</asp:Content>
