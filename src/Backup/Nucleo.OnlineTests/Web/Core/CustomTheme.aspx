<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="CustomTheme.aspx.cs" Inherits="Nucleo.Web.Core.CustomTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link type="text/css" href="../../Css/CustomStyles.css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:Accordion ID="acc" runat="server" EnableCustomTheming="true">
		<Items>
			<n:AccordionItem ID="a1" runat="server" Title="First Header">
				<Content>
					This is my content.
				</Content>
			</n:AccordionItem>
			<n:AccordionItem ID="a2" runat="server" Title="Second Header">
				<Content>
					This is my content.
				</Content>
			</n:AccordionItem>
		</Items>
	</n:Accordion>

</asp:Content>
