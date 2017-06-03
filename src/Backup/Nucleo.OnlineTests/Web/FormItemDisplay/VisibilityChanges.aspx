<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="VisibilityChanges.aspx.cs" Inherits="Nucleo.Web.FormItemDisplay.VisibilityChanges" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div>
	<n:FormItemSection ID="s1" runat="server">
		<Items>
			<n:FormItemDisplay ID="d1" runat="server" Header="User Name">
				<ReadOnlyTemplate>
					<Template>
						*********
					</Template>
				</ReadOnlyTemplate>
			</n:FormItemDisplay>
			<n:FormItemDisplay ID="d2" runat="server" Header="Password">
				<ReadOnlyTemplate>
					<Template>
						********
					</Template>
				</ReadOnlyTemplate>
			</n:FormItemDisplay>
			<n:FormItemDisplay ID="d3" runat="server" Header="Application Name">
				<ReadOnlyTemplate>
					<Template>
						**********
					</Template>
				</ReadOnlyTemplate>
			</n:FormItemDisplay>
			<n:FormItemDisplay ID="FormItemDisplay2" runat="server" Header="Environment">
				<ReadOnlyTemplate>
					<Template>
						********
					</Template>
				</ReadOnlyTemplate>
			</n:FormItemDisplay>
		</Items>
	</n:FormItemSection>
	</div>

	<div>
		<asp:Button ID="btnToggle" runat="server" Text="Toggle Random Visibility" OnClick="btnToggle_Click" />
	</div>
</asp:Content>
