<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.MessagingSamples.FirstLook" %>
<%@ Register src="FirstLookSender.ascx" tagname="FirstLookSender" tagprefix="uc1" %>
<%@ Register src="FirstLookReceiver.ascx" tagname="FirstLookReceiver" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div>
		<uc1:FirstLookSender ID="MessageSender1" runat="server" />
	</div>

	<div>
		<uc2:FirstLookReceiver ID="MessageReceiver1" runat="server" />
	</div>

</asp:Content>
