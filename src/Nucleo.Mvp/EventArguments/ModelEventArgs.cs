using System;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents the event arguments used to pass a model from the view to the presenter.
	/// </summary>
	/// <typeparam name="TModel">The model type.</typeparam>
	public class ModelEventArgs<TModel> : EventArgs
		where TModel : class, new()
	{
		private TModel _model = default(TModel);



		#region " Properties "

		/// <summary>
		/// Gets or sets the model in the event.
		/// </summary>
		public TModel Model
		{
			get { return _model; }
			set { _model = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates an empty model event args.
		/// </summary>
		public ModelEventArgs() { }

		/// <summary>
		/// Creates an event args with a model.
		/// </summary>
		public ModelEventArgs(TModel model)
		{
			_model = model;
		}

		#endregion
	}

	/// <summary>
	/// The event handler for models.
	/// </summary>
	/// <typeparam name="TModel">The model type.</typeparam>
	/// <param name="sender">The sender.</param>
	/// <param name="e">THe model event args.</param>
	public delegate void ModelEventHandler<TModel>(object sender, ModelEventArgs<TModel> e)
		where TModel : class, new();
}
