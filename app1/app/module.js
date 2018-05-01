(function () {
    "use strict";
    var module = angular.module("psCustomers", ["ngComponentRouter"]);

    module.value("$routerRootComponent", "customerApp");

    module.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.defaults.withCredentials = true;
    }]);
    module.value("appConfig", {
        apiUrl:'http://localhost:9000/api/'
    });
} ());