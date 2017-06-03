using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Navigation
{
	[Obsolete]
	public class InlineNavigationManager : IInlineNavigationManager
	{
		private IDictionary<string, List<IInlineNavigationPresenter>> _presenters = null;



		#region " Presenters "

		private IDictionary<string, List<IInlineNavigationPresenter>> Presenters
		{
			get
			{
				if (_presenters == null)
					_presenters = new Dictionary<string, List<IInlineNavigationPresenter>>();

				return _presenters;
			}
		}

		#endregion



		#region " Methods "

		public void ChangeStatus(string navigationCommandName, bool active)
		{
			if (this.Presenters.ContainsKey(navigationCommandName))
			{
				var presenters = this.Presenters[navigationCommandName];
				foreach (var presenter in presenters)
					presenter.ChangeStatus(navigationCommandName, active);
			}
		}

		public void RegisterPresenter(IInlineNavigationPresenter presenter)
		{
			string[] keys = presenter.GetNavigationCommandNames();

			for (int index = 0, len = keys.Length; index < len; index++)
			{
				if (this.Presenters.ContainsKey(keys[index]))
					this.Presenters[keys[index]].Add(presenter);
				else
					this.Presenters.Add(keys[index], new List<IInlineNavigationPresenter> { presenter });
			}
		}

		#endregion
	}
}
