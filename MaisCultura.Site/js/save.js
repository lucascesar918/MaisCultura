$("#cbxSave").change(function () {
    console.log("entrou");

    const urlParams = new URLSearchParams(location.search);
    var usuario = urlParams.get('l');

    if (usuario == null) {
        $("#cbxSave").checked = false;
        console.log("teste");
        //return $("#btnLog").click();
    }

    var evento = urlParams.get('e');

    if ($("#cbxSave").prop("checked") == true) {
        PageMethods.salvarEvento(usuario, evento);
    }
    else {
        PageMethods.removerSalvo(usuario, evento);
    }
});

