(function () {
    "use strict";
    var module = angular.module("psCustomers");


  
    module.component("customerApp", {
        templateUrl: "/app/customer-app/customer-app.component.html",
        $routeConfig: [
		
            { path: '/', component: 'customerList', as: 'Home' },
    { path: '/about', component: 'customerAbout', as: 'About' },
    { path: '/list', component: 'customerList', as: 'List' },
    { path: '/**', component: 'customerList' }
          
        ]
    });
}());