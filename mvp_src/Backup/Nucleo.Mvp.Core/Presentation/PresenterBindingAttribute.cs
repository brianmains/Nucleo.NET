using System;


namespace Nucleo.Presentation
{
	/// <summary>
	/// Represents the binding of the presenter to the view.  Define this on the view user control/page.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class PresenterBindingAttribute : Attribute
	{
		private Type _presenterType = null;
		private string _presenterTypeName = null;



		#region " Properties "

		/// <summary>
		/// Gets the type of the presenter.
		/// </summary>
		public Type PresenterType
		{
			get { return _presenterType; }
		}

		/// <summary>
		/// Gets the type name of the presenter.
		/// </summary>
		public string PresenterTypeName
		{
			get { return _presenterTypeName; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the binding with the presenter type.
		/// </summary>
		/// <param name="presenterType">The type of presenter.</param>
		public PresenterBindingAttribute(Type presenterType)
		{
			_presenterType = presenterType;
		}

		/// <summary>
		/// Creates the binding with the presenter type name.
		/// </summary>
		/// <param name="presenterType">The type name of presenter.</param>
		public PresenterBindingAttribute(string presenterTypeName)
		{
			_presenterTypeName = presenterTypeName;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the type of presenter.
		/// </summary>
		/// <returns>The type of the presenter.</returns>
		public Type GetPresenterType()
		{
			if (this.PresenterType != null)
				return this.PresenterType;

			return Type.GetType(this.PresenterTypeName);
		}

		#endregion
	}
}
