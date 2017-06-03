using System;
using System.Windows.Forms;
using API = Nucleo.Windows.UI;


namespace Nucleo.Windows.Application
{
	public class WindowsDocumentRenderer : InterfaceRenderer<API.DocumentWindow>
	{
		private ApplicationModel _application = null;
		private TabControl _documents = null;



		#region " Properties "

		public ApplicationModel Application
		{
			get { return _application; }
		}

		public TabControl Documents
		{
			get { return _documents; }
		}

		#endregion



		#region " Constructors "

		public WindowsDocumentRenderer(TabControl documents, ApplicationModel application)
		{
			if (documents == null)
				throw new ArgumentNullException("documents");

			_documents = documents;
			_application = application;

			if (!_documents.IsHandleCreated)
				_documents.CreateControl();

			_documents.TabIndexChanged += new EventHandler(Documents_TabIndexChanged);
		}

		#endregion



		#region " Methods "

		public override void AddItem(API.DocumentWindow uiItem)
		{
			this.AddItem(this.Documents.TabCount - 1, uiItem);
		}

		public override void AddItem(int index, API.DocumentWindow uiItem)
		{
			if (index < 0)
				throw new ArgumentOutOfRangeException("index");
			if (uiItem == null)
				throw new ArgumentNullException("uiItem");

			TabPage page = this.CreateDocument(uiItem);
			this.Documents.TabPages.Insert(index, page);
		}

		private TabPage CreateDocument(API.DocumentWindow uiItem)
		{
			TabPage page = new TabPage();
			page.Name = uiItem.Name;
			page.Text = uiItem.Title;
			page.Tag = uiItem;
			page.Controls.Add(this.GetControlReference(uiItem.UIInterface));

			return page;
		}

		public static WindowsDocumentRenderer GetRenderer(TabControl documents, ApplicationModel application)
		{
			if (documents != null)
				return new WindowsDocumentRenderer(documents, application);
			else
				return null;
		}

		public override void RemoveItem(API.DocumentWindow uiItem)
		{
			this.Documents.TabPages.RemoveByKey(uiItem.Name);
		}

		#endregion



		#region " Event Handlers "

		void Documents_TabIndexChanged(object sender, EventArgs e)
		{
			TabPage selectedPage = this.Documents.SelectedTab;
			if (selectedPage != null)
			{
				API.DocumentWindow window = (API.DocumentWindow)selectedPage.Tag;

			}
		}

		#endregion
	}
}
