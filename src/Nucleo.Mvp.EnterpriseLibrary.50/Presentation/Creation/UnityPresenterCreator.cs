using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;

using Nucleo.Presentation;


namespace Nucleo.Presentation.Creation
{
	/// <summary>
	/// Represents a presenter creator that uses the unity dependency injector.
	/// </summary>
	public class UnityPresenterCreator : IPresenterCreator
	{
		private IUnityContainer _container = null;



		#region " Properties "

		public IUnityContainer Container
		{
			get
			{
				if (_container == null)
					_container = new UnityContainer();

				return _container;
			}
		}

		#endregion




		#region " Constructors "

		public UnityPresenterCreator() { }

		public UnityPresenterCreator(IUnityContainer container)
		{
			_container = container;
		}

		#endregion



		#region IPresenterCreator Members

		/// <summary>
		/// Creates the presenter by using the unity container to inject any constructor references it knows about.
		/// </summary>
		/// <param name="presenterType">The type of presenter.</param>
		/// <param name="view">The view instance.</param>
		/// <returns>The presenter instance created by the unity container.</returns>
		public IPresenter Create(Type presenterType, object view)
		{
			return _container.Resolve(presenterType, new ParameterOverride("view", view)) as IPresenter;
		}

		#endregion
	}
}
