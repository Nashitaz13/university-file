<!--
function selectCode(id)
{
	var e = document.getElementById(id);
	if (window.getSelection) // Not IE
	{
		var s = window.getSelection();
		
		if (s.setBaseAndExtent) // Safari
		{
			s.setBaseAndExtent(e, 0, e, e.innerText.length - 1);
		}
		else // Firefox and Opera
		{
			var r = document.createRange();
			r.selectNodeContents(e);
			s.removeAllRanges();
			s.addRange(r);
		}
	}
	else if (document.getSelection) // Some older browsers
	{
		var s = document.getSelection();
		var r = document.createRange();
		r.selectNodeContents(e);
		s.removeAllRanges();
		s.addRange(r);
	}
	else if (document.selection) // IE
	{
		var r = document.body.createTextRange();
		r.moveToElementText(e);
		if(r.boundingWidth > 0 && r.boundingHeight > 0) r.select();
	}
}

function expandCode(id){
	var parent = document.getElementById(id);
	if (parent.style.display === 'block' || parent.style.display === '') {
		parent.style.display = 'none';
	} else {
		parent.style.display = 'block';
	}
}
//-->