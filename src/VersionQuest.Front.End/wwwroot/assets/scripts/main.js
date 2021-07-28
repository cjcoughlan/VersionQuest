$(function () {
    // TODO Should be in Config
    let endpoint = 'http://localhost:51500/software'

    // Add listener for submit button
    $("#searchButton").click(function () {
        let searchString = $("#searchString").val();
        callSearch(searchString);
    });

    // Add function for REST Call
    const callSearch = (searchString) => {
        $.ajax({
            url: `${endpoint}?searchString=${searchString}`,
            contentType: "application/json",
            dataType: 'json',
            success: function (result) {

                $('#resultsTable tbody').find("tr").remove();

                $.each(result, function (index, value) {
                    console.log(value.name + '--' + value.version);
                    var tableRow = `<tr class="child"><td>${value.name}</td><td>${value.version}</td></tr>`
                    $('#resultsTable tbody').append(tableRow);
                });
            }
        })
    }

});