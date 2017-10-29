// site.js

function doLoad()
{
	var fullName = document.getElementById("fullName");

	if (!isNullOrUndefined(fullName) && !isNullOrUndefined(fullName.innerHTML))
	{
		fullName.innerHTML = "JavaScript Name";
	} // if

	var main = document.getElementById("main");

	main.onmouseenter =
		function()
		{
			this.style.backgroundColor = "#aaa";
		};

	main.onmouseleave =
		function()
		{
			this.style.backgroundColor = "";
		};
}

doLoad();
