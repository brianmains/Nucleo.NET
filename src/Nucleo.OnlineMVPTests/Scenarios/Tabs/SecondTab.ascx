<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SecondTab.ascx.cs" Inherits="Nucleo.Scenarios.Tabs.SecondTab" %>

<div>
	This is my second tab.
</div>
<div>
	<asp:TextBox ID="txtOutput" runat="server" />
</div>
<div>
	<asp:Label ID="lblOutput" runat="server" EnableViewState="false" />
</div>
<div>
	<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
</div>