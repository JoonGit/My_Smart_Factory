
function Update() {
    $('table').on('click', '.btn-primary', function (e) {
        e.preventDefault();

        var row = $(this).closest('tr');
        var id = row.find('input[name="id"]').val();
        var prodName = row.find('input[name="prodName"]').val();
        var prodCode = row.find('input[name="prodCode"]').val();
        var prodWeight = row.find('input[name="prodWeight"]').val();
        var data = {
            id: id,
            prodName: prodName,
            prodCode: prodCode,
            prodWeight: prodWeight
        };
        AjaxPost("/ProdInfo/update", data, "update");
    });
}
