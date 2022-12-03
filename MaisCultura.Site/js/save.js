$("#cbxSave").change(function () {

    if (!verificarUser()) {
        document.getElementById("cbxSave").checked = false;
        return $("#btnLog").click();
    }

    const urlParams = new URLSearchParams(location.search);
    var usuario = urlParams.get("l");
    var evento = urlParams.get("e");

    if ($("#cbxSave").prop("checked") == true) {
        $("#cbxSave").css('pointer-events', 'none');
        PageMethods.salvarEvento(usuario, evento);
        $("#cbxSave").css('pointer-events', 'auto');
    }
    else {
        $("#cbxSave").css('pointer-events', 'none');
        PageMethods.removerSalvo(usuario, evento);
        $("#cbxSave").css('pointer-events', 'auto');
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