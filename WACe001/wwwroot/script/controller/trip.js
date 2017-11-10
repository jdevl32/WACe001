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

			// Create empty container for trip(s).
			viewModel.trip = [];

			// Create empty container for new trip.
			viewModel.newTrip = {};

			// Form submit handler.
			viewModel.AddTrip =
				function()
				{
					// Add new trip to the container.
					viewModel.trip.push
						(
							{
								name: viewModel.newTrip.name
								,
								createTimestamp: new Date()
							}
						);

					// Clear/reset new trip (form).
					viewModel.newTrip = {};
				};
		}

		// Use the existing module, specify controller.
		angular.module("app-trip").controller("trip", trip);
	}
)();
