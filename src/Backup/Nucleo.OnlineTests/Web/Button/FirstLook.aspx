<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.Button.FirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1 class="TestHeader">Disable On Page Load, and On Every Click</h1>
	
	<n:Button ID="btnClientWithDisabling" runat="server" RenderingMode="ClientOnly"
		Text="Client-Side With Disabling Test" DisableUntilPageLoad="true" DisableOnFirstClick="true"
		DisableOnFirstClickTimeout="3000" />

	<hr />

	<h1 class="TestHeader">Client-Side Only Button</h1>
	
	<n:Button ID="btnClientOnly" runat="server" RenderingMode="ClientOnly"
		Text="Client-Side Test">
		<ClientEvents OnClientClicked="Button_Click" />
	</n:Button>
	<hr />
	
	<h1 class="TestHeader">Server-Side Only Submit Button</h1>
		
	<n:Button ID="btnServerSide" runat="server" RenderingMode="ServerOnly" UseSubmitBehavior="true"
		Text="Server-Side Only Click Button Test" OnClick="btnServerSide_Click" />
	<hr />

	<h1 class="TestHeader">Server-Side Only Button</h1>
		
	<n:Button ID="Button1" runat="server" RenderingMode="ServerOnly" UseSubmitBehavior="false"
		Text="Server-Side Only Click Button Test" OnClick="btnServerSide_Click" />
	<hr />
	
	<h1 class="TestHeader">Server-Side Disable On Click</h1>
	
	<n:Button ID="btnServerSideDisableOnClick" runat="server" RenderingMode="ServerOnly"
		Text="Mixed Mode Test" OnClick="btnMixed_Click" DisableOnFirstClick="true" />
	
	<h1 class="TestHeader">Client-Side Postback</h1>
	
	<n:Button ID="btnClientOnlyPostback" runat="server" RenderingMode="ClientOnly" PostBackAlways="true"
		Text="Client-Side With Postback" OnClick="btnClientOnlyPostback_Click" />
		
	<h1 class="TestHeader">Conditional Postback</h1>
	<n:Button ID="btnClientOnlyConditionalPostback" runat="server" RenderingMode="ClientOnly"
		Text="Client-Side With Postback" OnClick="btnClientOnlyPostback_Click">
		<ButtonClientEvents OnClientNeedPostback="Button_NeedPostback" />
	</n:Button>

	<h1 class="TestHeader">Image Button</h1>
	<n:Button ID="btnImageButton" runat="server" RenderingMode="ClientAndServer" Mode="Image"
		ImageUrl="~/TestImages/SampleButton.png" ImageAlternateText="Sample Button">
		<ClientEvents OnClientClicked="Button_Click" />
	</n:Button>
		
	<br /><br />
	
	<hr />
	<h2>Output</h2>
	
	<asp:Label ID="lblOutput" runat="server" />
	<hr />	
	
	<script language="javascript" type="text/javascript">
		var index = 0;

		function Button_Click() {
			n$.Debug.write("Click event raised on the client");
		}

		function Button_NeedPostback(sender, e) {
			if (index == 5)
				e.set_shouldPostBack(true);

			index++;
		}
	</script>
</asp:Content>
