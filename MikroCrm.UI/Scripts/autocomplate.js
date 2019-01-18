$("#txtCustomer").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: '/CustomerCrm/AutoComplete',
            data: "{ 'prefix': '" + request.term + "'}",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                response($.map(data, function (item) {
                    return item;
                }))
            },
            error: function (response) {
                alert(response.responseText);
            },
            failure: function (response) {
                alert(response.responseText);
            }
        });
    },
    select: function (e, i) {
        $("#hfCustomer").val(i.item.val);
    },
    minLength: 1
});