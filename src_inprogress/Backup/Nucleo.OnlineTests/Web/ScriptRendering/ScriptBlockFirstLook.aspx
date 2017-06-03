<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ScriptBlockFirstLook.aspx.cs" Inherits="Nucleo.Web.ScriptRendering.ScriptBlockFirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div id="FirstScripts">
		<n:ScriptSection ID="ss1" runat="server" RegionName="First" />
	</div>

	<n:ScriptBlock ID="sb1" runat="server" RegionName="Second">
		<script type="text/javascript">
			var a = 1;
		</script>
	</n:ScriptBlock>
	<n:ScriptBlock ID="sb2" runat="server" RegionName="First">
		<script type="text/javascript">
			var b = 2;
		</script>
	</n:ScriptBlock>
	<n:ScriptBlock ID="sb3" runat="server" RegionName="First">
		<script type="text/javascript">
			var c = 3;
		</script>
	</n:ScriptBlock>

	<div id="SecondScripts">
		<n:ScriptSection ID="ss2" runat="server" RegionName="Second" />
	</div>

</asp:Content>
