import HttpGet from "../services/HttpGet";
import MostrarLista from "../utils/MostrarLista";


const ListaFabricante = () => {
    const { error, isLoading, data: lista } = HttpGet('https://localhost:7200/api/Fabricante')
    const page = 'Fabricante';
    const titulo = 'Lista de fabricantes';

    return (
        <div className="home">
            {error && <div>{error}</div>}
            {isLoading && <div>Atualizando...</div>}
            {lista && <MostrarLista titulo={titulo} page={page} lista={lista} />}
        </div>
    );
}

export default ListaFabricante;