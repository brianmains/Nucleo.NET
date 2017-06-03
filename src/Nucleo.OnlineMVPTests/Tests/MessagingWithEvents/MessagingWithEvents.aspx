<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MessagingWithEvents.aspx.cs" Inherits="Nucleo.Tests.MessagingWithEvents.MessagingWithEvents" %>
<%@ Register TagPrefix="uc" TagName="MessageChild01" Src="~/Tests/MessagingWithEvents/MessageChild01.ascx" %>
<%@ Register TagPrefix="uc" TagName="MessageChild02" Src="~/Tests/MessagingWithEvents/MessageChild02.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<div>
		<uc:MessageChild01 id="uc1" runat="server" />
	</div>
	<div>
		<uc:MessageChild02 id="uc2" runat="server" />
	</div>
	<div>
		<asp:Label ID="lblOutput" runat="server" />
	</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
