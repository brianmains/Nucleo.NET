using System;


namespace Nucleo.Windows.Application
{
	public class ModuleAttribute : System.Attribute
	{
		private Type _moduleType = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the type of module to provide a reference for.
		/// </summary>
		public Type ModuleType
		{
			get { return _moduleType; }
			set { _moduleType = value; }
		}

		#endregion



		#region " Constructors "

		public ModuleAttribute(Type moduleType)
		{
			if (!moduleType.IsAssignableFrom(typeof(BaseModule)))
				throw new ArgumentException("The module type must inherit from the BaseModule class.");

			_moduleType = moduleType;
		}

		#endregion
	}
}
