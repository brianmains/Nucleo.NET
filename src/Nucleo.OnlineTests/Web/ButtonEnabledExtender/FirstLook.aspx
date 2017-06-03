<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.ButtonEnabledExtender.FirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div>
		<asp:TextBox ID="txt1" runat="server" />
		<asp:Button ID="btn1" runat="server" Text="Test Submit Behavior" CausesValidation="false" UseSubmitBehavior="false" />
		<n:ButtonEnabledExtender ID="ext1" runat="server" TargetControlID="btn1" ReceiverControlID="txt1" />
	</div>

	<div>
		<asp:TextBox ID="txt5" runat="server" Text="Disable" />
		<asp:Button ID="btn5" runat="server" Text="Test Disabling Initially" CausesValidation="false" UseSubmitBehavior="false" />
		<n:ButtonEnabledExtender ID="ext5" runat="server" TargetControlID="btn5" ReceiverControlID="txt5" IsEnabledInitially="false" />
	</div>

	<div>
		<asp:TextBox ID="txt4" runat="server" />
		<asp:Button ID="btn4" runat="server" Text="Test Toggling State" CausesValidation="false" />
		<n:ButtonEnabledExtender ID="ext4" runat="server" TargetControlID="btn4" ReceiverControlID="txt4" />
	</div>
	<br />

</asp:Content>
