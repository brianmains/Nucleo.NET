using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

using Nucleo.ObjectModel;
using Nucleo.Web.Tags;


namespace Nucleo.Web.Mvc.Elements.Forms
{
	public class HtmlFormBuilder : BaseElementBuilder<HtmlForm, HtmlFormBuilder>
	{
		#region " Constructors "

		public HtmlFormBuilder(NucleoElementFactory elementFactory)
			: base(elementFactory) { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Specifies the action of the form, using a route values dictionary.  The controller/action can be specified in this dictionary, or they can be null.
		/// </summary>
		/// <param name="routeValues">The collection of routing values.</param>
		/// <returns>The form builder.</returns>
		public HtmlFormBuilder Action(RouteValueDictionary routeValues)
		{
			string controller = null, action = null;

			if (routeValues.ContainsKey("controller"))
			{
				controller = routeValues["controller"] as string;
				routeValues.Remove("controller");
			}
			if (routeValues.ContainsKey("action"))
			{
				action = routeValues["action"] as string;
				routeValues.Remove("action");
			}

			return this.Action(action, controller, routeValues);
		}

		/// <summary>
		/// Specifies the action of the form to redirect to.
		/// </summary>
		/// <param name="actionName">The name of the action within the current controller.</param>
		/// <returns>The form builder.</returns>
		public HtmlFormBuilder Action(string actionName)
		{
			return Action(actionName, null);
		}

		/// <summary>
		/// Specifies the action of the form to redirect to.
		/// </summary>
		/// <param name="actionName">The name of the action within the current controller.</param>
		/// <param name="routeValues">The collection of routing values.</param>
		/// <returns>The form builder.</returns>
		public HtmlFormBuilder Action(string actionName, RouteValueDictionary routeValues)
		{
			string controller = null;

			if (routeValues != null && routeValues.ContainsKey("controller"))
			{
				controller = (string)routeValues["controller"];
				routeValues.Remove("controller");
			}

			return Action(actionName, controller, routeValues);
		}

		/// <summary>
		/// Specifies the action of the form to redirect to.
		/// </summary>
		/// <param name="actionName">The name of the action within the current controller.</param>
		/// <param name="routeValues">The collection of routing values.</param>
		/// <returns>The form builder.</returns>
		public HtmlFormBuilder Action(string actionName, string controllerName, RouteValueDictionary routeValues)
		{
			this.GetElement().ActionName = actionName;
			this.GetElement().ControllerName = controllerName;
			this.GetElement().RouteValues = routeValues;
			return this;
		}

		/// <summary>
		/// Sets up the form, using the action to supply the parameters to.
		/// </summary>
		/// <param name="builder">The builder to setup the form's parameters.</param>
		/// <returns>The form builder.</returns>
		public HtmlFormBuilder Form(Action<HtmlForm> builder)
		{
			HtmlForm form = this.GetElement();
			builder(form);

			return this;
		}

		/// <summary>
		/// Gets the reference to the form.
		/// </summary>
		/// <returns>The html form builder.</returns>
		public HtmlForm GetForm()
		{
			return this.GetElement();
		}

		/// <summary>
		/// Sets the attributes using reflection to inflect the values from an anonymous type, as in the format of HtmlAttributes(new { a = 1, b = 2 }).
		/// </summary>
		/// <param name="attributes">The attributes to use to load the form with.</param>
		/// <returns>The html form builder.</returns>
		public HtmlFormBuilder HtmlAttributes(object attributes)
		{
			ObjectReader reader = new ObjectReader();
			reader.ReadAttributes(attributes);

			this.GetElement().HtmlAttributes = reader.Attributes;
			return this;
		}

		/// <summary>
		/// Sets the attributes using the dictionary to supply the values.
		/// </summary>
		/// <param name="attributes">The attributes to use to load the form with.</param>
		/// <returns>The html form builder.</returns>
		public HtmlFormBuilder HtmlAttributes(IDictionary<string, object> attributes)
		{
			this.GetElement().HtmlAttributes = attributes;
			return this;
		}

		/// <summary>
		/// Gets the method to use for the form; passes this value to the html attribute collection.
		/// </summary>
		/// <param name="method">The method (get/post) to operate as.</param>
		/// <returns>The form builder.</returns>
		public HtmlFormBuilder Method(FormMethod method)
		{
			if (this.GetElement().HtmlAttributes == null)
				this.GetElement().HtmlAttributes = new Dictionary<string, object>();

			this.GetElement().HtmlAttributes["method"] = method.ToString();
			return this;
		}

		/// <summary>
		/// Renders the forms.
		/// </summary>
		/// <returns>The rendered form tag (not for the ending tab).</returns>
		public override string Render()
		{
			UrlHelper urls = new UrlHelper(this.ElementFactory.Html.ViewContext.RequestContext);

			TagElement form = TagElementBuilder.Create("FORM");
			form.Attributes.TryAppendAttributes(this.GetElement().HtmlAttributes)
				.AppendAttribute("action", string.IsNullOrEmpty(this.GetElement().ActionName)
					? this.ElementFactory.Html.ViewContext.HttpContext.Request.RawUrl
					: urls.Action(this.GetElement().ActionName, this.GetElement().ControllerName, this.GetElement().RouteValues));

			return form.ToHtmlString(TagRenderingMode.BeginTag);	
		}

		#endregion
	}
}
