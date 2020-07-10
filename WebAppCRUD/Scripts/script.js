$(function () {
    $(document).on("keyup", "#product-search-input", function () {
            
        var value = $(this).val().toLowerCase();
        console.log(value)
        $(".table .name").filter(function () {
            $(this).parent().toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });

       
    });
});