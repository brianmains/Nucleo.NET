using System;
using System.Collections.Generic;

using Nucleo.EventsManagement.Listeners;


namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents the details about the publish event.
	/// </summary>
	/// <example>
	/// public class SomePresenter : IPresenter&lt;SomeView>
	/// {
	///		public SomePresenter(ISomeView view) { .. }
	///		
	///		public void View_Save(object sender, EventArgs e)
	///		{
	///			this.CurrentContext.EventsRegistry.Publish(new PublishedEventDetails(
	///				ListenerCriterion.Identifier("EventName"), 
	///				new Dictionary&lt;string, object> { "Key", 123 }));
	///		}
	/// }
	/// </example>
	public class PublishedEventDetails : BaseEventDetails
	{
		private IDictionary<string, object> _attributes = null;
		private object _source = null;



		#region " Properties "

		/// <summary>
		/// Gets the attributes for the event details.
		/// </summary>
		public IDictionary<string, object> Attributes
		{
			get
			{
				if (_attributes == null)
					_attributes = new Dictionary<string, object>();
				return _attributes;
			}
		}

		/// <summary>
		/// Gets the source that published the event, which may be null.
		/// </summary>
		public object Source
		{
			get { return _source; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the published details with the listener criteria.
		/// </summary>
		/// <param name="criteria">The criteria that an event is being published for.</param>
		[Obsolete("Please use the PublishedEventDetails(source, criteria) overload instead.")]
		public PublishedEventDetails(IListenerCriteria criteria)
			: base(criteria) 
		{
		}

		/// <summary>
		/// Creates the published details with the listener criteria.
		/// </summary>
		/// <param name="source">The source object publishing the event.</param>
		/// <param name="criteria">The criteria that an event is being published for.</param>
		public PublishedEventDetails(object source, IListenerCriteria criteria)
			: base(criteria)
		{
			_source = source;
		}

		/// <summary>
		/// Creates the published details with the listener criteria with additional attributes.
		/// </summary>
		/// <param name="criteria">The criteria that an event is being published for.</param>
		/// <param name="attributes">The attributes to publish.</param>
		[Obsolete("Please use the PublishedEventDetails(source, criteria, attributes) overload instead.")]
		public PublishedEventDetails(IListenerCriteria criteria, IDictionary<string, object> attributes)
			: base(criteria) 
		{
			_attributes = attributes;
		}

		/// <summary>
		/// Creates the published details with the listener criteria with additional attributes.
		/// </summary>
		/// <param name="source">The source object publishing the event.</param>
		/// <param name="criteria">The criteria that an event is being published for.</param>
		/// <param name="attributes">The attributes to publish.</param>
		public PublishedEventDetails(object source, IListenerCriteria criteria, IDictionary<string, object> attributes)
			: this(source, criteria)
		{
			_attributes = attributes;
		}
		
		#endregion
	}
}
