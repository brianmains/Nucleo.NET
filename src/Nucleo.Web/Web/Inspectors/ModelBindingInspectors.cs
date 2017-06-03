using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;


namespace Nucleo.Web.Inspectors
{
	/// <summary>
	/// Represents the collection of inspectors for model binding.
	/// </summary>
	public class ModelBindingInspectors
	{
		private List<IControlInspector> _inspectors = null;



		#region " Properties "

		protected List<IControlInspector> Inspectors
		{
			get
			{
				if (_inspectors == null)
					_inspectors = new List<IControlInspector>();

				return _inspectors;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the default set of inspectors.
		/// </summary>
		/// <returns>The default set of inspectors.</returns>
		public static ModelBindingInspectors GetDefault()
		{
			return new ModelBindingInspectors
			{
				_inspectors = new List<IControlInspector>
				{
					new CheckControlInspector(),
					new ListControlInspector(),
					new PanelInspector(),
					new TextControlInspector()
				}
			};
		}

		public IControlInspector GetInspectorForControl(Control control)
		{
			return this.Inspectors.FirstOrDefault(i => i.IsForControl(control.GetType()));
		}

		public void RegisterInspector(IControlInspector inspector)
		{
			this.Inspectors.Add(inspector);
		}

		#endregion
	}
}
