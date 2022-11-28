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
        $("#denuncia").toggle();
        $("#shade3").toggle();
        $("html").css({ 'overflow': 'auto' });
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