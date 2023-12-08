import HttpGet from "../services/HttpGet";
import MostrarLista from "../utils/MostrarLista";


const ListaTipoMercadoria = () => {
    const { error, isLoading, data: lista } = HttpGet('https://localhost:7253/api/TipoMercadoria')
    const page = 'TipoMercadoria';
    const titulo = 'Lista dos tipos de mercadoria';

    return (
        <div className="home">
            {error && <div>{error}</div>}
            {isLoading && <div>Atualizando...</div>}
            {lista && <MostrarLista titulo={titulo} page={page} lista={lista} />}
        </div>
    );
}

export default ListaTipoMercadoria;