<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="BubbleTunnelEvents.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.MessagingSamples.BubbleTunnelEvents" %>
<%@ Register src="BubbleTunnelEventsChild01.ascx" tagname="SendingEventsChild01" tagprefix="uc1" %>
<%@ Register src="BubbleTunnelEventsChild02.ascx" tagname="SendingEventsChild02" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1>Sending Events Page</h1>

	<asp:Button ID="btnSendTunnelledMessage" runat="server" Text="Send Tunnelled Message"
		OnClick="btnSendTunnelledMessage_Click" />

	<asp:Label ID="lblOutput" runat="server" EnableViewState="false" />
	<br />

	<uc1:SendingEventsChild01 ID="SendingEventsChild011" runat="server" />
	<uc2:SendingEventsChild02 ID="SendingEventsChild021" runat="server" />

</asp:Content>
