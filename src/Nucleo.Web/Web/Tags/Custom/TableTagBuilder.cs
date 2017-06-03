using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web.Tags.Custom
{
	/// <summary>
	/// Represents a builder to create a table.
	/// </summary>
	public class TableTagBuilder : ICustomTagBuilder
	{
		private TagElement _element = null;



		#region " Constructors "

		private TableTagBuilder(TagElement element)
		{
			_element = element;
		}

		#endregion



		#region " Methods "

		public static TableTagBuilder Create()
		{
			return CreateInternal(-1, -1, false);
		}

		public static TableTagBuilder Create(int rows, int columns, bool buildHeaderRow)
		{
			return CreateInternal(rows, columns, buildHeaderRow);
		}

		private static TableTagBuilder CreateInternal(int rows, int columns, bool buildHeaderRow)
		{
			TagElement table = new TagElement("TABLE");

			TagElement header = new TagElement("THEAD");
			table.Children.AppendTag(header);

			if (buildHeaderRow)
			{
				TagElement headerRow = new TagElement("TR");
				header.Children.AppendTag(headerRow);

				for (int index = 0; index < rows; index++)
					headerRow.Children.AppendTag(new TagElement("TH"));
			}

			TagElement body = new TagElement("TBODY");
			table.Children.AppendTag(body);

			for (int rowIndex = 0; rowIndex < rows; rowIndex++)
			{
				TagElement bodyRow = new TagElement("TR");
				body.Children.AppendTag(bodyRow);

				for (int columnIndex = 0; columnIndex < columns; columnIndex++)
					bodyRow.Children.AppendTag(new TagElement("TD"));
			}

			return new TableTagBuilder(table);
		}

		public TagElement ToElement()
		{
			return _element;
		}

		#endregion
	}
}
