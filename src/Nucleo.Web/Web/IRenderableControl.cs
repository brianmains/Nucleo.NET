using System;
using System.Web.UI;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents the interface for allowing a control to render using the <see cref="BaseControlWriter"/> class.
	/// </summary>
	public interface IRenderableControl
	{
		void RenderUI(BaseControlWriter writer);
	}
}
