using System;
using System.Web.UI;
using System.Reflection;
using Nucleo.Web.Mappings.Configuration;


namespace Nucleo.Web.Mappings
{
	public class ControlMappingsManager
	{
		private ControlMappingCollection _mappings = null;



		#region " Properties "

		/// <summary>
		/// Gets the mappings setup by the manager.
		/// </summary>
		public ControlMappingCollection Mappings
		{
			get
			{
				if (_mappings == null)
					_mappings = new ControlMappingCollection();
				return _mappings;
			}
		}

		#endregion



		#region " Constructors "

		public ControlMappingsManager() { }

		#endregion



		#region " Methods "

		private Control GetControl(string controlID)
		{
			return null;
		}

		private object GetControlValue(Control control)
		{
			return null;
		}

		public void ReadFromControls(ref object parentObject)
		{
			foreach (ControlMapping mapping in this.Mappings)
			{
				Control control = this.GetControl(mapping.ControlID);
				if (control == null)
					throw new ArgumentException("No control was found with the ID: " + mapping.ControlID);

				object value = this.GetControlValue(control);
				PropertyInfo property = parentObject.GetType().GetProperty(mapping.ObjectPropertyName);
				if (property == null)
					throw new Exception("The object does not have a property: " + mapping.ObjectPropertyName);

				property.SetValue(parentObject, value, null);
			}
		}

		/// <summary>
		/// Registers a single mapping, mapping the control ID to the object name.
		/// </summary>
		/// <param name="controlID">The ID of the control.</param>
		/// <param name="objectPropertyName">The name of the property.</param>
		public void RegisterMapping(string controlID, string objectPropertyName)
		{
			this.Mappings.Add(new ControlMapping(
			                  	controlID, objectPropertyName));
		}

		/// <summary>
		/// Register the mapping for a group specified in the configuration file.
		/// </summary>
		/// <param name="group">The group to register.</param>
		public void RegisterMappingFromConfiguration(string group)
		{
			ControlMappingsSection section = ControlMappingsSection.Instance;
			if (section == null)
				throw new System.Configuration.ConfigurationErrorsException(
					"The controlMappings section hasn't been created in the config file");

			ControlMappingGroupElement groupElement = section.Groups[group];
			if (groupElement == null)
				throw new NullReferenceException(String.Format("The group '{0}' was not found in the configuration file", group));

			foreach (ControlMappingElement element in groupElement.Mappings)
				this.Mappings.Add(new ControlMapping(
				                  	element.ControlID, element.ObjectPropertyName));
		}

		private void SetControlValue(Control control, object value)
		{
			
		}

		public void WriteToControls(object parentObject)
		{
			foreach (ControlMapping mapping in this.Mappings)
			{
				Control control = this.GetControl(mapping.ControlID);
				PropertyInfo property = parentObject.GetType().GetProperty(mapping.ObjectPropertyName);
				if (property == null)
					throw new Exception("The object doesn't have the property " + parentObject);

				this.SetControlValue(control, property.GetValue(parentObject, null));
			}
		}

		#endregion
	}
}
