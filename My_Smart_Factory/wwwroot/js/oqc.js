function GetData() {
    return {
        oqcId: document.getElementsByName("oqcId")[0].value,
        controlnumber: document.getElementsByName("controlnumber")[0].value,
        processName: document.getElementsByName("processName")[0].value,
        inspectionTime: document.getElementsByName("inspectionTime")[0].value,
        inspectionResult: document.getElementsByName("inspectionResult")[0].value,
        inspector: document.getElementsByName("inspector")[0].value,
        confirmor: document.getElementsByName("confirmor")[0].value,
        capacityDefect: document.getElementsByName("capacityDefect")[0].value,
        lossDefect: document.getElementsByName("lossDefect")[0].value,
        bubbleDefect: document.getElementsByName("bubbleDefect")[0].value,
        centerDefect: document.getElementsByName("centerDefect")[0].value,
        innerDiameterDefect: document.getElementsByName("innerDiameterDefect")[0].value,
        markDefect: document.getElementsByName("markDefect")[0].value,
        caseDefect: document.getElementsByName("caseDefect")[0].value,
        epoxyDefect: document.getElementsByName("epoxyDefect")[0].value,
        etcDefect: document.getElementsByName("etcDefect")[0].value,
        etcInfo: document.getElementsByName("etcInfo")[0].value
    };
}

var info = null;

// oqc ajax POST ��û


// modal�� ������ ���� ��ư ����
function showModalWithData(response) {
    const modal = $('#DataChoiceModal');
    let choiceData = "";
    response.forEach((data, i) => {
        var btnData = (i + 1) + " : " + data["inspectionTime"];
        choiceData += `<button type='button' class='btn btn-primary' onclick='populateData(info[${i}])'>${btnData}</button><p>`;
    });

    modal.find('.modal-body').html(choiceData);
}

// ������ ������ ǥ��
function populateData(data) {
    const fields = ['oqcId', 'processName', 'inspectionTime', 'inspectionResult',
        'inspector', 'confirmor', 'capacityDefect', 'lossDefect',
        'bubbleDefect', 'centerDefect', 'innerDiameterDefect',
        'markDefect', 'caseDefect', 'epoxyDefect', 'etcDefect', 'etcInfo'];

    fields.forEach(field => {
        document.getElementsByName(field)[0].value = data[field];
    });
}

// controlnumber�� ������ ��û
function fetchData() {
    const data = GetData();

    $.ajax({
        url: "/oqc/read",
        data: { 'controlnumber': data.controlnumber },
        type: 'get',
        success: function (response) {
            info = response;
            showModalWithData(response);
            if (response.length === 1) {
                populateData(response[0]);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

// modal����
// �Ϲ������� ����ϴ� model.show�� �ϸ� 
// showModalWithData ������ ���â�� �������� �ʴ� ���� �߻��ϱ� ������ ��ư�� Ŭ���ϴ� �������� ����
function openModal() {
    $("#modalBtn").click();
}

function fetchDataAndOpenModal() {
    fetchData();
    openModal();
}
