using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Mvc.Elements
{
	public abstract class BaseElementBuilder<TItem, TBuilder>
		where TItem: class
		where TBuilder: BaseElementBuilder<TItem, TBuilder>
	{
		private TItem _element = null;
		private NucleoElementFactory _elementFactory = null;



		#region " Properties "

		protected internal NucleoElementFactory ElementFactory
		{
			get { return _elementFactory; }
		}

		#endregion



		#region " Constructors "

		public BaseElementBuilder(NucleoElementFactory elementFactory)
		{
			_elementFactory = elementFactory;
		}

		public BaseElementBuilder(NucleoElementFactory elementFactory, TItem element)
			: this(elementFactory)
		{
			_element = element;
		}

		#endregion



		#region " Methods "

		protected internal TItem GetElement()
		{
			if (_element == null)
				_element = Activator.CreateInstance<TItem>();
			return _element;
		}

		public abstract string Render();

		#endregion
	}
}
