﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="LinkButtons.aspx.cs" Inherits="Nucleo.Web.Button.LinkButtons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1>Client-Only Button</h1>

	<n:Button ID="b1" runat="server" Text="Click Me Client" RenderingMode="ClientOnly" 
		OnClientClick="n$.Debug.write('Client only button clicked');" />

	<h1>Client-Only Button With Postback Always</h1>

	<n:Button ID="b2" runat="server" Text="Click Me Client With Postback" RenderingMode="ClientOnly"
		PostBackAlways="true" OnClick="b2_Click" />

	<h1>Client-Server Button</h1>

	<n:Button ID="b3" runat="server" Text="Click Me Client/Server" RenderingMode="ClientAndServer"
		OnClick="b3_Click" OnClientClick="n$.Debug.write('Client/server button clicked');" />

	<h1>Client-Server Button With Postback Always</h1>

	<n:Button ID="b5" runat="server" Text="Click Me Client/Server" RenderingMode="ClientAndServer"
		 PostBackAlways="true" OnClick="b5_Click" />

	<h1>Server-Only Button</h1>

	<n:Button ID="b4" runat="server" Text="Click Me Client/Server" RenderingMode="ServerOnly"
		OnClick="b4_Click" />

	<h1>PostBackUrl Set</h1>

	<n:Button ID="b6" runat="server" Text="PostBack Url Redirect" PostBackAlways="true"
		PostBackUrl="ImageButtons.aspx" RenderingMode="ServerOnly" />

</asp:Content>
