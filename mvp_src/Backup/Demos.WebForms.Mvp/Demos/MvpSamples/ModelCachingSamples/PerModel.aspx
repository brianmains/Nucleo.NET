<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="PerModel.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.ModelCachingSamples.PerModel" %>
<%@ Register src="PerModelChild.ascx" tagname="PerModelChild" tagprefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1>Per Model</h1>

	<asp:Repeater ID="rpt" runat="server">
		<ItemTemplate>
			<div>
				<uc:PerModelChild runat="server" />
			</div>
		</ItemTemplate>
	</asp:Repeater>

</asp:Content>
