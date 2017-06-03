
namespace Nucleo.Web
{
	/// <summary>
	/// Interface that represents an AJAX control, which has both a server and client piece.
	/// </summary>
	public interface IAjaxControl : IAjaxComponent
	{
		RenderMode RenderingMode { get; set; }
	}
}
