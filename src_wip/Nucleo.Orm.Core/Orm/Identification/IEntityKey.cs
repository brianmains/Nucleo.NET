using System;


namespace Nucleo.Orm.Identification
{
	public interface IEntityKey
	{
        object KeyIdentifier { get; set; }
	}
}
