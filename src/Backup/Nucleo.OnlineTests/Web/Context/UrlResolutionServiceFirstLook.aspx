<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="UrlResolutionServiceFirstLook.aspx.cs" Inherits="Nucleo.Web.Context.UrlResolutionServiceFirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div>
		Resolved Url: <asp:Label ID="lblResolvedUrl" runat="server" />
	</div>
	<div>
		Mapped Url: <asp:Label ID="lblMappedUrl" runat="server" />
	</div>

</asp:Content>
