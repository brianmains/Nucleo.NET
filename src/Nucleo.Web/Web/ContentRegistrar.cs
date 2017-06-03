using System;
using System.Collections.Generic;
using System.Web.UI;

using Nucleo.Web.Description;
using Nucleo.Web.Scripts;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents the registrar for content.  This registrar manages CSS references, script references, and script descriptors.
	/// </summary>
	public class ContentRegistrar : IContentRegistrar
	{
		private ComponentDescriptorCollection _componentDescriptors = null;
		private CssReferenceCollection _cssReferences = null;
		private ScriptDescriptorCollection _descriptors = null;
		private ScriptReferenceCollection _scripts = null;



		#region " Properties "

		private ComponentDescriptorCollection ComponentDescriptors
		{
			get
			{
				if (_componentDescriptors == null)
					_componentDescriptors = new ComponentDescriptorCollection();
				return _componentDescriptors;
			}
		}

		private CssReferenceCollection CssReferences
		{
			get
			{
				if (_cssReferences == null)
					_cssReferences = new CssReferenceCollection();
				return _cssReferences;
			}
		}

		private ScriptDescriptorCollection Descriptors
		{
			get
			{
				if (_descriptors == null)
					_descriptors = new ScriptDescriptorCollection();
				return _descriptors;
			}
		}

		private ScriptReferenceCollection Scripts
		{
			get
			{
				if (_scripts == null)
					_scripts = new ScriptReferenceCollection();
				return _scripts;
			}
		}

		#endregion



		#region " Methods "

		public ComponentDescriptor AddComponentDescriptor(ComponentDescriptionRequestDetails details)
		{
			ComponentDescriptor descriptor = this.ComponentDescriptors.GetByDetails(details);
			if (descriptor != null)
				return descriptor;

			descriptor = new ComponentDescriptor(details.ClientTypeName);
			this.ComponentDescriptors.Add(descriptor);

			return descriptor;
		}

		/// <summary>
		/// Adds a CSS reference to the registrar.
		/// </summary>
		/// <param name="details">The details of the CSS to create or get.</param>
		/// <returns>The CSS reference information.</returns>
		/// <example>
		/// var registrar = new ContentRegistrar();
		/// registrar.AddCssReference(new CssReferenceRequestDetails(
		///		Page.ClientScript.GetWebResourceUrl(this.GetType(), "MyCssFile.css")));
		/// </example>
		public CssReference AddCssReference(CssReferenceRequestDetails details)
		{
			CssReference reference = this.CssReferences.GetByDetails(details);
			if (reference != null)
				return reference;

			reference = new CssReference(details);
			this.CssReferences.Add(reference);

			return reference;
		}

		/// <summary>
		/// Adds the collection of CSS references to the registrar.
		/// </summary>
		/// <param name="details">The collection of details.</param>
		/// <returns>The collection of CSS references.</returns>
		/// <example>
		/// var registrar = new ContentRegistrar();
		/// registrar.AddCssReferences(new CssReferenceRequestDetailsCollection
		/// {
		///		new CssReferenceRequestDetails(Page.ClientScript.GetWebResourceUrl(this.GetType(), "MyCssFile.css")),
		///		new CssReferenceRequestDetails(Page.ClientScript.GetWebResourceUrl(this.GetType(), "MyCssFile2.css"))
		/// });
		/// </example>
		public CssReferenceCollection AddCssReferences(IEnumerable<CssReferenceRequestDetails> details)
		{
			CssReferenceCollection references = new CssReferenceCollection();

			foreach (CssReferenceRequestDetails detail in details)
				references.Add(this.AddCssReference(detail));

			return references;
		}

		/// <summary>
		/// Adds the collection of CSS references to the registrar.
		/// </summary>
		/// <param name="details">The collection of details.</param>
		/// <returns>The collection of CSS references.</returns>
		/// <example>
		/// var registrar = new ContentRegistrar();
		/// registrar.AddCssReferences(new CssReferenceRequestDetailsCollection
		/// {
		///		new CssReferenceRequestDetails(Page.ClientScript.GetWebResourceUrl(this.GetType(), "MyCssFile.css")),
		///		new CssReferenceRequestDetails(Page.ClientScript.GetWebResourceUrl(this.GetType(), "MyCssFile2.css"))
		/// });
		/// </example>
		public CssReferenceCollection AddCssReferences(CssReferenceRequestDetailsCollection details)
		{
			return this.AddCssReferences((IEnumerable<CssReferenceRequestDetails>)details);
		}

		/// <summary>
		/// Adds or gets the script descriptor, using the details specified.
		/// </summary>
		/// <param name="details">The details of the script description.</param>
		/// <returns>The script descriptor instance.</returns>
		/// <example>
		/// var registrar = new ContentRegistrar();
		/// registrar.AddDescriptor(new ScriptDescriptionRequestDetails(
		///		ctlInstance, typeof(MyControl), ctlInstance.ClientID));
		/// </example>
		public ScriptDescriptor AddDescriptor(ScriptDescriptionRequestDetails details)
		{
			ScriptDescriptor descriptor = this.Descriptors.GetByDetails(details);
			if (descriptor != null)
				return descriptor;

			descriptor = CreateDescriptor(details);
			this.Descriptors.Add(descriptor);

			return descriptor;
		}

		/// <summary>
		/// Adds or gets the script descriptor, using the details specified.
		/// </summary>
		/// <param name="details">The details of the script description.</param>
		/// <typeparam name="T">The type of descriptor, either a control or extender descriptor; the nucleo framework uses a custom script descriptor.</typeparam>
		/// <returns>The script descriptor instance.</returns>
		/// <example>
		/// var registrar = new ContentRegistrar();
		/// registrar.AddDescriptor&lt;ScriptControlDescriptor>(new ScriptDescriptionRequestDetails(
		///		ctlInstance, typeof(MyControl), ctlInstance.ClientID));
		/// </example>
		public T AddDescriptor<T>(ScriptDescriptionRequestDetails details) 
			where T : System.Web.UI.ScriptDescriptor
		{
			return (T)AddDescriptor(details);
		}

		/// <summary>
		/// Adds the collection of descriptors.
		/// </summary>
		/// <param name="details">The collection of details for script descriptions to register.</param>
		/// <returns>The collection of script descriptors.</returns>
		/// <example>
		/// var registrar = new ContentRegistrar();
		/// registrar.AddDescriptors(new ScriptDescriptionRequestDetailsCollection
		/// {
		///		new ScriptDescriptionRequestDetails(ctlInstance, typeof(MyControl), ctlInstance.ClientID)
		///	});
		/// </example>
		public ScriptDescriptorCollection AddDescriptors(IEnumerable<ScriptDescriptionRequestDetails> details)
		{
			ScriptDescriptorCollection descriptors = new ScriptDescriptorCollection();

			foreach (ScriptDescriptionRequestDetails detail in details)
				descriptors.Add(this.AddDescriptor(detail));

			return descriptors;
		}

		/// <summary>
		/// Adds the collection of descriptors.
		/// </summary>
		/// <param name="details">The collection of details for script descriptions to register.</param>
		/// <returns>The collection of script descriptors.</returns>
		/// <example>
		/// var registrar = new ContentRegistrar();
		/// registrar.AddDescriptors(new ScriptDescriptionRequestDetailsCollection
		/// {
		///		new ScriptDescriptionRequestDetails(ctlInstance, typeof(MyControl), ctlInstance.ClientID)
		///	});
		/// </example>
		public ScriptDescriptorCollection AddDescriptors(ScriptDescriptionRequestDetailsCollection details)
		{
			return this.AddDescriptors((IEnumerable<ScriptDescriptionRequestDetails>)details);
		}

		/// <summary>
		/// Adds a script reference to the registrar, using the script details.
		/// </summary>
		/// <param name="details">The details of the reference.</param>
		/// <returns>The script reference information.</returns>
		public ScriptReference AddReference(ScriptReferencingRequestDetails details)
		{
			var reference = this.Scripts.GetByDetails(details);
			if (reference != null)
				return reference;

			reference = ReferenceScriptManager.CreateReference(details);
			this.Scripts.Add(reference);

			return reference;
		}

		/// <summary>
		/// Adds a script reference to the registrar, using the list of script details.
		/// </summary>
		/// <param name="details">The list of details to reference.</param>
		/// <returns>The script reference information collection.</returns>
		public ScriptReferenceCollection AddReferences(IEnumerable<ScriptReferencingRequestDetails> details)
		{
			ScriptReferenceCollection collection = new ScriptReferenceCollection();

			foreach (ScriptReferencingRequestDetails detail in details)
				collection.Add(this.AddReference(detail));

			return collection;
		}

		/// <summary>
		/// Adds a script reference to the registrar, using the list of script details.
		/// </summary>
		/// <param name="details">The list of details to reference.</param>
		/// <returns>The script reference information collection.</returns>
		public ScriptReferenceCollection AddReferences(ScriptReferencingRequestDetailsCollection details)
		{
			return this.AddReferences((IEnumerable<ScriptReferencingRequestDetails>)details);
		}

		/// <summary>
		/// Creates the script description using the script details.
		/// </summary>
		/// <param name="details">THe details to get the descriptor.</param>
		/// <returns>The script descriptor.</returns>
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

		public ComponentDescriptorCollection GetComponentDescriptors()
		{
			return this.ComponentDescriptors;
		}

		/// <summary>
		/// Gets all of the CSS references in the registrar.
		/// </summary>
		/// <returns>The collection of CSS references.</returns>
		public CssReferenceCollection GetCssReferences()
		{
			return this.CssReferences;
		}

		/// <summary>
		/// Gets all of the descriptors in the registrar.
		/// </summary>
		/// <returns>The collection of descriptors.</returns>
		public ScriptDescriptorCollection GetDescriptors()
		{
			return this.Descriptors;
		}

		/// <summary>
		/// Gets all of the script references in the registrar.
		/// </summary>
		/// <returns>The collection of script references.</returns>
		public ScriptReferenceCollection GetScripts()
		{
			return this.Scripts;
		}

		#endregion
	}
}
