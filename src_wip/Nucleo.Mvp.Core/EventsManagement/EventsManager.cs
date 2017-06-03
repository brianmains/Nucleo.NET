using System;
using System.Reflection;
using System.Collections.Generic;

using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Presentation.Context;
using Nucleo.Views;


namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Responsible for raising an event.  Translates an event fired within the view into a cross-presenter event.
	/// </summary>
	public static class EventsManager
	{
		#region " Methods "

		private static BaseEvent FindEvent(object source, string propertyName)
		{
			FieldInfo prop = source.GetType().GetField(propertyName, BindingFlags.Static | BindingFlags.Public);
			if (prop != null)
				return prop.GetValue(source) as BaseEvent;

			prop = source.GetType().BaseType.GetField(propertyName, BindingFlags.Static | BindingFlags.Public);
			if (prop != null)
				return prop.GetValue(source) as BaseEvent;

			return null;
		}

		/// <summary>
		/// Gets the event by its event name.
		/// </summary>
		/// <param name="view">The view instance.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <returns>The event instance.</returns>
		public static BaseEvent GetEvent(IView view, string eventName)
		{
			if (view == null)
				throw new ArgumentNullException("view");

			BaseEvent evt = FindEvent(view, eventName);
			if (evt != null) return evt;

			evt = FindEvent(view, (eventName.EndsWith("Event"))
				? eventName : eventName + "Event");
			if (evt != null) return evt;

			return default(BaseEvent);
		}

		/// <summary>
		/// Gets the event by its event name.
		/// </summary>
		/// <typeparam name="T">The type of event.</typeparam>
		/// <param name="view">The view instance.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <returns>The event instance.</returns>
		public static T GetEvent<T>(IView view, string eventName)
			where T: BaseEvent, new()
		{
			return GetEvent(view, eventName) as T;
		}

		public static T GetEvent<T>(IView view)
			where T : BaseEvent, new()
		{
			FieldInfo[] fields = view.GetType().GetFields(BindingFlags.Static | BindingFlags.Public);
			if (fields.Length == 0)
				fields = view.GetType().BaseType.GetFields(BindingFlags.Static | BindingFlags.Public);

			foreach (FieldInfo field in fields)
			{
				if (field.FieldType is T)
					return (T)field.GetValue(view);
			}

			return default(T);
		}

		/// <summary>
		/// Raises the event to the eventing system.
		/// </summary>
		/// <param name="view">The view that defined the event.</param>
		/// <param name="eventInfo">The name of the event.</param>
		internal static void RaiseEvent(IView view, BaseEvent eventInfo, IDictionary<string, object> attributes)
		{
			PresenterContext ctx = PresenterContextInternal.CreateContextOrGetFromCache();
			ctx.EventRegistry.Publish(new PublishedEventDetails(view,
				ListenerCriterion.Event(eventInfo, view), attributes));
		}

		/// <summary>
		/// Registers the event.
		/// </summary>
		/// <typeparam name="T">The type of event.</typeparam>
		/// <param name="name">The name of the event.</param>
		/// <returns>The event instance.</returns>
		public static T Register<T>(Type viewType, string name)
			where T : BaseEvent, new()
		{
			return Register<T>(viewType, name, null);
		}

		/// <summary>
		/// Registers the event.
		/// </summary>
		/// <typeparam name="T">The type of event.</typeparam>
		/// <param name="name">The name of the event.</param>
		/// <param name="securityAccess">The security access details of the event.</param>
		/// <returns>The event instance.</returns>
		public static T Register<T>(Type viewType, string name, object securityAccess)
			where T: BaseEvent, new()
		{
			T evt = new T();
			evt.Initialize(name, securityAccess);

			return evt;
		}

		#endregion
	}
}
