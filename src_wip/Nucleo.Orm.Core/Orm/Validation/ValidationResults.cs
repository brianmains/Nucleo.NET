using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Orm.Validation
{
	/// <summary>
	/// Represents the results of the validation rule validation.
	/// </summary>
	public class ValidationResults
	{
		private object _entity = null;
		private ValidationRuleType _ruleType = ValidationRuleType.Create;
		private ValidationMessageCollection _messages = new ValidationMessageCollection();


		/// <summary>
		/// Gets a reference to the entity the validation rule is being applied for.
		/// </summary>
		public object Entity
		{
			get { return _entity; }
		}

		/// <summary>
		/// Gets whether the validation is valid.
		/// </summary>
		public bool IsValid
		{
			get;
			private set;
		}

		private ValidationMessageCollection Messages
		{
			get
			{
				if (_messages == null)
					_messages = new ValidationMessageCollection();

				return _messages;
			}
		}

		/// <summary>
		/// Gets the type of rule.
		/// </summary>
		public ValidationRuleType RuleType
		{
			get { return _ruleType; }
		}



		/// <summary>
		/// Creates the result with initial values.
		/// </summary>
		public ValidationResults(object entity, ValidationRuleType ruleType)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			_entity = entity;
			_ruleType = ruleType;

			IsValid = true;
		}


		/// <summary>
		/// Adds a mesage to the validation result.
		/// </summary>
		/// <param name="message">The message to add.</param>
		/// <exception cref="ArgumentNullException">Thrown when the message is null.</exception>
		public void AddMessage(ValidationMessage message)
		{
			if (message == null)
				throw new ArgumentNullException("message");

			this.Messages.Add(message);

			//If an error, set the valid state to false
			if (message.IsErrorResult)
				this.IsValid = false;
		}

		/// <summary>
		/// Gets the collection of messages.
		/// </summary>
		/// <returns>The messages.</returns>
		public ValidationMessageCollection GetMessages()
		{
			return this.Messages;
		}
	}
}
