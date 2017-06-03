using System;
using System.Diagnostics;


namespace Nucleo.Text
{
	[DebuggerDisplay("{Title} ({ID}), Effective {EffectiveDate}")]
	public class Message
	{
		private Guid _id = Guid.Empty;



		#region " Properties "

		public DateTime EffectiveDate { get; set; }

		/// <summary>
		/// Gets or sets the date that the message is no longer valid.
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Gets the unique identifier for the message.
		/// </summary>
		public Guid ID
		{
			get { return _id; }
		}

		/// <summary>
		/// Gets or sets the text of the message.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Gets or sets the title of the message.
		/// </summary>
		public string Title { get; set; }

		#endregion



		#region " Constructors "

		public Message(Guid id, string title, string text)
		{
			_id = id;
			this.Title = title;
			this.Text = text;
		}

		public Message(Guid id, string title, string text, DateTime effectiveDate, DateTime? endDate)
			: this(id, title, text)
		{
			this.EffectiveDate = effectiveDate;
			this.EndDate = endDate;
		}

		#endregion
	}
}
