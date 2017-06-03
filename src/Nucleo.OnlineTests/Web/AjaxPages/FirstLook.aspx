<%@ Page Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.AjaxPages.FirstLook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
		
	<div>
		<span id="TitleSpan"></span>
	</div>

	<div>
		<span id="ErrorMessage" style="font-weight:bold;color:Red;display:none;"></span>
		<br /><br />

		<div>
			Name: <asp:TextBox id="txtName" runat="server"></asp:TextBox>
		</div>
		<div>
			City: <asp:TextBox id="txtCity" runat="server"></asp:TextBox>
		</div>

	</div>

	<div>
		<n:Button ID="btnSubmit" runat="server" Text="Save" UseSubmitBehavior="false" />
	</div>

</asp:Content>