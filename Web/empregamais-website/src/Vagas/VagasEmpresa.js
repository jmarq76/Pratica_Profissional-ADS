import axios from "axios";
import { useEffect, useState } from "react"
import { Link } from "react-router-dom";
import { Header } from "../Shared/Header"

export const VagasEmpresa = () => {
    const [vagas, setVagas] = useState(null);


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
        .get('https://localhost:5001/vagas/listaVagasEmpresa', config)
        .then((res) => {
            setVagas(res.data);
        })
    };
    
    if(vagas){
        return (
            <div>
                <Header headerHome='true'/>
                <h1>Vagas Ativas</h1>
                <div>{vagas.vagasAtivas.map((vagaAtiva) => (
                    <div className='card' key={vagaAtiva.id}>
                        <Link to={vagaAtiva.id}>{vagaAtiva.titulo}</Link>
                        <div>{vagaAtiva.local}</div>
                        <div>{vagaAtiva.dataExpiracao}</div>
                        <div dangerouslySetInnerHTML={{__html: vagaAtiva.descricao.slice(0, 500)+ '...'}}></div>
                        <div>{vagaAtiva.beneficios}</div>
                        <div>{vagaAtiva.faixaSalarial}</div>
                        <div>{vagaAtiva.idiomas}</div>
                        <div>{vagaAtiva.nivelSenioridade}</div>
                    </div>
                ))}</div>
                <h1>Vagas Inativas</h1>
                <div>{vagas.vagasInativas.map((vagaInativa) => (
                    <div className='card' key={vagaInativa.id}>
                        <div>{vagaInativa.titulo}</div>
                        <div>{vagaInativa.local}</div>
                        <div>{vagaInativa.dataExpiracao}</div>
                        <div dangerouslySetInnerHTML={{__html: vagaInativa.descricao?.slice(0, 500)+ '...'}}></div>
                        <div>{vagaInativa.beneficios}</div>
                        <div>{vagaInativa.faixaSalarial}</div>
                        <div>{vagaInativa.idiomas}</div>
                        <div>{vagaInativa.nivelSenioridade}</div>
                    </div>
                ))}</div>
            </div>
        )
    } else {
        <div>
            <Header headerHome='true'/>
            <div>Loading.......</div>
        </div>
    }
    
}