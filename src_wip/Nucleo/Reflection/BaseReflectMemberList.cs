using System;
using System.Collections.Generic;
using System.Reflection;


namespace Nucleo.Reflection
{
	public class BaseReflectMemberList
	{
		private object _target = null;
		private bool _isPrivate = false;



		#region " Properties "

		protected bool IsPrivate
		{
			get { return _isPrivate; }
		}

		protected object Target
		{
			get { return _target; }
		}

		#endregion



		#region " Constructors "

		public BaseReflectMemberList(object target, bool isPrivate)
		{
			_target = target;
			_isPrivate = isPrivate;
		}

		#endregion



		#region " Methods "

		protected BindingFlags GetFlags()
		{
			if (_isPrivate)
				return (BindingFlags.Instance | BindingFlags.NonPublic);
			else
				return (BindingFlags.Instance | BindingFlags.Public);
		}

		#endregion
	}
}
