using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Security
{
	public abstract class BaseSecurityObject
	{
		private string _description = string.Empty;
		private Guid _id = Guid.Empty;
		private string _name = string.Empty;


		#region " Properties "

		public string Description
		{
			get { return _description; }
		}

		internal Guid ID
		{
			get { return _id; }
		}

		public string Name
		{
			get { return _name; }
		}

		#endregion



		#region " Constructors "

		protected internal BaseSecurityObject(string name, string description)
		{
			_name = name;
			_description = description;
		}

		protected internal BaseSecurityObject(Guid id, string name, string description)
			: this(name, description)
		{
			_id = id;
		}

		#endregion
	}
}
