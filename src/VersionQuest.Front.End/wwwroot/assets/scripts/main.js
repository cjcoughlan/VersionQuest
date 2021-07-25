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
                
                $.each(result, function (index, value) {
                    console.log(value.name + '--' + value.version);
                    //console.log(value);
                });
            }
        })
    }

});