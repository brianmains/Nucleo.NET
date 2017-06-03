using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.State
{
	/// <summary>
	/// Represents a user that may be authenticated.
	/// </summary>
	public class StateUser
	{
		private bool _isAuthenticated = false;
		private string _userName = null;



		#region " Properties "

		/// <summary>
		/// Gets whether the user is authenticated in the underlying system.
		/// </summary>
		public bool IsAuthenticated
		{
			get { return _isAuthenticated; }
		}

		/// <summary>
		/// Gets the name of the user.
		/// </summary>
		public string UserName
		{
			get { return _userName; }
		}

		#endregion



		#region " Constructors "

		public StateUser(string userName, bool isAuthenticated)
		{
			_userName = userName;
			_isAuthenticated = isAuthenticated;
		}

		#endregion
	}
}
