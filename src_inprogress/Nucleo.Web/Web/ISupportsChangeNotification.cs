using System;
using System.Collections.Generic;

using Nucleo.EventArguments;


namespace Nucleo.Web
{
	public interface ISupportsChangeNotification
	{
		event ChangeEventHandler ChangesOccurred;
		bool HasChanges { get; }
	}
}
