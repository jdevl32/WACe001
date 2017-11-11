// /script/controller/trip.js

// Exclude from global scope.
(
	function()
	{
		"use strict";

		// Define the trip controller.
		// Last modification:
		// Add the http service dependency.
		function trip($http)
		{
			var viewModel = this;

			viewModel.isBusy = true;
			viewModel.isDev = false;

			// Create empty container for error message.
			viewModel.errorMessage = "";

			// Create empty container for trip(s).
			viewModel.trip = [];

			// Create empty container for new trip.
			viewModel.newTrip = {};

			// Create success handler for GET.
			var onGetSuccess =
				function(response)
				{
					// todo|jdevl32: make this global method...
					// todo|jdevl32: fix (is-dev not working) !!!
					if (viewModel.isDev)
					{
						var x = "[response=";

						for (var p in response)
						{
							if (!response.hasOwnProperty(p))
							{
								continue;
							} // if

							if ("" !== x)
							{
								x += "\n";
							} // if

							x += "[response." + p + "=" + response[p] + "]";
						} // for

						x += "]";

						alert(x);
					} // if

					angular.copy(response.data, viewModel.trip);
				};

			// Create error handler for GET.
			var onGetError =
				function(error)
				{
					viewModel.errorMessage = "Failed to get trips:  " + error;
				};

			// Create success handler for POST.
			var onPostSuccess =
				function(response)
				{
					// Add new trip to the container.
					viewModel.trip.push(response.data);

					// Clear/reset new trip (form).
					viewModel.newTrip = {};
				};

			// Create error handler for POST.
			var onPostError =
				function(error)
				{
					viewModel.errorMessage = "Failed to save trip:  " + error;
				};

			// Create finally handler.
			var doFinally =
				function()
				{
					// Reset busy flag.
					viewModel.isBusy = false;
				};

			try
			{
				// Get the set of trips from the API, using the defined handlers.
				$http.get("/api/trip")
					.then(onGetSuccess, onGetError)
					.finally(doFinally);
			} // try
			catch (e)
			{
				viewModel.isBusy = false;
				viewModel.errorMessage = "Failed to get trips:  " + e;
			} // catch

			// Form submit handler.
			viewModel.AddTrip =
				function()
				{
					viewModel.isBusy = true;
					viewModel.errorMessage = "";

					// Post the new trip to the API, using the defined handlers.
					$http.post("/api/trip", viewModel.newTrip)
						.then(onPostSuccess, onPostError)
						.finally(doFinally);
				};
		}

		// Use the existing module, specify controller.
		angular.module("app-trip").controller("trip", trip);
	}
)();
