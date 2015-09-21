/// <reference path="addMachines.js" />
function addLines(lines,getMachinesUrl,createMachinesUrl) {
    var noOfLines = lines.length;

    for (var i = 0; i < noOfLines; i++) {

        var rowId = "LineRow" + parseInt(i / 4).toString();
        var divId = "LineDiv" + (i).toString();

        var Id = lines[i]["LineId"];
        var LineName = lines[i]["Name"];

        var LineDiv = $("<div class='col-md-3' id=\"" + divId + "\"></div>");
        var LineButton = $("<button class='btn btn-info btn-lg btn-block' line-id=\"" + Id.toString() + "\"></button>").html(LineName);


        $("#" + rowId).append(LineDiv);
        LineDiv.append(LineButton);

        LineButton.on("click", function (e) {
            //debugger;
            var i = $(e.currentTarget).attr("line-id");
            var line = {
                LineId: i,
                LineName: $(e.currentTarget).html()
            };
            $.ajax({
                url: getMachinesUrl,
                type: "POST",
                data: "{'id':" + i.toString() + "}",
                contentType: "application/json",
                error: function () { alert('GetMachines Failure'); },
                success: function (machines) {

                    addMachines(machines,createMachinesUrl);
                }
            });
        });
    }
}