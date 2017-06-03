using System;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.DataFields
{
	public abstract class BaseReflectedSingleEditDataField<T> : BaseSingleEditDataField
		where T:Control
	{
		#region " Properties "

		public abstract string ControlEditProperty { get; }

		#endregion



		#region " Methods "

		public override void BindEditControl(object control, bool insertMode)
		{
			T controlRef = control as T;
			if (controlRef == null)
				throw new ArgumentNullException("control");

			if (!insertMode)
			{
				PropertyInfo prop = controlRef.GetType().GetProperty(this.ControlEditProperty, Nucleo.Reflection.ReflectionUtility.InstanceFlags);
				if (prop == null)
					throw new NullReferenceException(string.Format("The property '{0}' was not found for the specified control.", this.ControlEditProperty));

				prop.SetValue(controlRef, this.GetDataItemValue(controlRef.NamingContainer, this.GetDataItemFieldName(this.GetEditRowState(insertMode))), null);
			}
		}

		public override string GetEditControlValue(TableCell cell)
		{
			T controlRef = this.ExtractControl<T>(cell);
			if (controlRef == null)
				throw new ArgumentNullException("control");

			PropertyInfo prop = controlRef.GetType().GetProperty(this.ControlEditProperty, Nucleo.Reflection.ReflectionUtility.InstanceFlags);
			if (prop == null)
				throw new NullReferenceException(string.Format("The property '{0}' was not found for the specified control.", this.ControlEditProperty));

			object value = prop.GetValue(controlRef, null);
			return (value == null) ? null : (string)value;
		}

		public override Control SetupEditControl()
		{
			T control = Activator.CreateInstance<T>();
			this.SetupInitialEditControlProperties(control);
			return control;
		}

		/// <summary>
		/// Sets up the initial properties for the control that will edit the underlying data source.
		/// </summary>
		/// <param name="control">An instance of the control freshly created.</param>
		protected virtual void SetupInitialEditControlProperties(T control) { }

		#endregion
	}
}
