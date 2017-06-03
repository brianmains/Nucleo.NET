<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="ManyMessages.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.MessagingSamples.ManyMessages" %>
<%@ Register TagPrefix="uc" TagName="ManyMessages" Src="ManyMessagesChild.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<uc:ManyMessages id="mm01" runat="server" />
	<uc:ManyMessages id="mm02" runat="server" />
	<uc:ManyMessages id="mm03" runat="server" />
	<uc:ManyMessages id="mm04" runat="server" />
	<uc:ManyMessages id="mm05" runat="server" />

	<asp:Label ID="lblOutput" runat="server" />

</asp:Content>
