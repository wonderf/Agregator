function httpGet() {
    var url = $("#url").val();

    var client = new XMLHttpRequest()
    client.open("GET", url)
    client.onloadend = function (pe) {
        $("#page").val("");
        $("#page").val(pe.returnValue);
    }
    client.send()
}
