using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using Nucleo.Lookups;


namespace Nucleo.Web.Mvc.DropDownControls
{
	/// <summary>
	/// Represents a component that uses the lookup repository system.
	/// </summary>
	public class LookupComponentBuilder : BaseMvcServerComponentBuilder<LookupComponentBuilder>
	{
		private LookupCriteria _criteria = null;
		private IDictionary<string, object> _htmlAttributes = null;
		private string _lookupName = null;
		private string _name = null;
		private LookupInterfaceType _ui = LookupInterfaceType.DropDown;



		#region " Constructors "

		public LookupComponentBuilder(NucleoControlFactory controlFactory) 
			: base(controlFactory) { }

		#endregion



		#region " Methods "

		public LookupComponentBuilder Criteria(LookupCriteria criteria)
		{
			if (criteria == null)
				throw new ArgumentNullException("criteria");

			_criteria = criteria;
			return this;
		}

		public LookupComponentBuilder HtmlAttributes(IDictionary<string, object> htmlAttributes)
		{
			_htmlAttributes = htmlAttributes;
			return this;
		}

		public LookupComponentBuilder Interface(LookupInterfaceType ui)
		{
			_ui = ui;
			return this;
		}

		public LookupComponentBuilder LookupName(string lookupName)
		{
			if (string.IsNullOrEmpty(lookupName))
				throw new ArgumentNullException("lookupName");

			_lookupName = lookupName;
			return this;
		}

		public LookupComponentBuilder Name(string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			_name = name;
			return this;
		}

		protected override void RenderUI(BaseControlWriter writer)
		{
			ILookupRepository repository = LookupManager.Create().GetLookupRepository(_lookupName);
			LookupCollection lookups = repository.GetAllValues(_criteria);

			writer.Write(base.ControlFactory.Html.DropDownList(_name, lookups.ToListItems(), _htmlAttributes));
		}

		#endregion
	}
}
