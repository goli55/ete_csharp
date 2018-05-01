(function () {
    "use strict";
    var module = angular.module("psCustomers");

    
    function controller(customerListService) {
        
        var model = this;

        model.customers = [];

            model.$onInit = function () {
                customerListService.fetchCustomers()
                    .then(function (data) {
                        if (!data)
                            return;
                        model.customers = data;
                    },
                    function (err) {
                        console.log("fail to get customer list from server:" + err);
                    }
                );
            }
            model.message = "hello from component";
            model.changeMessage = function () {
                model.message = "new message";
            };
        
    }
    module.component("customerList", {
        templateUrl: "/app/customer-list/customer-list.component.html",
        controllerAs:"model",
        controller: ["customerList.service",
            
            controller]
    });
}());