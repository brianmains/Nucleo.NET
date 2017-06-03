using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Presentation.Creation;


namespace Nucleo.Tests.PresenterCreation
{
	public class FirstLookPresenter : BasePresenter
	{
		public FirstLookPresenter(IView view)
			: base(view) { }
	}

	/// <summary>
	/// This would normally be stored in the configuration file.  This example simplifies it a bit.
	/// The configuration file is the &lt;frameworkSettings> configuration element, and points
	/// to the object that implements IPresenterCreator.
	/// </summary>
	public class TempPresenterCreator : IPresenterCreator
	{
		#region " Methods "

		public IPresenter Create(Type presenterType, object view)
		{
			return new FirstLookPresenter((IView)view);
		}

		#endregion
	}
}