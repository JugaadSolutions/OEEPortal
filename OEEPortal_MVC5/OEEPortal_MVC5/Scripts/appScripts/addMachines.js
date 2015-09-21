function addMachines(machines,createMachinesUrl) {
    //debugger;
    var noOfMachines = machines.length;
    $("#BaseContainerDiv").empty();

    var machineRows = Math.ceil(noOfMachines / 4, 10).toString();

    if (machineRows == 0) machineRows = 1;

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
        var MachineButton = $("<button class='btn machinebtn btn-info btn-lg btn-block' data-machine=\""+ Machine +"\"></button>").html(MachineName);

        
        $("#" + rowId).append(MachineCol);
        MachineCol.append(MachineButton);

        
    }

    $('.machinebtn').bind("click", function (e) {
        onMachineClick($(this),createMachinesUrl);

    });
}

function onMachineClick(elem,createMachinesUrl)
{
    debugger;
    var id = elem.data("machine");
    location.href = createMachinesUrl+'?Machine=' + id;
}