using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using Nucleo.EventArguments;
using Nucleo.Models;
using Nucleo.Views;
using Nucleo.Dependencies;
using Nucleo.Presentation.Creation;
using Nucleo.Presentation.Discovery;
using Nucleo.Presentation.Initialization;


namespace Nucleo.Presentation
{
	/// <summary>
	/// Represents the manager used to create presenters.
	/// </summary>
	public class PresentationManager
	{
		private IPresenterCreator _builder = null;
		private IPresentationDiscoveryStrategy _discoveryStrategy = null;
		private IDependencyResolver _resolver = null;
		private ModelInjectionManager _register = null;



		#region " Events "

		/// <summary>
		/// Fires when the presenter is created, but not yet returned from the caller.
		/// </summary>
		public static event PresenterEventHandler PresenterFound;

		#endregion



		#region " Constructors "

		private PresentationManager() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Creates an instance of the presentation manager.
		/// </summary>
		/// <returns>The manager.</returns>
		public static PresentationManager Create()
		{
			return new PresentationManager();
		}

		/// <summary>
		/// Creates an instance of the presentation manager using a builder of type <see cref="IPresenterCreator"/>.
		/// </summary>
		/// <param name="builder">The builder used to create the presenter.</param>
		/// <returns>The manager.</returns>
		public static PresentationManager Create(PresenterOptions options)
		{
			if (options == null)
				throw new ArgumentNullException("options");

			PresentationManager mgr = new PresentationManager();
			mgr._builder = options.Creator;
			mgr._discoveryStrategy = options.DiscoveryStrategy;
			mgr._resolver = options.Resolver;
			return mgr;
		}

		private IPresenter CreatePresenter(Type presenterType, IView view, IPresenterCreator creator)
		{
			return ((creator != null)
				? creator.Create(presenterType, view)
				: Activator.CreateInstance(presenterType, new object[] { view })) as IPresenter;
		}

		private void Initialize(IPresenter presenter)
		{
			if (_resolver == null)
				return;

			var initializer = _resolver.GetDependency<IPresenterInitializer>();
			if (initializer == null)
				return;

			initializer.Initialize(presenter);			
		}

		/// <summary>
		/// Loads the presenter mapped to the view.  Currently, this process looks for a <see cref="PresenterBindingAttribute"/> definition.
		/// </summary>
		/// <param name="view">The view to load the presenter for.</param>
		/// <returns>The presenter that was mapped, or null if nothing was found.</returns>
		public IPresenter Load(IView view)
		{
			if (_discoveryStrategy == null)
				_discoveryStrategy = new DefaultPresentationDiscoveryStrategy();

			//PresenterBindingAttribute presenterBinding = view.GetType().GetCustomAttribute<PresenterBindingAttribute>(true);
			//if (presenterBinding == null)
			//    return null;

			//Type presenterType = presenterBinding.GetPresenterType();
			//if (presenterType == null)
			//    return null;

			Type presenterType = _discoveryStrategy.FindPresenterType(new DiscoveryOptions { View = view });
			if (presenterType == null) return null;

			IPresenter presenter = this.CreatePresenter(presenterType, view, _builder);
			if (presenter == null) return null;

			this.Initialize(presenter);

			OnPresenterFound(this, presenter, view);
			return presenter;
		}
		
		/// <summary>
		/// Loads the presenter with the associated view.
		/// </summary>
		/// <typeparam name="TPresenter">The type of presenter to load.</typeparam>
		/// <param name="view">The view to pass to the presenter.</param>
		/// <returns>The loaded presenter.</returns>
		/// <example>
		/// var presenter = PresenterManager.Create().Load&lt;MyPresenter>(myView);
		/// </example>
		public TPresenter Load<TPresenter>(IView view)
			where TPresenter : IPresenter
		{
			TPresenter presenter = (TPresenter)this.Load(typeof(TPresenter), view);

			return presenter;
		}

		/// <summary>
		/// Loads the presenter with the associated view.
		/// </summary>
		/// <typeparam name="TPresenter">The type of presenter to load.</typeparam>
		/// <typeparam name="TView">The type of view to load.</typeparam>
		/// <param name="view">The view to pass to the presenter.</param>
		/// <returns>The loaded presenter.</returns>
		/// <example>
		/// var presenter = PresenterManager.Create().Load&lt;MyPresenter>(myView);
		/// </example>
		public TPresenter Load<TPresenter, TView>(TView view)
			where TPresenter: IPresenter<TView>
			where TView: IView
		{
			TPresenter presenter = (TPresenter)this.Load(typeof(TPresenter), view);

			return presenter;
		}

		/// <summary>
		/// Loads the presenter with the associated view.
		/// </summary>
		/// <param name="presenterType">The type of presenter to create.</param>
		/// <param name="view">The view to pass to the presenter.</param>
		/// <returns>The loaded presenter.</returns>
		/// <example>
		/// var presenter = PresenterManager.Create().Load&lt;MyPresenter>(myView);
		/// </example>
		public IPresenter Load(Type presenterType, object view)
		{
			IPresenter presenter = this.CreatePresenter(presenterType, (IView)view, _builder);

			OnPresenterFound(this, presenter, (IView)view);

			return presenter;
		}

		protected static void OnPresenterFound(PresentationManager manager, IPresenter presenter, IView view)
		{
			if (PresenterFound != null)
				PresenterFound(manager, new PresenterEventArgs(presenter, view));
		}

		#endregion
	}
}
