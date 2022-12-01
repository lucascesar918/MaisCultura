$("#alteraSenha").click(function (e) {
    e.preventDefault();
    $("#boxSenha").toggle();
});

$("#sumirPopupSenha").click(function (e) {
    e.preventDefault();
    $("#boxSenha").toggle();
});

$("#btnExcluirConta").click(function (e) {
    e.preventDefault();
    $("#boxExcluir").toggle();
});

$("#cancelarExcluir").click(function (e) {
    e.preventDefault();
    $("#boxExcluir").toggle();
});