using System;
using System.Collections.Generic;


namespace Nucleo.Text
{
	public class FakeMessageProvider : MessageProvider
	{
		MessageCollection _messages = new MessageCollection();



		#region " Properties "

		public MessageCollection Messages
		{
			get { return _messages; }
		}

		#endregion



		#region " Methods "

		public override void AddMessage(Message message)
		{
			_messages.Add(message);
		}

		public override MessageCollection GetMessages(DateTime messageDate)
		{
			MessageCollection messagesList = new MessageCollection();

			foreach (Message message in _messages)
			{
				if (message.EffectiveDate <= messageDate &&
					(message.EndDate ?? DateTime.MaxValue) >= messageDate)
					messagesList.Add(message);
			}

			return messagesList;
		}

		public override bool RemoveMessage(Message message, bool endDateOnly)
		{
			if (endDateOnly)
			{
				message.EndDate = DateTime.Now;
				return true;
			}
			else
				return _messages.Remove(message);
		}

		public override void UpdateMessage(Message message)
		{
			Message msg = null;
			int i = 0;

			for (int index = 0, len = this.Messages.Count; index < len; index++)
			{
				if (this.Messages[index].ID == message.ID)
				{
					msg = this.Messages[index];
					i = index;
					break;
				}
			}

			if (msg == null)
				throw new NullReferenceException("The message could not be updated because it could not be found with ID: " + message.ID.ToString());

			this.Messages.RemoveAt(i);
			this.Messages.Insert(i, msg);
		}

		#endregion
	}
}
