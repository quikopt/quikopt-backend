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