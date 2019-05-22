$(document).ready(function () {
    var allOption = $('option[data-product="1"]');
    $('#txt_Search').keyup(function () {
        var selectElement = $('#selectProduct');
        selectElement.empty();
        let search = $(this);
        let value = search.val();
        //alert(value);
       
        //closest div in kapandıgı yada tr nin kapandıgı kısma giderken
        if (value.length >= 3) {
            for (var i = 0; i < allOption.length; i++) {
                var option = $(allOption[i]);

                var productName = option.text();//val=>id i vericek $(option).val deyip bakablirsin
                if (productName.toLowerCase().indexOf(value.toLowerCase()) > -1) {
                    selectElement.append(allOption[i]);
                }
            }
        } else {
            for (var i = 0; i < allOption.length; i++) {
                
                    selectElement.append(allOption[i]);
              
            }
        }
    });
});