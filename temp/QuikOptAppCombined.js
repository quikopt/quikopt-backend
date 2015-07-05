//QuikOptApp.js Archivo principal de la app

(function () {
    "use strict";

    var app = angular.module("app", ["ngRoute", "kendo.directives"]);

    app.config([
        "$routeProvider", function ($routeProvider) {
            $routeProvider
           .when('/', { templateUrl: '/App/Home/index.html', controller: 'homeController' })
           .otherwise({ redirectTo: "/" });
        }
    ]);
})();
(function () {
    'use strict';

    angular
        .module('app')
        .controller('homeController', homeController);

    homeController.$inject = ['$location']; 

    function homeController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'homeController';

        activate();

        function activate() { }
    }
})();
