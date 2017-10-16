(function () {
    'use strict';

    angular.module('app').service('loadAnimeService', ['$timeout', function ($timeout) {

        this.show = function () {

            //jQuery(".panel-body").css("display", "none");
            jQuery("#loader").show();
            jQuery("#myOverlay").addClass("loader-overlay").css("visibility", "visible").fadeIn(0, function () {
                jQuery("#loader").css("visibility", "visible").fadeIn(0);
            });
        }

        this.close = function () {         
            jQuery("#myOverlay").removeClass("loader-overlay").fadeOut(0, function () {
                jQuery("#loader").css("visibility", "hidden").fadeOut(0);
            });

        };


    }]);
})();