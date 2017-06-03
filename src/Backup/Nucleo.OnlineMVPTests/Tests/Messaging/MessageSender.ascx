<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageSender.ascx.cs" Inherits="Nucleo.Tests.Messaging.MessageSender" %>

<div>
	Text: 
	<asp:TextBox ID="txtMsg" runat="server" />
</div>
<div>
	<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
</div>