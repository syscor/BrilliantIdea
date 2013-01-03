﻿BoardSettings = {};
BoardSettings.SettingsLogic = {};

function BoardSettingsLogic() {
    var self = this;
    self.type = "BoardSettingsLogic";
    self.boardTypes = ko.observableArray(new Array());
    self.selectedBoardType = ko.observable().extend({required:{message: 'Se requiere seleccionar un elemento'}});
    self.boardId = ko.observable();
    self.boardName = ko.observable().extend({required:true});
    self.boardDescription = ko.observable();
    self.deviceUrl = ko.observable().extend({required:true});
    self.PortsConfiguration = ko.observableArray(new Array());
    self.boardList = ko.observableArray(new Array());
    self.showOnlyEnables = ko.observable(false);
    self.alert = {
        head: ko.observable(),
        body: ko.observable()
    };
    self.testCommunication = function() {

    };
    
    self.boardFilteredList = ko.observableArray(new Array());

    self.saveBoard = function () {
        if (self.errors().length>0) {
            self.errors.showAllMessages();
            return;
        }
        var board = {
            DeviceId: self.boardId(),
            Name: self.boardName(),
            Description: self.boardDescription(),
            Type: self.selectedBoardType(),
            Url: self.deviceUrl(),
            PortsConfiguration: self.PortsConfiguration()
        };

        var boardJson = ko.toJSON(board);

        $.post("config/SaveBoardDevice", { boardJson: boardJson }, function(data) {
            if (data=="success") {
                $.getJSON("/config/GetBoards", function(data1) {
                    ko.mapping.fromJS(data1, self.boardList);
                    self.boardName("");
                    self.boardDescription("");
                    self.deviceUrl("");
                });
                $("#boardSteps").wijtabs('select', 0);
                SysCor.showAlert(SysCor.AlertEnum.Success, "Proceso exitoso", "El nuevo dispositivo ha sido almacenado correctamente");
                self.errors.showAllMessages(false);
            } else {
                SysCor.showAlert(SysCor.AlertEnum.Error, "Lo sentimos se ha producido un problema", "Contacte a su administrador de sistemas, detalle: " + data);
            }
        });
    };
    
    self.errors = ko.validation.group(self);
}

BoardSettings.initialize = function () {
    $(document).ready(function () {
        $("#boardSteps").wijtabs();
    });
    BoardSettings.SettingsLogic.BoardSettings = new BoardSettingsLogic();
    BoardSettings.getInitialValues(BoardSettings.SettingsLogic.BoardSettings);
};

BoardSettings.getInitialValues = function (boardLogic) {
    $.getJSON("/config/GetBoardTypes", function (data) {
        var vmType = ko.mapping.fromJS(data);

        boardLogic.boardTypes(vmType.BoardTypeList());
        
        $.getJSON("/config/GetBoards", function (data1) {
            
            boardLogic.boardList = ko.mapping.fromJS(data1);
            BoardSettings.filterBoardList(boardLogic);
            ko.validation.configure({ errorMessageClass: 'custom-error'});
            ko.applyBindings(boardLogic, document.getElementById("boardSteps"));
            $("#boardDropDown").wijcombobox({});
            if (data.length == 0 || data1.length == 0) {
                SysCor.showAlert(SysCor.AlertEnum.Error, "Falta de datos", "No se ha inicializado aún la base de datos, por favor vaya a configuración -> Inicializar Configuraciones");
                for (var i = 1; i < 4; i++) {
                    $("#boardSteps").wijtabs('disableTab', i);
                }
            }
        });
    });
};

BoardSettings.initializeConfigurations = function () {
    $.getJSON("config/InitializeConfigs", function (data) {
        if (data) {
            SysCor.showAlert(SysCor.AlertEnum.Success, "Datos Inicializados", SysCor.AlertGenericMessages.Success);
        } else {
            SysCor.showAlert(SysCor.AlertEnum.Error, "Verifique sus datos de conexión", SysCor.AlertGenericMessages.Error);
        }
    });
};

BoardSettings.filterBoardList = function(boardLogic) {
    var i = boardLogic.boardList().length;
    boardLogic.boardFilteredList(new Array());
    for (var j = 0; j < i; j++) {
        if (boardLogic.boardList()[j].Enable() && boardLogic.showOnlyEnables()) {
            boardLogic.boardFilteredList().push(boardLogic.boardList()[j]);
        } else if (!boardLogic.showOnlyEnables()) {
            boardLogic.boardFilteredList().push(boardLogic.boardList()[j]);
        }
    }
};