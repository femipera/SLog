import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import HttpPost from '../services/HttpPost';

const AddSaida = () => {
    const [mercadoriaId, setMercadoriaId] = useState('');
    const [quantidade, setQuantidade] = useState('');
    const [dataHora, setDataHora] = useState('');
    const [local, setLocal] = useState('');
    const [mercadorias, setMercadorias] = useState([]);
    const [mensagem, setMensagem] = useState('');
    const navigate = useNavigate();

    useEffect(() => {
        fetch('https://localhost:7253/api/Mercadoria')
            .then(response => response.json())
            .then(data => setMercadorias(data))
            .catch(error => console.error('Erro ao buscar mercadorias:', error));
    }, []);

    const handleSubmit = async (e) => {
        e.preventDefault();

        let mensagemErro = '';

        if (!mercadoriaId || !quantidade || !dataHora || !local) {
            mensagemErro += 'Por favor, preencha todos os campos obrigatorios.';
        }

        if (mensagemErro) {
            window.alert(mensagemErro);
            return;
        }

        const saida = { mercadoriaId, quantidade, dataHora, local };

        const sucesso = await HttpPost('https://localhost:7253/api/Saida', saida);

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
            <h2>Adicionar uma nova Sa&iacute;da</h2>
            <form onSubmit={handleSubmit}>
                <label>Mercadoria:</label>
                <select
                    value={mercadoriaId}
                    onChange={(e) => setMercadoriaId(e.target.value)}>
                    <option value="">Selecione uma mercadoria</option>
                    {mercadorias.map((mercadoria) => (
                        <option key={mercadoria.id} value={mercadoria.id}>
                            {mercadoria.nome}
                        </option>
                    ))}
                </select>
                <label>Quantidade:</label>
                <input
                    type="number"
                    min="1"
                    value={quantidade}
                    onChange={(e) => setQuantidade(e.target.value)}
                />
                <label>Data e Hora:</label>
                <input
                    type="datetime-local"
                    value={dataHora}
                    onChange={(e) => setDataHora(e.target.value)}
                />
                <label>Local:</label>
                <input
                    type="text"
                    value={local}
                    onChange={(e) => setLocal(e.target.value)}
                />
                <button>Incluir</button>
            </form>
        </div>
    );
};

export default AddSaida;