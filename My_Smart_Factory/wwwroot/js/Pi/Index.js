function Update() {
    $('table').on('click', '.btn-primary', function (e) {
        e.preventDefault();

        var row = $(this).closest('tr');
        var id = row.find('input[name="id"]').val();
        var controlNumber = row.find('input[name="controlNumber"]').val();
        var specification = row.find('input[name="specification"]').val();
        var lotNumber = row.find('input[name="lotNumber"]').val();
        var data = {
            id: id,
            controlNumber: controlNumber,
            specification: specification,
            lotNumber: lotNumber
        };
        AjaxPost("/oqc/create", data, "create");
}
