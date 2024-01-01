function loadTableData() {
    var date = $('#date').val();
    $.ajax({
        url: '/processStatus/readbydate',
        data: { 'date': date },
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var tbody = $('tbody');
            tbody.empty();

            $.each(data, function (index, item) {
                var row = $('<tr>');
                console.log(item);

                row.append($('<input>').attr({ type: 'hidden', name: 'id', value: item.id }));
                row.append($('<td>').text(item.specification));
                row.append($('<td>').text(item.lotNumber));
                row.append($('<td>').text(item.quantity));
                row.append($('<td>').text(item.defectiveQuantity));
                row.append($('<td>').text(item.defectRate + "%"));

                tbody.append(row);
            });
        },
        error: function (error) {
            alert('false');
        }
    });
}