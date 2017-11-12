// /script/controller/trip.edit.js

// Exclude from global scope.
(
	function()
	{
		"use strict";

		// Define the trip edit controller.
		// Last modification:
		function controller($routeParams)
		{
			var vm = this;
			vm.name = $routeParams.name;
			vm.isBusy = true;
			vm.isDev = false;

			// Create empty container for error message.
			vm.errorMessage = "";
			//vm.errorMessage = "[Error Message]";

			// Create empty container for stop(s).
			vm.stop = [];

			/**
			// Create empty container for new trip.
			vm.newTrip = {};

			// Create success handler for GET.
			var onGetSuccess =
				function(response)
				{
					// todo|jdevl32: make this global method...
					// todo|jdevl32: fix (is-dev not working) !!!
					if (vm.isDev)
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

					angular.copy(response.data, vm.trip);
				};

			// Create error handler for GET.
			var onGetError =
				function(error)
				{
					vm.errorMessage = "Failed to get trips:  " + error;
				};

			// Create success handler for POST.
			var onPostSuccess =
				function(response)
				{
					// Add new trip to the container.
					vm.trip.push(response.data);

					// Clear/reset new trip (form).
					vm.newTrip = {};
				};

			// Create error handler for POST.
			var onPostError =
				function(error)
				{
					vm.errorMessage = "Failed to save trip:  " + error;
				};

			// Create finally handler.
			var doFinally =
				function()
				{
					// Reset busy flag.
					vm.isBusy = false;
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
				vm.isBusy = false;
				vm.errorMessage = "Failed to get trips:  " + e;
			} // catch

			// Form submit handler.
			vm.AddTrip =
				function()
				{
					vm.isBusy = true;
					vm.errorMessage = "";

					// Post the new trip to the API, using the defined handlers.
					$http.post("/api/trip", vm.newTrip)
						.then(onPostSuccess, onPostError)
						.finally(doFinally);
				};
			**/
		}

		// Use the existing module, specify controller.
		angular.module("app-trip").controller("tripEdit", controller);
	}
)();
