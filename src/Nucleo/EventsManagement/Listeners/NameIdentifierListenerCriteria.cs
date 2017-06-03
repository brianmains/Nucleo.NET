using System;


namespace Nucleo.EventsManagement.Listeners
{
	/// <summary>
	/// Represents a listener critera for text identifiers.
	/// </summary>
	public class NameIdentifierListenerCriteria : IListenerCriteria
	{
		private string _identifier = null;



		#region " Properties "

		/// <summary>
		/// Gets the identifier.
		/// </summary>
		public string Identifier
		{
			get { return _identifier; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the identifier.
		/// </summary>
		/// <param name="identifier">The identifying string.</param>
		/// <exception cref="ArgumentNullException">Thrown when the identifier is empty or null.</exception>
		public NameIdentifierListenerCriteria(string identifier)
		{
			if (string.IsNullOrEmpty(identifier))
				throw new ArgumentNullException("identifier");

			_identifier = identifier;
		}

		#endregion



		#region " Methods "

		public virtual bool IsMatch(IListenerCriteria criteria)
		{
			if (criteria is NameIdentifierListenerCriteria)
				return (string.Compare(this.Identifier, ((NameIdentifierListenerCriteria)criteria).Identifier, StringComparison.InvariantCultureIgnoreCase) == 0);
			else if (criteria is EventListenerCriteria)
				return (string.Compare(this.Identifier, ((EventListenerCriteria)criteria).Event.Name, StringComparison.InvariantCultureIgnoreCase) == 0);
			else if (criteria is AnyListenerCriteria)
				return true;

			return false;
		}

		#endregion
	}
}
