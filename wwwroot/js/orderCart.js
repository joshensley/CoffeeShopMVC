$(document).ready(function () {

    // Delete Item in cart
    $(document).on('click', ".delete-item", function () {

        var data = $(this).data("id");
        var url = $(this).data("request-url");

        $.ajax({
            type: "POST",
            url: url + '/' + data,
            contentType: "application/json;charset=UTF-8",
            dataType: "JSON",
            success: function (response) {

                // Change the total item price in navbar cart
                const deleteItemText = $(`#navbarTotalPrice-${response.id}`).text();
                const itemPrice = parseInt(deleteItemText.slice(1, deleteItemText.length));

                const previousSumText = $("#sumTotalPrice").text();
                const previousSum = parseInt(previousSumText.slice(1, previousSumText.length));
                const sum = parseInt(previousSum - itemPrice);
                $("#sumTotalPrice").text("$" + sum);

                $(`#deleteItem-${response.id}`)
                    .fadeOut(1000, function () {
                        $(this).remove();
                    });

                // Remove item from list in navbar cart
                $(`#list-item-${response.id}`).remove();

                // Change the quantity in navbar cart
                const quantity = parseInt($("#sumTotalQuantity").text()) - 1;
                $("#sumTotalQuantity").text(quantity);

                // Get number of items in cart
                const listItemLength = $('[id*="list-item"]').length
                if (listItemLength <= 0) {
                    $(".dropdown-menu").prepend(
                        `<li id="no-items-in-cart">
                            <a class="dropdown-item text-center" href="#">
                                <small>
                                   No items in cart
                                </small>
                            </a>
                        </li>`
                    )

                    $("#cart-list").prepend(
                        `<li class="list-group-item text-center">
                            <small>
                                No items in cart
                            </small>
                        </li>`
                    )
                }

            },
            error: function (req, status, error) {
                console.log(error);
            }
        })
    });

});