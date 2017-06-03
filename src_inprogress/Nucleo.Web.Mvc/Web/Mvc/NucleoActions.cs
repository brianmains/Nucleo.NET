using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using Nucleo.Configuration;
using Nucleo.Reflection;
using Nucleo.Web.Lookups;
using Nucleo.Models;


namespace Nucleo.Web.Mvc
{
	/// <summary>
	/// Represents a collection of custom actions.
	/// </summary>
	public class NucleoActions
	{
		private HtmlHelper _html = null;



		#region " Constructors "

		/// <summary>
		/// Creates the actions component.
		/// </summary>
		/// <param name="html">The html helper.</param>
		public NucleoActions(HtmlHelper html)
		{
			_html = html;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Finds the model property value using the specified name.  Returns null if the property isn't found.
		/// </summary>
		/// <param name="name">The name of the property to look for.  Will attempt to suffix the property with the word "Model".</param>
		/// <returns>The value of the property.</returns>
		private object FindModelProperty(string name)
		{
			object model = _html.ViewData.Model;
			if (model is BaseModel)
			{
				BaseModel mod = (BaseModel)model;
				if (mod.HasValue(name))
					return mod.GetValue(name);
				if (mod.HasValue(name + "Model"))
					return mod.GetValue(name + "Model");
			}

			PropertyInfo property = model.GetType().GetProperty(name);
			if (property != null)
				return property.GetValue(model, null);

			property = model.GetType().GetProperty(name + "Model");
			if (property != null)
				return property.GetValue(model, null);

			return null;
		}

		/// <summary>
		/// Renders a partial view using the name of the partial view.  Reflects against the model to find a property with the same name as the partial view, or for a property with the name of the partial view and a suffix of "Model".
		/// </summary>
		/// <param name="partialName">The partial name to look for.</param>
		public void RenderPartial(string partialName)
		{
			object model = _html.ViewData.Model;
			object value = this.FindModelProperty(partialName);

			_html.RenderPartial(partialName, value);
		}

		/// <summary>
		/// Renders a partial view using the name of the partial view.  Reflects against the model to find a property with the model name property, or for a property with the model name and a suffix of "Model".
		/// </summary>
		/// <param name="partialName">The partial name to look for.</param>
		/// <param name="modelName">The name of the model within the view.</param>
		public void RenderPartial(string partialName, string modelName)
		{
			object model = _html.ViewData.Model;
			object value = this.FindModelProperty(modelName);

			_html.RenderPartial(partialName, value);
		}

		/// <summary>
		/// Renders a partial view by looking for the type of collection desired for the partial view.  This then does not require the use of a name; it reflects against all of the parameters to find the property with the given type.
		/// </summary>
		/// <typeparam name="TPartialModel">The partial model type to look for.</typeparam>
		/// <param name="partialName">The name of the partial view.</param>
		/// <remarks>Finds the first instance that the partial model type is assignable from.  Be careful how you use this method.</remarks>
		public void RenderPartial<TPartialModel>(string partialName)
		{
			object model = _html.ViewData.Model;
			object submodel = null;

			PropertyInfo[] properties = model.GetType().GetProperties();
			Type partialType = typeof(TPartialModel);

			foreach (PropertyInfo property in properties)
			{
				if (partialType.IsAssignableFrom(property.PropertyType))
				{
					submodel = property.GetValue(model, null);
					break;
				}
			}

			_html.RenderPartial(partialName, submodel);
		}

		#endregion
	}
}
