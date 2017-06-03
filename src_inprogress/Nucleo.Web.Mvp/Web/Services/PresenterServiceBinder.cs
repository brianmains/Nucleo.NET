using System;
using System.Web;
using System.Reflection;

using Nucleo.Presentation;
using Nucleo.Web.Presentation;


namespace Nucleo.Web.Services
{
	/// <summary>
	/// Represents a binder for loading the presenter for a web service. 
	/// </summary>
	public class PresenterServiceBinder
	{
		private HttpContextBase _context = null;



		#region " Constructors "

		public PresenterServiceBinder(HttpContextBase context)
		{
			_context = context;
		}

		#endregion



		#region " Methods "

		public IPresenter FindPresenter(object view)
		{
			if (_context == null || _context.Request.PathInfo == null)
				return null;

			string methodName = _context.Request.PathInfo.Substring(1);
			MethodInfo method = view.GetType().GetMethod(methodName);

			PresenterBindingAttribute attribute = method.GetCustomAttribute<PresenterBindingAttribute>(false);
			if (attribute == null)
				return null;

			Type type = attribute.GetPresenterType();
			if (type == null)
				throw new InvalidOperationException("The given type could not be found: " + type.FullName);

			IPresenter presenter = Activator.CreateInstance(type) as IPresenter;
			if (presenter == null)
				throw new InvalidOperationException("The presenter type is not of the given type IPresenter: " + type.FullName);

			return presenter;
		}

		#endregion
	}
}
