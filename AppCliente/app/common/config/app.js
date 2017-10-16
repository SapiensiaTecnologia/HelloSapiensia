
// Define the `app` module
var app = angular.module('app', [
    'ngAnimate',
    'ngRoute',
    'ngResource', 
    'ngStorage',
    'angular-md5'  
    
]);

app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);