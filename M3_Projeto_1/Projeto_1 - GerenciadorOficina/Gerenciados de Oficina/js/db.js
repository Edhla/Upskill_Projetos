const BASE_URL = "http://localhost:5013";

// ─────────────────────────────────────────────
// Utilitário central de fetch
// ─────────────────────────────────────────────
async function request(method, path, body = null) {
    const options = {
        method,
        headers: { "Content-Type": "application/json" },
    };
    if (body !== null) {
        options.body = JSON.stringify(body);
    }

    const response = await fetch(`${BASE_URL}${path}`, options);

    if (response.status === 404) return null;
    if (!response.ok) {
        const text = await response.text();
        throw new Error(`Erro ${response.status}: ${text}`);
    }

    // Respostas sem corpo (ex.: 200 OK em PUT/DELETE)
    const contentType = response.headers.get("Content-Type") || "";
    if (contentType.includes("application/json")) {
        return response.json();
    }
    return null;
}

// ─────────────────────────────────────────────
// MARCAS
// ─────────────────────────────────────────────
const MarcaService = {
    /** Devolve todas as marcas */
    getAll() {
        return request("GET", "/marcas");
    },

    /** Devolve uma marca pelo id; null se não encontrada */
    getById(id) {
        return request("GET", `/marcas/${id}`);
    },

    /**
     * Insere uma nova marca.
     * @param {{ nome: string }} marca
     * @returns {{ id: number }}
     */
    insert(marca) {
        return request("POST", "/marcas", marca);
    },

    /**
     * Atualiza uma marca existente.
     * @param {{ id: number, nome: string }} marca
     */
    update(marca) {
        return request("PUT", "/marcas", marca);
    },

    /** Remove uma marca pelo id */
    delete(id) {
        return request("DELETE", `/marcas/${id}`);
    },
};

// ─────────────────────────────────────────────
// MODELOS
// ─────────────────────────────────────────────
const ModeloService = {
    /** Devolve todos os modelos */
    getAll() {
        return request("GET", "/modelos");
    },

    /** Devolve um modelo pelo id; null se não encontrado */
    getById(id) {
        return request("GET", `/modelos/${id}`);
    },

    /**
     * Insere um novo modelo.
     * @param {{ nome: string, marcaId: number }} modelo
     * @returns {{ id: number }}
     */
    insert(modelo) {
        return request("POST", "/modelos", modelo);
    },

    /**
     * Atualiza um modelo existente.
     * @param {{ id: number, nome: string, marcaId: number }} modelo
     */
    update(modelo) {
        return request("PUT", "/modelos", modelo);
    },

    /** Remove um modelo pelo id */
    delete(id) {
        return request("DELETE", `/modelos/${id}`);
    },
};

// ─────────────────────────────────────────────
// VEÍCULOS
// ─────────────────────────────────────────────
const VeiculoService = {
    /** Devolve todos os veículos */
    getAll() {
        return request("GET", "/veiculos");
    },

    /** Devolve um veículo pelo id; null se não encontrado */
    getById(id) {
        return request("GET", `/veiculos/${id}`);
    },

    /**
     * Insere um novo veículo.
     * @param {{ modeloId: number, ano: number, ultimaInspecao: string, vendido: boolean }} veiculo
     * @returns {{ id: number }}
     */
    insert(veiculo) {
        return request("POST", "/veiculos", veiculo);
    },

    /**
     * Atualiza um veículo existente.
     * @param {{ id: number, modeloId: number, ano: number, ultimaInspecao: string, vendido: boolean }} veiculo
     */
    update(veiculo) {
        return request("PUT", "/veiculos", veiculo);
    },

    /** Remove um veículo pelo id */
    delete(id) {
        return request("DELETE", `/veiculos/${id}`);
    },
};

// ─────────────────────────────────────────────
// Exportações (ESM)  –  apague se usar <script> simples
// ─────────────────────────────────────────────
//export { MarcaService, ModeloService, VeiculoService };
