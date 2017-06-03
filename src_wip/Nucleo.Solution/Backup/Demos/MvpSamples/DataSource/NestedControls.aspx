<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="NestedControls.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.DataSource.NestedControls" %>
<%@ Register TagPrefix="uc" TagName="NestedControls01" Src="NestedControls01.ascx" %>
<%@ Register TagPrefix="uc" TagName="NestedControls02" Src="NestedControls02.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1>Page Binding</h1>
		<div>
			<uc:NestedControls02 id="ucData2" runat="server" />
		</div>

		<h1>User Control View Binding</h1>
		<div>
			<uc:NestedControls01 id="ucData1" runat="server" />
		</div>

</asp:Content>
