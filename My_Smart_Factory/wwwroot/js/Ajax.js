function AjaxPost(url, data, url) {
    $.ajax({
        url: url,
        type: "POST",
        data: data,
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
