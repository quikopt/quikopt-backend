
var app = angular.module('QuikOptApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeLoginController",
        templateUrl: "/app/views/homelogin.html"
    });

    $routeProvider.when("/login", {
        controller: "homeLoginController",
        templateUrl: "/app/views/homelogin.html"
    });

    $routeProvider.when("/signup", {
        controller: "homeLoginController",
        templateUrl: "/app/views/homesignup.html"
    });

    $routeProvider.when("/orders", {
        controller: "ordersController",
        templateUrl: "/app/views/orders.html"
    });

    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "/app/views/refresh.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/app/views/tokens.html"
    });

    $routeProvider.when("/associate", {
        controller: "associateController",
        templateUrl: "/app/views/associate.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

});

//var serviceBase = 'http://localhost:26264';
///var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';
var serviceBase = 'http://localhost:26264/';///Location.host;

app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


