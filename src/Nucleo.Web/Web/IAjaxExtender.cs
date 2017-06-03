

namespace Nucleo.Web
{
	/// <summary>
	/// Interface that represents an AJAX extender, which has both a server and client piece.
	/// </summary>
	public interface IAjaxExtender : IAjaxComponent
	{
		string TargetControlID { get; set; }
	}
}
