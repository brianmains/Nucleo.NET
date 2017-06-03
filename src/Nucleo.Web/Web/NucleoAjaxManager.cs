using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Web.Context;
using Nucleo.Web.Core;
using Nucleo.Web.Controls.Configuration;
using Nucleo.Web.Pages;
using Nucleo.EventArguments;
using Nucleo.Web.Scripts;
using Nucleo.Global;
using Nucleo.Reflection;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents the central AJAX manager to offer core AJAX services.  This component is required on the page.
	/// </summary>
	public class NucleoAjaxManager : ScriptControl
	{
		private AjaxComponentCollection _components = null;
		private IContentRegistrar _registrar = null;
		private ServiceReferenceCollection _services = null;



		#region " Events "

		/// <summary>
		/// Signals that a change occurred with one of its targeted components.
		/// </summary>
		public event ChangeEventHandler ChangesOccurred;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets the collection of components being listened to.
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		public AjaxComponentCollection Components
		{
			get
			{
				if (_components == null)
					_components = new AjaxComponentCollection();
				return _components;
			}
		}

		/// <summary>
		/// Gets or sets whether to detect changes amongst the AJAX controls, a mechanism that controls that support <see cref="ISupportsChangeNotification" /> interface can listen for.
		/// </summary>
		public bool DetectChanges
		{
			get { return (bool)(ViewState["DetectChanges"] ?? false); }
			set { ViewState["DetectChanges"] = value; }
		}

		/// <summary>
		/// Gets or sets whether to enable custom theming, instead of specifying it for each individual control.  This specifies it for ALL controls.
		/// </summary>
		public bool EnableCustomTheming
		{
			get { return (bool)(ViewState["EnableCustomTheming"] ?? false); }
			set { ViewState["EnableCustomTheming"] = value; }
		}

		/// <summary>
		/// Gets or sets the scripts to render from the reference script manager.
		/// </summary>
		public string ReferenceScripts
		{
			get { return (string)ViewState["ReferenceScripts"]; }
			set { ViewState["ReferenceScripts"] = value; }
		}

		public IContentRegistrar Registrar
		{
			get
			{
				if (_registrar == null)
				{
					IWebContext context = WebContext.GetCurrent();

					if (context != null)
						_registrar = context.ContentRegistrar;
					else
						_registrar = new ContentRegistrar();
				}

				return _registrar;
			}
		}

		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
		MergableProperty(false)
		]
		public ServiceReferenceCollection Services
		{
			get
			{
				if (_services == null)
					_services = new ServiceReferenceCollection();
				return _services;
			}
		}

		#endregion



		#region " Methods "

		private void AddCssReferencesInternal()
		{
			HtmlHead head = this.Page.Header;
			if (head == null)
				throw new Exception("The <head> attribute is missing or doesn't define the runat='server' attribute");

			CssReferenceCollection cssReferences = this.Registrar.GetCssReferences();

			foreach (CssReference css in cssReferences)
			{
				HtmlLink link = new HtmlLink();
				link.Href = css.Path;
				link.Attributes.Add("type", "text/css");
				link.Attributes.Add("rel", "stylesheet");
				head.Controls.Add(link);
			}
		}

		private void AddReferenceScriptsInternal()
		{
			if (string.IsNullOrEmpty(this.ReferenceScripts))
				return;

			string[] referenceScripts = this.ReferenceScripts.Split(',');
			foreach (string referenceScript in referenceScripts)
				this.Registrar.AddReference(ReferenceScriptManager.GetExternalScriptDetails(referenceScript));
		}

		public static ScriptDescriptor CreateDescriptor(ScriptDescriptionRequestDetails details)
		{
			string clientType = details.ClientType;

			if (details.ControlReference is IScriptControl)
				return new NucleoScriptControlDescriptor(clientType, details.TargetID);
			else if (details.ControlReference is IExtenderControl)
				return new NucleoScriptBehaviorDescriptor(clientType, details.TargetID);
			else
				throw new InvalidCastException("The control being described must be a script or extender control");
		}

		/// <summary>
		/// Returns the script that's used to create the client side registration method for the nucleo framework.  By default, the script tries to use JQuery to do the initialization, but defaults back to the MS AJAX framework.
		/// </summary>
		/// <returns>The script for creating the startup.</returns>
		/// <remarks>This can be customized, but it must return a $nucleo_register method and defining the surrounding &lt;script> tags.</remarks>
		protected virtual string CreateStartupScript()
		{
			return null;
		}

		/// <summary>
		/// Gets the list of components by the reference name.
		/// </summary>
		/// <param name="referenceName"></param>
		/// <returns></returns>
		public AjaxComponentCollection GetByReferenceName(string referenceName)
		{
			AjaxComponentCollection subList = new AjaxComponentCollection();

			foreach (IAjaxComponent component in this.Components)
			{
				if (string.Compare(component.ReferenceName, referenceName, StringComparison.CurrentCultureIgnoreCase) == 0)
					subList.Add(component);
			}

			return subList;
		}

		public static NucleoAjaxManager GetInstance(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			PageRequestContext context = PageRequestContext.GetCurrent(page);
			if (context != null)
				return context.Singletons.GetEntry<NucleoAjaxManager>();

			return WebSingletonManager.GetCurrent().GetEntry<NucleoAjaxManager>();

			//return page.Items[typeof(NucleoAjaxManager)] as NucleoAjaxManager;
		}

		public static string GetPostbackClientHyperlink(Control control, string argument)
		{
			return GetPostbackClientHyperlinkInternal(control, argument, false);
		}

		public static string GetPostbackClientHyperlink(Control control, string argument, bool registerForEventValidation)
		{
			return GetPostbackClientHyperlinkInternal(control, argument, registerForEventValidation);
		}

		private static string GetPostbackClientHyperlinkInternal(Control control, string argument, bool registerForEventValidation)
		{
			if (control == null)
				throw new ArgumentNullException("control");
			if (string.IsNullOrEmpty(argument))
				throw new ArgumentNullException("argument");

			return control.Page.ClientScript.GetPostBackClientHyperlink(control, argument, registerForEventValidation);
		}

		protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
		{
			foreach (IAjaxComponent component in this.Components)
			{
				if (component is IAjaxScriptableComponent)
				{
					if (component is IScriptControl)
						((IScriptControl)component).GetScriptDescriptors();
					//((IAjaxScriptableComponent)component).GetAjaxScriptDescriptors(this.Registrar, component);
					else if (component is IAjaxExtender)
					{
						IAjaxExtender extender = (IAjaxExtender)component;
						Control targetControl = ControlUtility.FindControl((Control)extender, extender.TargetControlID);

						((IAjaxScriptableComponent)component).GetAjaxScriptDescriptors(this.Registrar, targetControl);
					}
				}
			}

#if DEBUG
			ApplicationContext context = ApplicationContext.GetCurrent();
			if (context != null)
			{
				ILoggerService logger = context.GetService<ILoggerService>();
				if (logger != null)
				{
					ScriptDescriptorCollection descriptors = this.Registrar.GetDescriptors();

					foreach (ScriptComponentDescriptor descriptor in descriptors)
					{
						ScriptDescriptorWrapper wrapper = new ScriptDescriptorWrapper(descriptor);

						logger.LogMessage(string.Format("The descriptor of '{0}' was added for element id '{1}', client id '{2}'.",
							wrapper.Type, wrapper.ElementID, wrapper.ClientID), "Script Description",
							logger.GetMessageTypes().GetLowest(),
							logger.GetVerbosityTypes().GetHighest());
					}
				}
			}
#endif

			//return this.Registrar.GetDescriptors();
			return new ScriptDescriptor[] { };
		}

		protected override IEnumerable<ScriptReference> GetScriptReferences()
		{
#if DEBUG
			this.Registrar.AddReference(new ScriptReferencingRequestDetails(
				typeof(NucleoAjaxManager).Assembly.FullName, "Nucleo.Framework", ScriptMode.Debug));
#else
			this.Registrar.AddReference(new ScriptReferencingRequestDetails(
				typeof(NucleoAjaxManager).Assembly.FullName, "Nucleo.Framework", ScriptMode.Release));
#endif

			foreach (IAjaxComponent component in this.Components)
			{
				if (component is IAjaxScriptableComponent)
					((IAjaxScriptableComponent)component).GetAjaxScriptReferences(this.Registrar);
			}

#if DEBUG
			ApplicationContext context = ApplicationContext.GetCurrent();
			if (context != null)
			{
				ILoggerService logger = context.GetService<ILoggerService>();
				if (logger != null)
				{
					ScriptReferenceCollection references = this.Registrar.GetScripts();

					foreach (ScriptReference reference in references)
					{
						logger.LogMessage(string.Format("The reference to '{0}' was added, in assembly '{1}'.", 
							reference.ToString(), reference.Assembly), "Script Description",
							logger.GetMessageTypes().GetLowest(),
							logger.GetVerbosityTypes().GetHighest());
					}
				}
			}
#endif

			return this.Registrar.GetScripts();
		}

		public static string GetWebResourceUrl(Control control, Type type, string resourceName)
		{
			if (control == null)
				throw new ArgumentNullException("control");

			if (type == null)
				throw new ArgumentNullException("type");
			if (string.IsNullOrEmpty(resourceName))
				throw new ArgumentNullException("resourceName");

#if DEBUG
			if (HttpContext.Current == null)
				return string.Format("webresource.axd?d={0}&t={1}", resourceName.Replace(".", "_"), DateTime.Now.Ticks);
			else
			{
				if (control.Page == null)
					throw new ArgumentNullException("control", "The page was null");

				return control.Page.ClientScript.GetWebResourceUrl(type, resourceName);
			}
#else
			return control.Page.ClientScript.GetWebResourceUrl(type, resourceName);
#endif
		}

		/// <summary>
		/// Fires the event to signal that a change occurred.
		/// </summary>
		/// <param name="e">The details regarding the event.</param>
		protected virtual void OnChangesOccurred(ChangeEventArgs e)
		{
			if (ChangesOccurred != null)
				ChangesOccurred(this, e);
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			IWebSingletonManager mgr = null; 

			PageRequestContext context = PageRequestContext.GetCurrent(this);
			if (context != null && context.Singletons != null)
				mgr = context.Singletons;
			else
				mgr = WebSingletonManager.GetCurrent();

			if (mgr.HasEntry<NucleoAjaxManager>())
			    throw new Exception("An instance of an AJAX manager already exists on the page");

			mgr.AddEntry<NucleoAjaxManager>(this);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			ScriptManager manager = ScriptManager.GetCurrent(this.Page);
			bool isLoggedIn = (this.Page is IPageDriver && ((IPageDriver)this.Page).CurrentContext != null)
					? ((IPageDriver)this.Page).CurrentContext.Context.UserSecurity.IsLoggedIn()
					: this.Page.User.Identity.IsAuthenticated;

			foreach (ServiceReference reference in this.Services)
			{
				NucleoServiceReference service = reference as NucleoServiceReference;

				if (service == null || service.InclusionOptions == ServiceReferenceIncludeOptions.Any ||
					(service.InclusionOptions == ServiceReferenceIncludeOptions.UserAuthenticated && isLoggedIn) ||
					(service.InclusionOptions == ServiceReferenceIncludeOptions.UserUnauthenticated && !isLoggedIn))
				{
					manager.Services.Add(reference);
					continue;
				}
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			this.AddReferenceScriptsInternal();

			base.OnPreRender(e);

			this.AddCssReferencesInternal();
		}

		/// <summary>
		/// Registers an AJAX component, so the manager knows all about its children.
		/// </summary>
		/// <param name="component">The component to register.</param>
		internal void RegisterAjaxComponent(IAjaxComponent component)
		{
			if (component == null)
				throw new ArgumentNullException("component");

			this.Components.Add(component);

			if (component is ISupportsChangeNotification)
			{
				ISupportsChangeNotification changeSupportControl = (ISupportsChangeNotification)component;
				changeSupportControl.ChangesOccurred += Control_ChangesOccurred;
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);

			string startupScript = this.CreateStartupScript();
			if (!string.IsNullOrEmpty(startupScript))
				writer.Write(startupScript);

			ScriptDescriptorCollection descriptorList = this.Registrar.GetDescriptors();

			writer.Write(@"<script language='javascript' type='text/javascript'>");

			for (int index = 0, len = descriptorList.Count; index < len; index++)
			{
				ScriptComponentDescriptor descriptor = (ScriptComponentDescriptor)descriptorList[index];
				this.RenderDescriptor(descriptor, writer);
			}

			writer.Write("</script>");
		}

		private void RenderDescriptor(ScriptComponentDescriptor descriptor, HtmlTextWriter writer)
		{
			//ScriptManager.RegisterStartupScript(this, this.GetType(), descriptor.ClientID, 
			//	ContentRendering.CreateDescriptorScript(descriptor) , true);

			writer.Write(ContentRendering.CreateDescriptorScript(descriptor));
		}

		public static string ResolveClientUrl(string relativeUrl)
		{
			if (HttpContext.Current != null)
				return ((Page)HttpContext.Current.Handler).ResolveClientUrl(relativeUrl);
			else
				return relativeUrl;
		}

		#endregion



		#region " Event Handlers "

		void Control_ChangesOccurred(object sender, ChangeEventArgs e)
		{
			this.OnChangesOccurred(e);
		}

		#endregion
	}
}
