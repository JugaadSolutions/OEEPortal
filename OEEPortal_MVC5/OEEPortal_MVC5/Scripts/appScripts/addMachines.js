function addMachines(machines) {
    //debugger;
    var noOfMachines = machines.length;
    $("#BaseContainerDiv").empty();

    var machineRows = parseInt(noOfMachines % 4, 10).toString();


    for (var i = 0; i < machineRows; i++) {
        var machineRowDiv = $("<div class='row' style='padding-top:5px' id=MachineRow" + i.toString() + "></div>");
        $("#BaseContainerDiv").append(machineRowDiv);

    }


    for (var i = 0; i < noOfMachines; i++) {

        var rowId = "MachineRow" + parseInt(i / 4).toString();
        var divId = "MachineDiv" + (i).toString();
        var MachineName = machines[i]["Name"];
        var Machine = machines[i]["MachineId"];


        var MachineCol = $("<div class='col-md-3' id=\"" + divId + "\"></div>");
        var MachineButton = $("<button class='btn btn-info btn-lg btn-block' ></button>").html(MachineName);


        $("#" + rowId).append(MachineCol);
        MachineCol.append(MachineButton);

        MachineButton.on("click", function (e) {
            location.href = '/MachineOutputRecords/Create/?Machine=' + Machine.toString();
        });
    }
}