using System;

using Nucleo.Core;
using Nucleo.Dependencies;
using Nucleo.Modules;
using Nucleo.Presentation.Modules;
using Nucleo.Views;


namespace Nucleo.Presentation.Creation
{
	/// <summary>
	/// Represents the default creator of presenters.
	/// </summary>
	public class DefaultPresenterCreator : IPresenterCreator
	{
		private void AssignModule(IPresenter presenter)
		{
			if (presenter is IModularPresenter)
			{
				var assembly = presenter.GetType().Assembly;
				var module = ModuleInspector.GetModule(assembly);

				((IModularPresenter)presenter).Module = module;
			}
		}


		public IPresenter Create(Type presenterType, object view)
		{
			Guard.NotNull(presenterType);
			Guard.NotNull(view);

			IPresenter presenter;
			var resolver = FrameworkSettings.Resolver;

			if (resolver == null)
				presenter = Activator.CreateInstance(presenterType, new object[] { view }) as IPresenter;
			else
				presenter = CreateUsingResolver(presenterType, view, resolver);

			AssignModule(presenter);

			return presenter;
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

				//TODO:Research default value options for ParameterInfo
				vals[i] = resolver.GetDependency(parm.ParameterType);
				//vals[i] = resolver.GetDependency(parm.ParameterType) ?? parm.DefaultValue;
			}

			return (IPresenter)ctor.Invoke(vals);
		}
	}
}
