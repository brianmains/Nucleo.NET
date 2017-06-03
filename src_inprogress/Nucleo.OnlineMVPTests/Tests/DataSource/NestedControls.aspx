<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NestedControls.aspx.cs" Inherits="Nucleo.Tests.DataSource.NestedControls" %>
<%@ Register TagPrefix="uc" TagName="NestedControls01" Src="~/Tests/DataSource/NestedControls01.ascx" %>
<%@ Register TagPrefix="uc" TagName="NestedControls02" Src="~/Tests/DataSource/NestedControls02.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
		
		<h1>Page Binding</h1>
		<div>
			<uc:NestedControls02 id="ucData2" runat="server" />
		</div>

		<h1>User Control View Binding</h1>
		<div>
			<uc:NestedControls01 id="ucData1" runat="server" />
		</div>

    </form>
</body>
</html>
