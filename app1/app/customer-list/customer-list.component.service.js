(function () {
    "use strict";
    var module = angular.module("psCustomers");


    function controller($http, config,utils) {

        var _api = config.apiUrl,
            _fetchCustomers = function () {
                return utils.fetchData(_api + "customers")
                .then(function (response) {
                    if (!response)
                        return null;
                    if (!response.hasOwnProperty("data"))
                        return null;

                    return response.data;
                    }, function (err) {
               
                        console.log(err);
                    });
        };
        
        return {
            fetchCustomers: _fetchCustomers
        };

    }
    module.factory("customerList.service", [
        "$http",
        "appConfig",
        "utils.common.service",
        controller
    ]);
}());