using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;

using Nucleo.Web;
using Nucleo.Web.Context;
using Nucleo.Web.Context.Services;
using Nucleo.Web.Helpers;
using Nucleo.Web.Settings;
using Nucleo.Web.Tags;
using Nucleo.Web.Tags.Custom;
using Nucleo.Web.Scripts;


namespace Nucleo.Web.Mvc.Content
{
	public class ContentManager
	{
		private NucleoControlFactory _controlFactory = null;
		private bool _enableDynamicCssRegistration = false;
		private bool _frameworkScriptAdded = false;
		private ContentRegistrar _registrar = null;


		#region " Properties "

		private ContentRegistrar Registrar
		{
			get
			{
				if (_registrar == null)
					_registrar = new ContentRegistrar();
				return _registrar;
			}
		}

		#endregion



		#region " Constructors "

		public ContentManager(NucleoControlFactory controlFactory)
		{
			_controlFactory = controlFactory;
		}

		#endregion



		#region " Methods "

		private void AddFrameworkScript()
		{
			if (_frameworkScriptAdded)
				return;

			//Make sure the framework script exists
#if DEBUG
			this.Registrar.AddReference(new ScriptReferencingRequestDetails(
				typeof(NucleoAjaxManager).Assembly.FullName, "Nucleo.Framework", ScriptMode.Debug));
#else
			this.Registrar.AddReference(new ScriptReferencingRequestDetails(
				typeof(NucleoAjaxManager).Assembly.FullName, "Nucleo.Framework", ScriptMode.Release));
#endif

			_frameworkScriptAdded = true;
		}

		public ContentManager CssFiles(ListSettingsBuilder<CssReferenceRequestDetails> builder)
		{
			if (builder == null)
				throw new ArgumentNullException("builder");

			this.Registrar.AddCssReferences(builder.GetAll());
			return this;
		}

		public ContentManager CssFiles(Action<ListSettingsBuilder<CssReferenceRequestDetails>> builder)
		{
			if (builder == null)
				throw new ArgumentNullException("builder");

			ListSettingsBuilder<CssReferenceRequestDetails> obj = new ListSettingsBuilder<CssReferenceRequestDetails>();
			builder(obj);

			return this.CssFiles(obj);
		}

		/// <summary>
		/// When true, since registration has to occur at the bottom of the page, CSS will get added via javascript to the page header.  This may cause a delay in processing.
		/// </summary>
		/// <param name="enabled">Whether dynamic CS registration occurs.</param>
		public void EnableDynamicCssRegistration(bool enabled)
		{
			_enableDynamicCssRegistration = enabled;
		}

		public void RegisterComponent<TComponent, TBuilder>(BaseMvcControlBuilder<TComponent, TBuilder> builder)
			where TComponent : BaseAjaxControl
			where TBuilder : BaseMvcControlBuilder<TComponent, TBuilder>
		{
			this.AddFrameworkScript();

			builder.RegisterComponentCss(this.Registrar);
			builder.RegisterComponentDescriptors(this.Registrar);
			builder.RegisterComponentScripts(this.Registrar);
		}

		public void RegisterComponent<TComponent, TBuilder>(BaseMvcComponentBuilder<TComponent, TBuilder> builder)
			where TComponent : BaseMvcComponent
			where TBuilder : BaseMvcComponentBuilder<TComponent, TBuilder>
		{
			//TODO: Load descriptors here
			builder.RegisterComponentCss(this.Registrar);
			builder.RegisterComponentDescriptors(this.Registrar);
			builder.RegisterComponentScripts(this.Registrar);
		}

		public ContentManager Scripts(ListSettingsBuilder<ScriptReferencingRequestDetails> builder)
		{
			if (builder == null)
				throw new ArgumentNullException("builder");

			this.Registrar.AddReferences(builder.GetAll());
			return this;
		}

		public ContentManager Scripts(Action<ListSettingsBuilder<ScriptReferencingRequestDetails>> builder)
		{
			if (builder == null)
				throw new ArgumentNullException("builder");

			ListSettingsBuilder<ScriptReferencingRequestDetails> obj = new ListSettingsBuilder<ScriptReferencingRequestDetails>();
			builder(obj);

			this.Scripts(obj);

			return this;
		}

		public void Render()
		{
			this.RenderScripts(_controlFactory.Html.ViewContext.HttpContext.Response.Output);
			//Has to occur after scripts because of dynamic script additions
			if (_enableDynamicCssRegistration)
				this.RenderDynamicCss(_controlFactory.Html.ViewContext.HttpContext.Response.Output);
			this.RenderDescriptors(_controlFactory.Html.ViewContext.HttpContext.Response.Output);
		}

		private void RenderDynamicCss(TextWriter writer)
		{
			CssReferenceCollection cssFiles = this.Registrar.GetCssReferences();
			writer.Write("<script type='text/javascript' language='javascript'>");

			foreach (CssReference cssFile in cssFiles)
			{
				writer.Write(string.Format("n$.css('{0}');", cssFile.Path));

				//writer.WriteLine(ContentRendering.CreateCssReference(cssFile));
			}

			writer.Write("</script>");
		}

		private void RenderDescriptors(TextWriter writer)
		{
			ScriptDescriptorCollection descriptors = this.Registrar.GetDescriptors();
			foreach (ScriptComponentDescriptor descriptor in descriptors)
			{
				TagElement tag = new TagElement("SCRIPT");
				tag.Attributes.AppendAttribute("type", "text/javascript")
					.AppendAttribute("language", "javascript");

				tag.Content = ContentRendering.CreateDescriptorScript(descriptor);

				writer.Write(tag.ToHtmlString());
			}
		}

		private void RenderScripts(TextWriter writer)
		{
			ScriptReferenceCollection scripts = this.Registrar.GetScripts();

			foreach (ScriptReference script in scripts)
			{
				TagElement tag = new TagElement("SCRIPT");
				tag.Attributes.AppendAttribute("type", "text/javascript")
					.AppendAttribute("language", "javascript");

				if (!string.IsNullOrEmpty(script.Path))
					tag.Attributes.AppendAttribute("src",
						((new MvcUrlResolutionService()).GetClientBasedUrl(script.Path)));
				else
				{
					bool zip = (_controlFactory.Html.ViewContext.HttpContext.Request.Headers.Get("Accept-encoding") == "gzip");
					Assembly assembly = Assembly.Load(script.Assembly);

					tag.Attributes.AppendAttribute("src",
						ScriptReferencing.GetResourceUrl(assembly, script.Name,
							System.Globalization.CultureInfo.CurrentCulture, zip, false));
				}

				writer.Write(tag.ToHtmlString());
			}
		}

		#endregion
	}
}
