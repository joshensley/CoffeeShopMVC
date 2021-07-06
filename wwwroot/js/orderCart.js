$(document).ready(function () {

    // Delete Item in cart
    $(".deleteItem").click(function () {

        console.log($(this).data());

        var data = $(this).data("id");
        var url = $(this).data("request-url");

        $.ajax({
            type: "POST",
            url: url + '/' + data,
            contentType: "application/json;charset=UTF-8",
            dataType: "JSON",
            success: function (response) {

                $(`#deleteItem-${response}`)
                    .fadeOut(1000, function () {
                        $(this).remove();
                    });

                // When deleting item need to remove the item in the cart as well

                const quantity = parseInt($("#sumTotalQuantity").text()) - 1;
                $("#sumTotalQuantity").text(quantity);

            },
            error: function (req, status, error) {
                console.log(error);
            }
        })
    });
});