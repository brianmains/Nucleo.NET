using System;

using Nucleo.Text.Configuration;
using Nucleo.Exceptions;


namespace Nucleo.Text
{
	public class Messages
	{
		private MessageProvider _provider = null;
		private bool _keepOldMessages = false;



		#region " Properties "

		private MessageProvider Provider
		{
			get { return _provider; }
		}

		#endregion



		#region " Constructors "

		private Messages() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a message to the underlying data source.
		/// </summary>
		/// <param name="message">The message to add.</param>
		/// <exception cref="ArgumentNullException">Thrown if the message is null.</exception>
		public void AddMessage(Message message)
		{
			if (message == null)
				throw new ArgumentNullException("message");

			this.Provider.AddMessage(message);
		}

		/// <summary>
		/// Creates a new instance of the messages component.  Uses the provider specified within the configuration file.
		/// </summary>
		/// <returns>The messages component.</returns>
		public static Messages Create()
		{
			Messages obj = new Messages();
			obj.InitializeProvider(true);

			return obj;
		}

		/// <summary>
		/// Creates a new instance of the messages component.  Uses the provider specified within the configuration file.
		/// </summary>
		/// <returns>The messages component.</returns>
		public static Messages Create(MessageProvider provider)
		{
			Messages obj = new Messages();
			obj.InitializeProvider(false);
			obj._provider = provider;

			return obj;
		}

		/// <summary>
		/// Gets a collection of messages from the underlying data store.
		/// </summary>
		/// <returns>A collection of message objects.</returns>
		public MessageCollection GetMessages()
		{
			return GetMessages(DateTime.Now);
		}

		/// <summary>
		/// Gets a collection of messages from the underlying data store.
		/// </summary>
		/// <param name="messageDate">The relative date of the message.</param>
		/// <param name="includeEndDated">Whether to include messages that are end-dated.  If old messages are configured not to be kept, than this parameter won't matter.</param>
		/// <returns>A collection of message objects.</returns>
		public MessageCollection GetMessages(DateTime messageDate)
		{
			return this.Provider.GetMessages(messageDate);
		}

		private void InitializeProvider(bool loadProvider)
		{
			MessagesSection section = MessagesSection.Instance;
			if (section == null)
				throw new System.Configuration.ConfigurationErrorsException("The messages section has not been defined in the configuration file");

			if (loadProvider)
				_provider = (MessageProvider)Activator.CreateInstance(Type.GetType(section.DefaultProvider));
			_keepOldMessages = section.KeepOldMessages;
		}

		/// <summary>
		/// Removes a message from the underlying system.
		/// </summary>
		/// <param name="message">The message to remove.</param>
		/// <returns>Whether the removal worked.</returns>
		/// <exception cref="ArgumentNullException">Thrown if the message is null.</exception>
		public bool RemoveMessage(Message message)
		{
			if (message == null)
				throw new ArgumentNullException("message");

			return this.Provider.RemoveMessage(message, _keepOldMessages);
		}

		/// <summary>
		/// Updates a message in the system.
		/// </summary>
		/// <param name="message">The message to update.</param>
		/// <exception cref="ArgumentNullException">Thrown if the message is null.</exception>
		public void UpdateMessage(Message message)
		{
			if (message == null)
				throw new ArgumentNullException("message");

			this.Provider.UpdateMessage(message);
		}

		#endregion
	}
}
