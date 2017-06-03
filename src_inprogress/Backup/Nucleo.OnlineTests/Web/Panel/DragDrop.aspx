<%@ Page Title="Drag/Drop" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="DragDrop.aspx.cs" Inherits="Nucleo.Web.Panel.DragDrop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.DragPanels
		{
			height:50;
			width:50;
		}
		
		.DropPanels
		{
			height:100px;
			width:100px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div style="height:400px">
		<n:Panel ID="p1" runat="server" CssClass="DragPanels">
			<DragDrop Operation="Drag" />
			<content>
				<Template>
					Drag Content
				</Template>
			</content>
		</n:Panel>

		<n:Panel ID="p2" runat="server" CssClass="DragPanels">
			<DragDrop Operation="Drag" />
			<content>
				<Template>
					Drag Content
				</Template>
			</content>
		</n:Panel>

		<n:Panel ID="p3" runat="server" CssClass="DragPanels">
			<DragDrop Operation="Drag" />
			<content>
				<Template>
					Drag Content
				</Template>
			</content>
		</n:Panel>

		<n:Panel ID="pDrop" runat="server">
			<DragDrop Operation="Drop" />
			<content>
				<Template>
					Drop Content
				</Template>
			</content>
		</n:Panel>
	</div>

</asp:Content>
