using System;
using System.Web.Security;
using System.Security.Principal;


namespace Nucleo.Security
{
	public class UserAccount : IIdentity
	{
		private string _authenticationType = null;
		private bool _isAuthenticated = false;
		private string _name = null;



		#region " Properties "

		public string AuthenticationType
		{
			get { return _authenticationType; }
		}

		public bool IsAuthenticated
		{
			get { return _isAuthenticated; }
		}

		public string Name
		{
			get { return _name; }
		}

		#endregion



		#region " Constructors "

		private UserAccount() { }

		private UserAccount(string name, bool isAuthenticated, string authenticationType)
		{
			_name = name;
			_isAuthenticated = isAuthenticated;
			_authenticationType = authenticationType;
		}

		#endregion



		#region " Methods "

		public static UserAccount FromIdentity(IIdentity user)
		{
			if (user == null)
				return new UserAccount();

			return new UserAccount(user.Name, user.IsAuthenticated, user.AuthenticationType);
		}

		public static UserAccount FromMembership(MembershipUser user)
		{
			if (user == null)
				return new UserAccount();

			return new UserAccount(user.UserName, true, "ASP.NET Membership");
		}

		public static UserAccount FromUserName(string user)
		{
			if (string.IsNullOrEmpty(user))
				return new UserAccount();

			return new UserAccount(user, true, "Unknown");
		}

		public static UserAccount FromWindowsAccount()
		{
			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			return FromIdentity(identity);
		}

		#endregion
	}
}
