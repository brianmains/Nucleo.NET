<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ServerSideAPI.aspx.cs" Inherits="Nucleo.Web.Mapping.ServerSideAPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	<!-- Additionally postback to server and process object on server -->

	<h1 class="TestHeader">Extracting Objects On Client Test</h1>
	<n:ControlMappingManager ID="cmmClientSideInfo" runat="server" />
		
	First Name:
	<asp:TextBox ID="txtStaticFirstName" runat="server"></asp:TextBox>
	<n:ControlMappingExtender ID="cmeStaticFirstName" runat="server" TargetControlID="txtStaticFirstName"
		ManagerID="cmmClientSideInfo" MappedName="FirstName" />
	<br />
	
	Last Name:
	<asp:TextBox ID="txtStaticLastName" runat="server"></asp:TextBox>
	<n:ControlMappingExtender ID="cmeStaticLastName" runat="server" TargetControlID="txtStaticLastName"
		ManagerID="cmmClientSideInfo" MappedName="LastName" />
	<br />
	
	City:
	<asp:TextBox ID="txtStaticCity" runat="server"></asp:TextBox>
	<n:ControlMappingExtender ID="cmeStaticCity" runat="server" TargetControlID="txtStaticCity"
		ManagerID="cmmClientSideInfo" MappedName="City" />
	<br />
		
	State:
	<asp:TextBox ID="txtStaticState" runat="server"></asp:TextBox>
	<n:ControlMappingExtender ID="cmeStaticState" runat="server" TargetControlID="txtStaticState"
		ManagerID="cmmClientSideInfo" MappedName="State" />
	<br />
	
	Zip Code:
	<asp:TextBox ID="txtStaticZipCode" runat="server"></asp:TextBox>
	<n:ControlMappingExtender ID="cmeStaticZipCode" runat="server" TargetControlID="txtStaticZipCode"
		ManagerID="cmmClientSideInfo" MappedName="ZipCode" />
	<br /><br />
	
	<asp:Button ID="btnStaticCreateNew" runat="server" Text="Create New" OnClientClick="createNewObject();return false;" />
	<asp:Button ID="btnStaticLoad" runat="server" Text="Load" OnClientClick="loadObject();return false;" />
	<asp:Button ID="btnStaticUpdate" runat="server" Text="Update" OnClientClick="updateObject();return false;" />
	
	<br /><br />


	
	<asp:Label ID="lblOutput" runat="server"></asp:Label>
	
	<script type="text/javascript">
		function createNewObject() {
			var manager = $find("<%= cmmClientSideInfo.ClientID %>");
			var obj = manager.createObject();

			_writeObject(obj);
		}

		function loadObject() {
			var obj = { FirstName: 'Joe', LastName: 'Test', City: 'Tempe', State: 'AZ', ZipCode: '11111' };
			var manager = $find("<%= cmmClientSideInfo.ClientID %>");

			manager.loadObject(obj);
		}

		function updateObject() {
			var obj = { FirstName: 'Joe', LastName: 'Test', City: 'Tempe', State: 'AZ', ZipCode: '11111' };
			var manager = $find("<%= cmmClientSideInfo.ClientID %>");
			manager.updateObject(obj);

			_writeObject(obj);
		}

		function _writeObject(obj) {
			var label = $get("<%= lblOutput.ClientID %>");
			
			label.innerHTML = String.format("{0} {1} - {2}, {3} {4}",
				obj.FirstName, obj.LastName, obj.City, obj.State, obj.ZipCode);
		}
	</script>

</asp:Content>