using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm.Triggers
{
	public class ActionTrigger : ITrigger
	{
		private Action<object, TriggerAction> _actionToRun = null;
		private bool _isForObject = true;



		#region " Constructors "

		public ActionTrigger(bool isForObject, Action<object, TriggerAction> fireAction)
		{
			_isForObject = isForObject;
			_actionToRun = fireAction;
		}

		#endregion



		#region " Methods "

		public bool Fire(object obj, TriggerAction action)
		{
			if (_actionToRun != null)
				_actionToRun(obj, action);
			return true;
		}

		public bool IsForObject(object obj, TriggerAction action)
		{
			return _isForObject;
		}

		#endregion
	}
}
