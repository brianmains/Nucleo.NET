<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EntityInstanceSender.ascx.cs" Inherits="Nucleo.Demos.MvpSamples.MessagingSamples.EventTypes.EntityInstanceSender" %>

<div>
	Text: 
	<asp:TextBox ID="txtMsg" runat="server" />
</div>
<div>
	<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
</div>