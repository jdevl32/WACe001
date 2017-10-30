// site.js

"use script";

(
	function ()
	{
		var fullName = $("#fullName");

		if (!isNullOrUndefined(fullName) && !isNullOrUndefined(fullName.text))
		{
			fullName.text("JavaScript Name");
		} // if

		var main = $("#main");

		main.on
			(
				"mouseenter"
				,
				function()
				{
					this.style.backgroundColor = "#aaa";
				}
			);

		main.on
			(
				"mouseleave"
				,
				function()
				{
					this.style.backgroundColor = "";
				}
			);
	}
)();
