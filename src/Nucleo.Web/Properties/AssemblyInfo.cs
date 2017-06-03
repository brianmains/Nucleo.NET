﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Web.UI;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Nucleo.Web")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Nucleo.Web")]
[assembly: AssemblyCopyright("Copyright ©  2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("92b40158-1d39-4648-8637-ed284f1dec8b")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("0.1.0.0")]
[assembly: AssemblyFileVersion("0.1.0.0")]

[assembly:System.Web.UI.WebResource("controlscript.js", "text/js")]
[assembly:System.CLSCompliant(true)]

//*******************************************************************
//  Debug References
//*******************************************************************
[assembly: WebResource("Nucleo.Common.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Framework.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.ObjectUtilities.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.WebUtilities.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.CommonStyles.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("Nucleo.Web.BaseAjaxCompositeDataBoundControl.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.BaseAjaxControl.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.BaseAjaxExtender.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.BaseAjaxPanel.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.NucleoAjaxManager.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.PrototypeWebTemplate.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.WebTemplate.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.AccordionControls.Accordion.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.AccordionControls.AccordionItem.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ButtonControls.BaseButtonExtender.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ButtonControls.Button.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ButtonControls.ButtonEnabledExtender.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ButtonControls.ButtonList.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ButtonControls.ButtonVisibilityExtender.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ClientSettings.ListRowSettings.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ClientState.ClientStateData.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ContainerControls.Panel.debug.js", "type/javascript")]
[assembly: WebResource("Nucleo.Web.ContentControls.DragDropPanel.debug.js", "type/javascript")]
[assembly: WebResource("Nucleo.Web.ContentControls.BaseNavigationBarControl.debug.js", "type/javascript")]
[assembly: WebResource("Nucleo.Web.Controls.Check.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.Controls.HiddenField.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.Controls.HiddenFieldManager.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.Controls.Link.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.DataboundControls.DataSourceHelper.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.DropDownControls.ComboList.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.DropDownControls.ComboListItem.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.DropDownControls.ComboListTemplateItem.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.DropDownControls.ComboListWebTemplateItem.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.DropDownControls.DropDown.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.EditorControls.BaseEditorControl.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.EditorControls.TextEditor.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.HealthMonitoring.AjaxWebErrorEvent.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.HealthMonitoring.AjaxWebEvent.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.HealthMonitoring.AjaxWebMessageEvent.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.Inspectors.ModelBindingInspectors.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.Builders.ListControlBuilder.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ClientCheckboxList.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ContentList.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ListScripts.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ListControl.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ListControlExtender.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ListControlExtenderScripts.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ListItemWrapper.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ListScripts.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.PageableList.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.PageableListItem.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.MappingControls.ControlMappingExtender.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.MappingControls.ControlMappingManager.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.MappingControls.OperationNeededEventArgs.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.MathControls.CalculatedFieldExtender.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.MathControls.CalculatorExtender.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.MathControls.CalculatorView.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.NavigationControls.NavigationBar.debug.js", "type/javascript")]
[assembly: WebResource("Nucleo.Web.NavigationControls.NavigationBarContainer.debug.js", "type/javascript")]
[assembly: WebResource("Nucleo.Web.NavigationControls.NavigationBarItem.debug.js", "type/javascript")]
[assembly: WebResource("Nucleo.Web.Pages.BaseAjaxPage.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.Pages.Widgets.PageWidget.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.Repeating.RepeaterInfo.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.State.WebStateManager.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.TabularControls.TableExtender.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.TabularControls.TableScripts.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ValidationControls.ValidationResults.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ValidationControls.BaseValidator.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ValidationControls.RequiredValidator.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ValidationControls.ValidationManager.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ValidationControls.Categories.Categories.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ValidationControls.Items.DisplayItems.debug.js", "text/javascript")]

//*******************************************************************
//  Release References
//*******************************************************************
[assembly: WebResource("Nucleo.Common.js", "text/javascript")]
[assembly: WebResource("Nucleo.Framework.js", "text/javascript")]
[assembly: WebResource("Nucleo.ObjectUtilities.js", "text/javascript")]
[assembly: WebResource("Nucleo.WebUtilities.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.BaseAjaxCompositeDataBoundControl.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.BaseAjaxControl.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.BaseAjaxExtender.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.BaseAjaxPanel.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.NucleoAjaxManager.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.PrototypeWebTemplate.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.WebTemplate.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.AccordionControls.Accordion.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.AccordionControls.AccordionItem.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ButtonControls.BaseButtonExtender.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ButtonControls.Button.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ButtonControls.ButtonEnabledExtender.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ButtonControls.ButtonList.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ButtonControls.ButtonVisibilityExtender.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ClientSettings.ListRowSettings.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ClientState.ClientStateData.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ContainerControls.Panel.js", "type/javascript")]
[assembly: WebResource("Nucleo.Web.ContentControls.DragDropPanel.js", "type/javascript")]
[assembly: WebResource("Nucleo.Web.ContentControls.BaseNavigationBarControl.js", "type/javascript")]
[assembly: WebResource("Nucleo.Web.Controls.Check.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.Controls.HiddenField.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.Controls.HiddenFieldManager.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.Controls.Link.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.DataboundControls.DataSourceHelper.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.DropDownControls.ComboList.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.DropDownControls.ComboListItem.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.DropDownControls.ComboListTemplateItem.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.DropDownControls.ComboListWebTemplateItem.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.DropDownControls.DropDown.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.EditorControls.BaseEditorControl.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.EditorControls.TextEditor.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.HealthMonitoring.AjaxWebErrorEvent.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.HealthMonitoring.AjaxWebEvent.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.HealthMonitoring.AjaxWebMessageEvent.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.Inspectors.ModelBindingInspectors.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.Builders.ListControlBuilder.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ClientCheckboxList.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ContentList.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ListControl.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ListControlExtender.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ListControlExtenderScripts.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ListItemWrapper.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.ListScripts.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.PageableList.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ListControls.PageableListItem.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.MappingControls.ControlMappingExtender.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.MappingControls.ControlMappingManager.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.MappingControls.OperationNeededEventArgs.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.MathControls.CalculatedFieldExtender.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.MathControls.CalculatorExtender.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.MathControls.CalculatorView.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.NavigationControls.NavigationBar.js", "type/javascript")]
[assembly: WebResource("Nucleo.Web.NavigationControls.NavigationBarContainer.js", "type/javascript")]
[assembly: WebResource("Nucleo.Web.NavigationControls.NavigationBarItem.js", "type/javascript")]
[assembly: WebResource("Nucleo.Web.Pages.BaseAjaxPage.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.Pages.Widgets.PageWidget.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.Repeating.RepeaterInfo.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.TabularControls.TableExtender.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.TabularControls.TableScripts.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ValidationControls.ValidationResults.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ValidationControls.BaseValidator.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ValidationControls.RequiredValidator.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ValidationControls.ValidationManager.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ValidationControls.Categories.Categories.js", "text/javascript")]
[assembly: WebResource("Nucleo.Web.ValidationControls.Items.DisplayItems.js", "text/javascript")]


//Images
[assembly: WebResource("Nucleo.Web.Controls.checkempty.png", "images/png")]
[assembly: WebResource("Nucleo.Web.Controls.checkno.png", "images/png")]
[assembly: WebResource("Nucleo.Web.Controls.checknodisabled.png", "images/png")]
[assembly: WebResource("Nucleo.Web.Controls.checkyes.png", "images/png")]
[assembly: WebResource("Nucleo.Web.Controls.checkyesdisabled.png", "images/png")]
[assembly: WebResource("Nucleo.Web.DropDownControls.closemenu.png", "images/png")]
[assembly: WebResource("Nucleo.Web.DropDownControls.DropDownControlStyles.css", "text/css")]
[assembly: WebResource("Nucleo.Web.DropDownControls.DropDownStyles.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("Nucleo.Web.DropDownControls.selectordropdown.png", "images/png")]
[assembly: WebResource("Nucleo.Web.EditorControls.EditorControlStyles.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("Nucleo.Web.EditorControls.erroricon.png", "images/png")]
[assembly: WebResource("Nucleo.Web.ListControls.ListControls.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("Nucleo.Web.NavigationControls.NavigationBarStyles.css", "text/css")]
[assembly: WebResource("Nucleo.Web.ValidationControls.Validation.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("Nucleo.Web.ValidationControls.validationerror.png", "images/png")]
[assembly: WebResource("Nucleo.Web.ValidationControls.validationinfo.png", "images/png")]
[assembly: WebResource("Nucleo.Web.ValidationControls.validationwarning.png", "images/png")]
