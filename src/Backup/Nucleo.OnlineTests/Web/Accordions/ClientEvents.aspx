<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ClientEvents.aspx.cs" Inherits="Nucleo.Web.Accordions.ClientEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:Accordion id="accControl" runat="server">
		<AccordionEvents OnClientItemClosed="itemClosed" OnClientItemClosing="itemClosing" 
						 OnClientItemOpened="itemOpened" OnClientItemOpening="itemOpening" />
		<Items>
			<n:AccordionItem ID="AccordionItem1" runat="server" Title="First Item">
				<AccordionEvents OnClientClosed="closed" OnClientOpened="opened"
								 OnClientSelected="selected" />
				<Content>
					This is my first content.
				</Content>
			</n:AccordionItem>
			<n:AccordionItem ID="AccordionItem2" runat="server" Title="Second Item">
				<AccordionEvents OnClientClosed="closed" OnClientOpened="opened"
								 OnClientSelected="selected" />
				<Content>
					This is my second content.
				</Content>
			</n:AccordionItem>
			<n:AccordionItem ID="AccordionItem3" runat="server" Title="Third Item">
				<AccordionEvents OnClientClosed="closed" OnClientOpened="opened"
								 OnClientSelected="selected" />
				<Content>
					This is my third content.
				</Content>
			</n:AccordionItem>
		</Items>
	</n:Accordion>

	<script type="text/javascript">
		function closed(sender, e) {
			n$.Debug.write("Closed event fired.");
		}

		function opened(sender, e) {
			n$.Debug.write("Opened event fired.");
		}

		function selected(sender, e) {
			n$.Debug.write("Selected event fired.");
		}

		function itemClosed(sender, e) {
			n$.Debug.write("Item Closed event fired.");
		}

		function itemClosing(sender, e) {
			n$.Debug.write("Item Closing event fired.");
		}

		function itemOpened(sender, e) {
			n$.Debug.write("Item Opened event fired.");
		}

		function itemOpening(sender, e) {
			n$.Debug.write("Item Opening event fired.");
		}
	</script>

</asp:Content>
