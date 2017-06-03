using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.Controls
{
	public class HiddenField : System.Web.UI.WebControls.HiddenField, IScriptControl
	{
		private HiddenFieldManager _manager = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets a key that groups a specific range of fields.
		/// </summary>
		public string Key
		{
			get { return (string)(ViewState["Key"] ?? null); }
			set { ViewState["Key"] = value; }
		}

		/// <summary>
		/// Gets a reference to the manager for hidden fields.
		/// </summary>
		public HiddenFieldManager Manager
		{
			get { return _manager; }
		}

		/// <summary>
		/// Gets or sets whether the client lifecycle is supported.
		/// </summary>
		public bool SupportsClientLifecycle
		{
			get { return (bool)(ViewState["SupportsClientLifecycle"] ?? true); }
			set { ViewState["SupportsClientLifecycle"] = value; }
		}

		#endregion



		#region " Methods "

		public IEnumerable<ScriptDescriptor> GetScriptDescriptors()
		{
			ScriptControlDescriptor descriptor = new ScriptControlDescriptor("Nucleo.Web.Controls.HiddenField", this.ClientID);
			descriptor.AddProperty("key", this.Key);
			descriptor.AddComponentProperty("manager", this.Manager.ClientID);
			descriptor.AddProperty("value", this.Value);

			return new ScriptDescriptor[] { descriptor };
		}

		public IEnumerable<ScriptReference> GetScriptReferences()
		{
			ScriptReferenceCollection references = new ScriptReferenceCollection();
#if DEBUG
			
			references.Add(Scripts.ReferenceScriptManager.CreateReference(new ScriptReferencingRequestDetails(typeof(HiddenField), ScriptMode.Debug)));
#else
			references.Add(Scripts.ReferenceScriptManager.CreateReference(new ScriptReferencingRequestDetails(typeof(HiddenField), ScriptMode.Release)));
#endif

			return references;
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if (base.DesignMode == true) return;
			if (this.Page == null) return;

			_manager = HiddenFieldManager.GetCurrent(this.Page);
			if (_manager != null)
				_manager.AddField(this);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.SupportsClientLifecycle)
			{
				ScriptManager manager = ScriptManager.GetCurrent(this.Page);
				manager.RegisterScriptControl<HiddenField>(this);
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			if (this.SupportsClientLifecycle)
			{
				ScriptManager manager = ScriptManager.GetCurrent(this.Page);
				manager.RegisterScriptDescriptors(this);
			}

			base.Render(writer);
		}

		#endregion
	}
}
