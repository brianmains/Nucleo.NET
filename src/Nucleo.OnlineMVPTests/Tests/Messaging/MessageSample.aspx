<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MessageSample.aspx.cs" Inherits="Nucleo.Tests.Messaging.MessageSample" %>
<%@ Register src="MessageSender.ascx" tagname="MessageSender" tagprefix="uc1" %>
<%@ Register src="MessageReceiver.ascx" tagname="MessageReceiver" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
	<div>
		<uc1:MessageSender ID="MessageSender1" runat="server" />
	</div>

	<div>
		<uc2:MessageReceiver ID="MessageReceiver1" runat="server" />
	</div>
</asp:Content>
