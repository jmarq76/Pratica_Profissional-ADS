import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom"
import { Header } from "../Shared/Header";

export const Vaga = () => {
    const { vagaId } = useParams();
    const [vaga, setVaga] = useState(null);
    const [responseData, setResponseData] = useState(null);
    const [dadosVaga, setDadosVaga] = useState({});
    const navigate = useNavigate();

    const enviarCurriculo = () => {
            const config = {
                headers: {
                    'Authorization' : JSON.parse(localStorage.getItem("user"))?.token,
            }
        };

        axios
        .post('https://localhost:5001/perfilpf/enviarcurriculo', dadosVaga, config)
        .then((res) => {
            setResponseData(res.data);
        }).catch((err) => {
            setResponseStatus(err);
        })
    };

    const handleDenunciaVaga = () => {
        navigate('/denunciavaga/' + vagaId);
    }

    useEffect(() => {
        getVaga();
        setDadosVaga({['IdVaga'] : vagaId});
    }, []);

    const config = {
        headers: {
            'Access-Control-Allow-Origin' : '*'
    }
};

    const getVaga = () => {
    axios
    .get('https://localhost:5001/vagas/buscaVaga?textoBusca='+ vagaId, config)
    .then((res) => {
        setVaga(res.data);
    })
        .catch((err) => {
        });
    };

    if(vaga){
        return(
            <div>
                <Header headerHome='true'/>
                <div>
                    {vaga.Vaga.Titulo}
          </div>
          <div>Nome Empresa</div>
          <div>{vaga.Vaga.Local}</div>
          <div>Faixa Salarial: {vaga.Vaga.FaixaSalarial}</div>
          <div>{vaga.Vaga.NivelSenioridade}</div>
          <div>Expira em: {new Date(vaga.Vaga.DataExpiracao).toLocaleDateString()}</div>
          <div>{vaga.Vaga.Descricao}</div>
          <div>{vaga.Vaga.Beneficios}</div>
          <div>{vaga.Vaga.Idiomas}</div>
          <div>{vaga.Vaga.OutrosRequisitos}</div>
          <button onClick={enviarCurriculo}>Enviar Currículo</button>
          <button onClick={handleDenunciaVaga}>Denunciar</button>
          {responseData === null ? "" : responseData === "CadastroJaFeito" ? <h2>O seu currículo já está cadastrado nesta vaga</h2> : <h2>Currículo Enviado com Sucesso</h2>}
            </div>
        )
    } else {
        return(
            <div>
                Carregando vaga....
            </div>
        )
    }
    
}