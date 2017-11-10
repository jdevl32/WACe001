// /script/controller/trip.js

// Exclude from global scope.
(
	function()
	{
		"use strict";

		function trip()
		{
			var viewModel = this;
			viewModel.name = "[Angular Controller Name]";
		}

		// Use the existing module, specify controller.
		angular.module("app-trip").controller("trip", trip);
	}
)();
