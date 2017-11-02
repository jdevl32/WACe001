// site.js

"use script";

(
	function ()
	{
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
