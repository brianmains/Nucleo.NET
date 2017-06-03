using System;
using Nucleo.Collections;


namespace Nucleo.Security
{
	public class UserCollection : SimpleCollection<UserAccount>
	{
		#region " Methods "

		public static UserCollection FromString(string users)
		{
			string[] userList = users.Split(',');
			UserCollection collection = new UserCollection();

			foreach (string user in userList)
			{
				if (!string.IsNullOrEmpty(user) && user != "\r\n")
					collection.Add(UserAccount.FromUserName(user));
			}

			return collection;
		}

		#endregion
	}
}
