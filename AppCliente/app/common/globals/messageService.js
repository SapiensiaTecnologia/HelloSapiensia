/* Request $http RestFull GET PUT DELETE UPDATE*/
(function () {
    'use strict';

    angular.module('app').service('messageService', ['$timeout', function ($timeout) {

        /* The pattern for success is <p> in html with text-success from bootstrap */
        this.success = function (data) {
            BootstrapDialog.configDefaultOptions({
                cssClass: 'modal-message'
            });

            if (angular.isString(data)) {
                BootstrapDialog.show({
                    type: BootstrapDialog.TYPE_SUCCESS,
                    title: 'Success',
                    message: data,
                    closable: true, // <-- Default value is false
                    draggable: true, // <-- Default value is false
                    buttons: [{
                        label: 'Ok',
                        cssClass: 'btn-success',
                        action: function (dialogItself) {
                            dialogItself.close();
                        }
                    }]
                });
            }
            
        }


        this.confirm = function (data, resp) {
          
        }

        this.warning = function (data) {
            BootstrapDialog.configDefaultOptions({
                cssClass: 'modal-message'
            });
            if (angular.isString(data)) {
                BootstrapDialog.show({
                    type: BootstrapDialog.TYPE_WARNING,
                    title: 'Warning: ',
                    message: data

                });
            }
        }

        this.danger = function (data) {
            BootstrapDialog.configDefaultOptions({
                cssClass: 'modal-message'
            });
            if (angular.isString(data)) {
                BootstrapDialog.show({
                    type: BootstrapDialog.TYPE_DANGER,
                    title: 'Error: ',
                    message: data

                });
            }
        }


    }]);

})();