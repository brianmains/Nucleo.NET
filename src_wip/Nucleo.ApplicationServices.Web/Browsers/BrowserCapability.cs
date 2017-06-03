using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Browsers
{
	/// <summary>
	/// Represents an individual browser capability that the browser has.
	/// </summary>
	/// <example>
	/// var cap = new BrowserCapability("ActiveXControls");
	/// var feature = cap.Feature; //BrowserCapabilityFeature.ActiveXControls
	/// 
	/// var cap2 = new BrowserCapability(BrowserCapabilityFeature.Frames);
	/// var name = cap2.Name; //"Frames"
	/// </example>
	public class BrowserCapability
	{
		private BrowserCapabilityFeature _feature = BrowserCapabilityFeature.ActiveXControls;
		private string _name = null;




		#region " Properties "

		/// <summary>
		/// Gtes the browser capability feature in enumeration form.
		/// </summary>
		public BrowserCapabilityFeature Feature
		{
			get { return _feature; }
		}

		/// <summary>
		/// Gets the name of the browse capability.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the browser capability using the enumeration.
		/// </summary>
		/// <param name="feature">The browser capability.</param>
		public BrowserCapability(BrowserCapabilityFeature feature)
		{
			_feature = feature;
			_name = _feature.ToString();
		}

		/// <summary>
		/// Creates the browser capability using the name.  Must be exact.
		/// </summary>
		/// <param name="name">The browser capability.</param>
		public BrowserCapability(string name)
		{
			_name = name;
			_feature = (BrowserCapabilityFeature)Enum.Parse(typeof(BrowserCapabilityFeature), name);
		}

		

		#endregion
	}
}
