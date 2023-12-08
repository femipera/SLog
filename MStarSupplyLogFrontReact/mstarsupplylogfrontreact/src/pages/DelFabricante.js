import React, { useState } from 'react';
import { useParams } from "react-router-dom";
import { useNavigate } from 'react-router-dom';
import HttpDelete from '../services/HttpDelete';
import HttpGet from "../services/HttpGet";

const DelFabricante = () => {
    const { id } = useParams();
    const { data: dados, isLoading, error } = HttpGet('https://localhost:7253/api/Fabricantes/' + id);
    const [mensagem, setMensagem] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();

        const sucesso = await HttpDelete('https://localhost:7253/api/Fabricantes/' + id);

        if (sucesso) {
            setMensagem('Dados excluidos com sucesso!');
            setTimeout(() => {
                navigate('/ListaFabricante');
            }, 1000);
        } else {
            setMensagem('Falha na exclusão.');
        }
    }

    return (
        <div className="create">
            {isLoading && <div>Loading...</div>}
            {error && <div>{error}</div>}
            {dados && (
                <div>
                    <h2>Confirmar a exclus&atilde;o do registro</h2>
                    <form onSubmit={handleSubmit}>
                        <h3>{dados.id} {dados.nome}</h3>  
                        <button className="form-button">Confirmar</button>                 
                    </form>
                    <p className={mensagem ? (mensagem.includes('sucesso') ? 'success' : 'error') : ''}>{mensagem}</p>
                </div>
            )}
        </div>
    );
}

export default DelFabricante;