<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CodeWindow.ascx.cs" Inherits="Nucleo.Layout.CodeWindow" %>

<asp:Panel ID="Window" runat="server" CssClass="CodeWindow">
	<div>
		<asp:UpdatePanel ID="upFiles" runat="server" UpdateMode='Always'>
			<ContentTemplate>
				<div>
					<div>
						Select File:
						<asp:DropDownList ID="ddlFiles" runat="server" AutoPostBack="true" DataTextField="FileDisplayName"
							DataValueField="FileFullName" OnSelectedIndexChanged="ddlFiles_SelectedIndexChanged" />
					</div>
					<br />

					<div class="CodeContent">
						<asp:Label ID="Content" runat="server" />
					</div>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
</asp:Panel>
