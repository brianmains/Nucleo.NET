<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NestedControls01.ascx.cs" Inherits="Nucleo.Tests.DataSource.NestedControls01" %>
<%@ Register TagPrefix="uc" TagName="NestedControls02" Src="~/Tests/DataSource/NestedControls02.ascx" %>

<div>
	<uc:NestedControls02 id="ucData" runat="server" />
</div>