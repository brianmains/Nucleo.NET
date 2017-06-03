<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="BubblingEvents.aspx.cs" Inherits="Nucleo.Web.Accordions.BubblingEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">


	<n:Accordion id="accControl" runat="server" OnItemCommand="ac_Command">
		<Items>
			<n:AccordionItem ID="AccordionItem1" runat="server" Title="First Item">
				<Content>
					<asp:Button ID="b1" runat="server" Text="First Button" CommandName="First" />
				</Content>
			</n:AccordionItem>
			<n:AccordionItem ID="AccordionItem2" runat="server" Title="Second Item">
				<Content>
					<asp:Button ID="b2" runat="server" Text="Second Button" CommandName="Second" />
				</Content>
			</n:AccordionItem>
			<n:AccordionItem ID="AccordionItem3" runat="server" Title="Third Item">
				<Content>
					<asp:Button ID="b3" runat="server" Text="Third Button" CommandName="Third" />
				</Content>
			</n:AccordionItem>
		</Items>
	</n:Accordion>

	<div>
		<asp:Label ID="lblOutput" runat="server" />
	</div>
</asp:Content>
