using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Nucleo.EventsManagement;
using Nucleo.Models;
using Nucleo.State;


namespace Nucleo.Presentation.Context
{
	/// <summary>
	/// Represents the current context for the presenter execution.
	/// </summary>
	public class PresenterContext
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the registry for events.
		/// </summary>
		public EventsRegistry EventRegistry
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the model injection manager.
		/// </summary>
		public ModelInjectionManager ModelInjection
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the collection of state values for the presenter.
		/// </summary>
		public ICurrentExecutionState State
		{
			get;
			set;
		}

		#endregion
	}
}
