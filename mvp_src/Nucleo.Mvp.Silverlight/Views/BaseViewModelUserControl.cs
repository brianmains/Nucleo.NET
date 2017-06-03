using System;
using System.Windows;

using Nucleo.Views;


namespace Nucleo.Views
{
	/// <summary>
	/// Represents the base view for a user control.
	/// </summary>
	/// <typeparam name="TModel">The model reference.</typeparam>
	public abstract class BaseViewModelUserControl : BaseViewUserControl, IViewModel
	{
		private static readonly DependencyProperty ModelProperty;



		#region " Properties "

		/// <summary>
		/// Gets or sets the model.
		/// </summary>
		public object Model
		{
			get { return base.GetValue(ModelProperty); }
			set { base.SetValue(ModelProperty, value); }
		}

		#endregion



		#region " Constructors "

		static BaseViewModelUserControl()
		{
			ModelProperty = DependencyProperty.Register("Model", typeof(object), typeof(BaseViewUserControl), null);
		}

		#endregion
	}
}
