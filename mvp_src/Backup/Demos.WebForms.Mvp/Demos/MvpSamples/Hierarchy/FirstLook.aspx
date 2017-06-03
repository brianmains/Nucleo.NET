<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.Hierarchy.FirstLook" %>
<%@ Register src="Hierarchy1.ascx" tagname="Hierarchy1" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1>First Look</h1>

	<uc1:Hierarchy1 ID="Hierarchy11" runat="server" />

</asp:Content>
