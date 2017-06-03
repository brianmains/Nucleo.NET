<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BubbleTunnelEventsSubchild01.ascx.cs" Inherits="Nucleo.Demos.MvpSamples.MessagingSamples.BubbleTunnelEventsSubchild01" %>

<h1>Sending Events Subchild 1</h1>

<asp:Button ID="btnSendBubbledMessage" runat="server" Text="Sending Bubbled Message"
	OnClick="btnSendBubbledMessage_Click" />

<asp:Label ID="lblOutput" runat="server" EnableViewState="false" />
<br />