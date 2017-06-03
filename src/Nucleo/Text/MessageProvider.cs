using System;


namespace Nucleo.Text
{
	/// <summary>
	/// The base interface for the message provider.
	/// </summary>
	public abstract class MessageProvider : Providers.ProviderBase
	{
		/// <summary>
		/// Adds a new message to the underlying data store.
		/// </summary>
		/// <param name="message">The message to add.</param>
		public abstract void AddMessage(Message message);

		/// <summary>
		/// Retrieves a collection of messages from the underlying data store.
		/// </summary>
		/// <param name="includeEndDated">Whether to include end-dated messages in the returned data.</param>
		/// <returns>A collection of messages in the underlying data store.</returns>
		public abstract MessageCollection GetMessages(DateTime messageDate);

		/// <summary>
		/// Removes a message from the retrieved lists of messages, either by deleting it from the database or by end-dating it.
		/// </summary>
		/// <param name="message">The message to remove.</param>
		/// <param name="endDateOnly">Whether to end-date the message only, or to remove it.</param>
		/// <returns>Whether the removal process occurred successfully.</returns>
		public abstract bool RemoveMessage(Message message, bool endDateOnly);

		/// <summary>
		/// Updates a message in the underlying data store.
		/// </summary>
		/// <param name="message">The message to update.</param>
		public abstract void UpdateMessage(Message message);
	}
}
