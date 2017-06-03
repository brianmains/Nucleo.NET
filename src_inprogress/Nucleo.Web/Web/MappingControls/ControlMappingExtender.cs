using System;
using System.ComponentModel;
using System.Web.UI;

using Nucleo.Web.Mappings;


namespace Nucleo.Web.MappingControls
{
	/// <summary>
	/// Represents a mapping for a manager.  This mapping is then used to construct a client-side object.
	/// </summary>
	[
	ToolboxData("<{0}:ControlMappingExtender runat=server />"),
	TargetControlType(typeof(Control)),
	ParseChildren(true),
	PersistChildren(false),
	ControlBuilder(typeof(ControlMappingExtenderControlBuilder)),
	WebScriptMetadata(typeof(ControlMappingExtenderScriptMetadata))
	]
	public class ControlMappingExtender : BaseAjaxExtender
	{
		private Control _targetControl = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the ID of the manager component.
		/// </summary>
		public string ManagerID
		{
			get { return (string)ViewState["ManagerID"]; }
			set { ViewState["ManagerID"] = value; }
		}

		/// <summary>
		/// Gets the name of the object's property name, or the name of the method/web service parameter.
		/// </summary>
		public string MappedName
		{
			get { return (string)ViewState["MappedName"]; }
			set { ViewState["MappedName"] = value; }
		}

		/// <summary>
		/// Gets or sets the order to use when passing the values to another object.  If no order is needed, supply a value of zero (the default).
		/// </summary>
		[
		Category("Data"),
		DefaultValue(-1),
		Description("The zero-based order that the property must be supplied, if used in a method or web service call.  This parameter is optional.")
		]
		public int Order
		{
			get { return (int) (ViewState["Order"] ?? -1); }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("value");
				ViewState["Order"] = value;
			}
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{
			base.GetAjaxScriptDescriptors(registrar, targetControl);

			NucleoScriptBehaviorDescriptor descriptor = registrar.AddDescriptor<NucleoScriptBehaviorDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(ControlMappingExtender), targetControl.ClientID));

			Control managerControl = ControlUtility.FindControl(this, this.ManagerID);
			if (managerControl != null)
			{
				if (managerControl == null)
					throw new Nucleo.Exceptions.NotFoundException("The manager control instance couldn't be found");

				descriptor.AddComponentProperty("manager", managerControl.ClientID);
			}

			descriptor.AddProperty("mappedName", this.MappedName);
			descriptor.AddProperty("order", this.Order);
		}

		protected internal override void OnValidateState(EventArguments.ValidateEventArgs e)
		{
			base.OnValidateState(e);

			if (string.IsNullOrEmpty(this.ManagerID))
				throw new ArgumentNullException("ManagerID");
		}

		#endregion
	}
}
