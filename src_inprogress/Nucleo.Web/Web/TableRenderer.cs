using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Web
{
	public class TableRenderer
	{
		private Dictionary<int, List<Control>> _controlSetup = null;
		private HtmlTextWriter _writer = null;



		#region " Constructors "

		public TableRenderer(HtmlTextWriter writer)
		{
			if (writer == null)
				throw new ArgumentNullException("writer");

			_writer = writer;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a control at a specified column.
		/// </summary>
		/// <param name="control"></param>
		/// <param name="column"></param>
		public void AddControl(Control control, int column)
		{
			if (_controlSetup.ContainsKey(column))
				_controlSetup[column].Add(control);
			else
			{
				List<Control> controlList = new List<Control>();
				controlList.Add(control);

				_controlSetup.Add(column, controlList);
			}
		}

		public void AddAttribute(string attribute, string value)
		{
			_writer.AddAttribute(attribute, value);
		}

		public void AddAttribute(HtmlTextWriterAttribute attribute, string value)
		{
			_writer.AddAttribute(attribute, value);
		}

		public void AddStyle(string style, string value)
		{
			_writer.AddStyleAttribute(style, value);
		}

		public void AddStyle(HtmlTextWriterStyle style, string value)
		{
			_writer.AddStyleAttribute(style, value);
		}

		/// <summary>
		/// Completes rendering for the row.
		/// </summary>
		public void EndRow()
		{
			int index = 1;

			while (true)
			{
				if (_controlSetup.ContainsKey(index))
				{
					List<Control> controlList = _controlSetup[index];
					foreach (Control control in controlList)
						control.RenderControl(_writer);
				}
				else
					break;

				index++;
			}

			_writer.RenderEndTag(); //tr
		}

		/// <summary>
		/// Starts the rendering process for a new row.
		/// </summary>
		public void StartRow()
		{
			_controlSetup = new Dictionary<int, List<Control>>();
			_writer.RenderBeginTag(HtmlTextWriterTag.Tr);
		}

		#endregion
	}
}
