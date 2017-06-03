<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ClientSideAPI.aspx.cs" Inherits="Nucleo.Web.Check.ClientSideAPI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	<br />
	
	<n:Check ID="chkControl" runat="server" RenderingMode="ClientOnly">
		<TrueImage ImageUrl="~/TestImages/check_yes.gif" DisabledImageUrl="~/TestImages/check_yes_disabled.gif" />
		<FalseImage ImageUrl="~/TestImages/check_no.gif" DisabledImageUrl="~/TestImages/check_no_disabled.gif" />
		<EmptyImage ImageUrl="~/TestImages/check_empty.gif" DisabledImageUrl="~/TestImages/check_empty_disabled.gif" />
	</n:Check>
	<br /><br />

	<strong>Client-Side Functions</strong>
	
	<div>
		Text:
		<asp:TextBox ID="txtText" runat="server"></asp:TextBox>
	</div>

	<div>
		Checked:
		<asp:DropDownList ID="ddlChecked" runat="server">
			<asp:ListItem Value="True">Yes</asp:ListItem>
			<asp:ListItem Value="False">No</asp:ListItem>
			<asp:ListItem Value="">Empty</asp:ListItem>
		</asp:DropDownList>
	</div>

	<div>
		Allow Empty Check:
		<asp:CheckBox ID="chkAllowEmptyState" runat="server" />
	</div>
	
	<div>
		Enabled
		<asp:CheckBox ID="chkEnabled" runat="server" />
	</div>
	<div>
		<asp:Button ID="btnChangeClient" runat="server"
			Text="Change Client Settings" OnClientClick="changeSettings();return false;" />
	</div>

	<script type="text/javascript" language="javascript">
		function changeSettings() {
			var control = $find("<%= chkControl.ClientID %>");
			control.set_text($get("<%= txtText.ClientID %>").value);
			control.set_enabled($get("<%= chkEnabled.ClientID %>").checked);
			control.set_allowEmptyCheckState($get("<%= chkAllowEmptyState.ClientID %>").checked);

			var checked = $get("<%= ddlChecked.ClientID %>").value;
			if (checked == "")
				checked = null;
			else
				checked = Boolean.parse(checked);
			
			control.set_checked(checked);
		}
	</script>

</asp:Content>
