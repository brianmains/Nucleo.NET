using System;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents the type of member that belongs to the control or extender (a property, event, etc.)
	/// </summary>
	public enum ClientMemberType
	{
		Property,
		Event
	}

	[Flags]
	public enum CoreScriptIncludes
	{
		Common = 1,
		WebUtilities = 2,
		ObjectUtilities = 3
	}

	public enum JavaScriptConvertObjectType
	{
		Collection,
		SingleInstance,
		Unknown
	}

	public enum NumericEditingType
	{
		WholeNumber,
		Money,
		Unknown
	}

	/// <summary>
	/// Represents the rendering mode for the control, whether the control renders server-side only, client-side only rendering (meaning the client component takes over more of the rendering, usually wth JavaScript), or a mix of the two options.
	/// </summary>
	public enum RenderMode
	{
		ServerOnly = 1,
		ClientOnly = 2,
		ClientAndServer = 3
	}

	/// <summary>
	/// The type of layout to repeat with.
	/// </summary>
	public enum RepeatingLayout
	{
		Table = 0,
		Flow = 1,
		List = 2
	}

	/// <summary>
	/// The include options for the service reference, controlling when the service reference gets included.
	/// </summary>
	public enum ServiceReferenceIncludeOptions
	{
		Any = 0,
		UserAuthenticated = 1,
		UserUnauthenticated = 2
	}

	public enum ValidationItemType
	{
		Error,
		Warning,
		Information
	}

	/// <summary>
	/// Gets the format of the template using the correct web library.
	/// </summary>
	/// <remarks>Will add ASP.NET AJAX 4 support later.</remarks>
	public enum WebTemplateFormat
	{
		Prototype = 1
	}
}

namespace Nucleo.Web.Browsers
{
	public enum BrowserCapabilityFeature
	{
		ActiveXControls,
		Adapters,
		AOL,
		BackgroundSounds,
		Beta,
		Browser,
		Browsers,
		CanCombineFormsInDeck,
		CanInitiateVoiceCall,
		CanRenderAfterInputOrSelectElement,
		CanRenderEmptySelects,
		CanRenderInputAndSelectElementsTogether,
		CanRenderMixedSelects,
		CanRenderOneventAndPrevElementsTogether,
		CanRenderPostBackCards,
		CanRenderSetvarZeroWithMultiSelectionList,
		CanSendMail,
		CDF,
		ClrVersion,
		Cookies,
		Crawler,
		DefaultSubmitButtonLimit,
		EcmaScriptVersion,
		Frames,
		GatewayMajorVersion,
		GatewayMinorVersion,
		GatewayVersion,
		HasBackButton,
		HidesRightAlignedMultiselectScrollbars,
		Id,
		InputType,
		IsColor,
		IsMobileDevice,
		JavaApplets,
		JScriptVersion,
		MajorVersion,
		MaximumHrefLength,
		MaximumRenderedPageSize,
		MaximumSoftkeyLabelLength,
		MinorVersion,
		MinorVersionString,
		MobileDeviceManufacturer,
		MobileDeviceModel,
		MSDomVersion,
		NumberOfSoftkeys,
		Platform,
		PreferredImageMime,
		PreferredRenderingMime,
		PreferredRenderingType,
		PreferredRequestEncoding,
		PreferredResponseEncoding,
		RendersBreakBeforeWmlSelectAndInput,
		RendersBreaksAfterHtmlLists,
		RendersBreaksAfterWmlAnchor,
		RendersBreaksAfterWmlInput,
		RendersWmlDoAcceptsInline,
		RendersWmlSelectsAsMenuCards,
		RequiredMetaTagNameValue,
		RequiresAttributeColonSubstitution,
		RequiresContentTypeMetaTag,
		RequiresControlStateInSession,
		RequiresDBCSCharacter,
		RequiresHtmlAdaptiveErrorReporting,
		RequiresLeadingPageBreak,
		RequiresNoBreakInFormatting,
		RequiresOutputOptimization,
		RequiresPhoneNumbersAsPlainText,
		RequiresSpecialViewStateEncoding,
		RequiresUniqueFilePathSuffix,
		RequiresUniqueHtmlCheckboxNames,
		RequiresUniqueHtmlInputNames,
		RequiresUrlEncodedPostfieldValues,
		ScreenBitDepth,
		ScreenCharactersHeight,
		ScreenCharactersWidth,
		ScreenPixelsHeight,
		ScreenPixelsWidth,
		SupportsAccesskeyAttribute,
		SupportsBodyColor,
		SupportsBold,
		SupportsCacheControlMetaTag,
		SupportsCallback,
		SupportsCss,
		SupportsDivAlign,
		SupportsDivNoWrap,
		SupportsEmptyStringInCookieValue,
		SupportsFontColor,
		SupportsFontName,
		SupportsFontSize,
		SupportsImageSubmit,
		SupportsIModeSymbols,
		SupportsInputIStyle,
		SupportsInputMode,
		SupportsItalic,
		SupportsJPhoneMultiMediaAttributes,
		SupportsJPhoneSymbols,
		SupportsQueryStringInFormAction,
		SupportsRedirectWithCookie,
		SupportsSelectMultiple,
		SupportsUncheck,
		SupportsXmlHttp,
		Tables,
		TagWriter,
		Type,
		UseOptimizedCacheKey,
		VBScript,
		Version,
		W3CDomVersion,
		Win16,
		Win32
	}
}

namespace Nucleo.Web.ClientRegistration
{
	public enum ClientPropertyContentType
	{
		Data,
		ClientElement,
		AjaxComponent,
		Event
	}
}

namespace Nucleo.Web.CodeGeneration
{
	public enum ClassMemberType
	{
		Method,
		Property,
		Event
	}
}

namespace Nucleo.Web.ControlStorage
{
	/// <summary>
	/// Represents the storage for control property dictionary.
	/// </summary>
	public enum ControlPropertyStorage
	{
		/// <summary>
		/// Persist the values.
		/// </summary>
		Persist,
		/// <summary>
		/// Don't persist the values.
		/// </summary>
		DontPersist
	}
}

namespace Nucleo.Web.Description
{
	public enum ScriptIDFormatting
	{
		Standard,
		Element,
		Control,
		Extender
	}
}

namespace Nucleo.Web.FormControls
{
	public enum FormCurrentView
	{
		ReadOnly,
		Insert,
		Edit
	}

	public enum SectionHeaderAppearance
	{
		None,
		H1,
		H2,
		H3,
		Strong
	}
}

namespace Nucleo.Web.Pages
{
	public enum PageControllerEvent : int
	{
		Startup = 0,
		Initializing = 1,
		Loading = 2,
		ValidateState = 3,
		PrepareToRender = 4,
		Rendering = 5,
		Rendered = 6,
		Unloading = 7
	}

	public enum PageEvent
	{
		Init,
		InitComplete,
		PreInit,
		Load,
		LoadComplete,
		PreLoad,
		PreRender,
		PreRenderComplete,
		Unload,
		Validated,
		Validating
	}
}

namespace Nucleo.Web.Panels
{
	public enum FiltrationAction
	{
		Before,
		After
	}
}

namespace Nucleo.Web.Security.Configuration
{
	public enum AuthorizationCheckAction
	{
		Redirect,
		ThrowException
	}

}

namespace Nucleo.Web.ContainerControls
{
	/// <summary>
	/// Represents the type of operation to perform (dragging or dropping).
	/// </summary>
	public enum DragDropPanelOperation
	{
		Drag = 1,
		Drop = 2
	}

	/// <summary>
	/// Represents the position for the panel.
	/// </summary>
	public enum PanelPosition
	{
		BottomLeft = 1
	}
}

namespace Nucleo.Web.ContentControls
{
	/// <summary>
	/// Represents the type of operation to perform (dragging or dropping).
	/// </summary>
	public enum DragDropPanelOperation
	{
		Drag = 1,
		Drop = 2
	}
}

namespace Nucleo.Web.Controls
{
	/// <summary>
	/// Represents the click action for a link, whether to redirect to another page, or for firing an event.
	/// </summary>
	public enum LinkClickAction
	{
		FireEvent = 1,
		Redirect = 2
	}

	/// <summary>
	/// Represents the target for the click action, whether targeting the same window or a new one.
	/// </summary>
	public enum LinkTargetOptions
	{
		SameWindow = 1,
		NewWindow = 2
	}
}

namespace Nucleo.Web.DataSourceControls.Parameters
{
	public enum IdentityEvaluation
	{
		WindowsIdentity,
		OnlineUserIdentity
	}
}

namespace Nucleo.Web.DropDownControls
{
	public enum ComboListDropDownMode
	{
		ItemTemplate,
		Columns,
		Custom
	}
}

namespace Nucleo.Web.EditorControls
{
	/// <summary>
	/// Represents the current state of the editor, whether in normal mode or in error mode.
	/// </summary>
	public enum EditorCurrentState
	{
		Normal = 1,
		Error = 2
	}
}

namespace Nucleo.Web.ListControls
{
	public enum ListControlExtendedType
	{
		CheckboxList = 1,
		RadioButtonList = 2,
		DropDownList = 3,
		BulletedList = 4,
		ListBox = 5
	}

	public enum ListInterfaceType
	{
		CheckboxList = 0,
		RadioButtonList = 1,
		DropDownList = 2,
		BulletedList = 3,
		Custom = 4
	}
}

namespace Nucleo.Web.MathControls
{
	/// <summary>
	/// Represents the user interface of the calculator view.
	/// </summary>
	public enum CalculatorViewAppearance
	{
		Readonly,
		Editable,
		Custom
	}
}

namespace Nucleo.Web.Scripts
{
	public enum ScriptFramework
	{
		WebForms,
		Mvc,
		Mvp
	}
}

namespace Nucleo.Web.Searching
{
	public enum ControlSearcherDirection
	{
		Up
	}
}

namespace Nucleo.Web.TabularControls
{
	public enum StaticDetailsViewMode
	{
		ReadOnly,
		Edit,
		Insert
	}

	public enum StaticDetailsViewRowState
	{
		DataItem,
		AlternateItem,
		HeaderItem,
		FooterItem
	}
}

namespace Nucleo.Web.Tags
{
	public enum TagRenderingMode
	{
		Full,
		BeginTag,
		EndTag,
		Children
	}
}

namespace Nucleo.Web.Templates
{
	public enum ClientTemplateEvaluation
	{
		MSAjaxFormatString,
		Prototype
	}
}

namespace Nucleo.Web.Testing
{
	public enum TestScope
	{
		Client,
		Server,
		ClientAndServer
	}
}

namespace Nucleo.Web.ValidationControls
{
	/// <summary>
	/// Represents the type of validation message to display to the user.
	/// </summary>
	public enum MessageType
	{
		Error,
		Warning,
		Information
	}

	public enum NumericInputType
	{
		Any,
		WholeNumber,
		Decimal,
		Money,
		FahrenheitTemperature,
		CelciusTemperature
	}
}