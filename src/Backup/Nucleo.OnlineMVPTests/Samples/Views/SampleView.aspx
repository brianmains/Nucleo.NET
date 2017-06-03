<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SampleView.aspx.cs" Inherits="Nucleo.Samples.Views.SampleView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<table>
			<tbody>
				<tr>
					<td>Name</td>
					<td>
						<asp:TextBox ID="txtName" runat="server" />
					</td>
				</tr>
				<tr>
					<td>pwd</td>
					<td>
						<asp:TextBox ID="txtPwd" runat="server" TextMode="Password" />
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Button ID="btnLogin" runat="server" />
					</td>
				</tr>
			</tbody>
		</table>
    </div>
    </form>
</body>
</html>
