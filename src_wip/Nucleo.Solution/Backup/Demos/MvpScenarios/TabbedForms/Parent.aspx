<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="Parent.aspx.cs" Inherits="Nucleo.Demos.MvpScenarios.TabbedForms.Parent" %>
<%@ Register TagPrefix="uc" TagName="Display" Src="Display.ascx" %>
<%@ Register TagPrefix="uc" TagName="ContactInfo" Src="ContactInfo.ascx" %>
<%@ Register TagPrefix="uc" TagName="Addresses" Src="Addresses.ascx" %>
<%@ Register TagPrefix="uc" TagName="PhoneNumbers" Src="PhoneNumbers.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div id="ParentContainer">
		<ul>
			<li><a href="#tpContactInfo">Contact</a></li>
			<li><a href="#tpAddresses">Addresses</a></li>
			<li><a href="#tpPhoneNumbers">Phone Numbers</a></li>
			<li><a href="#tpDisplay">Display</a></li>
		</ul>
		<div>
			<div id="tpContactInfo">
				<uc:ContactInfo ID="ucContactInfo" runat="server" />
			</div>
			<div id="tpAddresses">
				<uc:Addresses ID="ucAddresses" runat="server" />
			</div>
			<div id="tpPhoneNumbers">
				<uc:PhoneNumbers ID="ucPhoneNumbers" runat="server" />
			</div>
			<div id="tpDisplay">
				<uc:Display ID="ucDisplay" runat="server" />
			</div>
		</div>
	</div>
	<script type="text/javascript">
		$(document).ready(function () {
			$("#ParentContainer").tabs();
		});
	</script>

</asp:Content>
