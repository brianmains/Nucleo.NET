using System;
using System.IO;
using System.Web.Mvc;


namespace Nucleo.Web.Views
{
	public class FakeView : IView
	{
		private string _name = null;
		private string _viewContent = null;



		#region " Properties "

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string ViewContent
		{
			get { return _viewContent; }
			set { _viewContent = value; }
		}

		#endregion



		#region" Constructors "

		public FakeView() { }

		public FakeView(string name) 
		{
			_name = name;
		}

		#endregion



		#region " Methods "

		public void Render(ViewContext viewContext, TextWriter writer)
		{
			writer.Write(this.ViewContent);
		}

		#endregion
	}
}
