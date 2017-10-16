(function () {
    'use strict';

    app.controller('LoginCtrl', ['$scope', '$injector', '$timeout', 'loadAnimeService', 'messageService', '$location', 'authService',
        function ($scope, $injector, $timeout, loadAnimeService, messageService, $location, authService) {

            var vm = this;

            function startVm() {

                //bag from Services which wil be bringing a list of objects from db
                vm.bagPerfil = [];
                vm.user = {};
                vm.goLogado = goLogado;
                vm.tela = 'Consulta';
            }

            startVm();

            function getVm() {
                return vm;
            }


            vm.loadGrid = function () {
                loadAnimeService.show();
                vm.LoginError = '';
                loadAnimeService.close();
            }

            function goLogado() {
                loadAnimeService.show();
                vm.tela = 'Logado';
                vm.user = [];
                $location.path("/consumir");
                loadAnimeService.close();
            }


            vm.realizaLogin = function () {
                loadAnimeService.show();
                console.info(vm.usuario);
                authService.login(vm.usuario).then(function () {
                    console.log("executando authService");                   
                    vm.goLogado();
                }).catch(function (response) {
                    console.log("WebAPI access denied");
                    vm.LoginError = "Usuário ou senha inválidos.";
                    loadAnimeService.close();
                });

            }


            vm.loadGrid();

        }]);
})();