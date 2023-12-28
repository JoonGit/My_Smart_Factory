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

function Ajax(url) {
    var requestUrl = "/oqc/" + url;
    var requestData = GetData();

    $.ajax({
        url: requestUrl,
        type: "POST",
        data: requestData,
        success: function (response) {
            var successMessage = "DB " + url + " 추가 완료";
            var failureMessage = "DB " + url + " 추가 실패\n" + response;

            if (response === "success") {
                FetchData();
                alert(successMessage);
            } else {
                alert(failureMessage);
            }
        },
        error: function (request, status, error) {
            var errorMessage = "code:" + request.status + "\n"
                + "message:" + request.responseText + "\n"
                + "error:" + error;
            alert(errorMessage);
        }
    });
}

function showModalWithData(response) {
    const modal = $('#DataChoiceModal');
    let choiceData = "";

    response.forEach((data, i) => {
        choiceData += `<button type='button' class='btn btn-primary' onclick='populateData(info[${i}])'>${data.inspectionTime}</button><p>`;
    });

    modal.find('.modal-body').html(choiceData);
}

function populateData(data) {
    const fields = ['oqcId', 'processName', 'inspectionTime', 'inspectionResult',
        'inspector', 'confirmor', 'capacityDefect', 'lossDefect',
        'bubbleDefect', 'centerDefect', 'innerDiameterDefect',
        'markDefect', 'caseDefect', 'epoxyDefect', 'etcDefect', 'etcInfo'];

    fields.forEach(field => {
        document.getElementsByName(field)[0].value = data[field];
    });
}



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

function openModal() {
    $("#modalBtn").click();
}

function fetchDataAndOpenModal() {
    fetchData();
    openModal();
}
