<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AjaxCallback.ascx.cs" Inherits="Nucleo.Tests.AjaxRequests.AjaxCallback" %>


<div>
	<asp:Label ID="lblOutput" runat="server" />
</div>
<div>
	<asp:TextBox ID="txtValue" runat="server" />
	<asp:Button ID="btnValue" runat="server" Text="Add" OnClientClick="addNew();return false;" />
</div>

<n:ScriptBlock ID="sbPresenterAjax" runat="server" RegionName="Presenter">
	<script type="text/javascript">
		function updateLabel() {
			n$.Presenters["AjaxCallbackPresenter"].GetItems(function (response) {
				$get("<%= lblOutput.ClientID %>").innerHTML = response.data.toString();
			});
		}

		Sys.Application.add_load(function () {
			updateLabel();
		});

		function addNew() {
			n$.Presenters["AjaxCallbackPresenter"].AddItem($get("<%= txtValue.ClientID %>").value, function (response) {
				updateLabel();
				$get("<%= txtValue.ClientID %>").value = "";
			});
		}
	</script>
</n:ScriptBlock>