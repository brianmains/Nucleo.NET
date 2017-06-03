using System;
using Nucleo.Windows.Application;


namespace Nucleo.DependencyInjection
{
	public class WindowsApplicationFrameworkReceiver : IDependencyInjectionReceiver
	{
		#region " Methods "

		public virtual object GetInjectedObject(object baseObject, object member, Type attributeType)
		{
			if (attributeType.Equals(typeof(CreateNewAttribute)))
			{
				Type objectType = DependencyInjectionHelper.GetUnderlyingType(member);
				if (objectType == null) return null;

				if (objectType.Equals(typeof(ApplicationModel)))
					return ApplicationModel.Instantiate();
				else if (objectType.Equals(typeof(ModuleService)))
					return new ModuleService();
				else
					throw new NotSupportedException();
			}
			else
				throw new NotSupportedException();
		}

		#endregion
	}
}
