<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThirdTab.ascx.cs" Inherits="Nucleo.Scenarios.Tabs.ThirdTab" %>

<div>
	This is my third tab.
</div>
<div>
	<asp:UpdatePanel ID="upClientUpdate" runat="server">
		<ContentTemplate>
			<div>
				<asp:TextBox ID="txtOutput" runat="server" />
			</div>
			<div>
				<asp:Label ID="lblOutput" runat="server" EnableViewState="false" />
			</div>
			<div>
				<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
</div>