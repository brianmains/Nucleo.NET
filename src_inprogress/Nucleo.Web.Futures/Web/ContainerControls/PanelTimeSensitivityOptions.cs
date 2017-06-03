using System;


namespace Nucleo.Web.ContainerControls
{
	/// <summary>
	/// Represents time sensitivity options.
	/// </summary>
	public class PanelTimeSensitivityOptions : JsonSerializableObject
	{
		#region " Properties "

		/// <summary>
		/// Gets the beginning filter date to potentially filter the panel by.
		/// </summary>
		public DateTime? FilterBeginDate
		{
			get { return base.GetNullableValue<DateTime>("filterBeginDate"); }
			set { base.AddOrUpdateValue("filterBeginDate", value); }
		}

		/// <summary>
		/// Gets the ending filter date to potentially filter the panel by.
		/// </summary>
		public DateTime? FilterEndDate
		{
			get { return base.GetNullableValue<DateTime>("filterEndDate"); }
			set { base.AddOrUpdateValue("filterEndDate", value); }
		}

		/// <summary>
		/// Gets whether the panel is visible.
		/// </summary>
		public bool IsVisible
		{
			get
			{
				DateTime currentDate = this.GetCurrentDate();

				if ((this.FilterBeginDate ?? DateTime.MinValue) > currentDate)
					return false;
				if ((this.FilterEndDate ?? DateTime.MaxValue) < currentDate)
					return false;

				return true;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the current date.
		/// </summary>
		/// <returns>The date/time of the current time.</returns>
		private DateTime GetCurrentDate()
		{
			return DateTime.Now;
		}

		#endregion
	}
}
