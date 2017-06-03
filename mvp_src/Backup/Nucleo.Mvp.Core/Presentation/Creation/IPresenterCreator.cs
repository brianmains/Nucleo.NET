using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Presentation;


namespace Nucleo.Presentation.Creation
{
	public interface IPresenterCreator
	{
		#region " Methods "

		IPresenter Create(Type presenterType, object view);

		#endregion
	}
}
