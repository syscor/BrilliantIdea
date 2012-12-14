BoardSettings = {};
BoardSettings.SettingsLogic = {};

function BoardSettingsLogic() {
    var self = this;
    self.type = "BoardSettingsLogic";
    self.boardTypes = ko.observableArray(new Array());
    self.selectedBoard = ko.observable();
    self.deviceUrl = ko.observable();

    self.testCommunication = function () {
       
    };
}

BoardSettings.initialize = function() {
    $(document).ready(function() {
        $("#boardSteps").wijtabs();
    });
    BoardSettings.SettingsLogic.BoardSettings = new BoardSettingsLogic();
    BoardSettings.getInitialValues(BoardSettings.SettingsLogic.BoardSettings);
};

BoardSettings.getInitialValues = function(boardLogic) {
    $.getJSON("/config/GetBoardTypes", function (data) {
       boardLogic.boardTypes = ko.mapping.fromJS(data);
        ko.applyBindings(boardLogic, document.getElementById("boardSteps"));
        $("#boardDropDown").wijcombobox({
           
        });
    });
};