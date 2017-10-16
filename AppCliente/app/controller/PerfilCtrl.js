(function () {
    'use strict';

    app.controller('PerfilCtrl', ['$scope', '$injector', '$timeout', 'loadAnimeService', 'messageService', '$location', 'perfilService',
        function ($scope, $injector, $timeout, loadAnimeService, messageService, $location, perfilService) {

            var vm = this;

            function startVm() {

                //bag from Services which wil be bringing a list of objects from db
                vm.bagPerfil = [];
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
                perfilService.listAll(function (resp) {
                    if (resp !== null) {
                        console.info(resp);
                        vm.tela = 'Consulta';
                        vm.bagPerfil = resp.data;
                        loadAnimeService.close();
                    }

                });

                vm.bagTipos = ['Física', 'Jurídica'];
            }

            function goCadastro() {
                loadAnimeService.show();
                vm.tela = 'Cadastro';
                vm.user = [];
                loadAnimeService.close();
            }

            function goConsulta() {
                vm.bagPerfil = null;
                vm.bagPerfil = [];
                loadAnimeService.show();
                vm.tela = 'Consulta';
                vm.loadGrid();
                loadAnimeService.close();
            }

            vm.validaPessoa = function () {
                loadAnimeService.show();
                if (vm.user.tipo === 'Física') {
                    vm.user.cnpj = '';
                    loadAnimeService.close();
                }
                else if (vm.user.tipo !== 'Física') {
                    vm.user.cpf = '';
                    loadAnimeService.close();
                }
            }


            vm.goDeletar = function (codigo) {
                loadAnimeService.show();
                perfilService.delete(codigo, function (resp) {
                    if (resp !== null) {
                        vm.goConsulta();
                        messageService.success("Operação realizada com sucesso!");
                    }
                });
            }


            vm.goEditar = function (obj) {
                loadAnimeService.show();
                vm.tela = 'Cadastro';
                vm.user = obj;
                loadAnimeService.close();
            }

            vm.goSaveOrUpdate = function () {
                loadAnimeService.show();
                perfilService.goSaveOrUpdate(vm.user, function (resp) {
                    if (resp !== null) {
                        vm.loadGrid();
                        messageService.success("Operação realizada com sucesso!");
                        loadAnimeService.close();
                    }
                });

            }


            vm.loadGrid();

        }]);
})();