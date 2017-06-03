using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Web
{
	public partial class TestMasterPage : System.Web.UI.MasterPage
	{
		#region " Properties "

		public string Aspx
		{
			get { return this.AspxLabel.Text; }
			set { this.AspxLabel.Text = value; }
		}

		public string Code
		{
			get { return this.CodeLabel.Text; }
			set { this.CodeLabel.Text = value; }
		}

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		public string Description
		{
			get { return this.DescriptionLabel.Text; }
			set { this.DescriptionLabel.Text = value; }
		}

		#endregion



		#region " Methods "

		private void AddScriptReference(string output)
		{
			this.lblScriptReferenceOutput.Text += output + "<br/>";
		}

		/// <summary>
		/// Adds a statement to the trace console.
		/// </summary>
		/// <param name="statement"></param>
		public void AddTraceStatement(string statement)
		{
			this.TraceConsole.Text += statement + "\n";
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			ScriptManager manager = ScriptManager.GetCurrent(this.Page);
			manager.ResolveScriptReference += asm_ResolveScriptReference;
		}

		#endregion



		#region " Event Handlers "

		protected void asm_ResolveScriptReference(object sender, ScriptReferenceEventArgs e)
		{
			if (!string.IsNullOrEmpty(e.Script.Path))
				this.AddScriptReference("Local: " + e.Script.Path);
			else
			{
				if (!e.Script.Name.StartsWith("AjaxControlToolkit"))
					this.AddScriptReference("Embedded: " + e.Script.Name);
			}
		}

		#endregion
	}
}