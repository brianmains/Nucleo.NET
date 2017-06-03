using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Nucleo.Reflection;


namespace Nucleo.Web.Pages
{
	/// <summary>
	/// Represents a fake page used to assist with unit testing.
	/// </summary>
	public class FakePage : PageBase
	{

		#region " Constructors "

		/// <summary>
		/// Creates an empty page.
		/// </summary>
		public FakePage() { }

		/// <summary>
		/// Creates a page with a single child control.
		/// </summary>
		/// <param name="control">The control to add.</param>
		public FakePage(Control control)
		{
			this.Controls.Add(control);
			control.Page = this;
		}

		/// <summary>
		/// Creates the page with a collection of controls.  Adds the controls to the page's collection, and sets the Page property for the control.
		/// </summary>
		/// <param name="controls">The controls to add.</param>
		public FakePage(IEnumerable<Control> controls)
		{
			foreach (Control control in controls)
			{
				this.Controls.Add(control);
				control.Page = this;
			}
		}

		#endregion



		#region " Methods "
		
		/// <summary>
		/// Adds the script manager and ajax manager to the controls collection, and makes them available for retrieval.
		/// </summary>
		public void AddAjaxFrameworkControls()
		{
			this.AddAjaxFrameworkControls(true);
		}

		/// <summary>
		/// Adds the script manager and ajax manager to the controls collection, and makes them available for retrieval.
		/// </summary>
		public void AddAjaxFrameworkControls(bool registerInItemsCollection)
		{
			ScriptManager manager = new ScriptManager { Page = this };
			this.Controls.AddAt(0, manager);
			if (registerInItemsCollection)
				this.Items[typeof(ScriptManager)] = manager;

			NucleoAjaxManager ajaxManager = new NucleoAjaxManager { Page = this };
			this.Controls.AddAt(1, ajaxManager);
			if (registerInItemsCollection)
				this.Items[typeof(NucleoAjaxManager)] = ajaxManager;
		}

		public void FireEvent(PageEvent pageEvent)
		{
			this.FireEvent(pageEvent, true);
		}

		/// <summary>
		/// Fires a page lifecycle event.
		/// </summary>
		/// <param name="pageEvent">The event to fire.</param>
		/// <remarks>Useful for testing that certain code runs in a specific event.</remarks>
		/// <example>
		/// var controlToTest = new SomeControl();
		/// var testPage = new FakePage(controlToTest);
		/// 
		/// testPage.FireEvent(PageEvent.Init);
		/// Assert.AreEqual(15, controlToTest.TestValue);
		/// </example>
		public void FireEvent(PageEvent pageEvent, bool fireForChildren)
		{
			switch(pageEvent)
			{
				case PageEvent.Init:
					this.OnInit(EventArgs.Empty);			
					break;
				case PageEvent.InitComplete:
					this.OnInitComplete(EventArgs.Empty);
					break;
				case PageEvent.Load:
					this.OnLoad(EventArgs.Empty);
					break;
				case PageEvent.LoadComplete:
					this.OnLoadComplete(EventArgs.Empty);
					break;
				case PageEvent.PreInit:
					this.OnPreInit(EventArgs.Empty);
					break;
				case PageEvent.PreLoad:
					this.OnPreLoad(EventArgs.Empty);
					break;
				case PageEvent.PreRender:
					this.OnPreRender(EventArgs.Empty);
					break;
				case PageEvent.PreRenderComplete:
					this.OnPreRenderComplete(EventArgs.Empty);
					break;
				case PageEvent.Unload:
					this.OnUnload(EventArgs.Empty);
					break;
				case PageEvent.Validated:
					this.OnValidated(EventArgs.Empty);
					break;
				case PageEvent.Validating:
					this.OnValidating(new System.ComponentModel.CancelEventArgs(false));
					break;
				default:
					throw new NotImplementedException();
			}

			if (fireForChildren)
				this.FireEventForControls(pageEvent);
		}

		private void FireEventForControls(PageEvent pageEvent)
		{
			switch (pageEvent)
			{
				case PageEvent.Init:
					foreach (Control control in this.Controls)
						Reflect.NonPublic(control).Method("OnInit").Invoke(EventArgs.Empty);
					break;
				case PageEvent.Load:
					foreach (Control control in this.Controls)
						Reflect.NonPublic(control).Method("OnLoad").Invoke(EventArgs.Empty);
					break;
				case PageEvent.PreRender:
					foreach (Control control in this.Controls)
						Reflect.NonPublic(control).Method("OnPreRender").Invoke(EventArgs.Empty);
					break;
				default:
					return;
			}
		}

		/// <summary>
		/// Gets a viewstate value by its key.
		/// </summary>
		/// <param name="key">The key to get.</param>
		/// <returns>The value.</returns>
		/// <remarks>Because viewstate is protected, useful for testing purposes.</remarks>
		/// <example>
		/// var testPage = new FakePage();
		/// Assert.AreEqual("1", testPage.GetViewStateValue("First"));
		/// </example>
		public object GetViewStateValue(string key)
		{
			return this.ViewState[key];
		}

		/// <summary>
		/// Sets the viewstate value using the key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		/// <example>
		/// var testPage = new FakePage();
		/// testPage.SetViewStateValue("First", "1");
		/// </example>
		public void SetViewStateValue(string key, object value)
		{
			this.ViewState[key] = value;
		}

		#endregion
	}
}
