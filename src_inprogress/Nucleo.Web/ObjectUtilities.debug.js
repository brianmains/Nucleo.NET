/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Text");

Nucleo.Text.StringUtility = function() {
	Nucleo.Text.StringUtility.initializeBase(this);
}
Nucleo.Text.StringUtility.registerClass("Nucleo.Text.StringUtility");

Nucleo.Text.StringUtility.isNullOrEmpty = function(value) {
	return (value != null && value != undefined && value.length > 0);
}

Nucleo.Text.StringUtility.concatenate = function(concatValues) {
	var text = "";

	for (var index = 0; index < concatValues.length; index++) {
		if (concatValues[index] instanceof String)
			text += concatValues[index];
		else
			text += (concatValues[index]) ? concatValues[index].toString() : "";
	}

	return text;
}

String.concatenate = function(concatValues) {
	return Nucleo.Text.StringUtility.concatenate(concatValues);
}

Nucleo.Text.StringUtility.SubstringCount = function(text, searchText) {
	if (text == null || text == "" || searchText == null || searchText == "")
		return 0;
	
	var splitChars = text.split(searchText);
	return splitChars.length - 1;
}

String.prototype.substringCount = function String$substringCount(searchText) {
	return Nucleo.Text.StringUtility.SubstringCount(this, searchText);
}

Nucleo.Text.StringUtility.stripChars = function(text, strip, charList) {
	if (text == null || text == "" || charList == null || charList == "" || strip == null || strip == "")
		return "";
	
	var outStr = "";
	var i;
	var j;
	var nextChar;
	var keepChar;
	for (i = 0; i < text.length; i++) {
		nextChar = text.substr(i, 1);
		if (!strip)
			keepChar = false;
		else
			keepChar = true;

		for (j = 0; j < charList.length; j++) {
			checkChar = charList.substr(j, 1);
			if (!strip && nextChar == checkChar) {
				keepChar = true;
			}
			if (strip && nextChar == checkChar) {
				keepChar = false;
			}
		}
		if (keepChar == true) {
			outStr = outStr + nextChar;
		}
	}
	
	return outStr;
}

String.prototype.stripChars = function String$stripChars(strip, charList) {
	return Nucleo.Text.StringUtility.stripChars(this, strip, charList);
}

Nucleo.Text.StringUtility.replace = function(text, oldText, newText) {
	if (text == null || text == "" || oldText == null || oldText == "" || newText == null || newText == "")
		return "";
		
	while (text.indexOf(oldText) > -1)
		text = text.replace(oldText, newText);
	return text;
}

String.prototype.replace = function String$replace(oldText, newText) {
	return Nucleo.Text.StringUtility.replace(oldText, newText);
}

Date.prototype.getDaysInMonth = function(month, year) {
	var leap_year = this.isLeapYear(year) ? 1 : 0;

	if (month == 4 || month == 6 || month == 9 || month == 11)
		return 30;
	else if (month == 2)
		return 28 + leap_year;
	else
		return 31;
}

Date.prototype.isLeapYear = function(year) {
	return ((year % 4 == 0 && !(year % 100 == 0)) || year % 400 == 0);
}

Array.prototype.average = function() {
  var accumulator = 0;
  //Ensure no divide by zero issues
  if (this.length == 0)
	return 0;
  
  for (var i = 0; i < this.length; i++)
    accumulator += this[i];

  return accumulator / this.length;
}

Array.prototype.max = function() {
	var max = null;
	//Ensure no divide by zero issues
	if (this.length == 0)
		return null;

	for (var i = 0; i < this.length; i++) {
		if (!max || max < this[i])
			max = this[i];
	}

	return max;
}

Array.prototype.min = function() {
	var min = null;
	//Ensure no divide by zero issues
	if (this.length == 0)
		return null;

	for (var i = 0; i < this.length; i++) {
		if (!min || min > this[i])
			min = this[i];
	}

	return min;
}