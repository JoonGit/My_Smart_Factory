function loadTableData() {
    var date = $('#date').val();
    $.ajax({
        url: '/pps/updatedateall', // �����͸� ������ ������ URL�� �Է����ּ���.
        data: { 'date': date },
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var tbody = $('tbody');
            tbody.empty(); // ������ ���̺� �����͸� ���ϴ�.

            $.each(data, function (index, item) {
                var row = $('<tr>');
                var date = new Date(item.date);
                date.setMinutes(date.getMinutes() - date.getTimezoneOffset());

                console.log(item);
                row.append($('<input>').attr({ type: 'hidden', name: 'id', value: item.id }));
                row.append($('<td>').append($('<input>').attr({ type: 'text', name: 'controlNumber', value: item.controlNumber, class: 'form-control' })));
                row.append($('<td>').append($('<input>').attr({ type: 'date', name: 'date', value: date.toISOString().split('T')[0], class: 'form-control' })));
                row.append($('<td>').append($('<input>').attr({ type: 'text', name: 'quantity', value: item.quantity, class: 'form-control' })));
                row.append($('<td>').append($('<input>').attr({ type: 'text', name: 'operatorName', value: item.operatorName, class: 'form-control' })));
                row.append($('<td>').append($('<input>').attr({ type: 'text', name: 'defectiveQuantity', value: item.defectiveQuantity, class: 'form-control' })));
                row.append($('<td>').append($('<button>').attr({ type: 'submit', class: 'btn btn-primary', onClick: 'Update()' }).text('update')));

                tbody.append(row);
            });
        },
        error: function (error) {
            // ���⿡ �������� ���� ó���� �ۼ����ּ���.
            alert('false');
        }
    });
}

function Update() {
    $('table').on('click', '.btn-primary', function (e) {
        e.preventDefault();
        var row = $(this).closest('tr');
        var id = row.find('input[name="id"]').val();
        var controlNumber = row.find('input[name="controlNumber"]').val();
        var date = row.find('input[name="date"]').val();
        var quantity = row.find('input[name="quantity"]').val();
        var operatorName = row.find('input[name="operatorName"]').val();
        var defectiveQuantity = row.find('input[name="defectiveQuantity"]').val();
        var data = {
            id: id,
            controlNumber: controlNumber,
            date: date,
            quantity: quantity,
            operatorName: operatorName,
            defectiveQuantity: defectiveQuantity
        };
    });
        AjaxPost("/pps/update", data, "update");
}