/* Request $http RestFull GET PUT DELETE UPDATE*/
(function () {
    'use strict';

    // Request service
    angular.module('app').service('locationhostService', ['$http',
        function ($http) {

            //Local Application
            this.apiBase = 'http://localhost:59806/';
    
        }])

})();