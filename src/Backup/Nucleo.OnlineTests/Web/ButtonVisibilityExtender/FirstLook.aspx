<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.ButtonVisibilityExtender.FirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div>
		<asp:Panel ID="p1" runat="server">
			Test hiding target on click.
		</asp:Panel>
		<asp:Button ID="btn1" runat="server" Text="Change Visibility" />

		<n:ButtonVisibilityExtender ID="ext1" runat="server" TargetControlID="btn1" 
			ReceiverControlID="p1" IsVisibleInitially="true" />
	</div>
	<br />

	<div>
		<asp:Panel ID="p2" runat="server">
			Test postback scenario with hidding.
		</asp:Panel>
		<asp:Button ID="btn2" runat="server" Text="Change Visibility With Postback" />

		<n:ButtonVisibilityExtender ID="ext2" runat="server" TargetControlID="btn2" 
			ReceiverControlID="p2" IsVisibleInitially="true"
			AllowPostback="true" />
	</div>
	<br />

	<div>
		<asp:Panel ID="p3" runat="server">
			Test hidden on start.
		</asp:Panel>
		<asp:Button ID="btn3" runat="server" Text="Hidden Initially" />

		<n:ButtonVisibilityExtender ID="ext3" runat="server" TargetControlID="btn3" 
			ReceiverControlID="p3" IsVisibleInitially="false" />
	</div>
	
</asp:Content>
