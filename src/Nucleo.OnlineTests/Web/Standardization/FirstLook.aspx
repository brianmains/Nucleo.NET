<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.Standardization.FirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:StandardizationManager ID="Standards" runat="server" ClientIDMode="Static" />

	<div>
		Standard Page Header:
		<n:PageHeader runat="server" Text="My Page Header" />
	</div>
	<div>
		Page Header Extracts Info From Page:
		<n:PageHeader runat="server" />
	</div>
	<div>
		Section Header:
		<n:SectionHeader runat="server" Text="My Section Header" />
	</div>
	<div>
		Form Field Label:
		<n:FormFieldLabel runat="server" Text="Form Field:" />
		<asp:TextBox runat="server" />
	</div>

	<div>
		<n:ContentList runat="server">
			<Items>
				<n:ContentListItem runat="server">
					This is content area 1.
				</n:ContentListItem>
				<n:ContentListItem runat="server">
					This is content area 2.
				</n:ContentListItem>
				<n:ContentListItem runat="server">
					This is content area 3.
				</n:ContentListItem>
			</Items>
		</n:ContentList>
	</div>

</asp:Content>
