using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Nucleo.Lookups;


namespace Nucleo.Web.Lookups.Controls
{
	/// <summary>
	/// Represents a lookup control that is a list.
	/// </summary>
	public class ListLookupControl : ILookupControl
	{
		private ListControl _control = null;
		private string _lookupName = null;



		#region " Properties "

		/// <summary>
		/// Gets the control reference.
		/// </summary>
		public ListControl Control
		{
			get { return _control; }
		}

		/// <summary>
		/// Gets or sets the name of the lookup to use.
		/// </summary>
		public string LookupName
		{
			get { return _lookupName; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Create the list control wrapper.
		/// </summary>
		/// <param name="control">The inner control.</param>
		/// <param name="lookupName">The name of the lookup.</param>
		public ListLookupControl(ListControl control, string lookupName)
		{
			if (control == null)
				throw new ArgumentNullException("control");
			if (string.IsNullOrEmpty(lookupName))
				throw new ArgumentNullException("lookupName");

			_control = control;
			_lookupName = lookupName;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Binds the lookup values to the list.
		/// </summary>
		public void BindValues(LookupCriteria criteria)
		{
			ILookupRepository repository = this.GetRepository();
			LookupCollection lookups = repository.GetAllValues(criteria);

			this.Control.DataSource = lookups;
			this.Control.DataBind();
		}

		/// <summary>
		/// Gets the repository using the lookup name.
		/// </summary>
		/// <returns>The lookup repository.</returns>
		private ILookupRepository GetRepository()
		{
			LookupManager manager = LookupManager.Create();
			return manager.GetLookupRepository(this.LookupName);
		}

		#endregion
	}
}
