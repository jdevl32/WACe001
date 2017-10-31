// site.js

"use script";

(
	function ()
	{
		var $fullName = $("#fullName");

		if (!isNullOrUndefined($fullName) && !isNullOrUndefined($fullName.text))
		{
			$fullName.text("JavaScript Name");
		} // if

		var $main = $("#main");

		$main.on
			(
				"mouseenter"
				,
				function()
				{
					this.style.backgroundColor = "#aaa";
				}
			);

		$main.on
			(
				"mouseleave"
				,
				function()
				{
					this.style.backgroundColor = "";
				}
		);

		//var $menuLinks = $("ul#menu li a");

		//$menuLinks.on
		//	(
		//		"click"
		//		,
		//		function()
		//		{
		//			window.alert(($(this)).text());
		//		}
		//	);

		var $sidebarToggle = $("#sidebarToggle");
		var $toggle = $("#mainWrapper, #sidebar");

		$sidebarToggle.on
			(
				"click"
				,
				function()
				{
					var hideSidebar = "hide-sidebar";

					$toggle.toggleClass(hideSidebar);

					var $this = $(this);

					if ($toggle.hasClass(hideSidebar))
					{
						$this.text("Show Sidebar");
					} // if
					else
					{
						$this.text("Hide Sidebar");
					} // else
				}
			);
	}
)();
