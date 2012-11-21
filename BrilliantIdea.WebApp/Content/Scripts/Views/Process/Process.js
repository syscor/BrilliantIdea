Process = {};

Process.initialize = function() {
    $(document).ready(function() {
        $("#splitter").wijsplitter({
            orientation: "vertical",
            panel1: { minSize:200 },
        });
    });
}