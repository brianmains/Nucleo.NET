using System;
using Nucleo.Collections;


namespace Nucleo.Security
{
	/// <summary>
	/// Represents a collection of roles.
	/// </summary>
	public class RoleCollection : SimpleCollection<Role>
	{
		#region " Constructors "

		/// <summary>
		/// Creates an empty role collection.
		/// </summary>
		public RoleCollection() { }

		/// <summary>
		/// Creates a role collection with the given roles.
		/// </summary>
		/// <param name="roles">The collection array of roles.</param>
		public RoleCollection(string[] roles)
		{
			if (roles == null)
				throw new ArgumentNullException("roles");

			foreach (string role in roles)
				this.Add(new Role(role));
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Converts a comma separated array into a role collection.
		/// </summary>
		/// <param name="roles">The comma separated string of roles.</param>
		/// <returns>The collection of roles.</returns>
		public static RoleCollection FromString(string roles)
		{
			if (roles == null)
				throw new ArgumentNullException("roles");

			RoleCollection collection = new RoleCollection();
			if (roles == string.Empty)
				return collection;

			string[] roleList = roles.Split(',');
			foreach (string role in roleList)
			{
				if (!string.IsNullOrEmpty(role) && role != @"\r\n")
					collection.Add(new Role(role));
			}

			return collection;
		}

		#endregion
	}
}
