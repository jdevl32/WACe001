// /script/controller/trip.js

// Exclude from global scope.
(
	function()
	{
		"use strict";

		// Define the trip controller.
		// Last modification:
		// Rename.
		function controller($http)
		{
			var vm = this;
			vm.isBusy = true;
			vm.isDev = false;

			// Create empty container for error message.
			vm.errorMessage = "";

			// Create empty container for trip(s).
			vm.trip = [];

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

			// Create finally handler.
			var doFinally =
				function()
				{
					// Reset busy flag.
					vm.isBusy = false;
				};

			var url = "/api/trip";

			try
			{
				$http
					// Get the set of trips from the API...
					.get(url)
					// ...Using the defined handlers.
					.then(onGetSuccess, onGetError)
					.finally(doFinally);
			} // try
			catch (e)
			{
				vm.isBusy = false;
				vm.errorMessage = "Failed to get trips:  " + e;
			} // catch

			// Create empty container for new trip.
			vm.new = {};

			// Create success handler for POST.
			var onPostSuccess =
				function(response)
				{
					// Add new trip to the container.
					vm.trip.push(response.data);

					// Clear/reset new trip (form).
					vm.new = {};
				};

			// Create error handler for POST.
			var onPostError =
				function(error)
				{
					vm.errorMessage = "Failed to save trip:  " + error;
				};

			// Form submit handler.
			vm.onSubmit =
				function()
				{
					vm.isBusy = true;
					vm.errorMessage = "";

					$http
						// Post the new trip to the API...
						.post(url, vm.new)
						// ...Using the defined handlers.
						.then(onPostSuccess, onPostError)
						.finally(doFinally);
				};
		}

		// Use the existing module, specify controller.
		angular.module("app-trip").controller("trip", controller);
	}
)();
