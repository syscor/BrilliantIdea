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
    self.showOnlyEnables = ko.observable(true);
    self.testboardFilteredList = ko.observableArray(new Array());

    self.boardFilteredList = ko.computed(function () {
        var status = self.showOnlyEnables();
        var i = self.boardList().length;
        self.testboardFilteredList().splice(0, i);
        for (var j = 0; j < i; j++) {
            if (self.boardList()[j].IsEnable() && status) {
                self.testboardFilteredList().push(self.boardList()[j]);
            } else if (!status) {
                self.testboardFilteredList().push(self.boardList()[j]);
            }
        }
        self.testboardFilteredList().sort(function(left, right) {
            return left.IsEnable == right.IsEnable ? 0 : (left.IsEnable < right.IsEnable ? -1 : 1);
        });
        return self.testboardFilteredList();
    }, self);

    self.alert = {
        head: ko.observable(),
        body: ko.observable()
    };
    
    self.testCommunication = function() {

    };

    self.toggleEnable = function (board) {
        var header = board.IsEnable() ? "Desactivación de dispositivo..." : "Activación de dispositivo";
        var body = board.IsEnable() ? "¿Está seguro que desea desactivar el dispositivo " + board.Name() + "?, tenga en cuenta que no podrá ser utilizado en ningún proceso, pero su historial no será borrado" : "¿Desea reactivar el dispositivo? Estará disponible para programar procesos";
        var modal = SysCor.getModal(header, body, "", "");
        $('#modalContainer').html(modal);
        $('#modalYes').click(function() {
            $('#sysCorModal').modal('hide');
            board.IsEnable(!board.IsEnable());
            self.updateBoard(board);
        });
        $('#sysCorModal').modal();
    };

    self.editBoard = function (board) {
        var id = board.DeviceId();
        var element = document.getElementById(id);
        element.setAttribute("style", "display:none");
        element = document.getElementById("edit" + id);
        element.removeAttribute("style", "");
    };

    self.saveChanges = function(board) {
        var header = "Actualización de dispositivo...";
        var body = "¿Desea guardar los cambios al dispositivo " + board.Name() + "?";
        var modal = SysCor.getModal(header, body, "", "", "BoardSettings.updateBoard");
        $('#modalContainer').html(modal);
        $('#modalYes').click(function () {
            $('#sysCorModal').modal('hide');
            self.updateBoard(board);
            var id = board.DeviceId();
            var element = document.getElementById(id);
            element.removeAttribute("style", "");
            element = document.getElementById("edit" + id);
            element.setAttribute("style", "display:none");
        });
        $('#sysCorModal').modal();
    };

    self.updateBoard = function(board) {
        var boardJson = ko.toJSON(board);
        $.post("config/UpdateBoardDevice", { boardJson: boardJson }, function (data) {
            if (data == "success") {
                SysCor.showAlert(SysCor.AlertEnum.Success, "Proceso exitoso", "El dispositivo ha sido actualizado correctamente");
            } else {
                SysCor.showAlert(SysCor.AlertEnum.Error, "Lo sentimos se ha producido un problema", "Contacte a su administrador de sistemas, detalle: " + data);
            }
        });

    };

    self.deleteBoard=function(board) {
        var header = "Eliminar el dispositivo...";
        var body = "¿Está seguro que desea eliminar el dispositivo " + board.Name() + "?, tenga en cuenta que no podrá ser utilizado en ningún proceso ni podrá volver a activarlo, pero su historial no será borrado";
        var modal = SysCor.getModal(header, body, "", "");
        $('#modalContainer').html(modal);
        $('#modalYes').click(function () {
            $('#sysCorModal').modal('hide');
            var boardJson = ko.toJSON(board.DeviceId);
            $.post("config/RemoveBoardDevice", { deviceJson: boardJson }, function (data) {
                if (data=="success") {
                    SysCor.showAlert(SysCor.AlertEnum.Success, "Proceso exitoso", "El dispositivo ha sido actualizado correctamente");
                } else {
                    SysCor.showAlert(SysCor.AlertEnum.Error, "Lo sentimos se ha producido un problema", "Contacte a su administrador de sistemas, detalle: " + data);
                }
            });
        });
        $('#sysCorModal').modal();

    };
    
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
            PortsConfiguration: self.PortsConfiguration(),
            IsEnable: true,
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
            ko.validation.configure({ errorMessageClass: 'custom-error'});
            ko.applyBindings(boardLogic, document.getElementById("boardSteps"));
            $("#boardDropDown").wijcombobox({});
            if (data.length == 0 || data1.length == 0) {
                SysCor.showAlert(SysCor.AlertEnum.Error, "Falta de datos", "No se ha inicializado aún la base de datos, por favor vaya a configuración -> Inicializar Configuraciones");
                for (var i = 1; i < 4; i++) {
                    $("#boardSteps").wijtabs('disableTab', i);
                }
            }
            boardLogic.showOnlyEnables(false);
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