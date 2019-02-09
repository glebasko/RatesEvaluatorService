function callGetAgreements() {
    $.ajax({
        type: "GET",
        url: "/Home/GetAgreementsList",
        success: function (data) {
            debugger;
            $('#agreements').html(data);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}