namespace Nucleo.Orm
{
	public enum ModificationType
	{
		Unchanged,
		Added,
		Updated,
		Removed
	}
}

namespace Nucleo.Orm.Triggers
{
	/// <summary>
	/// Represents the type of action that the trigger is performing.
	/// </summary>
	public enum TriggerAction
	{
		Insert,
		Update,
		Delete
	}
}

namespace Nucleo.Orm.Validation
{
	public enum ValidationRuleType
	{
		Create,
		Update,
		Delete
	}
}