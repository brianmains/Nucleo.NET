Type.registerNamespace("Sys.Mvc");Sys.Mvc.$create_Validation=function Sys_Mvc_Validation(){return{}};Sys.Mvc.$create_JsonValidationField=function Sys_Mvc_JsonValidationField(){return{}};Sys.Mvc.$create_JsonValidationOptions=function Sys_Mvc_JsonValidationOptions(){return{}};Sys.Mvc.$create_JsonValidationRule=function Sys_Mvc_JsonValidationRule(){return{}};Sys.Mvc.$create_ValidationContext=function Sys_Mvc_ValidationContext(){return{}};Sys.Mvc.NumberValidator=function Sys_Mvc_NumberValidator(){};Sys.Mvc.NumberValidator.create=function Sys_Mvc_NumberValidator$create(a){return Function.createDelegate(new Sys.Mvc.NumberValidator(),new Sys.Mvc.NumberValidator().validate)};Sys.Mvc.NumberValidator.prototype={validate:function Sys_Mvc_NumberValidator$validate(a,b){if(Sys.Mvc._validationUtil.stringIsNullOrEmpty(a)){return true}var c=Number.parseLocale(a);return(!isNaN(c))}};Sys.Mvc.FormContext=function Sys_Mvc_FormContext(a,c){this._errors=[];this.fields=new Array(0);this._formElement=a;this._validationSummaryElement=c;a[Sys.Mvc.FormContext._formValidationTag]=this;if(c){var b=c.getElementsByTagName("ul");if(b.length>0){this._validationSummaryULElement=b[0]}}this._onClickHandler=Function.createDelegate(this,this._form_OnClick);this._onSubmitHandler=Function.createDelegate(this,this._form_OnSubmit)};Sys.Mvc.FormContext._Application_Load=function Sys_Mvc_FormContext$_Application_Load(){var a=window.mvcClientValidationMetadata;if(a){while(a.length>0){var b=a.pop();Sys.Mvc.FormContext._parseJsonOptions(b)}}};Sys.Mvc.FormContext._getFormElementsWithName=function Sys_Mvc_FormContext$_getFormElementsWithName(a,b){var d=[];var f=document.getElementsByName(b);for(var e=0;e<f.length;e++){var c=f[e];if(Sys.Mvc.FormContext._isElementInHierarchy(a,c)){Array.add(d,c)}}return d};Sys.Mvc.FormContext.getValidationForForm=function Sys_Mvc_FormContext$getValidationForForm(a){return a[Sys.Mvc.FormContext._formValidationTag]};Sys.Mvc.FormContext._isElementInHierarchy=function Sys_Mvc_FormContext$_isElementInHierarchy(a,b){while(b){if(a===b){return true}b=b.parentNode}return false};Sys.Mvc.FormContext._parseJsonOptions=function Sys_Mvc_FormContext$_parseJsonOptions(a){var f=$get(a.FormId);var b=(!Sys.Mvc._validationUtil.stringIsNullOrEmpty(a.ValidationSummaryId))?$get(a.ValidationSummaryId):null;var o=new Sys.Mvc.FormContext(f,b);o.enableDynamicValidation();o.replaceValidationSummary=a.ReplaceValidationSummary;for(var m=0;m<a.Fields.length;m++){var h=a.Fields[m];var l=Sys.Mvc.FormContext._getFormElementsWithName(f,h.FieldName);var n=(!Sys.Mvc._validationUtil.stringIsNullOrEmpty(h.ValidationMessageId))?$get(h.ValidationMessageId):null;var e=new Sys.Mvc.FieldContext(o);Array.addRange(e.elements,l);e.validationMessageElement=n;e.replaceValidationMessageContents=h.ReplaceValidationMessageContents;for(var k=0;k<h.ValidationRules.length;k++){var c=h.ValidationRules[k];var p=Sys.Mvc.ValidatorRegistry.getValidator(c);if(p){var d=Sys.Mvc.$create_Validation();d.fieldErrorMessage=c.ErrorMessage;d.validator=p;Array.add(e.validations,d)}}e.enableDynamicValidation();Array.add(o.fields,e)}var g=f.validationCallbacks;if(!g){g=[];f.validationCallbacks=g}g.push(Function.createDelegate(null,function(){return Sys.Mvc._validationUtil.arrayIsNullOrEmpty(o.validate("submit"))}));return o};Sys.Mvc.FormContext.prototype={_onClickHandler:null,_onSubmitHandler:null,_submitButtonClicked:null,_validationSummaryElement:null,_validationSummaryULElement:null,_formElement:null,replaceValidationSummary:false,addError:function Sys_Mvc_FormContext$addError(a){this.addErrors([a])},addErrors:function Sys_Mvc_FormContext$addErrors(a){if(!Sys.Mvc._validationUtil.arrayIsNullOrEmpty(a)){Array.addRange(this._errors,a);this._onErrorCountChanged()}},clearErrors:function Sys_Mvc_FormContext$clearErrors(){Array.clear(this._errors);this._onErrorCountChanged()},_displayError:function Sys_Mvc_FormContext$_displayError(){if(this._validationSummaryElement){if(this._validationSummaryULElement){Sys.Mvc._validationUtil.removeAllChildren(this._validationSummaryULElement);for(var b=0;b<this._errors.length;b++){var a=document.createElement("li");Sys.Mvc._validationUtil.setInnerText(a,this._errors[b]);this._validationSummaryULElement.appendChild(a)}}Sys.UI.DomElement.removeCssClass(this._validationSummaryElement,Sys.Mvc.FormContext._validationSummaryValidCss);Sys.UI.DomElement.addCssClass(this._validationSummaryElement,Sys.Mvc.FormContext._validationSummaryErrorCss)}},_displaySuccess:function Sys_Mvc_FormContext$_displaySuccess(){var b=this._validationSummaryElement;if(b){var a=this._validationSummaryULElement;if(a){a.innerHTML=""}Sys.UI.DomElement.removeCssClass(b,Sys.Mvc.FormContext._validationSummaryErrorCss);Sys.UI.DomElement.addCssClass(b,Sys.Mvc.FormContext._validationSummaryValidCss)}},enableDynamicValidation:function Sys_Mvc_FormContext$enableDynamicValidation(){Sys.UI.DomEvent.addHandler(this._formElement,"click",this._onClickHandler);Sys.UI.DomEvent.addHandler(this._formElement,"submit",this._onSubmitHandler)},_findSubmitButton:function Sys_Mvc_FormContext$_findSubmitButton(c){if(c.disabled){return null}var d=c.tagName.toUpperCase();var b=c;if(d==="INPUT"){var a=b.type;if(a==="submit"||a==="image"){return b}}else{if((d==="BUTTON")&&(b.type==="submit")){return b}}return null},_form_OnClick:function Sys_Mvc_FormContext$_form_OnClick(a){this._submitButtonClicked=this._findSubmitButton(a.target)},_form_OnSubmit:function Sys_Mvc_FormContext$_form_OnSubmit(d){var b=d.target;var c=this._submitButtonClicked;if(c&&c.disableValidation){return}var a=this.validate("submit");if(!Sys.Mvc._validationUtil.arrayIsNullOrEmpty(a)){d.preventDefault()}},_onErrorCountChanged:function Sys_Mvc_FormContext$_onErrorCountChanged(){if(!this._errors.length){this._displaySuccess()}else{this._displayError()}},validate:function Sys_Mvc_FormContext$validate(e){var c=this.fields;var f=[];for(var d=0;d<c.length;d++){var a=c[d];var b=a.validate(e);if(b){Array.addRange(f,b)}}if(this.replaceValidationSummary){this.clearErrors();this.addErrors(f)}return f}};Sys.Mvc.FieldContext=function Sys_Mvc_FieldContext(a){this._errors=[];this.elements=new Array(0);this.validations=new Array(0);this.formContext=a;this._onBlurHandler=Function.createDelegate(this,this._element_OnBlur);this._onChangeHandler=Function.createDelegate(this,this._element_OnChange);this._onInputHandler=Function.createDelegate(this,this._element_OnInput);this._onPropertyChangeHandler=Function.createDelegate(this,this._element_OnPropertyChange)};Sys.Mvc.FieldContext.prototype={_onBlurHandler:null,_onChangeHandler:null,_onInputHandler:null,_onPropertyChangeHandler:null,defaultErrorMessage:null,formContext:null,replaceValidationMessageContents:false,validationMessageElement:null,addError:function Sys_Mvc_FieldContext$addError(a){this.addErrors([a])},addErrors:function Sys_Mvc_FieldContext$addErrors(a){if(!Sys.Mvc._validationUtil.arrayIsNullOrEmpty(a)){Array.addRange(this._errors,a);this._onErrorCountChanged()}},clearErrors:function Sys_Mvc_FieldContext$clearErrors(){Array.clear(this._errors);this._onErrorCountChanged()},_displayError:function Sys_Mvc_FieldContext$_displayError(){var a=this.validationMessageElement;if(a){if(this.replaceValidationMessageContents){Sys.Mvc._validationUtil.setInnerText(a,this._errors[0])}Sys.UI.DomElement.removeCssClass(a,Sys.Mvc.FieldContext._validationMessageValidCss);Sys.UI.DomElement.addCssClass(a,Sys.Mvc.FieldContext._validationMessageErrorCss)}var b=this.elements;for(var c=0;c<b.length;c++){var d=b[c];Sys.UI.DomElement.removeCssClass(d,Sys.Mvc.FieldContext._inputElementValidCss);Sys.UI.DomElement.addCssClass(d,Sys.Mvc.FieldContext._inputElementErrorCss)}},_displaySuccess:function Sys_Mvc_FieldContext$_displaySuccess(){var a=this.validationMessageElement;if(a){if(this.replaceValidationMessageContents){Sys.Mvc._validationUtil.setInnerText(a,"")}Sys.UI.DomElement.removeCssClass(a,Sys.Mvc.FieldContext._validationMessageErrorCss);Sys.UI.DomElement.addCssClass(a,Sys.Mvc.FieldContext._validationMessageValidCss)}var b=this.elements;for(var c=0;c<b.length;c++){var d=b[c];Sys.UI.DomElement.removeCssClass(d,Sys.Mvc.FieldContext._inputElementErrorCss);Sys.UI.DomElement.addCssClass(d,Sys.Mvc.FieldContext._inputElementValidCss)}},_element_OnBlur:function Sys_Mvc_FieldContext$_element_OnBlur(a){if(a.target[Sys.Mvc.FieldContext._hasTextChangedTag]||a.target[Sys.Mvc.FieldContext._hasValidationFiredTag]){this.validate("blur")}},_element_OnChange:function Sys_Mvc_FieldContext$_element_OnChange(a){a.target[Sys.Mvc.FieldContext._hasTextChangedTag]=true},_element_OnInput:function Sys_Mvc_FieldContext$_element_OnInput(a){a.target[Sys.Mvc.FieldContext._hasTextChangedTag]=true;if(a.target[Sys.Mvc.FieldContext._hasValidationFiredTag]){this.validate("input")}},_element_OnPropertyChange:function Sys_Mvc_FieldContext$_element_OnPropertyChange(a){if(a.rawEvent.propertyName==="value"){a.target[Sys.Mvc.FieldContext._hasTextChangedTag]=true;if(a.target[Sys.Mvc.FieldContext._hasValidationFiredTag]){this.validate("input")}}},enableDynamicValidation:function Sys_Mvc_FieldContext$enableDynamicValidation(){var b=this.elements;for(var c=0;c<b.length;c++){var d=b[c];if(Sys.Mvc._validationUtil.elementSupportsEvent(d,"onpropertychange")){var a=document.documentMode;if(a&&a>=8){Sys.UI.DomEvent.addHandler(d,"propertychange",this._onPropertyChangeHandler)}}else{Sys.UI.DomEvent.addHandler(d,"input",this._onInputHandler)}Sys.UI.DomEvent.addHandler(d,"change",this._onChangeHandler);Sys.UI.DomEvent.addHandler(d,"blur",this._onBlurHandler)}},_getErrorString:function Sys_Mvc_FieldContext$_getErrorString(a,b){var c=b||this.defaultErrorMessage;if(Boolean.isInstanceOfType(a)){return(a)?null:c}if(String.isInstanceOfType(a)){return((a).length)?a:c}return null},_getStringValue:function Sys_Mvc_FieldContext$_getStringValue(){var a=this.elements;return(a.length>0)?a[0].value:null},_markValidationFired:function Sys_Mvc_FieldContext$_markValidationFired(){var a=this.elements;for(var b=0;b<a.length;b++){var c=a[b];c[Sys.Mvc.FieldContext._hasValidationFiredTag]=true}},_onErrorCountChanged:function Sys_Mvc_FieldContext$_onErrorCountChanged(){if(!this._errors.length){this._displaySuccess()}else{this._displayError()}},validate:function Sys_Mvc_FieldContext$validate(a){var j=this.validations;var d=[];var c=this._getStringValue();for(var f=0;f<j.length;f++){var b=j[f];var g=Sys.Mvc.$create_ValidationContext();g.eventName=a;g.fieldContext=this;g.validation=b;var h=b.validator(c,g);var e=this._getErrorString(h,b.fieldErrorMessage);if(!Sys.Mvc._validationUtil.stringIsNullOrEmpty(e)){Array.add(d,e)}}this._markValidationFired();this.clearErrors();this.addErrors(d);return d}};Sys.Mvc.RangeValidator=function Sys_Mvc_RangeValidator(b,a){this._minimum=b;this._maximum=a};Sys.Mvc.RangeValidator.create=function Sys_Mvc_RangeValidator$create(c){var a=c.ValidationParameters.minimum;var b=c.ValidationParameters.maximum;return Function.createDelegate(new Sys.Mvc.RangeValidator(a,b),new Sys.Mvc.RangeValidator(a,b).validate)};Sys.Mvc.RangeValidator.prototype={_minimum:null,_maximum:null,validate:function Sys_Mvc_RangeValidator$validate(a,b){if(Sys.Mvc._validationUtil.stringIsNullOrEmpty(a)){return true}var c=Number.parseLocale(a);return(!isNaN(c)&&this._minimum<=c&&c<=this._maximum)}};Sys.Mvc.RegularExpressionValidator=function Sys_Mvc_RegularExpressionValidator(a){this._pattern=a};Sys.Mvc.RegularExpressionValidator.create=function Sys_Mvc_RegularExpressionValidator$create(b){var a=b.ValidationParameters.pattern;return Function.createDelegate(new Sys.Mvc.RegularExpressionValidator(a),new Sys.Mvc.RegularExpressionValidator(a).validate)};Sys.Mvc.RegularExpressionValidator.prototype={_pattern:null,validate:function Sys_Mvc_RegularExpressionValidator$validate(a,c){if(Sys.Mvc._validationUtil.stringIsNullOrEmpty(a)){return true}var b=new RegExp(this._pattern);var d=b.exec(a);return(!Sys.Mvc._validationUtil.arrayIsNullOrEmpty(d)&&d[0].length===a.length)}};Sys.Mvc.RequiredValidator=function Sys_Mvc_RequiredValidator(){};Sys.Mvc.RequiredValidator.create=function Sys_Mvc_RequiredValidator$create(a){return Function.createDelegate(new Sys.Mvc.RequiredValidator(),new Sys.Mvc.RequiredValidator().validate)};Sys.Mvc.RequiredValidator._isRadioInputElement=function Sys_Mvc_RequiredValidator$_isRadioInputElement(a){if(a.tagName.toUpperCase()==="INPUT"){var b=(a.type).toUpperCase();if(b==="RADIO"){return true}}return false};Sys.Mvc.RequiredValidator._isSelectInputElement=function Sys_Mvc_RequiredValidator$_isSelectInputElement(a){if(a.tagName.toUpperCase()==="SELECT"){return true}return false};Sys.Mvc.RequiredValidator._isTextualInputElement=function Sys_Mvc_RequiredValidator$_isTextualInputElement(a){if(a.tagName.toUpperCase()==="INPUT"){var b=(a.type).toUpperCase();switch(b){case"TEXT":case"PASSWORD":case"FILE":return true}}if(a.tagName.toUpperCase()==="TEXTAREA"){return true}return false};Sys.Mvc.RequiredValidator._validateRadioInput=function Sys_Mvc_RequiredValidator$_validateRadioInput(a){for(var b=0;b<a.length;b++){var c=a[b];if(c.checked){return true}}return false};Sys.Mvc.RequiredValidator._validateSelectInput=function Sys_Mvc_RequiredValidator$_validateSelectInput(a){for(var b=0;b<a.length;b++){var c=a[b];if(c.selected){if(!Sys.Mvc._validationUtil.stringIsNullOrEmpty(c.value)){return true}}}return false};Sys.Mvc.RequiredValidator._validateTextualInput=function Sys_Mvc_RequiredValidator$_validateTextualInput(a){return(!Sys.Mvc._validationUtil.stringIsNullOrEmpty(a.value))};Sys.Mvc.RequiredValidator.prototype={validate:function Sys_Mvc_RequiredValidator$validate(b,c){var a=c.fieldContext.elements;if(!a.length){return true}var d=a[0];if(Sys.Mvc.RequiredValidator._isTextualInputElement(d)){return Sys.Mvc.RequiredValidator._validateTextualInput(d)}if(Sys.Mvc.RequiredValidator._isRadioInputElement(d)){return Sys.Mvc.RequiredValidator._validateRadioInput(a)}if(Sys.Mvc.RequiredValidator._isSelectInputElement(d)){return Sys.Mvc.RequiredValidator._validateSelectInput((d).options)}return true}};Sys.Mvc.StringLengthValidator=function Sys_Mvc_StringLengthValidator(a,b){this._minLength=a;this._maxLength=b};Sys.Mvc.StringLengthValidator.create=function Sys_Mvc_StringLengthValidator$create(c){var a=c.ValidationParameters.minimumLength;var b=c.ValidationParameters.maximumLength;return Function.createDelegate(new Sys.Mvc.StringLengthValidator(a,b),new Sys.Mvc.StringLengthValidator(a,b).validate)};Sys.Mvc.StringLengthValidator.prototype={_maxLength:0,_minLength:0,validate:function Sys_Mvc_StringLengthValidator$validate(a,b){if(Sys.Mvc._validationUtil.stringIsNullOrEmpty(a)){return true}return(this._minLength<=a.length&&a.length<=this._maxLength)}};Sys.Mvc._validationUtil=function Sys_Mvc__validationUtil(){};Sys.Mvc._validationUtil.arrayIsNullOrEmpty=function Sys_Mvc__validationUtil$arrayIsNullOrEmpty(a){return(!a||!a.length)};Sys.Mvc._validationUtil.stringIsNullOrEmpty=function Sys_Mvc__validationUtil$stringIsNullOrEmpty(a){return(!a||!a.length)};Sys.Mvc._validationUtil.elementSupportsEvent=function Sys_Mvc__validationUtil$elementSupportsEvent(b,a){return(a in b)};Sys.Mvc._validationUtil.removeAllChildren=function Sys_Mvc__validationUtil$removeAllChildren(a){while(a.firstChild){a.removeChild(a.firstChild)}};Sys.Mvc._validationUtil.setInnerText=function Sys_Mvc__validationUtil$setInnerText(b,a){var c=document.createTextNode(a);Sys.Mvc._validationUtil.removeAllChildren(b);b.appendChild(c)};Sys.Mvc.ValidatorRegistry=function Sys_Mvc_ValidatorRegistry(){};Sys.Mvc.ValidatorRegistry.getValidator=function Sys_Mvc_ValidatorRegistry$getValidator(b){var a=Sys.Mvc.ValidatorRegistry.validators[b.ValidationType];return(a)?a(b):null};Sys.Mvc.ValidatorRegistry._getDefaultValidators=function Sys_Mvc_ValidatorRegistry$_getDefaultValidators(){return{required:Function.createDelegate(null,Sys.Mvc.RequiredValidator.create),stringLength:Function.createDelegate(null,Sys.Mvc.StringLengthValidator.create),regularExpression:Function.createDelegate(null,Sys.Mvc.RegularExpressionValidator.create),range:Function.createDelegate(null,Sys.Mvc.RangeValidator.create),number:Function.createDelegate(null,Sys.Mvc.NumberValidator.create)}};Sys.Mvc.NumberValidator.registerClass("Sys.Mvc.NumberValidator");Sys.Mvc.FormContext.registerClass("Sys.Mvc.FormContext");Sys.Mvc.FieldContext.registerClass("Sys.Mvc.FieldContext");Sys.Mvc.RangeValidator.registerClass("Sys.Mvc.RangeValidator");Sys.Mvc.RegularExpressionValidator.registerClass("Sys.Mvc.RegularExpressionValidator");Sys.Mvc.RequiredValidator.registerClass("Sys.Mvc.RequiredValidator");Sys.Mvc.StringLengthValidator.registerClass("Sys.Mvc.StringLengthValidator");Sys.Mvc._validationUtil.registerClass("Sys.Mvc._validationUtil");Sys.Mvc.ValidatorRegistry.registerClass("Sys.Mvc.ValidatorRegistry");Sys.Mvc.FormContext._validationSummaryErrorCss="validation-summary-errors";Sys.Mvc.FormContext._validationSummaryValidCss="validation-summary-valid";Sys.Mvc.FormContext._formValidationTag="__MVC_FormValidation";Sys.Mvc.FieldContext._hasTextChangedTag="__MVC_HasTextChanged";Sys.Mvc.FieldContext._hasValidationFiredTag="__MVC_HasValidationFired";Sys.Mvc.FieldContext._inputElementErrorCss="input-validation-error";Sys.Mvc.FieldContext._inputElementValidCss="input-validation-valid";Sys.Mvc.FieldContext._validationMessageErrorCss="field-validation-error";Sys.Mvc.FieldContext._validationMessageValidCss="field-validation-valid";Sys.Mvc.ValidatorRegistry.validators=Sys.Mvc.ValidatorRegistry._getDefaultValidators();Sys.Application.add_load(function(){Sys.Application.remove_load(arguments.callee);Sys.Mvc.FormContext._Application_Load()});