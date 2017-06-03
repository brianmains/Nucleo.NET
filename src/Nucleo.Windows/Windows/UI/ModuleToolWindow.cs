using System;
using Nucleo.Windows.Application;


namespace Nucleo.Windows.UI
{
	public class ModuleToolWindow : BaseCustomToolWindow
	{
		private ModuleElementCollection _elements = null;
		private BaseModule _module = null;



		#region " Properties "

		public ModuleElementCollection Elements
		{
			get
			{
				if (_elements == null)
					_elements = new ModuleElementCollection();
				return _elements;
			}
		}

		public BaseModule Module
		{
			get { return _module; }
		}

		#endregion



		#region " Constructors "

		public ModuleToolWindow(string name, string title, ToolWindowLocation location, object uiInterface, BaseModule module)
			: base(name, title, location, uiInterface)
		{
			_module = module;
		}

		#endregion
	}
}
