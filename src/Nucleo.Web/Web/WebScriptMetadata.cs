using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web
{
	public abstract class WebScriptMetadata
	{
		private object _component = null;



		#region " Properties "

		public object Component
		{
			get { return _component; }
		}

		#endregion



		#region " Methods "

		public abstract ScriptReferencingRequestDetailsCollection GetPrimaryScripts();

		public virtual void Initialize(object component)
		{
			_component = component;
		}

		#endregion
	}
}
