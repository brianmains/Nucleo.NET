using System;
using System.Collections.Generic;
using System.Reflection;

using Nucleo.Collections;
using Nucleo.Models.Cache;


namespace Nucleo.Models
{
	/// <summary>
	/// Represents a manager to store model bindings.
	/// </summary>
	/// <example>
	/// var model = new ModelClass();
	/// var injector = new ModelInjectionManager();
	/// injector.RegisterBinding(new ReferenceTableModelDataLoader()); // custom data loader
	/// injector.LoadInitialModelData(model);
	/// </example>
	public class ModelInjectionManager
	{
		private IModelInjectionCache _cache = null;
		private ModelDataLoaderCollection _loaders = new ModelDataLoaderCollection();
		private IModelInspector _inspector = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the model cache.
		/// </summary>
		public IModelInjectionCache Cache
		{
			get { return _cache; }
			set { _cache = value; }
		}

		/// <summary>
		/// Gets or sets the inspector used to find attributes for an object.
		/// </summary>
		public IModelInspector Inspector
		{
			get { return _inspector ?? new DefaultModelInspector(); }
			set { _inspector = value; }
		}

		#endregion



		#region " Constructors "

		public ModelInjectionManager() { }

		#endregion



		#region " Methods "

		private bool AssignCache(ModelInspectorOptions options, string key)
		{
			ModelCacheResults cacheResults = this.Cache.GetFromCache(options, key);
			if (cacheResults.HasValue)
			{
				options.Property.SetValue(options.Model, cacheResults.Value, null);
				return true;
			}

			return false;
		}

		private bool LoadCacheKeys(ModelInspectorOptions options, ref bool cacheable, ref string cacheKey)
		{
			if (this.Cache == null)
			{
				cacheable = false;
				cacheKey = null;
				return false;
			}

			var availability = this.Cache.GetCacheAvailability(options);
			if (availability.CanCache)
			{
				cacheKey = availability.Key;
				cacheable = true;

				if (this.AssignCache(options, cacheKey))
					return true;
			}

			return false;
		}

		/// <summary>
		/// Binds the model bindings to a model object, using reflection to infer the injection definitions used.
		/// </summary>
		/// <param name="model">The model to bind data into.</param>
		public void LoadInitialModelData(object model)
		{
			this.LoadInitialModelData(model, null);
		}

		/// <summary>
		/// Binds the model bindings to a model object, using reflection to infer the injection definitions used.
		/// </summary>
		/// <param name="model">The model to bind data into.</param>
		/// <param name="attributes">The attributes to use to load, which can introduce variability into the injection process.</param>
		public void LoadInitialModelData(object model, IDictionary<string, object> attributes)
		{
			PropertyInfo[] properties = model.GetType().GetProperties();

			foreach (PropertyInfo property in properties)
			{
				if (!property.CanWrite)
					continue;

				ModelInspectorOptions options = new ModelInspectorOptions
				{
					Model = model,
					Property = property,
					Attributes = attributes
				};

				string cacheKey = null;
				bool cacheable = false;
				this.LoadCacheKeys(options, ref cacheable, ref cacheKey);
				

				this.LoadForInjectionDefinition(options, model, property, attributes, cacheable, cacheKey);
			}
		}

		private void LoadForInjectionDefinition(ModelInspectorOptions options, object model, PropertyInfo property, IDictionary<string, object> attributes, bool cacheable, string cacheKey)
		{
			//If cache enabled, check that the attribute is set and that an entry is in the cache
			IModelInjection injectionDefinition = this.Inspector.FindInjectionDefinition(options);

			if (injectionDefinition == null)
				return;

			IModelDataLoader binding = this.GetBinding(injectionDefinition);

			if (binding != null)
			{
				ModelMemberMetadata metadata = new ModelMemberMetadata(model, property, injectionDefinition, attributes);
				object value = binding.GetModelData(metadata);

				metadata.SetMemberValue(value);

				if (cacheable)
					this.Cache.SaveToCache(options, cacheKey, value);
			}
		}

		/// <summary>
		/// Gets a binding from the binding definition.
		/// </summary>
		/// <param name="binding">The binding information.</param>
		/// <returns>The data loader matched with the data binding.</returns>
		public IModelDataLoader GetBinding(IModelInjection injection)
		{
			return _loaders.Find(injection);
		}

		/// <summary>
		/// Registers a binding and its associated data loader.
		/// </summary>
		/// <param name="register">The registered entry.</param>
		public void RegisterBinding(IModelDataLoader register)
		{
			_loaders.Add(register);
		}

		#endregion
	}
}
