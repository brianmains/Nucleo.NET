<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Display.ascx.cs" Inherits="Nucleo.Demos.MvpScenarios.TabbedForms.Display" %>

<div>
	<div style="float:left;width:25%;">

		<div>
			<asp:Label ID="Name" runat="server" />
		</div>

		<div>
			<asp:Label ID="Email" runat="server" />
		</div>

		<div>
			<asp:Label ID="UserName" runat="server" />
		</div>

		<div>
			<asp:Label ID="PrimaryPhone" runat="server" />
		</div>
		<div>
			<asp:Label ID="PrimaryAddress" runat="server" />
		</div>

	</div>
	<div style="float:left;">
		
		<div>
			<strong>Addresses</strong>
			<div>
				<asp:DataList ID="Addresses" runat="server">
					<ItemTemplate>
						<asp:Label ID="Label1" runat="server" Text='<%# Eval("Address") %>' />
					</ItemTemplate>
					<SeparatorTemplate>
						<hr style="width:200px;" />
					</SeparatorTemplate>
				</asp:DataList>
			</div>
		</div>

		<br />

		<div>
			<strong>Phones</strong>
			<div>
				<asp:DataList ID="Phones" runat="server">
					<ItemTemplate>
						<asp:Label ID="Label2" runat="server" Text='<%# Eval("Phone") %>' />
					</ItemTemplate>
					<SeparatorTemplate>
						<hr style="width:200px;" />
					</SeparatorTemplate>
				</asp:DataList>
			</div>
		</div>

	</div>
	<div style="clear:both;"></div>
</div>