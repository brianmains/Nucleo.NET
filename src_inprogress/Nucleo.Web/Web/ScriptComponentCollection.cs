using System;
using System.Collections.Generic;

using Nucleo.Collections;


namespace Nucleo.Web
{
	public class ScriptComponentCollection : SimpleCollection<IScriptComponent>
	{
		#region " Constructors "

		public ScriptComponentCollection() { }

		public ScriptComponentCollection(IEnumerable<IScriptComponent> components)
		{
			foreach (IScriptComponent component in components)
				this.Add(component);
		}

		#endregion



		#region " Methods "

		public override void Add(IScriptComponent item)
		{
			base.Add(item);
		}

		public void RegisterScriptComponentDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			foreach (IScriptComponent component in this)
				component.RegisterAjaxDescriptors(registrar, currentDescriptor);
		}

		public void RegisterScriptComponentReferences(IContentRegistrar registrar)
		{
			foreach (IScriptComponent component in this)
				component.RegisterAjaxReferences(registrar);
		}

		public override void Remove(IScriptComponent item)
		{
			base.Remove(item);
		}

		#endregion
	}
}
