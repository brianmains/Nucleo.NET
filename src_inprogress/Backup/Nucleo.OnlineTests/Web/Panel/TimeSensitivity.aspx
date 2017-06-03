<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="TimeSensitivity.aspx.cs" Inherits="Nucleo.Web.Panel.TimeSensitivity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1>Panel Should Be Hidden</h1>
	<div>
		<n:Panel ID="pnlTimeSensitivityHidden" runat="server">
			<TimeSensitivity FilterBeginDate="1/1/2000" FilterEndDate="1/1/2001" />
			<Content>
				<Template>
					This should be hidden.
				</Template>
			</Content>
		</n:Panel>
	</div>

	<h1>Panel Should Appear</h1>
	<div>
		<n:Panel ID="pnlTimeSensitivityVisible" runat="server">
			<TimeSensitivity FilterBeginDate="1/1/2000" FilterEndDate="12/31/9999" />
			<Content>
				<Template>
					This should be visible.
				</Template>
			</Content>
		</n:Panel>
	</div>

</asp:Content>
