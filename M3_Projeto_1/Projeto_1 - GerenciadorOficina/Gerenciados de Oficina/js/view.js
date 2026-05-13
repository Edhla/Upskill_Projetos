/** Inicia as funções fudamentais para o programa */
function initProgram() {
    getLocalVeiculos()
    render(null)
    initEventListener()
}

/** Renderiza a tabela body baseado no db */
function render(event) {
    let tabela = document.getElementById("tabela")
    tabela.innerHTML = ""
    if (veiculos != null && Object.keys(veiculos).length > 0) {
        let dados = veiculos
        if (event != null && event.target.value != "") {
            cleanForm(event)
            let atributo = event.target.id.replace("f", "").toLowerCase()
            dados = []
            veiculos.map(f => { if (`${f[atributo]}` == event.target.value) dados.push(f) })
        }
        count = 0
        dados.forEach((item) => {
            let tr = document.createElement("tr")
            tr.id = count
            let atributeArray = Object.keys(item)
            for (atribute in atributeArray) {
                let td = document.createElement("td")
                switch (atributeArray[atribute]) {
                    case "ultimaInspecao":
                        td.innerHTML = viewUltimaInspecao(item[atributeArray[atribute]])
                        break
                    case "vendido":
                        td.innerHTML = viewEstado(item[atributeArray[atribute]])
                        break
                    default: td.innerText = item[atributeArray[atribute]]
                }
                tr.appendChild(td)
            }
            btnEditRemove(tr)
            tabela.appendChild(tr)
            count++
        })
    }
    initEventListener()
    filtro()
}

/** Criar o texto da ultima inspeção */
function viewUltimaInspecao(date) {
    let newDate = new Date(date)
    const year = newDate.getFullYear()
    const moth = newDate.getMonth()
    const day = newDate.getDate()
    return `${year}/${moth}/${day} (${inspecaoEstado(date)})`
}

/** Criar o texto de Estado */
function viewEstado(vendido) {
    if (vendido) return '<p class="vendido">Vendido</p>'
    else return '<p class="ok">Disponivél</p>'
}

// --------------------------------------------------
// EVENTOS
// --------------------------------------------------

/** Direciona o evento para a função especifica */
function btnEvent(e) {
    if (e.target.id.includes("carregarLS")) {
        alert("Reiniciar")
        reInitDb()
    }
    else if (e.target.id.includes("limparLS")) {
        alert("Limpar")
        cleanDb()
    }
    else if (e.target.id.includes("guardar")) {
        alert("guardar")
        guardarNewVeiculo()
    }
    else if (e.target.id.includes("edit")) {
        alert("Editar")
        editar(e.target.id)
    }
    else if (e.target.id.includes("remove")) {
        alert("Remover")
    }
}

/** Inicar todos os eventos na pagina */
function initEventListener() {
    let btn = [...document.getElementsByTagName("button")]
    btn.forEach((f) => f.addEventListener('click', btnEvent))
}

// --------------------------------------------------
// VIEW DADOS
// --------------------------------------------------

/** Verifica o status do veiculo */
function inspecaoEstado(data) {
    const agora = new Date();
    const diffMeses = (agora - data) / (1000 * 60 * 60 * 24 * 30);
    if (diffMeses > 12) return '<span class="vendido">Expirada</span>';
    if (diffMeses > 10) return '<span class="aviso">A expirar</span>';
    return '<span class="ok">Válida</span>';
}

/** Editar veiculo */
function editar(i) {
    i = i.replace("edit", "")
    let marca = document.getElementById("marca")
    let modelo = document.getElementById("modelo")
    let ano = document.getElementById("ano")
    let inspecao = document.getElementById("inspecao")
    let vendido = document.getElementById("vendido")

    document.getElementById('editIndex').value = i;
    const v = veiculos[i];
    marca.value = v.marca;
    modelo.value = v.modelo;
    ano.value = v.ano;
    inspecao.value = toInputDateLocal(new Date(v.ultimaInspecao)); // sem fusos horários envolvidos
    vendido.checked = v.vendido;
};

/** Guardar novo veiculo no ojeto db e depois no local storage */
function guardarNewVeiculo() {
    let i = document.getElementById('editIndex').value
    let marca = document.getElementById("marca")
    let modelo = document.getElementById("modelo")
    let ano = document.getElementById("ano")
    let inspecao = document.getElementById("inspecao")
    let vendido = document.getElementById("vendido")

    if (i != "") {
        veiculos[i].marca = marca.value
        veiculos[i].modelo = modelo.value
        veiculos[i].ano = ano.value
        veiculos[i].ultimaInspecao = inspecao.value
        veiculos[i].vendido = vendido.checked
    }
    else {
        let newVeiculo = {
            marca: marca.value,
            modelo: modelo.value,
            ano: ano.value,
            ultimaInspecao: inspecao.value,
            vendido: vendido.value
        }
        veiculos[veiculos.length] = newVeiculo
    }
    [marca, modelo, ano, inspecao, vendido].forEach(f => {
        f = ""
    });
    guardar()
    render(null)
}


// --------------------------------------------------
// FORMULARIOS
// --------------------------------------------------
/** Limpa todos formularios excepto o que sofreu o evento */
function cleanForm(event) {
    console.log(event)
    let except = ""
    if(event.target.value != null){
        except = event.target.value
    }
    let marca = document.getElementById("marca")
    let modelo = document.getElementById("modelo")
    let ano = document.getElementById("ano")
    let inspecao = document.getElementById("inspecao")
    let vendido = document.getElementById("vendido")
    let fMarca = document.getElementById("fMarca")
    let fAno = document.getElementById("fAno")
    let fVendido = document.getElementById("fVendido")
    console.log(fVendido)
    let array = [marca,modelo,ano,inspecao,vendido,fMarca,fAno,fVendido]
    array.forEach((f) => {
        if(f.value != except) f.value = ""
    })
}

/** Criar os btn de Editar e remover */
function btnEditRemove(parent) {
    let edit = document.createElement("button")
    edit.id = "edit" + parent.id
    edit.innerText = "Editar"
    let remove = document.createElement("button")
    remove.id = "remove" + parent.id
    remove.innerText = "Remover"
    parent.appendChild(edit)
    parent.appendChild(remove)
}

// --------------------------------------------------
// FILTROS
// --------------------------------------------------

/** Criar option dentro dos select */
function filtro() {
    if (veiculos != null && Object.keys(veiculos).length > 0) {
        let veiculosArray = [...veiculos]
        let marcaSet = [...new Set(veiculosArray.map(item => item.marca))]
        let anoSet = [...new Set(veiculosArray.map(item => item.ano))]
        let fMarca = document.getElementById("fMarca")
        let fAno = document.getElementById("fAno")
        let fVendido = document.getElementById("fVendido")

        marcaSet.forEach((item) => {
            createSelect(item, fMarca)
        })
        anoSet.forEach((item) => {
            createSelect(item, fAno)
        })
        let arrayTeste = [fMarca, fAno, fVendido]
        arrayTeste.forEach(f => f.addEventListener('change', render));
    }
}

/** Criar option e fixar ao parent */
function createSelect(valor, parent) {
    let option = document.createElement("option")
    option.value = valor
    option.innerText = valor
    parent.appendChild(option)
}