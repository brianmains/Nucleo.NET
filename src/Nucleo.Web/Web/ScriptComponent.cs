using System;
using System.Collections.Generic;


namespace Nucleo.Web
{
	public class ScriptComponent
	{
		private string _clientPropertyName = null;
		private IScriptComponent _componentInstance = null;



		#region " Properties "

		/// <summary>
		/// Gets the property name of the client; which is used when writing the component to the descriptor.
		/// </summary>
		public string ClientPropertyName
		{
			get { return _clientPropertyName; }
		}

		/// <summary>
		/// Gets the component instance.
		/// </summary>
		public IScriptComponent ComponentInstance
		{
			get { return _componentInstance; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the script component.
		/// </summary>
		/// <param name="componentInstance">The component instance.</param>
		/// <param name="clientPropertyName">The client property name.</param>
		public ScriptComponent(IScriptComponent componentInstance, string clientPropertyName)
		{
			if (componentInstance == null)
				throw new ArgumentNullException("componentInstance");

			_componentInstance = componentInstance;
			_clientPropertyName = clientPropertyName;
		}

		#endregion
	}
}
