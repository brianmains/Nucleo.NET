using System;
using Nucleo.Windows.Application;


namespace Nucleo.Windows.UI
{
	public class ModuleDocumentWindow : BaseCustomDocumentWindow
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

		/// <summary>
		/// Gets the module that the document window is created for.
		/// </summary>
		public BaseModule Module
		{
			get { return _module; }
		}

		#endregion



		#region " Constructors "

		public ModuleDocumentWindow(string name, string title, object uiInterface, BaseModule module)
			: base(name, title, uiInterface)
		{
			_module = module;
		}

		#endregion
	}
}
