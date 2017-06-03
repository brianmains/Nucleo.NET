using System;
using System.Reflection;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock;
using TypeMock.ArrangeActAssert;


namespace Nucleo.State
{
	[TestClass]
	public class XmlStateValuesProviderTest
	{
		#region " Methods "

		private string GetFilePath(XmlStateValuesProvider provider, StateUser user, StatePropertyIsolation isolation, string path)
		{
			var method = typeof(XmlStateValuesProvider).GetMethod("GetFilePath", BindingFlags.Instance | BindingFlags.NonPublic);
			return (string)method.Invoke(provider, new object[] { user, isolation, path });
		}

		private XmlDocument GetTestDocument()
		{
			string xml = @"
				<StateProperties>
					<StateProperty>
						<Name>Requires Authentication</Name>
						<Value>True</Value>
					</StateProperty>
					<StateProperty>
						<Name>Requires Admin Privileges</Name>
						<Value>False</Value>
					</StateProperty>
					<StateProperty>
						<Name>Admin Role Name</Name>
						<Value>Administrators</Value>
					</StateProperty>
					<Region Name='Default.aspx'>
						<StateProperty>
							<Name>Current Mode</Name>
							<Value>Edit</Value>
						</StateProperty>
						<StateProperty>
							<Name>Allow Unauth Users</Name>
							<Value>False</Value>
						</StateProperty>	
					</Region>
				</StateProperties>
			";

			XmlDocument document = new XmlDocument();
			document.LoadXml(xml);

			return document;
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingFilePathForSharedPropertyWorksOK()
		{
			//Arrange
			var user = new StateUser("fake", true);
			var provider = new XmlStateValuesProvider();

			//Act
			var path1 = this.GetFilePath(provider, user, StatePropertyIsolation.Shared, "~/testfolder");
			var path2 = this.GetFilePath(provider, user, StatePropertyIsolation.Shared, "testfolder");

			//Assert
			Assert.AreEqual(AppDomain.CurrentDomain.BaseDirectory + @"\testfolder\shared.xml", path1);
			Assert.AreEqual(AppDomain.CurrentDomain.BaseDirectory + @"\testfolder\shared.xml", path2);
		}

		[TestMethod]
		public void GettingRegionStateValueWorksOK()
		{
			//Arrange
			XmlDocument document = this.GetTestDocument();
			var providerFake = Isolate.Fake.Instance<XmlStateValuesProvider>(Members.CallOriginal);
			Isolate.NonPublic.WhenCalled(providerFake, "GetDocument").WillReturn(document);

			var user = new StateUser("Test", true);

			//Act
			object mode = providerFake.GetRegionValue(user, new StateProperty("Current Mode", "Read"), "Default.aspx");
			object allow = providerFake.GetRegionValue(user, new StateProperty("Allow Unauth Users", "True"), "Default.aspx");

			//Assert
			Assert.AreEqual("Edit", mode);
			Assert.AreEqual("False", allow);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingStateValuesWorksCorrectly()
		{
			//Arrange
			XmlDocument document = this.GetTestDocument();
			Mock providerMock = MockManager.Mock<XmlStateValuesProvider>();
			providerMock.ExpectAndReturn("GetDocument", document, 3, null);

			var user = new StateUser("Test", true);

			//Act
			XmlStateValuesProvider provider = new XmlStateValuesProvider();
			object authValue = provider.GetValue(user, new StateProperty("Requires Authentication", false));
			object adminValue = provider.GetValue(user, new StateProperty("Requires Admin Privileges", true));
			object roleValue = provider.GetValue(user, new StateProperty("Admin Role Name", ""));

			//Assert
			Assert.IsNotNull(authValue);
			Assert.AreEqual(bool.TrueString, authValue);
			Assert.IsNotNull(adminValue);
			Assert.AreEqual(bool.FalseString, adminValue);
			Assert.IsNotNull(roleValue);
			Assert.AreEqual("Administrators", roleValue);
		}

		[TestMethod]
		public void SettingRegionStateValuesAssignsOK()
		{
			//Arrange
			XmlDocument document = this.GetTestDocument();
			var providerFake = Isolate.Fake.Instance<XmlStateValuesProvider>(Members.CallOriginal);
			Isolate.NonPublic.WhenCalled(providerFake, "GetDocument").WillReturn(document);
			Isolate.NonPublic.WhenCalled(providerFake, "SetValueInternal").WillReturn(true);

			var user = new StateUser("Test", true);

			//Act
			providerFake.SetRegionValue(user, new StateProperty("Current Mode", "Read"), "Default.aspx", "Insert");

			//Assert
			Isolate.Verify.NonPublic.WasCalled(providerFake, "SetValueInternal");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingStateValuesNullAssignsEmptyValue()
		{
			XmlDocument document = this.GetTestDocument();
			Mock providerMock = MockManager.Mock<XmlStateValuesProvider>();
			providerMock.ExpectAndReturn("GetDocument", document, null);

			var user = new StateUser("Test", true);

			XmlStateValuesProvider provider = new XmlStateValuesProvider();
			provider.SetValue(user, new StateProperty("Admin Role Name", ""), null);

			XmlElement testElement = (XmlElement)document.SelectSingleNode("//StateProperty[./Name='Admin Role Name']");
			Assert.IsNotNull(testElement);
			Assert.AreEqual(string.Empty, testElement["Value"].InnerText);
		}

		[TestMethod]
		public void SettingStateValueWhenValuesAreDifferentReturnsTrue()
		{
			//Arrange
			XmlDocument document = this.GetTestDocument();
			var providerFake = Isolate.Fake.Instance<XmlStateValuesProvider>(Members.CallOriginal);
			Isolate.NonPublic.WhenCalled(providerFake, "GetDocument").WillReturn(document);

			var user = new StateUser("Test", true);

			//Act
			var result = providerFake.SetValue(user, new StateProperty("Requires Authentication", true), false); 

			//Assert
			Assert.AreEqual(true, result);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingStateValueWhenValuesAreSameReturnsFalse()
		{
			//Arrange
			XmlDocument document = this.GetTestDocument();
			var providerFake = Isolate.Fake.Instance<XmlStateValuesProvider>(Members.CallOriginal);
			Isolate.NonPublic.WhenCalled(providerFake, "GetDocument").WillReturn(document);

			var user = new StateUser("Test", true);

			//Act
			var result = providerFake.SetValue(user, new StateProperty("Requires Authentication", false), true);

			//Assert
			Assert.AreEqual(false, result);
			
			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingStateValuesWorksCorrectly()
		{
			XmlDocument document = this.GetTestDocument();
			Mock providerMock = MockManager.Mock<XmlStateValuesProvider>();
			providerMock.ExpectAndReturn("GetDocument", document, 3, null);

			var user = new StateUser("Test", true);

			XmlStateValuesProvider provider = new XmlStateValuesProvider();
			provider.SetValue(user, new StateProperty("Requires Authentication", true), false);
			XmlElement testElement = (XmlElement)document.SelectSingleNode("//StateProperty[./Name='Requires Authentication']");
			Assert.IsNotNull(testElement);
			Assert.AreEqual(false.ToString(), testElement["Value"].InnerText);

			provider.SetValue(user, new StateProperty("Requires Admin Privileges", false), true);
			testElement = (XmlElement) document.SelectSingleNode("//StateProperty[./Name='Requires Admin Privileges']");
			Assert.IsNotNull(testElement);
			Assert.AreEqual(true.ToString(), testElement["Value"].InnerText);

			provider.SetValue(user, new StateProperty("Admin Role Name", ""), "Admins");
			testElement = (XmlElement)document.SelectSingleNode("//StateProperty[./Name='Admin Role Name']");
			Assert.IsNotNull(testElement);
			Assert.AreEqual("Admins", testElement["Value"].InnerText);
		}

		#endregion
	}
}
