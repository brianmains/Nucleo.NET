using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Web.Mvc.DataControls
{
	public class BindingPanelComponentBuilder<T> : BaseMvcServerComponentBuilder<BindingPanelComponentBuilder<T>>
	{
		private Action<T> _content = null;
		private T _data = default(T);
		private System.Action _noDataContent = null;



		#region " Constructors "

		/// <summary>
		/// Creates the control builder.
		/// </summary>
		/// <param name="controlFactory">The factory.</param>
		/// <param name="data">The underlying data.</param>
		public BindingPanelComponentBuilder(NucleoControlFactory controlFactory, T data)
			: base(controlFactory)
		{
			_data = data;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Sets the content of the binding panel, if data does exist.
		/// </summary>
		/// <param name="content">The content action to use for the data template.</param>
		/// <returns>The component builder.</returns>
		public BindingPanelComponentBuilder<T> Content(Action<T> content)
		{
			_content = content;
			return this;
		}

		/// <summary>
		/// Sets the content of the binding panel, if data does not exist.
		/// </summary>
		/// <param name="content">The content action to use for the data template.</param>
		/// <returns>The component builder.</returns>
		public BindingPanelComponentBuilder<T> NoDataContent(System.Action noDataContent)
		{
			_noDataContent = noDataContent;
			return this;
		}

		/// <summary>
		/// Renders the UI of the component.
		/// </summary>
		/// <param name="writer">The control writer.</param>
		protected override void RenderUI(BaseControlWriter writer)
		{
			bool hasData = (_data != null);
			if (hasData)
			{
				if (_data is IEnumerable)
					hasData = (((IEnumerable)_data).Cast<object>().FirstOrDefault() != null);
			}

			writer.Write("<div>");

			if (hasData)
				_content(_data);
			else
				_noDataContent();

			writer.Write("</div>");
		}

		#endregion
	}
}