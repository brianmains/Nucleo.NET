using System;
using System.Collections.Generic;

using Nucleo.Collections;


namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents the core event information.
	/// </summary>
	[CLSCompliant(true)]
	public class EventInformation
	{
		private DateTime _beginDate = DateTime.Now;
		private string _description = string.Empty;
		private DateTime _endDate = DateTime.Now.AddHours(1);
		private Identifier _id = null;
		private bool _isCancelled = false;
		private string _location = string.Empty;
		private int _maximumRegistration = 0;
		private string _name = string.Empty;
		private Uri _url = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the begin date of the event.
		/// </summary>
		public DateTime BeginDate
		{
			get { return _beginDate; }
			set { _beginDate = value; }
		}

		/// <summary>
		/// Gets whether the event can be registered to.
		/// </summary>
		public bool CanRegister
		{
			get { return (_maximumRegistration > 0); }
		}

		/// <summary>
		/// Gets or sets the description of the event.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Gets or sets the end date for the event.
		/// </summary>
		public DateTime EndDate
		{
			get { return _endDate; }
			set { _endDate = value; }
		}

		/// <summary>
		/// Gets or sets some unique ID for the event, which could be an ID, GUID, etc.
		/// </summary>
		public Identifier ID
		{
			get { return _id; }
			set { _id = value; }
		}

		/// <summary>
		/// Gets or sets whether the event has been cancelled.
		/// </summary>
		public bool IsCancelled
		{
			get { return _isCancelled; }
			set { _isCancelled = value; }
		}

		/// <summary>
		/// Gets or sets the location of the event.
		/// </summary>
		public string Location
		{
			get { return _location; }
			set { _location = value; }
		}

		/// <summary>
		/// Gets the number of people that could be registered for an event.
		/// </summary>
		public int MaximumRegistration
		{
			get { return _maximumRegistration; }
			set { _maximumRegistration = value; }
		}

		/// <summary>
		/// Gets or sets the name of the event.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the URL of the event.
		/// </summary>
		public Uri Url
		{
			get { return _url; }
			set { _url = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates an empty event.
		/// </summary>
		public EventInformation() { }

		public EventInformation(string name, string location, string description, Uri url, int maximumRegistration, DateTime beginDate, DateTime endDate)
		{
			_name = name;
			_location = location;
			_description = description;
			_url = url;
			_maximumRegistration = maximumRegistration;
			_beginDate = beginDate;
			_endDate = endDate;
		}

		public EventInformation(Identifier id, string name, string location, string description, Uri url, int maximumRegistration, bool isCancelled, DateTime beginDate, DateTime endDate)
			: this(name, location, description, url, maximumRegistration, beginDate, endDate)
		{
			_id = id;
			_isCancelled = isCancelled;
		}

		#endregion
	}
}
