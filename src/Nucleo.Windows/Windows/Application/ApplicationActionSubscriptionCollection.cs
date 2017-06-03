using System;
using Nucleo.Collections;
using Nucleo.Windows.Actions;
using Nucleo.Windows.UI;


namespace Nucleo.Windows.Application
{
	internal class ApplicationActionSubscriptionCollection : CollectionBase<ApplicationActionSubscription>
	{
		#region " Methods "

		public ApplicationActionSubscription[] FindByAction(IAction action)
		{
			SimpleCollection<ApplicationActionSubscription> list = new SimpleCollection<ApplicationActionSubscription>();

			foreach (ApplicationActionSubscription subscriber in this)
			{
				if (subscriber.Action.ActionName.Equals(action.ActionName))
					list.Add(subscriber);
			}

			return list.ToArray();
		}

		public ApplicationActionSubscription[] FindByActionType(IAction action, Type objectType)
		{
			if (objectType.GetInterface("IActionableElement") == null)
				throw new ArgumentException("The object type doesn't implement the correct interface");

			SimpleCollection<ApplicationActionSubscription> list = new SimpleCollection<ApplicationActionSubscription>();

			foreach (ApplicationActionSubscription subscriber in this)
			{
				bool containsAction = subscriber.Action.ActionName.Equals(action.ActionName);

				if (subscriber.ObjectType == null)
				{
					if (containsAction)
						list.Add(subscriber);
				}
				else
				{
					if (objectType == null) { }
					else if (subscriber.ObjectType.Equals(objectType) ||
					 objectType.IsSubclassOf(subscriber.ObjectType))
						list.Add(subscriber);
				}
			}

			return list.ToArray();
		}

		/// <summary>
		/// Finds a collection of subscriptions based on the person's name.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public ApplicationActionSubscription[] FindByParams(Type objectType, string objectName, IAction action)
		{
			SimpleCollection<ApplicationActionSubscription> list = new SimpleCollection<ApplicationActionSubscription>();

			foreach (ApplicationActionSubscription subscriber in this)
			{
				bool carryOn = true;

				if (!string.IsNullOrEmpty(subscriber.ObjectName) && string.Compare(objectName, subscriber.ObjectName, true) != 0)
					carryOn = false;

				if (carryOn && subscriber.ObjectType != null && (!object.Equals(objectType, subscriber.ObjectType) || !subscriber.ObjectType.IsAssignableFrom(objectType)))
					carryOn = false;

				if (carryOn && subscriber.Action != null && object.Equals(subscriber.Action, action))
					carryOn = false;

				if (carryOn)
					list.Add(subscriber);
			}

			return list.ToArray();
		}

		#endregion
	}
}
