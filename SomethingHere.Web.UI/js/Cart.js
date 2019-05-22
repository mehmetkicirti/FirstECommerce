$(document).ready(function () {
    $('a[data-cart="1"]').click(function () {
        var request = {};
        request.ProductID = $(this).data('id');
        $.ajax({
            url: '/Cart/AddToCart',
            contentType: 'application/json;charset=UTF-8',
            dataType: 'json',
            data: JSON.stringify(request),
            type: 'POST',
            success: function (response) {
                //alert(response.Message)
                if (response.Message == "Success") {
                    LoadCartInfo();
                } else {
                    alert(response.Message);
                }

            },
            error: function () {

            }
        })
    });//sepete ekleme
    LoadCartInfo()
    function LoadCartInfo() {
        var request = {};
        //anlık degisimleri kontrol edicegimizden
        request.ProductID = $(this).data('id');
        $.ajax({
            url: '/Cart/CartInfo',
            contentType: 'application/json;charset=UTF-8',
            dataType: 'json',
            type: 'POST',
            success: function (response) {
                // alert(response.ItemCount + " " + response.TotalPrice);
                $('#cartItemCount').text(response.ItemCount);
                $('#cartItemTotalPrice').text(response.TotalPrice);
            },
            error: function () {

            }
        });
    }
    //span[data-process="minus"] span[data-process="plus"] seklinde yazabiliriz
    $('span[data-process="minus"],span[data-process="plus"],span[data-process="remove"]').click(function () {
        debugger;
        var span = $(this);
        var request = {};//gönderdigimiz yerdeki ile aynı olmalı
        request.ProductID = $(this).data('id');
        request.ProcessName = $(this).data('process');
        $.ajax({
            url: '/Cart/ProductProcess',
            contentType: 'application/json;charset=UTF-8',
            dataType: 'json',
            data: JSON.stringify(request),
            type: 'POST',
            success: function (response) {
                //debugger;
                //alert(response.Message)
                
                if (response == false) {
                    var parent = span.closest('tr').remove();
                   
                }
                LoadCartInfo();
            },
            error: function () {

            }
        });

    });
});
