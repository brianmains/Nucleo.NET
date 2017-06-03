using System;
using System.Web.UI;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web.ClientState;
using Nucleo.Web.Pages.Testing;


namespace Nucleo.Web.EditorControls
{
	[TestClass]
	public class TextEditorTest
	{
		#region " Tests "

		[TestMethod]
		public void HasChangesFiresTextChangedEvent()
		{
			//Arrange
			var control = new TextEditor();
			control.ID = "txt";
			control.Page = new Page();

			var clientState = new ClientStateDictionary();
			clientState.Add("hasChanges", true);
			bool success = false;

			//Act/Assert
			control.TextChanged += delegate(object sender, EventArgs e)
			{
				success = true;
			};

			((IClientStateControl)control).LoadClientState(new ClientStateData(clientState));

			Assert.AreEqual(true, success);
		}

		[TestMethod]
		public void LoadingPostDataLoadsOK()
		{
			//Arrange
			var page = new PageRunner() { IsInitialLoad = false };

			var control = new TextEditor();
			control.ID = "txt";
			page.AddControl(control);

			var post = new NameValueCollection();
			post.Add("txt", "My Text");

			//Act
			((IPostBackDataHandler)control).LoadPostData("txt", post);

			//Assert
			Assert.AreEqual("My Text", control.Text);
		}

		#endregion
	}
}
