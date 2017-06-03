using System;
using Nucleo.Windows.Application;


namespace Nucleo.Windows.UI
{
	public abstract class BaseWindow : UIElement
	{
		private object _uiInterface = null;



		#region " Properties "

		public override ValuePath CurrentPath
		{
			get { return new ValuePath(this.Name); }
		}

		public object UIInterface
		{
			get { return _uiInterface; }
			set { _uiInterface = value; }
		}

		#endregion



		#region " Constructors "

		public BaseWindow(string name, string title, object uiInterface)
			: base(name, title)
		{
			_uiInterface = uiInterface;
		}

		#endregion
	}
}
