using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.ListControls;
using Nucleo.Web.Settings;
using Nucleo.Web.Templates;


namespace Nucleo.Web.Mvc.ListControls
{
	public class PageableListItemControlBuilder
	{
		private ActionElementTemplate _content = null;



		#region " Properties "

		internal ActionElementTemplate Template
		{
			get { return _content; }
		}

		#endregion



		#region " Constructors "

		public PageableListItemControlBuilder() { }

		#endregion



		#region " Methods "

		public PageableListItemControlBuilder Content(System.Action content)
		{
			if (content == null)
				throw new ArgumentNullException("content");

			_content = new ActionElementTemplate(content);
			return this;
		}

		#endregion
	}
}
