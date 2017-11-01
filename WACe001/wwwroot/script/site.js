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

		var $toggle = $("#mainWrapper, #sidebar");
		var $angle = $("#sidebarToggle i.fa");

		$("#sidebarToggle").on
			(
				"click"
				,
				function()
				{
					var hideSidebar = "hide-sidebar";

					$toggle.toggleClass(hideSidebar);

					if ($toggle.hasClass(hideSidebar))
					{
						$angle.removeClass("fa-angle-left");
						$angle.addClass("fa-angle-right");
					} // if
					else
					{
						$angle.removeClass("fa-angle-right");
						$angle.addClass("fa-angle-left");
					} // else
				}
			);
	}
)();
