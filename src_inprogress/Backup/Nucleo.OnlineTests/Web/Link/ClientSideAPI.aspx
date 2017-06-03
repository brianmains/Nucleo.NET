<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ClientSideAPI.aspx.cs" Inherits="Nucleo.Web.Link.ClientSideAPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:Link ID="lnkControl" runat="server" Text="Initial Text" RenderingMode="ClientOnly"
		ClickAction="FireEvent">
		<ClientEvents OnClientClicked="lnkControl_Clicked" />
	</n:Link>
	<br /><br />
	
	<strong>Client-Side Settings</strong>
	
	Text:
	<asp:TextBox ID="txtClientText" runat="server"></asp:TextBox>
	<asp:Button ID="btnClientTextChange" runat="server" Text="Change Text"
		OnClientClick="changeText();return false;" UseSubmitBehavior="false" />
	<br />
	
	Navigate Url:
	<asp:TextBox ID="txtClientNavigateUrl" runat="server"></asp:TextBox>
	<asp:Button ID="btnClientNavigateUrl" runat="server" Text="Change Navigate Url"
		OnClientClick="changeNavigateUrl();return false;" UseSubmitBehavior="false" />
	<br />
	
	Click Action:
	<asp:DropDownList ID="ddlClientClickAction" runat="server">
		<asp:ListItem>FireEvent</asp:ListItem>
		<asp:ListItem>Redirect</asp:ListItem>
	</asp:DropDownList>
	<asp:Button ID="btnClientClickActionChange" runat="server" Text="Change Action"
		OnClientClick="changeClickAction();return false;" UseSubmitBehavior="false" />
	<br />
	
	Target:
	<asp:DropDownList ID="ddlClientTarget" runat="server">
		<asp:ListItem>SameWindow</asp:ListItem>
		<asp:ListItem>NewWindow</asp:ListItem>
	</asp:DropDownList>
	<asp:Button ID="btnClientTarget" runat="server" Text="Change Target"
		OnClientClick="changeTarget();return false;" UseSubmitBehavior="false" />
	<br />
	
	<script type="text/javascript">
		var control = null;

		function pageLoad() {
			control = $find("<%= lnkControl.ClientID %>");
		}

		function changeText() {
			var ctl = $get("<%= txtClientText.ClientID %>");
			control.set_text(ctl.value);
			control.refreshUI();

			n$.Debug.write("Text has changed");
		}

		function changeClickAction() {
			var ctl = $get("<%= ddlClientClickAction.ClientID %>");
			control.set_clickAction(eval("Nucleo.Web.Controls.LinkClickAction." + ctl.options[ctl.selectedIndex].value));
			control.refreshUI();

			n$.Debug.write("Link click action has changed");
		}

		function changeNavigateUrl() {
			var ctl = $get("<%= txtClientNavigateUrl.ClientID %>");
			control.set_navigateUrl(ctl.value);
			control.refreshUI();

			n$.Debug.write("NavigateUrl has changed");
		}

		function changeTarget() {
			var ctl = $get("<%= ddlClientTarget.ClientID %>");
			control.set_target(eval("Nucleo.Web.Controls.LinkTargetOptions." + ctl.options[ctl.selectedIndex].value));
			control.refreshUI();

			n$.Debug.write("Target has changed");
		}

		function lnkControl_Clicked(sender, e) {
			n$.Debug.write("Link clicked on client");
		}
	</script>
</asp:Content>
