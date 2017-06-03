using System;
using System.Web.Security;

using Nucleo.Web.Security;


namespace System.Web.Security
{
	public static class MembershipExtensions
	{
		public static string GetFriendlyMessage(this MembershipCreateStatus status)
		{
			if (status == MembershipCreateStatus.Success)
				return "The user was created successfully.";
			else if (status == MembershipCreateStatus.InvalidUserName)
				return "The user name provided is not valid.";
			else if (status == MembershipCreateStatus.InvalidEmail)
				return "The email address provided is not valid.";
			else
				return "An error occurred when trying to create the user account.  Please review your information, and try again.";
		}
	}
}
