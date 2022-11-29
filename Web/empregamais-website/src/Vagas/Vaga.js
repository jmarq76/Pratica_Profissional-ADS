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
        if(!JSON.parse(localStorage.getItem("user"))){
            navigate('/login')
        } else {
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
            setResponseData(err);
        })
        }
            
    };

    const handleDenunciaVaga = () => {
        if(!JSON.parse(localStorage.getItem("user"))){
            navigate('/login')
        }
        else{
            navigate('/denunciavaga/' + vagaId);
        }
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
    console.log(vaga);
    if(vaga){
        return(
            <div>
                <Header />
                <div className="main-div-vaga">
                    <div className="dados-div-vaga titulo-div-vaga">{vaga.Vaga.Titulo}</div>
                    <div className="dados-div-vaga dados-empresa-div-vaga">{vaga.Usuario.Nome}</div>
                    <div className="dados-div-vaga dados-empresa-div-vaga">{vaga.Vaga.Local}</div>
                    <div className="dados-div-vaga dados-empresa-div-vaga">Faixa Salarial: R$ {vaga.Vaga.FaixaSalarial}</div>
                    <div className="dados-div-vaga dados-empresa-div-vaga">{vaga.Vaga.NivelSenioridade}</div>
                    <div className="dados-div-vaga expira-div-vaga">Expira em: {new Date(vaga.Vaga.DataExpiracao).toLocaleDateString()}</div>
                    <div className="dados-div-vaga descricao-div-vaga">{vaga.Vaga.Descricao}</div>
                    {/* <div className="dados-div-vaga">{vaga.Vaga.Beneficios}</div>
                    <div className="dados-div-vaga">{vaga.Vaga.Idiomas}</div> */}
                    <div className="dados-div-vaga descricao-div-vaga">{vaga.Vaga.OutrosRequisitos}</div>
                    <button onClick={enviarCurriculo} className="btn-curriculo">Enviar Currículo</button>
                    <button onClick={handleDenunciaVaga} className="btn-denuncia">Denunciar</button>
                    {responseData === null ? "" : responseData === "CadastroJaFeito" ? <h2>O seu currículo já está cadastrado nesta vaga</h2> : <h2>Currículo Enviado com Sucesso</h2>}
                </div>
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