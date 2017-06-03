<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="CustomTemplates.aspx.cs" Inherits="Nucleo.Web.FormItemDisplay.CustomTemplates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:FormItemContainer ID="fc" runat="server">
		<Sections>
			<n:FormItemSection ID="fs1" runat="server">
				<Content>
					<Template>
						<div style="width:50px;height:50px;border:1px solid black;">
							First Section Custom Content
						</div>
					</Template>
				</Content>
			</n:FormItemSection>
			<n:FormItemSection ID="fs2" runat="server">
				<Content>
					<Template>
						<div style="width:50px;height:50px;border:1px solid black;">
							Second Section Custom Content
						</div>
					</Template>
				</Content>
			</n:FormItemSection>
		</Sections>
	</n:FormItemContainer>

</asp:Content>
