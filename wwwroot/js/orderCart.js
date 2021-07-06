$(document).ready(function () {

    // Delete Item in cart
    $(document).on('click', ".delete-item", function () {
        console.log("click");

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
                // Add change the total price in check out

                const quantity = parseInt($("#sumTotalQuantity").text()) - 1;
                $("#sumTotalQuantity").text(quantity);

            },
            error: function (req, status, error) {
                console.log(error);
            }
        })
    });

});