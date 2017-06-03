using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.StandardizationControls
{
	public class SectionHeader : BaseHeader
	{
		#region " Properties "

		protected override string RootCssClass
		{
			get { return "NucleoSectionHeader"; }
		}

		protected override string RootTag
		{
			get { return "H2"; }
		}

		#endregion
	}
}
