using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.CodeGeneration
{
	/// <summary>
	/// Represents a member within a class.
	/// </summary>
	public abstract class ClassMember
	{
		private string _name = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the class member.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the type of class member.
		/// </summary>
		public abstract ClassMemberType Type
		{
			get;
		}

		#endregion
	}
}
