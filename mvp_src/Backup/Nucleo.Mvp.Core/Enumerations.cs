namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents the direction to send an event directly.
	/// </summary>
	public enum EventDirection
	{
		/// <summary>
		/// Represents that the event should be bubbled up.
		/// </summary>
		Bubble,
		/// <summary>
		/// Represents that the event should be tunneled down.
		/// </summary>
		Tunnel
	}
}

namespace Nucleo.Models
{
	public enum ShareAccessLevel
	{
		None,
		PerModel,
		Global
	}
}

namespace Nucleo.Notifications
{
	public enum NotificationType
	{
		Event
	}
}

namespace Nucleo.Security
{
    public enum SecurityAccessLevel
    {
        NoAccess,
        RestrictedAccess,
        FullAccess
    }
}