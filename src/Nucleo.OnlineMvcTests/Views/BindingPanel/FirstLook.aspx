<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Nucleo.Models.BindingPanel.BindingPanelModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Binding Panel First Look
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<p>
		<strong>Normal Data</strong><br />
	
		<% Html.NucleoControls().BindingPanel(Model.Data).Content((data) =>
		   {
				%>
					
					<% foreach (var item in Model.Data) { %>
						
						<div>
							<%= item.Name %>
							
							<div>
								<%= item.City %>, <%= item.State %>
							</div>
						</div>
						
					<% } %>
									
				<%
		   })
		   .NoDataContent(() =>
		   {
				%>
					No data has been supplied.
				<%
		   })
		   .Render(); %>
	</p>
	
	<p>
		<strong>Empty Data</strong><br />
	
		<% Html.NucleoControls().BindingPanel(Model.EmptyData).Content((data) =>
		   {
				%>
					
					<% foreach (var item in Model.Data) { %>
						
						<div>
							<%= item.Name %>
							
							<div>
								<%= item.City %>, <%= item.State %>
							</div>
						</div>
						
					<% } %>
				
				<%
		   })
		   .NoDataContent(() =>
		   {
				%>
				
					No data has been supplied.
				
				<%
		   })
		   .Render(); %>
	</p>
	
	<p>
		<strong>Null Data</strong><br />
	
		<% Html.NucleoControls().BindingPanel(Model.NullData).Content((data) =>
		   {
				%>
				
					<%= data.Name %>
				
				<%
		   })
		   .NoDataContent(() =>
		   {
				%>
				
					No data has been supplied.
				
				<%
		   })
		   .Render(); %>
	</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
