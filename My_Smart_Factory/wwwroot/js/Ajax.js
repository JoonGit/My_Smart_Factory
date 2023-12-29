function AjaxPost(url) {
    var requestUrl = "/oqc/" + url;
    var requestData = GetData();

    $.ajax({
        url: requestUrl,
        type: "POST",
        data: requestData,
        success: function (response) {
            var successMessage = "DB " + url + " success";
            var failureMessage = "DB " + url + " fale\n" + response;

            if (response === "success") {
                fetchData();
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