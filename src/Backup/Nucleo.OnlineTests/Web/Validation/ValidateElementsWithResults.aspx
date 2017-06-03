﻿<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="ValidateElementsWithResults.aspx.cs" Inherits="Nucleo.Web.Validation.ValidateElementsWithResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<n:ValidationManager ID="vm" runat="server" ClientIDMode="Static" />
	<div>
		<n:ValidationResults id="valResults" runat="server" />
	</div>

	<div>
		<input type="text" id="CTL1" name="CTL1" />
		<n:RequiredValidator ID="RV1" runat="server" ValidatedControlID="CTL1"
			Message="Please enter a value." />
	</div>

	<div>
		<input type="text" id="CTL2" name="CTL2" />
		<n:RequiredValidator ID="RV2" runat="server" ValidatedControlID="CTL2"
			Message="Please enter a value." DisplayText="*" />
	</div>
	<div>
		<asp:Button ID="Button1" runat="server" Text="Validate"
			 OnClientClick="n$.Validators.validate('');return false;" />
	</div>

</asp:Content>
