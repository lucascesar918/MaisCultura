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

    $("#alteraSenha").click(function (e) {
        e.preventDefault();
        window.scrollTo(0, 0);
        $("#boxSenha").toggle();
        $("#shad4").toggle();
        $("html, body").css({ 'overflow': 'hidden' });
    });

    $("#btnExcluirConta").click(function (e) {
        e.preventDefault();
        window.scrollTo(0, 0);
        $("#boxExcluir").toggle();
        $("#shade5").toggle();
        $("html, body").css({ 'overflow': 'hidden' });
    });

    $("#sumirPopupSenha").click(function (e) {
        e.preventDefault();
        $("#boxSenha").toggle();
        $("#shade4").toggle();
        $("html").css({ 'overflow': 'auto' });
    });

    $("#cancelarExcluir").click(function (e) {
        e.preventDefault();
        $("#boxExcluir").toggle();
        $("#shade5").toggle();
        $("html").css({ 'overflow': 'auto' });
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

        window.scrollTo(0, 0);
        $("#denuncia").toggle();
        $("#shade3").toggle();
        $("html").css({ 'overflow': 'hidden' });
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

    $("#shade4").click(function (e) {
        e.preventDefault();
        $("#boxSenha").toggle();
        $("#shade4").toggle();
        $("html").css({ 'overflow': 'auto' });
    });

    $("#shade5").click(function (e) {
        e.preventDefault();
        $("#boxExcluir").toggle();
        $("#shade5").toggle();
        $("html").css({ 'overflow': 'auto' });
    });
});