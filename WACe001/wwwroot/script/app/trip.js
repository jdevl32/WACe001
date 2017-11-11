// /script/app/trip.js

// Exclude from global scope.
(
	function()
	{
		"use strict";

		// Configure routing.
		// Last modification:
		// Add trip edit route configuration.
		function configRoute($routeProvider)
		{
			$routeProvider
				// Trip route configuration.
				.when
					(
						"/"
						,
						{
							controller: "trip"
							,
							controllerAs: "vm"
							,
							templateUrl: "/view/trip.html"
						}
					)
				// Trip edit route configuration.
				.when
					(
						"/edit"
						,
						{
							controller: "tripEdit"
							,
							controllerAs: "vm"
							,
							templateUrl: "/view/trip.edit.html"
						}
					)
				// Default route configuration.
				.otherwise({redirectTo: "/"});
		}

		// Create the module.
		// Last modification:
		// Add dependency on routing.
		angular.module("app-trip", ["spinner", "ngRoute"]).config(configRoute);
	}
)();
