﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Navigation
{
	[Obsolete]
	public interface IInlineNavigationManager
	{
		void ChangeStatus(string navigationCommandName, bool active);
		void RegisterPresenter(IInlineNavigationPresenter presenter);
	}
}
