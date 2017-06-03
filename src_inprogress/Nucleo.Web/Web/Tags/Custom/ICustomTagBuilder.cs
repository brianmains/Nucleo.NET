using System;

using Nucleo.Web.Tags;


namespace Nucleo.Web.Tags.Custom
{
	public interface ICustomTagBuilder
	{
		TagElement ToElement();
	}
}
