<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.MessagingSamples.EventTypes.FirstLook" %>
<%@ Register src="EntityTypeSender.ascx" tagname="EntityTypeSender" tagprefix="uc1" %>
<%@ Register src="EntityTypeReceiver.ascx" tagname="EntityTypeReceiver" tagprefix="uc2" %>
<%@ Register src="GenericEntityTypeSender.ascx" tagname="GenericEntityTypeSender" tagprefix="uc1" %>
<%@ Register src="GenericEntityTypeReceiver.ascx" tagname="GenericEntityTypeReceiver" tagprefix="uc2" %>
<%@ Register src="EntityInstanceSender.ascx" tagname="EntityInstanceSender" tagprefix="uc1" %>
<%@ Register src="EntityInstanceReceiver.ascx" tagname="EntityInstanceReceiver" tagprefix="uc2" %>
<%@ Register src="TextIdentifierSender.ascx" tagname="TextIdentifierSender" tagprefix="uc1" %>
<%@ Register src="TextIdentifierReceiver.ascx" tagname="TextIdentifierReceiver" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h2>By Entity Type</h2>

	<div>
		<uc1:EntityTypeSender ID="EntityTypeSender1" runat="server" />
	</div>

	<div>
		<uc2:EntityTypeReceiver ID="EntityTypeReceiver1" runat="server" />
	</div>

	<h2>By Entity Type With Generic Form</h2>

	<div>
		<uc1:GenericEntityTypeSender ID="GenericEntityTypeSender1" runat="server" />
	</div>

	<div>
		<uc2:GenericEntityTypeReceiver ID="GenericEntityTypeReceiver1" runat="server" />
	</div>

	<h2>By Entity Instance</h2>

	<div>
		<uc1:EntityInstanceSender ID="EntityInstanceSender1" runat="server" />
	</div>

	<div>
		<uc2:EntityInstanceReceiver ID="EntityInstanceReceiver1" runat="server" />
	</div>

	<h2>By Text Identifier</h2>

	<div>
		<uc1:TextIdentifierSender ID="TextIdentifierSender1" runat="server" />
	</div>

	<div>
		<uc2:TextIdentifierReceiver ID="TextIdentifierReceiver1" runat="server" />
	</div>

</asp:Content>
