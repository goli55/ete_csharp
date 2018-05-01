(function () {
    "use strict";
    var module = angular.module("psCustomers");


    function controller(customerListService) {

        var model = this;

       
        model.$onInit = function () {
           
        }
        model.message = "About Customers Manager App";
     
    }
    module.component("customerAbout", {
        templateUrl: "/app/customer-about/customer-about.component.html",
        controllerAs: "model",
        controller: [

            controller]
    });
}());