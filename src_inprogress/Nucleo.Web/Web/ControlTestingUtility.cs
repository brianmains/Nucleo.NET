using System;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

using Nucleo.Web.Pages;


namespace Nucleo.Web
{
	public static class ControlTestingUtility
	{
		#region " Methods "

		public static void AppendHeaderToPage(Page page)
		{
			HtmlHead head = new HtmlHead();
			head.Page = page;

			MethodInfo method = head.GetType().GetMethod("OnInit", BindingFlags.Instance | BindingFlags.NonPublic);
			method.Invoke(head, new object[] { System.EventArgs.Empty });
		}

		public static T CreateControl<T>()
			where T: Control
		{
			T control = (T)Activator.CreateInstance<T>();

			FakePage page = new FakePage();
			page.Controls.Add(control);
			control.Page = page;

			return control;
		}

		/// <summary>
		/// Creates a new control that normally appears at the top of the page.  This is normally a control that would appear at the top of the page, and only have one instance (such as the ScriptManager control).
		/// </summary>
		/// <typeparam name="T">The type of control to create.</typeparam>
		/// <returns>The control reference of the correct type.</returns>
		public static T CreateSingleInstanceControl<T>()
			where T: Control
		{
			T control = (T)Activator.CreateInstance<T>();

			FakePage page = new FakePage();
			page.Controls.Add(control);
			control.Page = page;

			page.Items[typeof(T)] = control;

			return control;
		}

		public static void FirePageEvent(Page page, PageEvent pageEvent)
		{
			FirePageEvent(page, pageEvent, System.EventArgs.Empty);
		}

		public static void FirePageEvent(Page page, PageEvent pageEvent, EventArgs e)
		{
			if (page is FakePage)
				((FakePage)page).FireEvent(pageEvent);
			else
			{
				MethodInfo method = page.GetType().GetMethod("On" + pageEvent.ToString(), BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
				if (method == null)
					throw new Nucleo.Exceptions.NotFoundException(string.Format("The page event '{0}' could not be found", pageEvent.ToString()));

				method.Invoke(page, new object[] { e });
			}
		}

		public static void SimulatePostbackData(Control control, NameValueCollection post)
		{
			if (!(control is IPostBackDataHandler))
				throw new InvalidOperationException("The control simulating postback must implement IPostBackDataHandler");

			IPostBackDataHandler handle = (IPostBackDataHandler)control;
			handle.LoadPostData(control.ClientID, post);
		}

		public static void SimulatePostbackEvent(Control control, string eventArgument)
		{
			if (!(control is IPostBackEventHandler))
				throw new InvalidOperationException("The control simulating postback must implement IPostBackEventHandler");

			IPostBackEventHandler handle = (IPostBackEventHandler)control;
			handle.RaisePostBackEvent(eventArgument);
		}

		#endregion
	}
}
