function MouseOverPanel_ChangeVisibility(panelID, isVisible)
{
	var panel = document.getElementById(panelID);
	if (isVisible)
		panel.style.display = 'block';
	else
		panel.style.display = 'none';
}

function NumericTextBox_KeyPress(textbox, e, includeDecimal)
{
	var key;
	var keychar;

	if (window.event)
	   key = window.event.keyCode;
	else if (e)
	   key = e.which;
	else
	   return true;

	keychar = String.fromCharCode(key);

	// control keys
	if ((key==null) || (key==0) || (key==8) || 
		(key==9) || (key==13) || (key==27) )
	   return true;

	// numbers
	else if ((("0123456789").indexOf(keychar) > -1))
	   return true;
	  
	else if ((".").indexOf(keychar) > -1)
		return includeDecimal;

   return false;
}