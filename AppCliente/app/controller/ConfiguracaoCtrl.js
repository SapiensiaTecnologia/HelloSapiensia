(function () {
    'use strict';

    app.controller('ConfiguracaoCtrl', ['$scope', '$injector', '$timeout', 'loadAnimeService', 'messageService', '$location', 'configuracaoService','perfilService',
        function ($scope, $injector, $timeout, loadAnimeService, messageService, $location, configuracaoService, perfilService) {

            var vm = this;

            function startVm() {

                //bag from Services which wil be bringing a list of objects from db
                vm.bagConfiguracao = [];
                vm.bagPerfils = [];
                vm.user = {};
                //vm.loadGrid = loadGrid;
                vm.goCadastro = goCadastro;
                vm.goConsulta = goConsulta;
                vm.tela = 'Consulta';
               
            }

            startVm();

            function getVm() {
                return vm;
            }


            vm.loadGrid = function () {
                loadAnimeService.show();
                configuracaoService.listAll(function (resp) {
                    if (resp !== null) {
                       
                        vm.tela = 'Consulta';
                        vm.bagConfiguracao = resp.data;
                        loadAnimeService.close();
                    }


                });

                perfilService.listAll(function (resp) {
                    if (resp.data !== null) {
                        console.info(resp);
                        vm.bagPerfils = resp.data;                      
                        loadAnimeService.close();
                    }

                });
               
               
            };

            function goCadastro() {
                loadAnimeService.show();
                vm.tela = 'Cadastro';
                vm.user = [];
                loadAnimeService.close();
            }

            function goConsulta() {
                vm.bagConfiguracao = null;
                vm.bagConfiguracao = [];
                loadAnimeService.show();
                vm.tela = 'Consulta';
                vm.loadGrid();
                loadAnimeService.close();
            }

           
            vm.goDeletar = function (codigo) {
                loadAnimeService.show();
                configuracaoService.delete(codigo, function (resp) {
                    if (resp !== null) {
                        vm.goConsulta();
                        messageService.success("Operação realizada com sucesso!");
                    }
                });
            };


            vm.goEditar = function (obj) {
                loadAnimeService.show();
                vm.tela = 'Cadastro';
                vm.user = obj;
                loadAnimeService.close();
            };

            vm.goSaveOrUpdate = function () {
                loadAnimeService.show();
                configuracaoService.goSaveOrUpdate(vm.user, function (resp) {
                    if (resp !== null) {
                        vm.loadGrid();
                        messageService.success("Operação realizada com sucesso!");
                        loadAnimeService.close();
                    }
                });

            };

            vm.getConfigConsumida = function (codigo) {
                configuracaoService.GetById(codigo, function (resp) {
                    if (resp !== null) {
                        console.log(resp);
                        vm.configConsumida = resp.data;
                    }
                });
            };


           
            vm.loadGrid();

        }]);
})();