using System;
using Nucleo.EventArguments;


namespace Nucleo.Windows.Application
{
	internal static class ApplicationEventsManager
	{
		#region " Events "

		public static event ApplicationEventEventHandler EventTriggered;

		#endregion



		#region " Methods "

		/// <summary>
		/// Fires an event notification to the object that is tapping into it.
		/// </summary>
		/// <param name="eventName">The name of the event firing.</param>
		/// <param name="sourceObject">The source object that is raising the notification.</param>
		/// <param name="targetObject">The target object receiving the notification.</param>
		public static void FireEventNotification(string eventName, object sourceObject, object targetObject)
		{
			if (EventTriggered != null)
				EventTriggered(sourceObject, new ApplicationEventEventArgs(eventName, sourceObject, targetObject));
		}

		public static void FireEventNotification(string eventName, object sourceObject, object targetObject, Actions.IAction action)
		{
			if (EventTriggered != null)
				EventTriggered(sourceObject, new ApplicationEventEventArgs(eventName, sourceObject, targetObject, action));
		}

		public static void FireEventNotification(string eventName, object sourceObject, object targetObject, int index)
		{
			if (EventTriggered != null)
				EventTriggered(sourceObject, new ApplicationEventEventArgs(eventName, sourceObject, targetObject, index));
		}

		#endregion
	}
}
