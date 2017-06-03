<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.HiddenField.FirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	<n:HiddenFieldManager ID="hdnManager" runat="server" />

	<n:HiddenField ID="hdn1" runat="server" Value="First" Key="Numbers" />
	<n:HiddenField ID="hdn2" runat="server" Value="Second" Key="Numbers" />
	<n:HiddenField ID="hdn3" runat="server" Value="Third" Key="Numbers" />

	<n:HiddenField ID="hdnA" runat="server" Value="A" Key="Letters" />
	<n:HiddenField ID="hdnB" runat="server" Value="B" Key="Letters" />
	<n:HiddenField ID="hdnC" runat="server" Value="C" Key="Letters" />
	<n:HiddenField ID="hdnD" runat="server" Value="D" Key="Letters" />
	<n:HiddenField ID="hdnE" runat="server" Value="E" Key="Letters" />

	<asp:GridView ID="gvw" runat="server" AutoGenerateColumns="false">
		<Columns>
			<asp:BoundField HeaderText="ID" DataField="ID" />
			<asp:BoundField HeaderText="Name" DataField="Name" />
			<asp:TemplateField>
				<ItemTemplate>
					<n:HiddenField ID="hdn" runat="server" Value='<%# Eval("ID") %>' Key="Grid" />
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>

	<br /><br />

	Server Results:<br />
	<asp:Label ID="ServerOutput" runat="server" />
	<hr />

	Client Results:<br />
	<span id="ClientOutput"></span>

	<script language="javascript" type="text/javascript">
		Sys.Application.add_load(HiddenFieldLoad);

		function HiddenFieldLoad() {
			var label = $get("ClientOutput");

			var manager = $find("<%= hdnManager.ClientID %>");
			var letters = manager.getKeyValues("Letters");
			label.innerHTML = "";

			for (var letterIndex = 0; letterIndex < letters.length; letterIndex++) {
				label.innerHTML += String.format("Letter Value: {0}<br />", letters[letterIndex]);
			}

			var number = manager.getFirstKeyValue("Numbers");
			label.innerHTML += String.format("Single Value: {0}<br />", number);
		}
	</script>

</asp:Content>