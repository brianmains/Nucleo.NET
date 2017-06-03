using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Mvc
{
	/// <summary>
	/// Represents a command; this is similar to a command for a button control in ASP.NET web forms, but not limited to that situation.
	/// </summary>
	public class Command
	{
		private string _argument;
		private string _name;



		#region " Properties "

		/// <summary>
		/// Gets the argument of the command.
		/// </summary>
		public string Argument
		{
			get { return _argument; }
		}

		/// <summary>
		/// Gets the name of the command.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the command with the given name.
		/// </summary>
		/// <param name="name">The name of the command.</param>
		public Command(string name)
		{
			_name = name;
		}

		/// <summary>
		/// Creates the command with the given name/argument.
		/// </summary>
		/// <param name="name">The name of the command.</param>
		/// <param name="argument">An associated argument related to the command.</param>
		public Command(string name, string argument)
			: this(name)
		{
			_argument = argument;
		}

		#endregion
	}
}
