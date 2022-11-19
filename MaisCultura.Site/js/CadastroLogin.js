
$(document).ready(function (e) {

    $("#btnCad").click(function (e) {
        e.preventDefault();
        $("#cad").toggle();
        $("#shade").toggle();
        $("html, body").css({ 'overflow': 'hidden' });
    });

    $("#btnLog").click(function (e) {
        e.preventDefault();
        $("#log").toggle();
        $("#shade").toggle();
        $("html, body").css({ 'overflow': 'hidden' });
    });

    $("#btnSairCad").click(function (e) {
        e.preventDefault();
        $("#cad").toggle();
        $("#shade").toggle();
        $("html, body").css({ 'overflow': 'auto' });
    });

    $("#btnSairLogin").click(function (e) {
        e.preventDefault();
        $("#log").toggle();
        $("#shade").toggle();
        $("html, body").css({ 'overflow': 'auto' });
    });

    $("#shade").click(function (e) {
        e.preventDefault();
        $("#pop").toggle();
        $("#shade").toggle();
        $("html, body").css({ 'overflow': 'auto' });
    });
});