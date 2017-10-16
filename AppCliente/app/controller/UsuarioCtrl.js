(function () {
    'use strict';

    app.controller('UsuarioCtrl', ['$scope', '$injector', '$timeout', 'loadAnimeService', 'messageService', '$location', 'usuarioService','perfilService',
        function ($scope, $injector, $timeout, loadAnimeService, messageService, $location, usuarioService, perfilService) {

            var vm = this;

            function startVm() {

                //bag from Services which wil be bringing a list of objects from db
                vm.bagusuarios = [];
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
                usuarioService.listAll(function (resp) {
                    if (resp !== null) {
                       
                        vm.tela = 'Consulta';
                        vm.bagusuarios = resp.data;
                        loadAnimeService.close();
                    }

                });        

                perfilService.listAll(function (resp) {
                    if (resp.data !== null) {
                        vm.bagPerfils = resp.data;
                        loadAnimeService.close();
                    }

                });
            }

            function goCadastro() {
                loadAnimeService.show();
                vm.tela = 'Cadastro';
                vm.user = [];
                loadAnimeService.close();
            }

            function goConsulta() {
                vm.bagusuarios = null;
                vm.bagusuarios = [];
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
                usuarioService.delete(codigo, function (resp) {
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
                usuarioService.goSaveOrUpdate(vm.user, function (resp) {
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