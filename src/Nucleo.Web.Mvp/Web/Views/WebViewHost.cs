using System;
using System.Web.UI;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Core;
using Nucleo.Presentation;
using Nucleo.Navigation;
using Nucleo.Web.Presentation.Configuration;
using Nucleo.Views;
using Nucleo.Views.Initialization;
using Nucleo.Web.Ajax;
using Nucleo.Web.Core;
using Nucleo.Web.Views;


namespace Nucleo.Web.Views
{
	/// <summary>
	/// Represents the host for web views.
	/// </summary>
	public class WebViewHost
	{
		#region " Methods "

		/// <summary>
		/// Creates a new view host, or gets the current view host instance.
		/// </summary>
		/// <param name="context">The context instance.</param>
		/// <returns>The view host.</returns>
		public static WebViewHost CreateOrGet(IWebContext context)
		{
			WebViewHost host = context.LocalStorage[typeof(WebViewHost)] as WebViewHost;
			if (host == null)
			{
				host = new WebViewHost();
				context.LocalStorage[typeof(WebViewHost)] = host;
			}

			return host;
		}

		private void InitializeView(Control control)
		{
			var resolver = FrameworkSettings.Resolver;
			if (resolver == null)
				return;

			var initializer = resolver.GetDependency<IViewInitializer>();
			if (initializer == null)
				return;

			initializer.Initialize((IView)control);
		}

		/// <summary>
		/// Processes the view.
		/// </summary>
		/// <param name="control">The control that is the view.</param>
		/// <param name="presenter">The presenter instance.</param>
		public void Process(Control control, IPresenter presenter)
		{
			if (presenter == null)
				return;

			this.InitializeView(control);
			this.RegisterAjax(control, presenter);
			this.RegisterNavigation(presenter);
		}

		/// <summary>
		/// Registers AJAX to the UI.
		/// </summary>
		/// <param name="control">The control as the parent.</param>
		/// <param name="presenter">The presenter instance.</param>
		private void RegisterAjax(Control control, IPresenter presenter)
		{
			Type presenterType = presenter.GetType();
			PresenterAjaxAttribute attribute = presenter.GetType().GetCustomAttribute<PresenterAjaxAttribute>(false);
			PresenterElement presenterConfig = null;

			if (attribute == null)
			{
				PresenterWebSettingsSection section = PresenterWebSettingsSection.Instance;
				if (section != null)
				{
					presenterConfig = section.Presenters[presenterType.FullName];
					if (presenterConfig == null)
						presenterConfig = section.Presenters[presenterType.Name];

					//If long and short name not found, exit
					if (presenterConfig == null)
						return;
				}
			}

			PresenterProxyGenerator gen = PresenterProxyGenerator.Create(presenterType);
			string output = null;

			if (presenterConfig != null)
				output = gen.Generate(presenterConfig.GetAjaxMethods());
			else
				output = gen.Generate();

			ScriptManager.RegisterStartupScript(control, control.GetType(), presenter.GetType().FullName, output, true);
		}

		private void RegisterNavigation(IPresenter presenter)
		{
			if (!(presenter is IInlineNavigationPresenter))
				return;

			//presenter.CurrentContext.InlineNavigation.RegisterPresenter((IInlineNavigationPresenter)presenter);
		}

		#endregion
	}
}
