<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.ModelCachingSamples.FirstLook" %>
<%@ Register src="FirstLook1.ascx" tagname="FirstLook1" tagprefix="uc1" %>
<%@ Register src="FirstLook2.ascx" tagname="FirstLook2" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1>First Look</h1>

	<asp:DropDownList ID="ddl" runat="server" />

	<uc1:FirstLook1 ID="F1" runat="server" />
	<uc2:FirstLook2 ID="F2" runat="server" />

</asp:Content>
