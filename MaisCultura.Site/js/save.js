$("#cbxSave").change(function () {

    const urlParams = new URLSearchParams(location.search);
    var usuario = urlParams.get('l');

    if (usuario == null) {
        PageMethods.checkando();
        document.getElementById('cbxSave').checked = false;
        return $("#btnLog").click();
    }

    var evento = urlParams.get('e');

    if ($("#cbxSave").prop("checked") == true) {
        PageMethods.salvarEvento(usuario, evento);
    }
    else {
        PageMethods.removerSalvo(usuario, evento);
    }
});

