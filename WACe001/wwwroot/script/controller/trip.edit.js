// /script/controller/trip.edit.js

// Exclude from global scope.
(
	function()
	{
		"use strict";

		// Call plugin to create visual map (based on Google maps and using that API).
		// Last modification:
		function _showMap(items)
		{
			if (isNullOrUndefined(items))
			{
				return;
			} // if

			if (items.length > 0)
			{
				// Use underscore library for mapping.
				var map = _.map
					(
						// Collection of stops.
						items
						,
						// Map item (stop) to object expected for travel-map.
						function(item)
						{
							return {
								lat: item.coordinate.latitude
								,
								long: item.coordinate.longitude
								,
								info: item.name
							};
						}
					);

				travelMap.createMap
					(
						{
							stops: map
							,
							selector: "#map"
							,
							currentStop: 1
							,
							initialZoom: 3
						}
					);
			} // if
		}

		// Define the trip edit controller.
		// Last modification:
		// Implement travel map.
		function controller($routeParams, $http)
		{
			var vm = this;
			vm.name = $routeParams.name;
			vm.isBusy = true;
			vm.isDev = false;

			// Create empty container for error message.
			vm.errorMessage = "";

			// Create empty container for stop(s).
			vm.stop = [];

			// Create success handler for GET.
			var onGetSuccess =
				function (response)
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

					angular.copy(response.data, vm.stop);
					// todo|jdevl32: fix (travel-map is not working) !!!
					//_showMap(vm.stop);
				};

			// Create error handler for GET.
			var onGetError =
				function (error)
				{
					vm.errorMessage = "Failed to get stops:  " + error;
				};

			// Create finally handler.
			var doFinally =
				function ()
				{
					// Reset busy flag.
					vm.isBusy = false;
				};

			try
			{
				// Get the set of stops from the API, using the defined handlers.
				$http.get("/api/trip/" + vm.name + "/stop")
					.then(onGetSuccess, onGetError)
					.finally(doFinally);
			} // try
			catch (e)
			{
				vm.isBusy = false;
				vm.errorMessage = "Failed to get stops:  " + e;
			} // catch

			/**
			// Create empty container for new stop.
			vm.newStop = {};

			// Create success handler for POST.
			var onPostSuccess =
				function(response)
				{
					// Add new stop to the container.
					vm.stop.push(response.data);

					// Clear/reset new stop (form).
					vm.newStop = {};
				};

			// Create error handler for POST.
			var onPostError =
				function(error)
				{
					vm.errorMessage = "Failed to save stop:  " + error;
				};

			// Form submit handler.
			vm.AddTrip =
				function()
				{
					vm.isBusy = true;
					vm.errorMessage = "";

					// Post the new stop to the API, using the defined handlers.
					$http.post("/api/trip", vm.newStop)
						.then(onPostSuccess, onPostError)
						.finally(doFinally);
				};
			**/
		}

		// Use the existing module, specify controller.
		angular.module("app-trip").controller("tripEdit", controller);
	}
)();
