using System;


namespace Nucleo.EventArguments
{
	public class ChangeEventArgs
	{
		private bool _hasChanges = false;
		private object _oldValue = null;
		private object _newValue = null;
		private object _source = null;



		#region " Properties "

		/// <summary>
		/// Gets whether there are changes between the object values.
		/// </summary>
		public bool HasChanges
		{
			get { return _hasChanges; }
		}

		/// <summary>
		/// Gets the old value that was changed potentially.
		/// </summary>
		public object OldValue
		{
			get { return _oldValue; }
		}

		/// <summary>
		/// Gets the new value that was changed potentially.
		/// </summary>
		public object NewValue
		{
			get { return _newValue; }
		}

		public object Source
		{
			get { return _source; }
		}

		#endregion



		#region " Constructors "

		public ChangeEventArgs(object source, object oldValue, object newValue)
			: this(source, oldValue, newValue, !Object.Equals(oldValue, newValue)) { }

		public ChangeEventArgs(object source, object oldValue, object newValue, bool hasChanges)
		{
			_source = source;
			_oldValue = oldValue;
			_newValue = newValue;
			_hasChanges = hasChanges;
		}

		#endregion
	}


	public delegate void ChangeEventHandler(object sender, ChangeEventArgs e);
}
