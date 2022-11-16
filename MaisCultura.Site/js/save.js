var saves = document.querySelectorAll(".save");

for (var i = 0; i < saves.length; i++) {
    let save = saves[i];
    save.addEventListener("click", () => { mudarSave(save) });
}

function mudarSave(save) {
    if (save.classList.contains('naoSalvo')) {
        save.classList.remove('naoSalvo');
        save.classList.add('salvo');
    }
    else {
        save.classList.remove('salvo');
        save.classList.add('naoSalvo');
    }
}