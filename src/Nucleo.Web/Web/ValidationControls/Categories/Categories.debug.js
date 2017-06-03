/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

if (typeof (n$) === "undefined")
	n$ = {};

n$.CategoryDefinitions = (function () {
	return {
		get_error: function () {
			return { category: "Error", isFailingCategory: true };
		},

		get_information: function() {
			return { category: "Information", isFailingCategory: false };
		},

		get_warning: function() {
			return { category: "Warning", isFailingCategory: false };
		}
	};
})();