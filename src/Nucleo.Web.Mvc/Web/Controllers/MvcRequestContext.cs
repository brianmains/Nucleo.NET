using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Nucleo.Models;
using Nucleo.Web.Core;


namespace Nucleo.Web.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	public class MvcRequestContext
	{
		private IWebContext _context = null;
		private ModelInjectionManager _modelInjection = null;



		#region " Properties "

		public IWebContext Context
		{
			get
			{
				if (_context == null)
					_context = WebContext.GetCurrent();

				return _context;
			}
			set { _context = value; }
		}

		public ModelInjectionManager ModelInjection
		{
			get { return _modelInjection; }
			set { _modelInjection = value; }
		}

		#endregion
	}
}
