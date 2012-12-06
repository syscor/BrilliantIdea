BoardSettings = {};

BoardSettings.initialize = function () {
    $(document).ready(function() {
        $("#boardSplitter").wijsplitter({
            orientation: "vertical",
            panel1: { minSize:200 },
        });
    });
};