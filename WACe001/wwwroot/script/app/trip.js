// /script/app/trip.js

// Exclude from global scope.
(
	function()
	{
		"use strict";

		// Configure routing.
		function configRoute($routeProvider)
		{
			$routeProvider.when
				(
					"/"
					,
					{
						controller: "trip"
						,
						controllerAs: "vm"
						,
						templateUrl: "/view/trips.html"
					}
				);
		}

		// Create the module.
		// Last modification:
		// Add dependency on routing.
		angular.module("app-trip", ["spinner", "ngRoute"]).config(configRoute);
	}
)();
