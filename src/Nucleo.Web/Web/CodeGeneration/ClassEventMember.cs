using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.CodeGeneration
{
	public class ClassEventMember : ClassMember
	{
		public override ClassMemberType Type
		{
			get { return ClassMemberType.Event; }
		}
	}
}
