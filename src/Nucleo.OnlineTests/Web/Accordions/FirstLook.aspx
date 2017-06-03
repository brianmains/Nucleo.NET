<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.Accordions.FirstLook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:Accordion id="accControl" runat="server">
		<Items>
			<n:AccordionItem runat="server" Title="First Item">
				<Content>
					This is my first content.
				</Content>
			</n:AccordionItem>
			<n:AccordionItem runat="server" Title="Second Item">
				<Content>
					This is my second content.
				</Content>
			</n:AccordionItem>
			<n:AccordionItem runat="server" Title="Third Item">
				<Content>
					This is my third content.
				</Content>
			</n:AccordionItem>
		</Items>
	</n:Accordion>

</asp:Content>