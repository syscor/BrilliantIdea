BoardSettings = {};
BoardSettings.SettingsLogic = {};

function BoardSettingsLogic() {
    var self = this;
    self.type = "BoardSettingsLogic";
    self.boardTypes = ko.observableArray(new Array());
    self.selectedBoardType = {
        BoardId: ko.observable(),
        Name: ko.observable(),
        Description: ko.observable(),
        PinFeatures: ko.observableArray()
    };

    self.deviceUrl = ko.observable();
    self.boardList = ko.observableArray(new Array());
    self.alert = {
        head: ko.observable(),
        body: ko.observable()
    };
    
    self.testCommunication = function() {

    };
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
            ko.applyBindings(boardLogic, document.getElementById("boardSteps"));
            $("#boardDropDown").wijcombobox({
            });
            if (data.length == 0 || data1.length == 0) {
                SysCor.showAlert(SysCor.AlertEnum.Error, "Falta de datos", "No se ha inicializado aún la base de datos, por favor vaya a configuración -> Inicializar Configuraciones");
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