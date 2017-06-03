<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.Check.FirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1 class="TestHeader">Client-Side Checkbox Toggles Through Checks</h1>
	<div>
		<n:Check ID="chkServerSideTest" runat="server" Checked="True" RenderingMode="ClientAndServer">
			<TrueImage ImageUrl="~/TestImages/check_yes.gif" DisabledImageUrl="~/TestImages/check_yes_disabled.gif" />
			<FalseImage ImageUrl="~/TestImages/check_no.gif" DisabledImageUrl="~/TestImages/check_no_disabled.gif" />
		</n:Check>
	</div>

	<h1 class="TestHeader">Client-Side Checkbox Disabled</h1>
	<div>
		<n:Check ID="chkClientSideDisabled" runat="server" Checked="False" RenderingMode="ClientAndServer" Enabled="false">
			<TrueImage ImageUrl="~/TestImages/check_yes.gif" DisabledImageUrl="~/TestImages/check_yes_disabled.gif" />
			<FalseImage ImageUrl="~/TestImages/check_no.gif" DisabledImageUrl="~/TestImages/check_no_disabled.gif" />
		</n:Check>
	</div>

	<h1 class="TestHeader">Server-Side Postbacks</h1>
	<div>
		<n:Check ID="chkServerSidePostback" runat="server" Checked="False" RenderingMode="ServerOnly" Enabled="true">
			<TrueImage ImageUrl="~/TestImages/check_yes.gif" DisabledImageUrl="~/TestImages/check_yes_disabled.gif" />
			<FalseImage ImageUrl="~/TestImages/check_no.gif" DisabledImageUrl="~/TestImages/check_no_disabled.gif" />
		</n:Check>
	</div>

	<h1 class="TestHeader">Custom Images</h1>
	<div>
		<n:Check ID="chkControl" runat="server" RenderingMode="ClientOnly" AllowEmptyCheckState="true" />
	</div>

</asp:Content>
