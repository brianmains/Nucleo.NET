using System;
using System.Web.UI;


namespace Nucleo.Web.Mappings
{
	public class ControlManagerFactory
	{
		private static readonly ControlManagerFactory _instance = new ControlManagerFactory();
		private ControlManagerCollection _managers = null;



		#region " Properties "

		/// <summary>
		/// Gets the representation of the manager factory, with all of the instantiated managers.
		/// </summary>
		internal static ControlManagerFactory Instance
		{
			get { return _instance; }
		}

		/// <summary>
		/// Gets the collection of managers to lookup.
		/// </summary>
		private ControlManagerCollection Managers
		{
			get
			{
				if (_managers == null)
					_managers = new ControlManagerCollection();
				return _managers;
			}
		}

		#endregion



		#region " Constructors "

		private ControlManagerFactory() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Finds the target manager by the instance of the control.
		/// </summary>
		/// <param name="control">The control to use to find the appropriate manager.</param>
		/// <returns>The manager that manages that control type.</returns>
		public static ControlManager FindManager(Control control)
		{
			if (control == null)
				throw new ArgumentNullException("control");

			return Instance.Managers.FindByControl(control);
		}

		/// <summary>
		/// Registers an instance of the manager with the factory.
		/// </summary>
		/// <param name="manager">The manager to register.</param>
		public static void RegisterManager(ControlManager manager)
		{
			if (manager == null)
				throw new ArgumentNullException("manager");

			Instance.Managers.Add(manager);
		}

		#endregion
	}
}
