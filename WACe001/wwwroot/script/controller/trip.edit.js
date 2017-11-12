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

			var url = "/api/trip/" + vm.name + "/stop";

			try
			{
				$http
					// Get the set of stops from the API...
					.get(url)
					// ...Using the defined handlers.
					.then(onGetSuccess, onGetError)
					.finally(doFinally);
			} // try
			catch (e)
			{
				vm.isBusy = false;
				vm.errorMessage = "Failed to get stops:  " + e;
			} // catch

			// Create empty container for new stop.
			vm.new = {};

			// Create success handler for POST.
			var onPostSuccess =
				function(response)
				{
					// Add new stop to the container.
					vm.stop.push(response.data);
					// todo|jdevl32: fix (travel-map is not working) !!!
					//_showMap(vm.stop);

					// Clear/reset new stop (form).
					vm.new = {};
				};

			// Create error handler for POST.
			var onPostError =
				function(error)
				{
					vm.errorMessage = "Failed to save stop:  " + error;
				};

			// Form submit handler.
			vm.onSubmit =
				function()
				{
					vm.isBusy = true;
					vm.errorMessage = "";

					$http
						// Post the new stop to the API...
						.post(url, vm.new)
						// ...Using the defined handlers.
						.then(onPostSuccess, onPostError)
						.finally(doFinally);
				};
		}

		// Use the existing module, specify controller.
		angular.module("app-trip").controller("tripEdit", controller);
	}
)();
