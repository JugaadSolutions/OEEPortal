var LoadData = function (url) {
    var self = this;
    self.locations = ko.observableArray();
    self.error = ko.observable();

    var destinationUri = '/api/locations';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: destinationUri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getData() {
        ajaxHelper(destinationUri, 'GET').done(function (data) {
            self.locations(data);
        });
    }

    // Fetch the initial data.
    getData();
};

