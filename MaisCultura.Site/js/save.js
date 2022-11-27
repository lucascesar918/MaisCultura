var save = document.getElementById("#btnSave");
save.addEventListener("click", verificarLogin());

function verificarLogin(e) {
    e.preventDefault();
    const urlParams = new URLSearchParams(location.search);
    var usuario = urlParams.get('l');

    if (usuario == null)
        return $("#btnLog").click();

    var evento = urlParams.get('e');

    if (save.classList.contains('naoSalvo')) {
        PageMethods.salvarEvento(usuario, evento);
        save.classList.remove('naoSalvo');
        save.classList.add('salvo');
    }
    else {
        PageMethods.removerSalvo(usuario, evento);
        save.classList.remove('salvo');
        save.classList.add('naoSalvo');
    }
}