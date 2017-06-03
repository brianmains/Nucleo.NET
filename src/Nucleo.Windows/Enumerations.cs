using System;

namespace Nucleo.Windows.Actions
{
	public enum DefaultEventAction
	{
		None,
		Click,
		Select,
		Show,
		Hide
	}
}

namespace Nucleo.Windows.Application
{
	internal class ApplicationEventKeys
	{
		internal const string AddedEventName = "Add";
		internal const string ClickEventName = "Click";
		internal const string CommandEventName = "Command";
		internal const string InsertedEventName = "Insert";
		internal const string PropertyChangedEventName = "PropertyChanged";
		internal const string RemovedEventName = "Remove";
		internal const string SelectEventName = "Select";
	}

	public enum WindowsInterfaceType
	{
		Menu,
		Toolbar,
		ToolbarItem,
		DocumentWindow,
		ToolWindow
	}
}

namespace Nucleo.Windows.UI
{
	public enum PopupNotificationLocation
	{
		TopLeft,
		TopCenter,
		TopRight,
		CenterLeft,
		CenterRight,
		BottomLeft,
		BottomCenter,
		BottomRight
	}

	public enum ToolbarDisplay
	{
		TextOnly,
		ImageOnly,
		ImageBeforeText,
		ImageAfterText
	}

	public enum ToolbarDropDownDisplay
	{
		DropDown,
		SplitButton
	}

	public enum ToolbarLocation
	{
		Top,
		Bottom
	}

	public enum ToolWindowLocation
	{
		Left,
		Right,
		Bottom
	}
}