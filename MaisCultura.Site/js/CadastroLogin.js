$(document).ready(function (e) {

    $("#btnCad").click(function (e) {
        e.preventDefault();
        window.scrollTo(0, 0);
        $("#cad").toggle();
        $("#shade").toggle();
        $("html, body").css({ 'overflow': 'hidden' });

    });

    $("#btnLog").click(function (e) {
        e.preventDefault();
        window.scrollTo(0, 0);
        $("#log").toggle();
        $("#shade2").toggle();
        $("html, body").css({ 'overflow': 'hidden' });
    });

    $("#btnSairCad").click(function (e) {
        e.preventDefault();
        $("#cad").toggle();
        $("#shade").toggle();
        $("html").css({ 'overflow': 'auto' });
    });

    $("#btnSairLogin").click(function (e) {
        e.preventDefault();
        $("#log").toggle();
        $("#shade2").toggle();
        $("html").css({ 'overflow': 'auto' });
    });

    $("#btnDenuncia").click(function (e) {
        e.preventDefault();
        const urlParams = new URLSearchParams(location.search);
        var usuario = urlParams.get("l");

        if (usuario == null) {
            return $("#btnLog").click();
        }

        $("#denuncia").toggle();
        $("#shade3").toggle();
        $("html").css({ 'overflow': 'auto' });
    });

    $("#btnInteresse").click(function (e) {
        e.preventDefault();
        const urlParams = new URLSearchParams(location.search);
        var usuario = urlParams.get("l");
        var evento = urlParams.get("e");

        if (usuario == null) {
            return $("#btnLog").click();
        }

        if (document.getElementById("btnInteresse").value == "Demonstrar Interesse") {
            document.getElementById("btnInteresse").classList.add("Int");
            document.getElementById("btnInteresse").classList.remove("naoInt");
            document.getElementById("btnInteresse").value = "Interesse Demonstrado";
            PageMethods.DemonstrarInteresse(usuario, evento);
        }
        else {
            document.getElementById("btnInteresse").classList.add("naoInt");
            document.getElementById("btnInteresse").classList.remove("Int");
            document.getElementById("btnInteresse").value = "Demonstrar Interesse";
            PageMethods.RemoverInteresse(usuario, evento);
        }
    });

    $("#shade").click(function (e) {
        e.preventDefault();
        $("#cad").toggle();
        $("#shade").toggle();
        $("html").css({ 'overflow': 'auto' });
    });

    $("#shade2").click(function (e) {
        e.preventDefault();
        $("#log").toggle();
        $("#shade2").toggle();
        $("html").css({ 'overflow': 'auto' });
    });

    $("#shade3").click(function (e) {
        e.preventDefault();
        $("#denuncia").toggle();
        $("#shade3").toggle();
        $("html").css({ 'overflow': 'auto' });
    });

});