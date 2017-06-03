<%@ Page Title="DropDown First Look" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.DropDown.FirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<p>
		<n:DropDown ID="ddl" runat="server">
			<Content>
				<Template>
					This is my template.
				</Template>
			</Content>
		</n:DropDown>
	</p>
	<p>
		<n:DropDown ID="DropDown1" runat="server" Text="Default">
			<InputOptions Enabled="false" />
			<MenuOptions Width="500" />
			<Content>
				<Template>
					This is my template.
				</Template>
			</Content>
		</n:DropDown>
	</p>

</asp:Content>
