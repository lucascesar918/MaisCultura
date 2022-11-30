$("#cbxSave").change(function () {

    if (!verificarUser()) {
        document.getElementById("cbxSave").checked = false;
        return $("#btnLog").click();
    }

    const urlParams = new URLSearchParams(location.search);
    var usuario = urlParams.get("l");
    var evento = urlParams.get("e");

    if ($("#cbxSave").prop("checked") == true) {
        PageMethods.salvarEvento(usuario, evento);
    }
    else {
        PageMethods.removerSalvo(usuario, evento);
    }
});

//$("#btnInteresse").click(function () {


//    if (!verificarUser()) {
//        return $("#btnLog").click();
//    }

//    const urlParams = new URLSearchParams(location.search);
//    var usuario = urlParams.get("l");
//    var evento = urlParams.get("e");

//    var btn = document.getElementById("btnInteresse"); 

//    if (btn.value == "Demonstrar Interesse") {
//        $("#btnLog").addClass("Int");
//        $("#btnLog").removeClass("naoInt");
//        btn.value = "Interesse Demonstrado";
//        PageMethods.DemonstrarInteresse(usuario, evento);
//    }
//    else {
//        $("#btnLog").addClass("naoInt");
//        $("#btnLog").removeClass("Int");
//        btn.value = "Demonstrar Interesse";
//        PageMethods.RemoverInteresse(usuario, evento);
//    }
//});

function verificarUser() {
    const urlParams = new URLSearchParams(location.search);
    var usuario = urlParams.get("l");

    if (usuario == null) {
        return false;
    }

    return true;
}