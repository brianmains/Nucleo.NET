using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Text
{
	[TestClass]
	public class MessagesTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingMessagesWorksOK()
		{
			//Arrange
			var provider = new FakeMessageProvider();
			var msgFake = Isolate.Fake.Instance<Messages>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(msgFake, "Provider").WillReturn(provider);
			Isolate.NonPublic.WhenCalled(msgFake, "InitializeProvider").IgnoreCall();

			//Act
			msgFake.AddMessage(new Message(Guid.NewGuid(), "Test", "Test Text"));
			msgFake.AddMessage(new Message(Guid.NewGuid(), "Fake Test", "Fake Text"));

			//Assert
			Assert.AreEqual(2, provider.Messages.Count);
			Assert.AreEqual("Test", provider.Messages[0].Title);
			Assert.AreEqual("Fake Test", provider.Messages[1].Title);
		}

		[TestMethod]
		public void GettingMessagesWorksOK()
		{
			//Arrange
			var provider = new FakeMessageProvider();
			var msgFake = Isolate.Fake.Instance<Messages>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(msgFake, "Provider").WillReturn(provider);
			Isolate.NonPublic.WhenCalled(msgFake, "InitializeProvider").IgnoreCall();

			//Act
			msgFake.AddMessage(new Message(Guid.NewGuid(), "Test", "Test Text"));
			msgFake.AddMessage(new Message(Guid.NewGuid(), "Fake Test", "Fake Text"));

			var messages = msgFake.GetMessages();

			//Assert
			Assert.AreEqual(2, messages.Count);
			Assert.AreEqual("Test", provider.Messages[0].Title);
			Assert.AreEqual("Fake Test", provider.Messages[1].Title);
		}

		[TestMethod]
		public void GettingMessagesUsingEndDatesReturnsPartialSubset()
		{
			//Arrange
			var provider = new FakeMessageProvider();
			provider.Messages.Add(new Message(Guid.NewGuid(), "Test", "Test Text", new DateTime(1900, 1, 1), new DateTime(2010, 1, 1)));
			provider.Messages.Add(new Message(Guid.NewGuid(), "Fake Test", "Fake Text", new DateTime(1900, 1, 1), new DateTime(2010, 1, 1)));
			provider.Messages.Add(new Message(Guid.NewGuid(), "Fake Test 2", "Fake Text 2", new DateTime(2010, 1, 1), new DateTime(9999, 1, 1)));
			provider.Messages.Add(new Message(Guid.NewGuid(), "Fake Test 3", "Fake Text 3", new DateTime(2010, 1, 1), new DateTime(9999, 1, 1)));

			var msgFake = Isolate.Fake.Instance<Messages>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(msgFake, "Provider").WillReturn(provider);
			Isolate.NonPublic.WhenCalled(msgFake, "InitializeProvider").IgnoreCall();

			//Act
			var messages = msgFake.GetMessages(new DateTime(2009, 1, 1));

			//Assert
			Assert.AreEqual(2, messages.Count);
			Assert.AreEqual("Test", messages[0].Title);
			Assert.AreEqual("Fake Test", messages[1].Title);
		}

		[TestMethod]
		public void RemovingMessagesWorksOK()
		{
			//Arrange
			var provider = new FakeMessageProvider();
			provider.Messages.Add(new Message(Guid.NewGuid(), "Test", "Test Text"));
			provider.Messages.Add(new Message(Guid.NewGuid(), "Fake Test", "Fake Text"));
			provider.Messages.Add(new Message(Guid.NewGuid(), "Fake Test 2", "Fake Text 2"));
			provider.Messages.Add(new Message(Guid.NewGuid(), "Fake Test 3", "Fake Text 3"));

			var msgFake = Isolate.Fake.Instance<Messages>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(msgFake, "Provider").WillReturn(provider);
			Isolate.NonPublic.WhenCalled(msgFake, "InitializeProvider").IgnoreCall();
			
			//Act
			msgFake.RemoveMessage(provider.Messages[1]);

			//Assert
			Assert.AreEqual(3, provider.Messages.Count);
			Assert.AreEqual("Fake Test 2", provider.Messages[1].Title);
		}

		[TestMethod]
		public void UpdatingMessageWorksOK()
		{
			//Arrange
			var provider = new FakeMessageProvider();
			provider.Messages.Add(new Message(Guid.NewGuid(), "Test", "Test Text"));
			provider.Messages.Add(new Message(Guid.NewGuid(), "Fake Test", "Fake Text"));
			provider.Messages.Add(new Message(Guid.NewGuid(), "Fake Test 2", "Fake Text 2"));
			provider.Messages.Add(new Message(Guid.NewGuid(), "Fake Test 3", "Fake Text 3"));

			var msgFake = Isolate.Fake.Instance<Messages>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(msgFake, "Provider").WillReturn(provider);
			Isolate.NonPublic.WhenCalled(msgFake, "InitializeProvider").IgnoreCall();

			//Act
			var message = provider.Messages[1];
			message.Title = "Updated";
			message.EffectiveDate = new DateTime(2010, 1, 1);
			message.EndDate = new DateTime(2010, 3, 1);

			msgFake.UpdateMessage(message);

			//Assert
			var newMessage = provider.Messages[1];
			Assert.AreEqual("Updated", newMessage.Title);
		}

		#endregion
	}
}
