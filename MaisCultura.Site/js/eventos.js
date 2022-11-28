console.log("TA FELIZ LUCAS?"); //TÔ JOÃO PEDRO, EU TÔ; SÓ FALTOU USAR A PORRA DA API

var categorias = document.querySelectorAll(".categoria");
var localTags = document.getElementById("localTags");
var btnLimpar = document.getElementById("btnLimpar");

for (var i = 0; i < categorias.length; i++) {
    let item = categorias[i];
    item.addEventListener("click", () => { adicionar(item) });
}

btnLimpar.addEventListener("click", excluirTodasTags);

function adicionar(cat) {
    //Verificando quantidade de tags
    let tags = document.querySelectorAll(".tag-header");
    if (tags.length >= 3)
        return

    let text = cat.textContent;

    //Verificando se já existe a tag na lista
    let verificarTag = document.querySelectorAll("." + text);
    if (verificarTag.length > 0)
        return

    //Criando a article tag
    let tag = document.createElement("article");
    tag.classList.add("tag");
    tag.classList.add("tag-header");
    tag.classList.add(text)
    tag.textContent = text;

    //Criando o botão
    let buttonExclude = document.createElement("article");
    buttonExclude.classList.add("button");
    buttonExclude.classList.add("button-exclude");
    buttonExclude.textContent = "X";

    //Adicionando o evento no botão
    buttonExclude.addEventListener("click", () => { excluir(buttonExclude) });

    //Colocando tudo no HTML
    tag.appendChild(buttonExclude);
    localTags.appendChild(tag)

    filtrar();
}

function excluir(item) {
    item.parentNode.remove();
    filtrar();
}

function excluirTodasTags() {
    let tags = document.querySelectorAll(".tag-header");

    for (var i = 0; i < tags.length; i++) {
        tags[i].remove()
    }

    mostrarTudo();
}

function filtrar() {
    let H2Tags = document.querySelectorAll("h2.tag");
    let tags = document.querySelectorAll(".tag-header");

    if (tags.length == 0) 
        return mostrarTudo();

    for (var i = 0; i < H2Tags.length; i++) {
        let pai = H2Tags[i].parentNode.parentNode;
        pai.querySelector(".card-header").style.display = 'none';
        pai.querySelector(".card-tags").style.display = 'none';
        pai.querySelector(".dateTime").style.display = 'none';
        pai.querySelector(".date").style.display = 'none';
        pai.querySelector(".time").style.display = 'none';
        pai.querySelector(".card-local").style.display = 'none';
        pai.style.display = 'none';
    }

    for (var j = 0; j < tags.length; j++) {
        let text = tags[j].textContent;
        text = text.substring(0, text.length - 1)

        for (var k = 0; k < H2Tags.length; k++) {
            let teste = H2Tags[k].textContent;

            if (text == teste) {
                let pai = H2Tags[k].parentNode.parentNode;
                pai.querySelector(".card-header").style.display = 'flex';
                pai.querySelector(".card-tags").style.display = 'flex';
                pai.querySelector(".dateTime").style.display = 'flex';
                pai.querySelector(".date").style.display = 'flex';
                pai.querySelector(".time").style.display = 'flex';
                pai.querySelector(".card-local").style.display = 'flex';
                pai.style.display = 'block';
            }
        }
    }
}

function mostrarTudo() {
    let H2Tags = document.querySelectorAll("h2.tag");

    for (var i = 0; i < H2Tags.length; i++) {
        let pai = H2Tags[i].parentNode.parentNode;
        pai.querySelector(".card-header").style.display = 'flex';
        pai.querySelector(".card-tags").style.display = 'flex';
        pai.querySelector(".dateTime").style.display = 'flex';
        pai.querySelector(".date").style.display = 'flex';
        pai.querySelector(".time").style.display = 'flex';
        pai.querySelector(".card-local").style.display = 'flex';
        pai.style.display = 'block';
    }
}