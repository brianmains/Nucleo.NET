using System;

using Nucleo.Core;
using Nucleo.Dependencies;
using Nucleo.Views;


namespace Nucleo.Presentation.Creation
{
	public class DefaultPresenterCreator : IPresenterCreator
	{

		public IPresenter Create(Type presenterType, object view)
		{
			var resolver = FrameworkSettings.Resolver;
			if (resolver == null)
				return Activator.CreateInstance(presenterType, new object[] { view }) as IPresenter;

			return CreateUsingResolver(presenterType, view, resolver);
		}

		private IPresenter CreateUsingResolver(Type presenterType, object view, IDependencyResolver resolver)
		{
			var ctor = presenterType.GetConstructors()[0];
			var parms = ctor.GetParameters();
			var vals = new object[parms.Length];
			vals[0] = view;

			for (int i = 1, len = parms.Length; i < len; i++)
			{
				var parm = parms[i];
				vals[i] = resolver.GetDependency(parm.ParameterType) ?? parm.DefaultValue;
			}

			return (IPresenter)ctor.Invoke(vals);
		}
	}
}
