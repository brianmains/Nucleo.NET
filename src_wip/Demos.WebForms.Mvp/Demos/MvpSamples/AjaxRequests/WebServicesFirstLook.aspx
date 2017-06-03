<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="WebServicesFirstLook.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.AjaxRequests.WebServicesFirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<asp:ScriptManagerProxy ID="smp" runat="server">
		<Services>
			<asp:ServiceReference Path="~/Demos/MvpSamples/WebServices/MvpSampleService.asmx" InlineScript="true" />
		</Services>
	</asp:ScriptManagerProxy>


	<div>
		<asp:Label ID="lblOutput" runat="server" />
	</div>
	<div>
		<input type="button" onclick="displayData();" value="Show Data" />
	</div>

	<script type="text/javascript">
		function displayData() {
			Nucleo.WebServices.MvpSampleService.GetValues(
				function (data) {
					var lbl = $get("<%= lblOutput.ClientID %>");

					lbl.innerHTML = "The values loaded were: ";
					for (var i = 0, len = data.length; i < len; i++) {
						lbl.innerHTML += data[i].toString();
					}
				},
				function (error) {
					debugger;
					$get("<%= lblOutput.ClientID %>").innerHTML = "An error occurred: " + error.toString();
				});
		}
	</script>

</asp:Content>
