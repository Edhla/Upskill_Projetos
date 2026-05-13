//import { VeiculoService } from "./db";

let veiculos = {}

// --------------------------------------------------------
// LOCAL STORAGE MANIPULATION
// --------------------------------------------------------


/** Buscar dados no local storage para veiculos */
async function getLocalVeiculos() {
    veiculos = await VeiculoService.getAll();
    await console.log(veiculos);
}

/** Guarda dados do veiculo no local storage */
function guardar() {
    localStorage.setItem('veiculos', JSON.stringify(veiculos));
}

// --------------------------------------------------------
// vEICULOS MANIPULATION
// --------------------------------------------------------

/** Reinicia veiculos para o dados iniciais */
function reInitDb() {
    localStorage.clear()
    veiculos = db
    render();
    guardar()
}

/** Limpa todos os dados dentro de veiculos */
function cleanDb() {
    localStorage.clear()
    veiculos = {}
    render();
}

// --------------------------------------------------------
// FUNÇÕES GENÉRICAS
// --------------------------------------------------------

/** Data local */
function toInputDateLocal(d) {
    const pad = n => String(n).padStart(2, "0");
    return `${d.getFullYear()}-${pad(d.getMonth() + 1)}-${pad(d.getDate())}`;
}
/** Definir data */
function setDate(y, m, d) {
    let tmp = new Date(y, m, d);
    tmp.setMonth(tmp.getMonth() - 1);
    return tmp;
}