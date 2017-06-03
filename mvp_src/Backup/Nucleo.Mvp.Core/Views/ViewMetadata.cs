using System;


namespace Nucleo.Views
{
	/// <summary>
	/// Represents the metadata about the view.
	/// </summary>
	public class ViewMetadata
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the type of contract.
		/// </summary>
		public Type ContractType { get; set; }

		/// <summary>
		/// Gets or sets the type of presenter.
		/// </summary>
		public Type PresenterType { get; set; }

		/// <summary>
		/// Gets or sets the type of view.
		/// </summary>
		public Type ViewType { get; set; }

		#endregion

	}
}
