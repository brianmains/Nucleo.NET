<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FormContainerFirstLook.aspx.cs" Inherits="Nucleo.Web.FormItemDisplay.FormContainerTemplates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	<div>
		<n:FormItemContainer ID="fc" runat="server">
			<Sections>
				<n:FormItemSection ID="s1" runat="server">
					<Items>
						<n:FormItemDisplay ID="d1" runat="server" Header="User Name">
							<ReadOnlyTemplate>
								<Template>
									**********
								</Template>
							</ReadOnlyTemplate>
							<EditTemplate>
								<Template>
									<asp:TextBox ID="EditUserName" runat="server" Text="Editing" />
								</Template>
							</EditTemplate>
							<InsertTemplate>
								<Template>
									<asp:TextBox ID="InsertUserName" runat="server" />
								</Template>
							</InsertTemplate>
						</n:FormItemDisplay>
						<n:FormItemDisplay ID="d2" runat="server" Header="Password">
							<ReadOnlyTemplate>
								<Template>
									********
								</Template>
							</ReadOnlyTemplate>
							<EditTemplate>
								<Template>
									<asp:TextBox ID="EditPassword" runat="server"  Text="Editing" />
								</Template>
							</EditTemplate>
							<InsertTemplate>
								<Template>
									<asp:TextBox ID="InsertPassword" runat="server" />
								</Template>
							</InsertTemplate>
						</n:FormItemDisplay>
					</Items>
				</n:FormItemSection>

				<n:FormItemSection ID="s2" runat="server">
					<Items>
						<n:FormItemDisplay ID="d3" runat="server" Header="Application Name">
							<ReadOnlyTemplate>
								<Template>
									**********
								</Template>
							</ReadOnlyTemplate>
							<EditTemplate>
								<Template>
									<asp:TextBox ID="TextBox1" runat="server" Text="Editing" />
								</Template>
							</EditTemplate>
							<InsertTemplate>
								<Template>
									<asp:TextBox ID="TextBox2" runat="server" />
								</Template>
							</InsertTemplate>
						</n:FormItemDisplay>
						<n:FormItemDisplay ID="FormItemDisplay2" runat="server" Header="Environment">
							<ReadOnlyTemplate>
								<Template>
									********
								</Template>
							</ReadOnlyTemplate>
							<EditTemplate>
								<Template>
									<asp:TextBox ID="TextBox3" runat="server"  Text="Editing" />
								</Template>
							</EditTemplate>
							<InsertTemplate>
								<Template>
									<asp:TextBox ID="TextBox4" runat="server" />
								</Template>
							</InsertTemplate>
						</n:FormItemDisplay>
					</Items>
				</n:FormItemSection>
			</Sections>
		</n:FormItemContainer>
	</div>

	<div>
		<asp:DropDownList ID="ddlNewServerMode" runat="server" AutoPostBack="true" 
			OnSelectedIndexChanged="ddlNewServerMode_SelectedIndexChanged">
			<asp:ListItem>ReadOnly</asp:ListItem>
			<asp:ListItem>Edit</asp:ListItem>
			<asp:ListItem>Insert</asp:ListItem>
		</asp:DropDownList>
	</div>

</asp:Content>
