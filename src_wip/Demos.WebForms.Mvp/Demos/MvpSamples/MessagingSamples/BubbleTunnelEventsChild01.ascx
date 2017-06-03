<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BubbleTunnelEventsChild01.ascx.cs" Inherits="Nucleo.Demos.MvpSamples.MessagingSamples.BubbleTunnelEventsChild01" %>
<%@ Register src="BubbleTunnelEventsSubchild01.ascx" tagname="SendingEventsSubchild01" tagprefix="uc1" %>

<h1>Sending Events Child 1</h1>
<asp:Label ID="lblOutput" runat="server" EnableViewState="false" />
<br />

<uc1:SendingEventsSubchild01 ID="SendingEventsSubchild011" runat="server" />