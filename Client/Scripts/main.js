function callGetAgreements() {
    $.ajax({
        type: "GET",
        url: "/Home/GetAgreementsList",
        success: function (data) {
            $('#agreements').html(data);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}