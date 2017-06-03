<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="LoggingServiceFirstLook.aspx.cs" Inherits="Nucleo.Web.Context.LoggingServiceFirstLook"
	Trace="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	<br /><br />
	
	Source: <asp:TextBox ID="txtSource" runat="server" />
	<br />
	
	Message: <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="5" Columns="40" />
	<br />
	
	<asp:Button ID="btnLog" runat="server" Text="Save Message" OnClick="btnLog_Click" />
	
	<br /><br />
</asp:Content>
