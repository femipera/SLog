import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import HttpPost from '../services/HttpPost';

const AddTipoMercadoria = () => {
    const [nome, setNome] = useState('');
    const [mensagem, setMensagem] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();

        const tipoMercadoria = { nome };

        const sucesso = await HttpPost('https://localhost:7253/api/TipoMercadoria', tipoMercadoria);

        if (sucesso) {
            setMensagem('Dados adicionados com sucesso!');
            setTimeout(() => {
                navigate('/ListaTipoMercadoria');
            }, 1000);
        } else {
            setMensagem('Falha ao adicionar dados.');
        }
    }

    return (
        <div className="create">
            <h2>Adicionar um novo tipo de mercadoria</h2>
            <form onSubmit={handleSubmit}>
                <label>Nome do tipo de mercadoria:</label>
                <input
                    type="text"
                    required
                    value={nome}
                    onChange={(e) => setNome(e.target.value)}
                />
                <button>Incluir</button>
            </form>
            <p className={mensagem ? (mensagem.includes('sucesso') ? 'success' : 'error') : ''}>{mensagem}</p>
        </div>
    );
}

export default AddTipoMercadoria;