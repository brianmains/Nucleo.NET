<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManyMessagesSample.aspx.cs" Inherits="Nucleo.Tests.Messaging.ManyMessagesSample" %>
<%@ Register TagPrefix="uc" TagName="ManyMessages" Src="~/Tests/Messaging/ManyMessages.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<uc:ManyMessages id="mm01" runat="server" />
	<uc:ManyMessages id="mm02" runat="server" />
	<uc:ManyMessages id="mm03" runat="server" />
	<uc:ManyMessages id="mm04" runat="server" />
	<uc:ManyMessages id="mm05" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
