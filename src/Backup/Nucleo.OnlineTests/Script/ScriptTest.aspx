<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="ScriptTest.aspx.cs" Inherits="Nucleo.Script.ScriptTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<script language="javascript" type="text/javascript">
		Type.registerNamespace("Nucleo");

		Nucleo.TestClass = function() { }

		Nucleo.TestClass.prototype = {
			doThis: function() { }
		}

		Nucleo.TestClass.registerClass("Nucleo.TestClass");

		function pageLoad() {
			Nucleo.TestClass._name = null;
			Nucleo.TestClass.prototype["get_name"] = function() { return this._name; }
			Nucleo.TestClass.prototype["set_name"] = function(value) { this._name = value; }

			Nucleo.TestClass.prototype["add_clicked"] = function(h) {
				this.get_events().addHandler("clicked", h);
			}

			Nucleo.TestClass.prototype["remove_clicked"] = function(h) {
				this.get_events().removeHandler("clicked", h);
			}

			Nucleo.TestClass.prototype["_onclicked"] = function(e) {
				var h = this.get_events().getHandler("clicked");
				if (h) h(this, e);
			}

			var o = new Nucleo.TestClass();
			o.set_name("Brian");
			o.add_clicked(function(sender, e) {
				alert('clicked');
			});

			alert(o.get_name());
			o._onclicked(Sys.EventArgs.Empty);
		}
	</script>

</asp:Content>
