// /script/controller/trip.js

// Exclude from global scope.
(
	function()
	{
		"use strict";

		// Define the trip controller.
		function trip()
		{
			var viewModel = this;
			viewModel.trip =
				[
					{
						name: "Angular [A] Trip"
						,
						createTimestamp: new Date()
					}
					,
					{
						name: "Angular [B] Trip"
						,
						createTimestamp: new Date()
					}
				];

			// Create container for new trip.
			viewModel.newTrip = {};

			// Form submit handler.
			viewModel.AddTrip =
				function()
				{
					// todo|jdevl32: debug only...
					alert(viewModel.newTrip.name);
				};
		}

		// Use the existing module, specify controller.
		angular.module("app-trip").controller("trip", trip);
	}
)();
