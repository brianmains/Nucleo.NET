using System;
using System.Reflection;


namespace System.Reflection
{
	/// <summary>
	/// Extensions for reflection members.
	/// </summary>
	public static class MemberInfoExtensions
	{
		#region " Methods "

		/// <summary>
		/// Gets a single custom attribute, the first one by type or null if not found.  Will inherit if set.
		/// </summary>
		/// <typeparam name="T">The type of attribute.</typeparam>
		/// <param name="member">The member to extend.</param>
		/// <param name="inherit">Whether to inherit from base types.</param>
		/// <returns>The instance of the attribute or null.</returns>
#if NET20
		public static T GetCustomAttribute<T>(MemberInfo member, bool inherit)
#else
		public static T GetCustomAttribute<T>(this MemberInfo member, bool inherit)
#endif
			where T: Attribute
		{
			object[] attributes = member.GetCustomAttributes(typeof(T), inherit);
			return (attributes.Length > 0) ? (T)attributes[0] : default(T);
		}

		#endregion
	}
}
