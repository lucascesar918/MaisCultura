$("#cbxSave").change(function () {

    if (!verificarUser()) {
        document.getElementById("cbxSave").checked = false;
        return $("#btnLog").click();
    }

    const urlParams = new URLSearchParams(location.search);
    var usuario = urlParams.get("l");
    var evento = urlParams.get("e");

    if ($("#cbxSave").prop("checked") == true) {
        $("#cbxSave").enable = false;
        PageMethods.salvarEvento(usuario, evento);
    }
    else {
        PageMethods.removerSalvo(usuario, evento);
    }
});

function verificarUser() {
    const urlParams = new URLSearchParams(location.search);
    var usuario = urlParams.get("l");

    if (usuario == null) {
        return false;
    }

    return true;
}