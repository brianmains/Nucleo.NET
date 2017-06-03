using System;
using System.Web.Mvc;


namespace Nucleo.Web.Controllers
{
	public abstract class NucleoController : Controller
	{
		private MvcRequestContext _context = null;


		#region " Properties "

		/// <summary>
		/// Gets or sets the controller context to use.
		/// </summary>
		new public MvcRequestContext Context
		{
			get { return _context; }
			set { _context = value; }
		}

		#endregion



		#region " Methods "

#if MVC2
		/// <summary>
		/// Creates a Nucleo AJAX Action invoker.
		/// </summary>
		/// <returns>The created action invoker.</returns>
		protected override IActionInvoker CreateActionInvoker()
		{
			return new NucleoActionInvoker();
		}
#endif

		#endregion
	}
}
