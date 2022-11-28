import axios from "axios";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Header } from "../Shared/Header"

export const HistoricoVagas = () => {
    const [histVagas, setHistVagas] = useState({});

    const getHistVagas = () => {
        const config = {
            headers: {
                'Authorization' : JSON.parse(localStorage.getItem("user"))?.token,
            }
        };

        axios
        .get('https://localhost:5001/perfilpf/historicovagas', config)
        .then((response) => {
            setHistVagas(response.data);
        }).catch((err) => {

        });
    };

    useEffect(() => {
        getHistVagas();
    }, []);

    console.log(histVagas);
    if(histVagas.length > 0){
        return (
            <div>
                <Header />
                <div>Historico Vagas</div>
                {histVagas.map((histvaga) => (
                    <div key={histvaga.vaga.id}>
                        <Link to={"/vagas/" + histvaga.vaga.id}>{histvaga.vaga.titulo}</Link>
                        <div>{histvaga.empresa.nome}</div>
                        <div>Data envio currículo: {new Date(histvaga.vagaUsuario.dataEnvioPerfilPf).toLocaleDateString()}</div>
                        <div>{histvaga.vaga.descricao}</div>
                    </div>
                ))}
            </div>
        )
    }
    
}