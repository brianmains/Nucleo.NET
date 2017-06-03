using System;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.Script.Serialization;

using Nucleo.Context;
using Nucleo.Web.ClientRegistration;
using Nucleo.Web.ClientSettings;
using Nucleo.Web.Core;
using Nucleo.Web.Styles;
using Nucleo.Web.ClientState;
using Nucleo.Web.Pages;
using Nucleo.Exceptions;
using Nucleo.EventArguments;


namespace Nucleo.Web
{
	[WebScriptMetadata(typeof(BaseAjaxExtenderScriptMetadata))]
	public abstract class BaseAjaxExtender : Control, IExtenderControl, IPostBackDataHandler, IAjaxExtender, IClientStateControl, IAjaxScriptableComponent
	{
		private ClientEvents _clientEvents = null;
		private ClientStateDictionary _clientState = null;
		private ScriptComponentCollection _scriptComponents = null;
		private string _targetControlID = null;



		#region " Events "

		/// <summary>
		/// Fires before the control has initialized.
		/// </summary>
		public event EventHandler Initializing;

		/// <summary>
		/// Fires before the control has loaded.
		/// </summary>
		public event EventHandler Loading;

		/// <summary>
		/// Fires when the control has prepared to render.
		/// </summary>
		public event EventHandler PrepareToRender;

		/// <summary>
		/// Fires when the control starts up.
		/// </summary>
		public event EventHandler Startup;

		/// <summary>
		/// Fires before the control has loaded.
		/// </summary>
		public event EventHandler Unloading;

		/// <summary>
		/// Fires when the control is validating.
		/// </summary>
		public event ValidateEventHandler ValidateState;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets the client events that relate to the control.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty)
		]
		public ClientEvents ClientEvents
		{
			get
			{
				if (_clientEvents == null)
					_clientEvents = new ClientEvents();
				return _clientEvents;
			}
			set { _clientEvents = value; }
		}

		/// <summary>
		/// Gets the client state dictionary for internal client state.  Useful for custom controls that want to read/write to custom client state.  Client state uses a hidden field to read/write from.
		/// </summary>
		protected ClientStateDictionary ClientState
		{
			get
			{
				if (_clientState == null)
					_clientState = new ClientStateDictionary();
				return _clientState;
			}
		}

		/// <summary>
		/// Gets the ID of the client state hidden field.
		/// </summary>
		private string ClientStateFieldID
		{
			get { return this.ClientID + "_hidden"; }
		}

		/// <summary>
		/// Gets or sets whether client-state is enabled, or whether to persist values from the client back to the server on postback.
		/// </summary>
		public bool EnableClientState
		{
			get { return (bool)(ViewState["EnableClientState"] ?? true); }
			set { ViewState["EnableClientState"] = value; }
		}

		/// <summary>
		/// Gets or sets whether to enable custom theming.  If set to true, you must use a <see cref="StyleSheetManager"/> control or define the reference yourself.
		/// </summary>
		public bool EnableCustomTheming
		{
			get { return (bool)(ViewState["EnableCustomTheming"] ?? false); }
			set { ViewState["EnableCustomTheming"] = value; }
		}

		/// <summary>
		/// Gets or sets a general reference name to this component.  This is a mechanism to retrieve a control by a generic name, made available through the <see cref="NucleoAjaxManager">NucleoAjaxManager control</see>.
		/// </summary>
		public string ReferenceName
		{
			get { return (string)ViewState["ReferenceName"]; }
			set { ViewState["ReferenceName"] = value; }
		}

		/// <summary>
		/// Gets or sets whether to register the extender with the script manager control.
		/// </summary>
		public bool RegisterWithScriptManager
		{
			get { return (bool)(ViewState["RegisterWithScriptManager"] ?? true); }
			set { ViewState["RegisterWithScriptManager"] = value; }
		}

		/// <summary>
		/// Gets a collection of script component, which implement <see cref="IScriptComponent">the IScriptComponent interface</see>.
		/// </summary>
		public ScriptComponentCollection ScriptComponents
		{
			get
			{
				if (_scriptComponents == null)
					_scriptComponents = new ScriptComponentCollection();
				return _scriptComponents;
			}
		}

		/// <summary>
		/// Gets or sets a generic tag to use to store data.  Any kind of serializable data can be stored here.
		/// </summary>
		public object Tag
		{
			get { return ViewState["Tag"]; }
			set { ViewState["Tag"] = value; }
		}

		/// <summary>
		/// Gets or sets the ID of the control to target.
		/// </summary>
		public string TargetControlID
		{
			get { return _targetControlID; }
			set { _targetControlID = value; }
		}

		/// <summary>
		/// Gets or sets whether to use global configuration settings.  Some features use global configuration settings, but most controls don't.  This will come more into play in future releases.
		/// </summary>
		public bool UseGlobalConfigurationSettings
		{
			get { return (bool)(ViewState["UseGlobalConfigurationSettings"] ?? true); }
			set { ViewState["UseGlobalConfigurationSettings"] = value; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a script component to the collection of components.  This is primarily used for custom controls as a generic place to add all of its script components.
		/// </summary>
		protected virtual void AddScriptComponents()
		{
			if (_clientEvents != null)
				this.ScriptComponents.Add(this.ClientEvents);
		}

		/// <summary>
		/// Defines the method that will setup AJAX script descriptors.
		/// </summary>
		/// <param name="registrar">The registrar to use to setup descriptors.</param>
		protected virtual void GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{
			NucleoScriptBehaviorDescriptor descriptor = registrar.AddDescriptor<NucleoScriptBehaviorDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(BaseAjaxExtender), targetControl.ClientID));

			descriptor.AddProperty("id", this.ClientID);
			descriptor.AddElementProperty("clientStateField", this.ClientStateFieldID);
			descriptor.AddPropertyIfExists("referenceName", this.ReferenceName);
			descriptor.AddProperty("renderingMode", RenderMode.ClientOnly);
			this.ScriptComponents.RegisterScriptComponentDescriptors(registrar, descriptor);
		}

		/// <summary>
		/// Defines the method that will setup AJAX script descriptors.
		/// </summary>
		/// <param name="registrar">The registrar to use to setup descriptors.</param>
		void IAjaxScriptableComponent.GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{
			this.GetAjaxScriptDescriptors(registrar, targetControl);
		}

		/// <summary>
		/// Defines the method that will setup any AJAX script references, including any dependencies.
		/// </summary>
		/// <param name="registrar">The registrar to use to setup references.</param>
		protected virtual void GetAjaxScriptReferences(IContentRegistrar registrar)
		{
			this.ScriptComponents.RegisterScriptComponentReferences(registrar);

			//WebScriptMetadata[] metadatas = ControlScriptMetadata.GetWebScriptMetadata(this);
			//if (metadatas.Length > 0)
			//{
			//    for (int index = 0, len = metadatas.Length; index < len; index++)
			//    {
			//        ScriptReferencingRequestDetailsCollection references = metadatas[index].GetPrimaryScripts();
			//        registrar.AddReferences(references);
			//    }
			//}

			ClientScriptRegistry registry = ClientScriptRegistry.CreateFor(this);
			if (registry != null && registry.Scripts.Count > 0)
			{
				foreach (ScriptReferencingRequestDetails script in registry.Scripts)
					registrar.AddReference(script);
			}
		}

		/// <summary>
		/// Defines the method that will setup any AJAX script references, including any dependencies.
		/// </summary>
		/// <param name="registrar">The registrar to use to setup references.</param>
		void IAjaxScriptableComponent.GetAjaxScriptReferences(IContentRegistrar registrar)
		{
			this.GetAjaxScriptReferences(registrar);
		}

		/// <summary>
		/// Defines the method that will setup any CSS references; this is optional so it may be omitted.
		/// </summary>
		/// <param name="registrar">The registrar to use to setup CSS references.</param>
		protected virtual void GetCssReferences(IContentRegistrar registrar) { }

		/// <summary>
		/// Defines the method that will setup any CSS references; this is optional so it may be omitted.
		/// </summary>
		/// <param name="registrar">The registrar to use to setup CSS references.</param>
		void IAjaxScriptableComponent.GetCssReferences(IContentRegistrar registrar)
		{
			this.GetCssReferences(registrar);
		}

		IEnumerable<ScriptDescriptor> IExtenderControl.GetScriptDescriptors(Control targetControl)
		{
			NucleoAjaxManager manager = WebSingletonManager.GetCurrent().GetEntry<NucleoAjaxManager>();
			((IAjaxScriptableComponent)this).GetAjaxScriptDescriptors(manager.Registrar, targetControl);			

			return new ScriptDescriptor[] { };
		}

		/// <summary>
		/// Gets the reference to the script manager.
		/// </summary>
		/// <param name="page">The current page.</param>
		/// <returns>The reference to the script manager.</returns>
		protected virtual ScriptManager GetScriptManager(Page page)
		{
			return ScriptManager.GetCurrent(page);
		}

		IEnumerable<ScriptReference> IExtenderControl.GetScriptReferences()
		{
			NucleoAjaxManager manager = WebSingletonManager.GetCurrent().GetEntry<NucleoAjaxManager>();
			((IAjaxScriptableComponent)this).GetAjaxScriptReferences(manager.Registrar);

			return new ScriptReference[] { };
		}

		/// <summary>
		/// Because controls must be registered in Render, and some controls override the Render method and do not call base.Render, this method alleviates the problem into a simple method call.
		/// </summary>
		protected void HandleManualScriptRegistering()
		{
			ScriptManager manager = this.GetScriptManager(this.Page);
			manager.RegisterScriptDescriptors(this);
		}

		/// <summary>
		/// Validates that the state of the control is OK.
		/// </summary>
		/// <exception cref="ValidateException">Thrown when the control isn't valid.</exception>
		private void IsValidateStateOK()
		{
			ValidateEventArgs vargs = new ValidateEventArgs();
			this.OnValidateState(vargs);

			if (!vargs.IsValid)
				throw new ValidateException("The control didn't validate correctly");
		}

		/// <summary>
		/// Loads client state into the control, using the <see cref="ClientStateData">ClientStateData component</see> or some derivative.  Override this control to load changed client-values that postback to the server.
		/// </summary>
		/// <param name="stateData">The state data to load.</param>
		protected virtual void LoadClientState(ClientStateData stateData)
		{
			if (!this.EnableClientState)
				return;

			if (stateData != null)
				this._clientState = stateData.Values;
		}

		void IClientStateControl.LoadClientState(ClientStateData stateData)
		{
			this.LoadClientState(stateData);
		}

		/// <summary>
		/// Loads client-state data from the data that loads back from the server.  If you need to access the posted data, please use <see cref="LoadPostDataValues">LoadPostDataValues</see> to implement this logic.
		/// </summary>
		/// <param name="postDataKey">The key of the posted data.</param>
		/// <param name="postCollection">The collection of the posted data.</param>
		/// <returns>false</returns>
		protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
		{
			if (Page.IsPostBack)
			{
				this.LoadPostDataValues(postDataKey, postCollection);

				string json = postCollection[this.ClientStateFieldID];

				if (!string.IsNullOrEmpty(json))
					this.LoadClientState(ClientStateData.FromJson(json));
				else
					this.LoadClientState(null);

				return false;
			}
			else
				return false;
		}

		bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
		{
			return this.LoadPostData(postDataKey, postCollection);
		}

		/// <summary>
		/// Processes the posted load in all sub-controls.  Please use this method instead of LoadPostData; they both do the same, but LoadPostData performs some intrinsic features.
		/// </summary>
		/// <param name="postDataKey">The key of the post.</param>
		/// <param name="postCollection">The post collection (entire posted data collection).</param>
		protected virtual void LoadPostDataValues(string postDataKey, NameValueCollection postCollection) { }

		protected internal virtual void OnInitializing(EventArgs e)
		{
			if (Initializing != null)
				Initializing(this, e);
		}

		protected internal virtual void OnLoading(EventArgs e)
		{
			if (Loading != null)
				Loading(this, e);
		}

		protected internal virtual void OnPrepareToRender(EventArgs e)
		{
			if (PrepareToRender != null)
				PrepareToRender(this, e);
		}

		protected internal virtual void OnStartup(EventArgs e)
		{
			if (Startup != null)
				Startup(this, e);
		}

		protected internal virtual void OnUnloading(EventArgs e)
		{
			if (Unloading != null)
				Unloading(this, e);
		}

		/// <summary>
		/// Fires the validate state event when its time to validate a control's state.
		/// </summary>
		/// <param name="e">The validation details.</param>
		protected internal virtual void OnValidateState(ValidateEventArgs e)
		{
			if (ValidateState != null)
				ValidateState(this, e);
		}

		/// <summary>
		/// Fires any logic for posted data, but this method will not execute based on the control plumbing.
		/// </summary>
		protected virtual void RaisePostDataChangedEvent() { }

		void IPostBackDataHandler.RaisePostDataChangedEvent()
		{
			this.RaisePostDataChangedEvent();
		}

		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);

			if (this.RegisterWithScriptManager)
				this.HandleManualScriptRegistering();
		}

		/// <summary>
		/// Returns any state to save to the client.
		/// </summary>
		/// <returns>The state to save to the client.</returns>
		protected virtual ClientStateData SaveClientState()
		{
			if (!this.EnableClientState)
				return null;

			return new ClientStateData(_clientState);
		}

		ClientStateData IClientStateControl.SaveClientState()
		{
			return this.SaveClientState();
		}

		#endregion



		#region " Lifecycle Methods "

		/// <summary>
		/// Initializes the extender, registering it with the <see cref="NucleoAjaxManager">NucleoAjaxManager</see> component if one exists.  CSS is also registered at this time.
		/// </summary>
		/// <param name="e">The details about the init event.</param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			PageRequestContext context = PageRequestContext.GetCurrent(this);
			if (context != null && context.Singletons != null)
			{
				NucleoAjaxManager manager = context.Singletons.GetEntry<NucleoAjaxManager>();
				if (manager != null)
				{
					manager.RegisterAjaxComponent(this);

					if (!this.EnableCustomTheming)
						this.GetCssReferences(manager.Registrar);
				}
			}

			if ((this.Page is IPageDriver && ((IPageDriver)this.Page).IsInitialLoad) ||
				(this.Page != null && !this.Page.IsPostBack))
				this.OnStartup(e);

			this.OnInitializing(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			this.OnLoading(e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			this.IsValidateStateOK();

			if (this.RegisterWithScriptManager)
			{
				if (string.IsNullOrEmpty(this.TargetControlID))
					throw new NullReferenceException("The target control ID is null.");

				Control target = null;
				bool used = false;

				if (this.Page is IPageDriver)
				{
					IPageDriver driver = (IPageDriver)this.Page;
					if (driver.CurrentContext != null && driver.CurrentContext.ControlSearcher != null)
					{
						target = driver.CurrentContext.ControlSearcher.FindControl(this, this.TargetControlID,
							Searching.ControlSearcherDirection.Up);
						used = true;
					}
				}

				if (!used)
					target = ControlUtility.FindControl(this, this.TargetControlID);

				if (target == null)
					throw new NullReferenceException("The target control ID could not be found with " + this.TargetControlID);

				this.GetScriptManager(this.Page).RegisterExtenderControl<BaseAjaxExtender>(this, target);
			}

			this.AddScriptComponents();
			base.OnPreRender(e);

			ClientStateData clientState = this.SaveClientState();

			if (clientState == null)
				ScriptManager.RegisterHiddenField(this, this.ClientStateFieldID, null);
			else
				ScriptManager.RegisterHiddenField(this, this.ClientStateFieldID, clientState.ToJson());

			this.OnPrepareToRender(e);
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);

			this.OnUnloading(e);
		}

		#endregion
	}
}
