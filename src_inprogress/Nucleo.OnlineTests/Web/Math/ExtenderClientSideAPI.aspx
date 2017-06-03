<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ExtenderClientSideAPI.aspx.cs" Inherits="Nucleo.Web.Math.ExtenderClientSideAPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<table cellspacing="0" border="0">
		<thead>
		</thead>
		<tbody>
			<tr>
				<td>
					First:
				</td>
				<td>
					<asp:TextBox ID="txtFirst" runat="server" />
					<n:CalculatedFieldExtender ID="extFirst" runat="server" TargetControlID="txtFirst"
						CalculatorControlID="extTotal" />
				</td>
			</tr>
			<tr>
				<td>
					Second:
				</td>
				<td>
					<asp:TextBox ID="txtSecond" runat="server" />
					<n:CalculatedFieldExtender ID="extSecond" runat="server" TargetControlID="txtSecond"
						CalculatorControlID="extTotal" />
				</td>
			</tr>
			<tr>
				<td>
					Third:
				</td>
				<td>
					<asp:TextBox ID="txtThird" runat="server" />
					<n:CalculatedFieldExtender ID="extThird" runat="server" TargetControlID="txtThird"
						CalculatorControlID="extTotal" />
				</td>
			</tr>
			<tr>
				<td>
					Fourth:
				</td>
				<td>
					<asp:TextBox ID="txtFourth" runat="server" />
					<n:CalculatedFieldExtender ID="extFourth" runat="server" TargetControlID="txtFourth"
						CalculatorControlID="extTotal" />
				</td>
			</tr>
			<tr>
				<td>
					Fifth:
				</td>
				<td>
					<asp:TextBox ID="txtFifth" runat="server" />
					<n:CalculatedFieldExtender ID="extFifth" runat="server" TargetControlID="txtFifth"
						CalculatorControlID="extTotal" />
				</td>
			</tr>
			<tr>
				<td>
					Sixth:
				</td>
				<td>
					<asp:TextBox ID="txtSixth" runat="server" />
					<n:CalculatedFieldExtender ID="extSixth" runat="server" TargetControlID="txtSixth"
						CalculatorControlID="extTotal" />
				</td>
			</tr>
			<tr>
				<td>
					Summation:
				</td>
				<td>
					<asp:Label ID="lblTotal" runat="server" />
					<n:CalculatorExtender ID="extTotal" runat="server" TargetControlID="lblTotal" OnClientControlValueUnassigned="CalculatorExtender_ControlValueUnassigned">
						
					</n:CalculatorExtender>
				</td>
			</tr>
		</tbody>
	</table>
	
	<br /><br />
	
	<asp:Label ID="lblOutput" runat="server" />

	<script type="text/javascript">
		function CalculatorExtender_ControlValueUnassigned(sender, e) {
			var extender = $find('<%= extTotal.ClientID %>');
			var label = $get('<%= lblTotal.ClientID %>');
			label.innerText = extender.get_totalValue().toString();

			$get("<%= lblOutput.ClientID %>").innerHTML += "Control value unassigned event fired<br/>";
		}
	</script>

</asp:Content>
