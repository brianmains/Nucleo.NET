using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.CodeGeneration
{
	public class ClassMethodMember : ClassMember
	{
		private MethodParameterCollection _parameters = null;



		#region " Properties "

		public MethodParameterCollection Parameters
		{
			get
			{
				if (_parameters == null)
					_parameters = new MethodParameterCollection();

				return _parameters;
			}
			set { _parameters = value; }
		}

		public override ClassMemberType Type
		{
			get { return ClassMemberType.Method; }
		}

		#endregion
	}
}
