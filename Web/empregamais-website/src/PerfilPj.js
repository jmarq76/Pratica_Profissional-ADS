import axios from "axios";
import { useEffect, useState } from "react"
import { Header } from "./Header";

export const PerfilPj = () => {
    const [dadosPerfilPj, setDadosPerfilPj] = useState({});
    const [vagasAtivas, setVagasAtivas] = useState(null);


    useEffect(() => {
        getVagas();
    }, []);

    const getVagas = () => {
        let config = {
            headers: {
                'Authorization' : JSON.parse(localStorage.getItem("user"))?.token,
        }
        };
        
        axios
        .get('https://localhost:5001/empresa/vagas/ativas', config)
        .then((res) => {
            setVagasAtivas(res.data);
        })
    };

    if(vagasAtivas){
        return (
            <div>
                <Header headerHome='true'/>
                <div>PerfilPJ</div>
                <div>Nome empresa</div>
                <div>Descricao</div>
                <div>Avaliacao da empresa</div>
                <div>Tempo Medio de Resposta</div>
                <h1>Vagas Ativas</h1>
                <div>{vagasAtivas.map((vagaAtiva) => (
                    <div className="card" key={vagaAtiva.id}>
                        <div>{vagaAtiva.titulo}</div>
                        <div>{vagaAtiva.local}</div>
                        <div>{vagaAtiva.dataExpiracao}</div>
                        <div dangerouslySetInnerHTML={{__html: vagaAtiva.descricao}}></div>
                        <div>{vagaAtiva.beneficios}</div>
                        <div>{vagaAtiva.faixaSalarial}</div>
                        <div>{vagaAtiva.idiomas}</div>
                        <div>{vagaAtiva.nivelSenioridade}</div>
                    </div>
                ))}</div>
            </div>
            
        )
    } else {
        return (
            <div>
                <Header headerHome='true'/>
                <div>Loading........</div>
            </div>
        )
    }
    
}