using System;


namespace Nucleo.Web.CodeGeneration
{
	/// <summary>
	/// Represents a class definition.
	/// </summary>
	public class ClassDefinition
	{
		private ClassMemberCollection _events = null;
		private ClassMemberCollection _methods = null;
		private ClassMemberCollection _properties = null;
		private Type _sourceType = null;



		#region " Properties "

		/// <summary>
		/// Gets the collection of members.
		/// </summary>
		public ClassMemberCollection Events
		{
			get
			{
				if (_events == null)
					_events = new ClassMemberCollection();

				return _events;
			}
			set { _events = value; }
		}

		/// <summary>
		/// Gets the collection of members.
		/// </summary>
		public ClassMemberCollection Methods
		{
			get
			{
				if (_methods == null)
					_methods = new ClassMemberCollection();

				return _methods;
			}
			set { _methods = value; }
		}

		/// <summary>
		/// Gets the collection of members.
		/// </summary>
		public ClassMemberCollection Properties
		{
			get
			{
				if (_properties == null)
					_properties = new ClassMemberCollection();

				return _properties;
			}
			set { _properties = value; }
		}

		public Type SourceType
		{
			get { return _sourceType; }
			set { _sourceType = value; }
		}

		#endregion



		#region " Methods "

		public void AddMember(ClassMember member)
		{
			if (member.Type == ClassMemberType.Property)
				this.Properties.Add(member);
			else if (member.Type == ClassMemberType.Method)
				this.Methods.Add(member);
			else if (member.Type == ClassMemberType.Event)
				this.Events.Add(member);
		}

		/// <summary>
		/// Returns whether the class has any members.
		/// </summary>
		/// <returns>Whether any members have been setup.</returns>
		public bool HasMembers()
		{
			return (
				(_properties != null && _properties.Count > 0) ||
				(_methods != null && _methods.Count > 0) ||
				(_events != null && _events.Count > 0)
			);
		}

		#endregion
	}
}
