using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;


namespace Nucleo.Web.Controls
{
	public class HiddenFieldManager : Control, IScriptControl
	{
		private List<HiddenField> _hiddenFields = null;



		#region " Properties "

		/// <summary>
		/// Gets the list of fields that are hidden, mapped to the hidden field manager.
		/// </summary>
		private List<HiddenField> HiddenFields
		{
			get
			{
				if (_hiddenFields == null)
					_hiddenFields = new List<HiddenField>();
				return _hiddenFields;
			}
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

		/// <summary>
		/// Adds a field to the local collection.
		/// </summary>
		/// <param name="field">The field to add.</param>
		protected internal void AddField(HiddenField field)
		{
			if (field == null)
				throw new ArgumentNullException("field");

			this.HiddenFields.Add(field);
		}

		/// <summary>
		/// Gets a reference to the current page.
		/// </summary>
		/// <param name="page">The page to implement.</param>
		/// <returns>A hidden field manager reference.</returns>
		public static HiddenFieldManager GetCurrent(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			return page.Items[typeof(HiddenFieldManager)] as HiddenFieldManager;
		}

		/// <summary>
		/// Gets the first value for a specified key in the list.
		/// </summary>
		/// <param name="key">The key of the hidden field value in the list.</param>
		/// <returns>The value of the hidden field.</returns>
		public string GetFirstKeyValue(string key)
		{
			return this.GetKeyValues(key)[0];
		}

		/// <summary>
		/// Gets the collection of values for a specified key.
		/// </summary>
		/// <param name="key">The key to get values for.</param>
		/// <returns>The array of values.</returns>
		public string[] GetKeyValues(string key)
		{
			if (key == null)
				throw new ArgumentNullException("key");

			List<string> output = new List<string>();
			foreach (HiddenField hf in this.HiddenFields)
			{
				if (string.Compare(hf.Key, key, StringComparison.CurrentCultureIgnoreCase) == 0)
					output.Add(hf.Key);
			}

			if (output.Count == 0)
				throw new KeyNotFoundException(string.Format("The key '{0}' was not found in the hidden fields collection", key));

			return output.ToArray();
		}

		public IEnumerable<ScriptDescriptor> GetScriptDescriptors()
		{
			ScriptControlDescriptor descriptor = new ScriptControlDescriptor("Nucleo.Web.Controls.HiddenFieldManager", this.ClientID);
			return new ScriptDescriptor[] { descriptor };
		}

		public IEnumerable<ScriptReference> GetScriptReferences()
		{
			ScriptReferenceCollection references = new ScriptReferenceCollection();
#if DEBUG
			references.Add(Scripts.ReferenceScriptManager.CreateReference(new ScriptReferencingRequestDetails(typeof(HiddenFieldManager), ScriptMode.Debug)));
#else
			references.Add(Scripts.ReferenceScriptManager.CreateReference(new ScriptReferencingRequestDetails(typeof(HiddenFieldManager), ScriptMode.Release)));
#endif

			return references;
		}

		/// <summary>
		/// Adds itself to the page's Items collection so all hidden fields can use this value.
		/// </summary>
		/// <param name="e">Empty.</param>
		protected override void OnInit(EventArgs e)
		{
			if (base.DesignMode == true) return;
			if (this.Page == null) return;

			if (this.Page.Items.Contains(typeof(HiddenFieldManager)))
				throw new Exception("There is already a HiddenFieldManager on the page");

			this.Page.Items.Add(typeof(HiddenFieldManager), this);

			base.OnInit(e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.SupportsClientLifecycle)
			{
				ScriptManager manager = ScriptManager.GetCurrent(this.Page);
				manager.RegisterScriptControl<HiddenFieldManager>(this);
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			if (this.SupportsClientLifecycle)
			{
				ScriptManager manager = ScriptManager.GetCurrent(this.Page);
				manager.RegisterScriptDescriptors(this);
			}

			writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
			writer.AddAttribute(HtmlTextWriterAttribute.Type, "HIDDEN");
			writer.RenderBeginTag(HtmlTextWriterTag.Input);
			writer.RenderEndTag();
		}

		#endregion
	}
}
