<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TabPage.aspx.cs" Inherits="Nucleo.Scenarios.Tabs.TabPage" %>


<%@ Register src="FirstTab.ascx" tagname="FirstTab" tagprefix="uc" %>
<%@ Register src="SecondTab.ascx" tagname="SecondTab" tagprefix="uc" %>
<%@ Register src="ThirdTab.ascx" tagname="ThirdTab" tagprefix="uc" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<act:TabContainer id="tabs" runat="server">
		<act:TabPanel ID="t1" runat="server" HeaderText="First Tab">
			<ContentTemplate>
				<uc:FirstTab ID="FirstTab" runat="server" />
			</ContentTemplate>
		</act:TabPanel>
		<act:TabPanel ID="t2" runat="server" HeaderText="Second Tab">
			<ContentTemplate>
				<uc:SecondTab ID="SecondTab" runat="server" />
			</ContentTemplate>
		</act:TabPanel>
		<act:TabPanel ID="t3" runat="server" HeaderText="Third Tab">
			<ContentTemplate>
				<uc:ThirdTab ID="ThirdTab" runat="server" />
			</ContentTemplate>
		</act:TabPanel>
	</act:TabContainer>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
