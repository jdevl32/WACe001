// /script/directive/spinner.js

// Exclude from global scope.
(
	function()
	{
		"use strict";

		function spinner()
		{
			return {
				// Restrict to element only.
				restrict: "E"
				,
				scope:
					{
						while: "="
					}
				,
				// Include the contents (innter-html) of the element.
				transclude: true
				,
				templateUrl: "/directive/spinner.html"
			};
		}

		// Create the module.
		angular.module("spinner", []).directive("spinner", spinner);
	}
)();
