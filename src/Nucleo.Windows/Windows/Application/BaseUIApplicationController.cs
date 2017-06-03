using System;
using System.Reflection;
using Nucleo.Windows.UI;
using Nucleo.Windows.Application.Configuration;


namespace Nucleo.Windows.Application
{
	public class BaseUIApplicationController : BaseApplicationController
	{
		private InterfaceRenderer<DocumentWindow> _documentRenderer = null;
		private InterfaceRenderer<MenuItem> _menuRenderer = null;
		private InterfaceRenderer<Toolbar> _toolbarRenderer = null;
		private InterfaceRenderer<ToolbarItem> _toolbarItemRenderer = null;
		private InterfaceRenderer<ToolWindow> _toolWindowRenderer = null;
		private bool _loadFromConfiguration = false;



		#region " Properties "

		protected InterfaceRenderer<DocumentWindow> DocumentRenderer
		{
			get
			{
				if (_documentRenderer == null && _loadFromConfiguration)
					_documentRenderer = this.LoadFromConfiguration<DocumentWindow>(WindowsInterfaceType.DocumentWindow);

				return _documentRenderer;
			}
		}

		protected InterfaceRenderer<MenuItem> MenuRenderer
		{
			get
			{
				if (_menuRenderer == null && _loadFromConfiguration)
					_menuRenderer = this.LoadFromConfiguration<MenuItem>(WindowsInterfaceType.Menu);

				return _menuRenderer;
			}
		}

		protected InterfaceRenderer<ToolbarItem> ToolbarItemRenderer
		{
			get
			{
				if (_toolbarItemRenderer == null && _loadFromConfiguration)
					_toolbarItemRenderer = this.LoadFromConfiguration<ToolbarItem>(WindowsInterfaceType.ToolbarItem);

				return _toolbarItemRenderer;
			}
		}

		protected InterfaceRenderer<Toolbar> ToolbarRenderer
		{
			get
			{
				if (_toolbarRenderer == null && _loadFromConfiguration)
					_toolbarRenderer = this.LoadFromConfiguration<Toolbar>(WindowsInterfaceType.Toolbar);

				return _toolbarRenderer;
			}
		}

		protected InterfaceRenderer<ToolWindow> ToolWindowRenderer
		{
			get
			{
				if (_toolWindowRenderer == null && _loadFromConfiguration)
					_toolWindowRenderer = this.LoadFromConfiguration<ToolWindow>(WindowsInterfaceType.ToolWindow);
				return _toolWindowRenderer;
			}
		}

		#endregion



		#region " Constructors "

		public BaseUIApplicationController(ApplicationModel application)
			: base(application)
		{
			ApplicationControllerSection section = ApplicationControllerSection.Instance;
			if (section == null)
				throw new System.Configuration.ConfigurationErrorsException("The nucleo/applicationControllers configuration section has not been defined; to use this constructor, it must be.");
			_loadFromConfiguration = true;
		}

		public BaseUIApplicationController(ApplicationModel application, InterfaceRenderer<MenuItem> menuItems, InterfaceRenderer<Toolbar> toolbars, InterfaceRenderer<ToolbarItem> toolbarItems, InterfaceRenderer<DocumentWindow> documentWindows, InterfaceRenderer<ToolWindow> toolWindows)
			: base(application)
		{
			_menuRenderer = menuItems;
			_documentRenderer = documentWindows;
			_toolbarRenderer = toolbars;
			_toolbarItemRenderer = toolbarItems;
			_toolWindowRenderer = toolWindows;
		}

		#endregion



		#region " Methods "

		protected override void AddDocumentWindow(int index, DocumentWindow window)
		{
			_documentRenderer.AddItem(index, window);
		}

		protected override void AddMenuItem(int index, MenuItem menu)
		{
			_menuRenderer.AddItem(index, menu);
		}

		protected override void AddToolbar(int index, Toolbar toolbar)
		{
			_toolbarRenderer.AddItem(index, toolbar);
		}

		protected override void AddToolbarItem(int index, ToolbarItem toolbarItem)
		{
			_toolbarItemRenderer.AddItem(index, toolbarItem);
		}

		protected override void AddToolWindow(int index, ToolWindow window)
		{
			_toolWindowRenderer.AddItem(index, window);
		}

		private InterfaceRenderer<T> LoadFromConfiguration<T>(WindowsInterfaceType uiInterface)
			where T:UIElement
		{
			ApplicationControllerSection section = ApplicationControllerSection.Instance;
			ApplicationControllerInterfaceElement element = section.Interfaces[uiInterface];

			Type rendererType = Type.GetType(element.RendererType);
			Type controlType = Type.GetType(element.ControlType);

			ConstructorInfo ctor = rendererType.GetConstructor(new Type[] { controlType, typeof(ApplicationModel) });
			if (ctor == null)
				throw new Exception(string.Format("The renderer type defined for '{0}' must have a constructor of type ({1}, ApplicationModel)", uiInterface, controlType.Name));

			return (InterfaceRenderer<T>)ctor.Invoke(new object[] { Activator.CreateInstance(controlType), base.Application });
		}

		protected override void RemoveDocumentWindow(DocumentWindow window)
		{
			_documentRenderer.RemoveItem(window);
		}

		protected override void RemoveMenuItem(MenuItem menu)
		{
			_menuRenderer.RemoveItem(menu);
		}

		protected override void RemoveToolbar(Toolbar toolbar)
		{
			_toolbarRenderer.RemoveItem(toolbar);
		}

		protected override void RemoveToolbarItem(ToolbarItem toolbarItem)
		{
			_toolbarItemRenderer.RemoveItem(toolbarItem);
		}

		protected override void RemoveToolWindow(ToolWindow window)
		{
			_toolWindowRenderer.RemoveItem(window);
		}

		#endregion
	}
}
