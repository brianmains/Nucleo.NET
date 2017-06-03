using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.Controls
{
	public class StandardCalendar : System.Web.UI.WebControls.Calendar, IEditorControl
	{
		#region " Properties "

		public virtual object DataValue
		{
			get { return ViewState["DataValue"]; }
			set { ViewState["DataValue"] = value; }
		}

		public bool EnableCurrentMonthOnly
		{
			get { return (bool)(ViewState["EnableCurrentMonthOnly"] ?? false); }
			set { ViewState["EnableCurrentMonthOnly"] = value; }
		}

		public bool EnableWeekends
		{
			get { return (bool)(ViewState["EnableWeekends"] ?? false); }
			set { ViewState["EnableWeekends"] = value; }
		}

		public virtual string EmptyDisplayText
		{
			get { return (string)(ViewState["EmptyDisplayText"] ?? null); }
			set { ViewState["EmptyDisplayText"] = value; }
		}

		public virtual bool ReadOnly
		{
			get { return (bool)(ViewState["ReadOnly"] ?? false); }
			set { ViewState["ReadOnly"] = value; }
		}

		public virtual bool ShowCurrentMonthOnly
		{
			get { return (bool)(ViewState["ShowCurrentMonthOnly"] ?? false); }
			set { ViewState["ShowCurrentMonthOnly"] = value; }
		}

		public virtual int? RelatedKey
		{
			get { return (int?)(ViewState["RelatedKey"] ?? null); }
			set { ViewState["RelatedKey"] = value; }
		}

		public virtual string Text
		{
			get { return this.SelectedDate.ToString(); }
			set
			{
				if (string.IsNullOrEmpty(value))
					this.SelectedDate = DateTime.Today;
				else
					this.SelectedDate = DateTime.Parse(value);
			}
		}

		public virtual object Value
		{
			get { return this.SelectedDate; }
			set
			{
				if (value == null || DBNull.Value.Equals(value))
					this.SelectedDate = DateTime.Now;
				else if (value is string)
					this.Text = value.ToString();
				else if (value is DateTime)
					this.SelectedDate = (DateTime)value;
				else if (value is long)
					this.SelectedDate = DateTime.FromFileTime((long)value);
				else
					throw new ArgumentException("The value provided cannot be converted to a date");
			}
		}

		#endregion



		#region " Methods "

		protected override void OnDayRender(TableCell cell, CalendarDay day)
		{
			if (day.IsOtherMonth)
				day.IsSelectable = this.EnableCurrentMonthOnly;
			if (day.IsWeekend)
				day.IsSelectable = this.EnableWeekends;

			base.OnDayRender(cell, day);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Enabled != this.ReadOnly)
			{
				if (!this.ReadOnly)
					this.Enabled = false;
			}
		}

		#endregion
	}
}
