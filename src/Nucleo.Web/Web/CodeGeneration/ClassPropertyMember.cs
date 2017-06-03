using System;


namespace Nucleo.Web.CodeGeneration
{
	public class ClassPropertyMember : ClassMember
	{

		#region " Properties "

		public override ClassMemberType Type
		{
			get { return ClassMemberType.Property; }
		}

		#endregion
	}
}
