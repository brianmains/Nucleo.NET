<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Nucleo.Web.ListControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Pageable List First Look
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
	<%= Html.NucleoControls().PageableList().RenderCss() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<p>
    <%
		Html.NucleoControls().PageableList().Name("ListHorizontal")
			.ImageOptions((options) => 
			{
				options.DownImageUrl = "~/Content/Images/downarrow.png";
				options.LeftImageUrl = "~/Content/Images/leftarrow.png";
				options.RightImageUrl = "~/Content/Images/rightarrow.png";
				options.UpImageUrl = "~/Content/Images/uparrow.png";
			})
			.ListSettings(0, 4)
			.Orientation(Orientation.Horizontal)
			.Items((items) =>
			{
				items.Add().Content(() => { %> A <% });
				items.Add().Content(() => { %> B <% });
				items.Add().Content(() => { %> C <% });
				items.Add().Content(() => { %> D <% });
				items.Add().Content(() => { %> E <% });
				items.Add().Content(() => { %> F <% });
				items.Add().Content(() => { %> G <% });
				items.Add().Content(() => { %> H <% });
				items.Add().Content(() => { %> I <% });
				items.Add().Content(() => { %> J <% });
				items.Add().Content(() => { %> K <% });
				items.Add().Content(() => { %> L <% });
				items.Add().Content(() => { %> M <% });
				items.Add().Content(() => { %> N <% });
			}).Render();
    %>
    </p>
    
    <p>
     <%
		Html.NucleoControls().PageableList().Name("ListVertical")
			.ImageOptions((options) => 
			{
				options.DownImageUrl = "~/Content/Images/downarrow.png";
				options.LeftImageUrl = "~/Content/Images/leftarrow.png";
				options.RightImageUrl = "~/Content/Images/rightarrow.png";
				options.UpImageUrl = "~/Content/Images/uparrow.png";
			})
			.ListSettings(0, 4)
			.Orientation(Orientation.Vertical)
			.Items((items) =>
			{
				items.Add().Content(() => { %> A <% });
				items.Add().Content(() => { %> B <% });
				items.Add().Content(() => { %> C <% });
				items.Add().Content(() => { %> D <% });
				items.Add().Content(() => { %> E <% });
				items.Add().Content(() => { %> F <% });
				items.Add().Content(() => { %> G <% });
				items.Add().Content(() => { %> H <% });
				items.Add().Content(() => { %> I <% });
				items.Add().Content(() => { %> J <% });
				items.Add().Content(() => { %> K <% });
				items.Add().Content(() => { %> L <% });
				items.Add().Content(() => { %> M <% });
				items.Add().Content(() => { %> N <% });
			}).Render();
    %>
    </p>

</asp:Content>