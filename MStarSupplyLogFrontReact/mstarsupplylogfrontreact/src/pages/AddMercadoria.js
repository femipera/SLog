import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import HttpPost from '../services/HttpPost';

const AddMercadoria = () => {
    const [nome, setNome] = useState('');
    const [descricao, setDescricao] = useState('');
    const [numeroRegistro, setNumeroRegistro] = useState('');
    const [tipoMercadoriaId, setTipoMercadoriaId] = useState('');
    const [fabricanteId, setFabricanteId] = useState('');
    const [tiposMercadoria, setTiposMercadoria] = useState([]);
    const [fabricantes, setFabricantes] = useState([]);
    const [mensagem, setMensagem] = useState('');
    const navigate = useNavigate();

    useEffect(() => {
        fetch('https://localhost:7253/api/TipoMercadoria')
            .then(response => response.json())
            .then(data => setTiposMercadoria(data))
            .catch(error => console.error('Erro ao buscar tipos de mercadoria:', error));

        fetch('https://localhost:7253/api/Fabricantes')
            .then(response => response.json())
            .then(data => setFabricantes(data))
            .catch(error => console.error('Erro ao buscar fabricantes:', error));
    }, []);

    const handleSubmit = async (e) => {
        e.preventDefault();

        let mensagemErro = '';

        if (nome.length < 3) {
            mensagemErro += 'Nome deve ter no minimo 3 caracteres.\n';
        }

        if (descricao.length < 7) {
            mensagemErro += 'Descricao deve ter no mínimo 7 caracteres.\n';
        }

        if (!tipoMercadoriaId || !fabricanteId) {
            mensagemErro += 'Por favor, preencha todos os campos obrigatorios.';
        }

        if (mensagemErro) {
            window.alert(mensagemErro);
            return;
        }

        const mercadoria = { nome, descricao, numeroRegistro, tipoMercadoriaId, fabricanteId };

        const sucesso = await HttpPost('https://localhost:7253/api/Mercadoria', mercadoria);

        if (sucesso) {
            setMensagem('Dados adicionados com sucesso!');
            setTimeout(() => {
                navigate('/ListaMercadoria');
            }, 1000);
        } else {
            setMensagem('Falha ao adicionar dados.');
        }
    }

    return (
        <div className="create">
            <h2>Adicionar uma nova mercadoria</h2>
            <form onSubmit={handleSubmit}>
                <label>Nome:</label>
                <input
                    type="text"
                    value={nome}
                    onChange={(e) => setNome(e.target.value)} />
                <label>Descri&ccedil;&atilde;o:</label>
                <textarea
                    type="text"
                    value={descricao}
                    onChange={(e) => setDescricao(e.target.value)} />
                <label> N&uacute;mero do Registro </label>
                <input
                    type="number"
                    min="1"
                    pattern="[0-9]*"
                    inputMode="numeric"
                    onKeyDown={(e) => {
                        if (!((e.key >= '0' && e.key <= '9') || e.key === 'Backspace' || e.key === 'Delete' || e.key === 'ArrowLeft' || e.key === 'ArrowRight')) {
                            e.preventDefault();
                        }
                    }}
                    value={numeroRegistro}
                    onChange={(e) => setNumeroRegistro(e.target.value)} /> 
                <label>Tipo de Mercadoria:</label>
                <select
                    value={tipoMercadoriaId}
                    onChange={(e) => setTipoMercadoriaId(e.target.value)}>
                    <option value="">Selecione um tipo</option>
                    {tiposMercadoria.map((tipo) => (
                        <option key={tipo.id} value={tipo.id}>
                            {tipo.nome}
                        </option>
                    ))}
                </select>
                <label>Fabricante:</label>
                <select
                    value={fabricanteId}
                    onChange={(e) => setFabricanteId(e.target.value)}>
                    <option value="">Selecione um fabricante</option>
                    {fabricantes.map((fabricante) => (
                        <option key={fabricante.id} value={fabricante.id}>
                            {fabricante.nome}
                        </option>
                    ))}
                </select>
                <button>Incluir</button>
            </form>
        </div>
    );
};

export default AddMercadoria;