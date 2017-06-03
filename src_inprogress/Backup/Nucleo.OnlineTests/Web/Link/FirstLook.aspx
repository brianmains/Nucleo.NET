<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.Link.FirstLook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	<div>
		<n:Link ID="Link1" runat="server" Text="Click to Postback" OnClicked="Link1_Clicked" />
	</div>
	<div>
		<n:Link ID="Link2" runat="server" Text="Click to Redirect in New Window" NavigateUrl="http://www.google.com"
			Target="NewWindow" ClickAction="Redirect" />
	</div>

	<div>
		<n:Link ID="Link3" runat="server" Text="Click to Redirect in Same Window" NavigateUrl="http://www.google.com"
			Target="SameWindow" ClickAction="Redirect" />
	</div>
</asp:Content>
