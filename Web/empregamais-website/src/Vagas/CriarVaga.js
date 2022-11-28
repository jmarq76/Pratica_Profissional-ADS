import axios from "axios";
import { useState } from "react"
import ReactQuill from "react-quill"
import { Header } from "../Shared/Header"

export const CriarVaga = () => {
    const [descricao, setDescricao] = useState("");
    const [vaga, setVaga] = useState({});
    const [response, setResponse] = useState("");

    const handleChange = (event) => {
        const nome = event.target.name;
        const valor = event.target.value;
        setVaga(values => ({...values, [nome]: valor}));
    };

    const handleDescricao = () => {
        setVaga(values => ({...values, ["descricao"]: descricao}));
    }

    const handleSave = () => {
        
        saveData();
        
    }

    const saveData = () => {
        let config = {
            headers: {
                'Authorization' : JSON.parse(localStorage.getItem("user"))?.token,
        }
    };

        axios
        .post('https://localhost:5001/empresa/cadastravaga', vaga, config)
        .then((res) => {
            setResponse(res);
        })
    }

    return (
        <div>
            <Header headerHome='true'/>
            <div>Criar vaga</div>
            <div>Titulo</div>
            <input value={vaga.titulo || ""} onChange={handleChange} name="titulo"></input>
            <div>Data Expiracao</div>
            <input type="date" value={vaga.dataExpiracao || ""} onChange={handleChange} name="dataExpiracao"></input>
            <div>Senioridade</div>
            <input value={vaga.nivelSenioridade || ""} onChange={handleChange} name="nivelSenioridade"></input>
            <div>Faixa Salarial</div>
            <input value={vaga.faixaSalarial || ""} onChange={handleChange} name="faixaSalarial"></input>
            <div>Local</div>
            <input value={vaga.local || ""} onChange={handleChange} name="local"></input>
            <div>Beneficios</div>
            <input></input>
            <div>Descricao</div>
            <ReactQuill theme="snow" value={descricao} onChange={setDescricao} onBlur={handleDescricao}/>
            <div>Lingua</div>
            <input ></input>
            <div>Fluencia</div>
            <input></input>
            <div>Outros Requisitos</div>
            <input value={vaga.outrosRequisitos || ""} onChange={handleChange} name="outrosRequisitos"></input>
            <button onClick={handleSave}>Save</button>
        </div>
    )
}