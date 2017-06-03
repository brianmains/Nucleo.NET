<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ServerUtilityServiceFirstLook.aspx.cs" Inherits="Nucleo.Web.Context.ServerUtilityServiceFirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div>
		Map Path:
		<asp:Label ID="lblMapPath" runat="server" />
	</div>
	
	<div>
		Machine Name:
		<asp:Label ID="lblMachineName" runat="server" />
	</div>
	<div>
		Script Timeout:
		<asp:Label ID="lblScriptTimeout" runat="server" />
	</div>
	<div>
		Encoded Text:
		<asp:Label ID="lblEncodedText" runat="server" />
	</div>
	<div>
		Decoded Text:
		<asp:Label id="lblDecodedText" runat="server" />
	</div>

</asp:Content>
