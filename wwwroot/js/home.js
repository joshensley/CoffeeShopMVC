$(document).ready(function () {

    // Increase item quantity
    $(".btnDown").click(function () {
        const $drinkValue = $("#drinkValue-" + this.value)
        const $value = parseInt($drinkValue.text());

        if ($value > 1) {
            $drinkValue.text($value - 1);
        }
    });

    // Decrease item quantity
    $(".btnUp").click(function () {
        const $drinkValue = $("#drinkValue-" + this.value)
        const $inputCount = $("#inputCount-" + this.value)
        const $value = parseInt($drinkValue.text());
        $drinkValue.text($value + 1);
        $inputCount.val($value + 1);
    });

    // Add Order to Cart
    /*$(".addToOrder").click(function () {
        const itemValue = this.value;
        const inputCountValue = $(`#inputCount-${itemValue}`).val();
        const orderCartGroup = localStorage.getItem("orderCartGroup");

        $.ajax({
            type: "POST",
            url: "@Url.Action("AddToOrder")",
            data: JSON.stringify({
                ItemValue: itemValue,
                InputCountValue: inputCountValue,
                OrderCartGroup: orderCartGroup
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "JSON",
            success: function (response) {

                $(".dropdown-menu").prepend(
                    `<li>
                        <a class="dropdown-item" href="#">
                            <small>
                                <i class="fas fa-coffee"></i> ${response.itemProductName} - ${response.quantity} qty - $${response.itemProductTotalPrice}
                            </small>
                        </a>
                    </li>`
                );

                const quantity = parseInt($("#sumTotalQuantity").text()) + 1;
                $("#sumTotalQuantity").text(quantity);

            },
            error: function (req, status, error) {
                console.log(error);
            }
        });
    });*/



});