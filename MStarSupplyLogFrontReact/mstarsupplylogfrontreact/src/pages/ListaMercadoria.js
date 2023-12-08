import HttpGet from "../services/HttpGet";
import MostrarLista from "../utils/MostrarLista";

const ListaMercadoria = () => {
    const { error, isLoading, data: lista } = HttpGet('https://localhost:7253/api/Mercadoria')
    const page = 'Mercadoria';
    const titulo = 'Lista de Mercadorias';

    return (
        <div className="home">
            {error && <div>{error}</div>}
            {isLoading && <div>Atualizando...</div>}
            {lista && <MostrarLista titulo={titulo} page={page} lista={lista} />}
        </div>
    );
}

export default ListaMercadoria;