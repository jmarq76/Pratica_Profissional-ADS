import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Header } from "../Shared/Header"

export const DenunciaVaga = () => {
    const { vagaId } = useParams();
    const [vaga, setVaga] = useState(null);
    const [denunciaVaga, setDenunciaVaga] = useState({});
    const [responseStatus, setResponseStatus] = useState("");

    const handleDenunciaVaga = (e) => {
        const name = e.target.name;
        const value = e.target.value;
        setDenunciaVaga({...denunciaVaga, [name]: value });
    }

    const handleSaveDenuncia = () => {
        enviaDenuncia();
    };

    const enviaDenuncia = () => {
        const config = {
            headers: {
                'Authorization' : JSON.parse(localStorage.getItem("user"))?.token,
        }
    };

    axios
    .post('https://localhost:5001/denunciaVaga', denunciaVaga, config)
    .then((res) => {
        setResponseStatus(res.status);
    }).catch((err) => {
        setResponseStatus(err);
    })
    }
    useEffect(() => {
        getVaga();
    }, []);

    const getVaga = () => {

        axios
        .get('https://localhost:5001/vagas/buscaVaga?textoBusca='+ vagaId)
        .then((res) => {
            setVaga(res.data);
            setDenunciaVaga({...denunciaVaga, ["idPerfilPj"]: res.data.Usuario.IdPerfil, ["idVaga"] : vagaId, ["usuarioCriacao"] : JSON.parse(localStorage.getItem("user"))?.id});
        })
            .catch((err) => {
            });
        };

        
    if(vaga){
        return (
            <div>
                <Header />
                <div>Denunciar Vaga</div>
                <div>{vaga.Vaga.Titulo}</div>
                <form>
                    <div>Descrição Denúncia</div>
                    <textarea value={denunciaVaga.descricao} onChange={handleDenunciaVaga} name="descricao"></textarea>
                    <div>Tipo Denuncia</div>
                    <label>Informações Enganadoras</label>
                    <input type='radio' name="tipoDenuncia" value={1} onChange={handleDenunciaVaga}></input>
                    <label>Possível Golpe</label>
                    <input type='radio' name="tipoDenuncia" value={2} onChange={handleDenunciaVaga}></input>
                    <label>Descrição da vaga pouco clara</label>
                    <input type='radio' name="tipoDenuncia" value={3} onChange={handleDenunciaVaga}></input>
                    <label>Descrição da vaga muito curta</label>
                    <input type='radio' name="tipoDenuncia" value={4} onChange={handleDenunciaVaga}></input>
                    <label>Vaga fazendo discriminação</label>
                    <input type='radio' name="tipoDenuncia" value={5} onChange={handleDenunciaVaga}></input>
                </form>
                <button onClick={handleSaveDenuncia}>Enviar Denúncia</button>
            </div>
        )
    }
    
}