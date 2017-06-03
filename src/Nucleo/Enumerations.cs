using System;


namespace Nucleo
{
	[Flags]
	public enum CalendarPeriod
	{
		None = 1,
		Day = 2,
		Week = 4,
		Month = 8,
		Year = 16
	}

	public enum Difficulty
	{
		Easy,
		Average,
		Moderate,
		Complex
	}

	public enum TimePeriodEra
	{
		BC,
		AD
	}

	public enum DevelopmentTargetStatus
	{
		InDevelopment,
		Complete,
		DeferredToLaterRelease,
		DeferredToLaterIteration,
		Delayed,
		WaitingForTaskCompletion
	}

	/// <summary>
	/// When looking for a portion of text, search from either the beginning of the text, the ending, or anywhere in the string.
	/// </summary>
	public enum PartialTextLocation
	{
		Beginning,
		Ending,
		Containing
	}

	public enum SearchMatching
	{
		Exactly,
		Any,
		Beginning,
		Ending
	}

	[Flags]
	public enum WeekNumber
	{
		Any = 1,
		First = 2,
		Second = 4,
		Third = 8,
		Fourth = 16,
		Fifth = 32
	}

	public enum WindowLocationType
	{
		Top = 1,
		Bottom = 2,
		Left = 4,
		Right = 8
	}
}

namespace Nucleo.Global.Configuration
{
	public enum ApplicationStorageLocation
	{
		Configuration,
		Provider,
		Settings
	}
}

namespace Nucleo.Logs
{
	public enum CommonLogMessageTypes
	{
		Information = 0,
		Warning = 127,
		Error = 255
	}

	public enum CommonLogVerbosityTypes
	{
		Minimal = 0,
		Normal = 127,
		Verbose = 255
	}
}

namespace Nucleo.Math
{
	public enum IndexRepeatDirection
	{
		Horizontal,
		Vertical
	}
}

namespace Nucleo.Reflection
{
	public enum ValueMatching
	{
		Equal,
		NotEqual,
		GreaterThan,
		LessThan
	}
}

namespace Nucleo.Registration
{
	public enum RegistrationStatusType
	{
		Success = 1,
		EventFull = 2,
		NoRegistration = 4,
		NoEventRegistration = 8,
		Error = 16
	}
}

namespace Nucleo.Security
{
	public enum AuthorizationType
	{
		Allow = 1,
		Deny = 2
	}

	[Flags]
	public enum PasswordStatusType
	{
		None = 1,
		Ok = 2,
		IllegalLength = 4,
		NoUpperCaseCharacters = 8,
		NoNumerics = 16,
		NoSpecialCharacters = 32,
		TooManyRepeatingCharacters = 64
	}

	public enum NewUserCreationStatusType
	{
		None,
		Success,
		DuplicateUserName,
		DuplicateEmail,
		DuplicateAddress,
		DuplicateHomePhoneNumber,
		DuplicateAlternatePhoneNumber,
		IllegalUserName,
		IllegalEmail,
		IllegalPassword,
		MissingEmail,
		MissingAddress,
		UnknownError
	}

	public enum SecurityPasswordFormat
	{
		Clear = 1,
		Hashed = 2,
		Encryped = 4,
		HashEncrypted = 8,
		DoubleEncrypted = 16
	}
}

namespace Nucleo.Staff
{
	public enum StaffCreationStatus
	{
		Success,
		DuplicateEmail,
		ProviderError
	}
}

namespace Nucleo.State
{
	public enum StateAlertEvaluationType
	{
		Equal,
		GreaterThan,
		LessThan
	}

	public enum StateConditionExecutionStatus
	{
		Unknown,
		Succeeded,
		Failed,
		Errored
	}

	public enum StatePropertyIsolation
	{
		PerUser,
		Shared
	}
}
