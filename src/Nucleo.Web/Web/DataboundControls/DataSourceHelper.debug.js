/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />

Type.registerNamespace("Nucleo.Web.DataboundControls");

Nucleo.Web.DataboundControls.DataSourceHelper = function() { throw Error.notImplemented(); }

Nucleo.Web.DataboundControls.DataSourceHelper.registerClass("Nucleo.Web.DataboundControls.DataSourceHelper");

Nucleo.Web.DataboundControls.DataSourceHelper.getDataSource = function(dataBoundControl) {
	Function._validateParams(arguments, [
		{ name: 'dataBoundControl', type: Nucleo.Web.DataboundControls.IDataSourceControl, mayBeNull: false, optional: false }
	]);

	if (dataBoundControl.get_dataSource() != null) {
		return dataBoundControl.get_dataSource();
	}
	else if (dataBoundControl.get_dataSourceManager() != null) {
		throw Error.notImplemented();
	}
	else
		return null;
}