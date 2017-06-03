using System;


namespace Nucleo.Orm.Generic
{
	public interface IEntityKeyGenerator
	{
		string GenerateName(Type entityType, string entityName);
	}
}
