<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="WithEvents.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.MessagingSamples.WithEvents" %>
<%@ Register TagPrefix="uc" TagName="WithEventsChild01" Src="WithEventsChild01.ascx" %>
<%@ Register TagPrefix="uc" TagName="WithEventsChild02" Src="WithEventsChild02.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div>
		<uc:WithEventsChild01 id="uc1" runat="server" />
	</div>
	<div>
		<uc:WithEventsChild02 id="uc2" runat="server" />
	</div>
	<div>
		<asp:Label ID="lblOutput" runat="server" />
	</div>

</asp:Content>
