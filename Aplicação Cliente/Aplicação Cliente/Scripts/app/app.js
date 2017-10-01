var app = angular.module('App', []);

app.controller('TextEditorController', function ($scope, $http) {

    $scope.style = {
        'font-size': '',
        'font-family': '',
        'text-align': '',
        'line-height': '',
        'border-color': '',
        'color': ''
    };
    $scope.resultSaved = [];
    $scope.color = '#F0F0F0';

    var result = document.getElementById('texto');
    var colorInput = document.getElementById('color');

    $http.get('https://www.googleapis.com/webfonts/v1/webfonts?key=AIzaSyAFWueyr6rbjqg-wq9ABj850tFDdlYeoJg').then( function (response) {
        $scope.fonts = response.data.items;
    }, function (error) {
        $scope.fonts = [
            { family: 'ABeeZee' },
            { family: 'Acme' },
            { family: 'Arial' },
            { family: 'Inder' },
        ];
    });

    var text_align = function (align) {
        $scope.style['text-align'] = align;
        result.style.textAlign = $scope.style['text-align'];
    };

    var text_color = function () {
        colorInput.click();
    };


    $scope.ChangeColor = function () {
        $scope.style['color'] = $scope.color;
        $scope.style['border-color'] = $scope.color;
        result.style.color = $scope.style['color'];
        result.style.borderColor = $scope.style['border-color'];
    };

    var limpar = function () {
        $scope.texto = '';
        $scope.style = {
            'font-size': '',
            'font-family': '',
            'text-align': '',
            'line-height': '',
            'border-color': '',
            'color': ''
        };
        result.style.textAlign = 'center';
        result.style.color = '#CCCCCC';
        result.style.borderColor = '#CCCCCC';
        result.style.fontFamily = '';
    };

    var saveText = function () {
        var result = {
            text: $scope.texto,
            style: $scope.style
        };

        $scope.resultSaved.push(result);
        limpar();
    };

    $scope.limpar = limpar;
    $scope.saveText = saveText;
    $scope.text_align = text_align;
    $scope.text_color = text_color;
    $scope.fontFamilyChange = function () {
        $scope.style['font-family'] = $scope.singleSelect;
        result.style.fontFamily = $scope.singleSelect;
    };

});