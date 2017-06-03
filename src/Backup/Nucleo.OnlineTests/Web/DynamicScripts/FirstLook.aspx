<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.DynamicScripts.FirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<n:DynamicScriptLoader ID="dsl" runat="server">
		<Scripts>
			<n:DynamicScript Name="t1" Path="test1.js" />
			<n:DynamicScript Name="t1" Path="test2.js" />
		</Scripts>
	</n:DynamicScriptLoader>

</asp:Content>
