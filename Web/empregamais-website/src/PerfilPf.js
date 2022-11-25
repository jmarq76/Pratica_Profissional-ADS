import axios from "axios";
import React, { useEffect, useState } from "react";
import { Header } from "./Header"
import 'react-quill/dist/quill.snow.css';
import { Navigate } from "react-router-dom";
import ReactQuill from "react-quill";

export const PerfilPf = () => {
    const [dados, setDados] = useState([]);
    const [resumoProf, setResumoProf] = useState("");
    const [infoComp, setInfoComp] = useState("");
    const [status, setStatus] = useState("");
    const [inputs, setInputs] = useState({});

    const handleChange = (e) => {
        const name = e.target.name;
        const value = e.target.value;
        setInputs(values => ({values, [name]: value}))
    }

    useEffect(() => {
        getData();
    }, []);

    const getData = () => {

        const config = {
            headers: {
                'Authorization' : JSON.parse(localStorage.getItem("user"))?.token,
        }
    };

        axios
        .get('https://localhost:5001/perfilpf/busca', config)
        .then((response) => {
            setDados(response.data);
            
        }).catch((error) => {
            setStatus(error.response.status);
        })
    };
    
    if(dados.id){
        return (
            <div>
                <Header headerHome={true}/>
                <div className="perfil-main-div">
                    <div>{dados.usuario.nome}</div>
                    <div>{dados.usuario.contatos.map((contato) => (
                        <div key={contato.id}>
                            <div>{contato.descricao}</div>
                            </div>
                    ))}</div>
                    <div>{dados.usuario.enderecos.logradouro}</div>
                </div>
                <div className="perfil-dados-div">
                    <div>Cargo Desejado</div>
                    <input></input>
                    <div>Areas Desejadas</div>
                    <input></input>
                    <input></input>
                    <input></input>
                    <div>Pretensao Salarial</div>
                    <input></input>
                    <div>Escolaridade</div>
                    <input></input>
                    <div>Resumo Profissional</div>
                    <div>
                        { inputs.resumoProf === "true" ? <ReactQuill theme="snow" value={resumoProf} onChange={setResumoProf}/> : <div dangerouslySetInnerHTML={{__html: resumoProf}}></div>} 
                    </div>
                    <div>
                       { inputs.resumoProf === "true" ? <button value="false" onClick={handleChange} name="resumoProf">Salvar</button> : <button value="true" onClick={handleChange} name="resumoProf">Editar</button> } 
                    </div>
                    <div>Historico Academico</div>
                    <div>Escolaridade</div>
                    <input></input>
                    <div>Nome Instituicao</div>
                    <input></input>
                    <div>Nome Curso</div>
                    <input></input>
                    <div>Data Inicio</div>
                    <input></input>
                    <div>Data Conclusao</div>
                    <input></input>
                    <div>Cursando</div>
                    <input></input>
                    <div>Historico Profissional</div>
                    <div>Nome Empresa</div>
                    <input></input>
                    <div>Cargo</div>
                    <input></input>
                    <div>Descricao Funcoes</div>
                    <input></input>
                    <div>Data Entrada</div>
                    <input></input>
                    <div>Data Saida</div>
                    <input></input> 
                    <div>Empresa Atual</div>
                    <input></input>
                    <div>Informacoes Complementares</div>
                    <div>
                        { inputs.infoComp === "true" ? <ReactQuill theme="snow" value={infoComp} onChange={setInfoComp}/> : <div dangerouslySetInnerHTML={{__html: infoComp}}></div>} 
                    </div>
                    <div>
                       { inputs.infoComp === "true" ? <button value="false" onClick={handleChange} name="infoComp">Salvar</button> : <button value="true" onClick={handleChange} name="infoComp">Editar</button> } 
                    </div>
                    <div>
                    </div>
                </div>
            </div>
        )
    } else if(status === 401){
        return (
            <div>
                <Navigate to="/login" replace={true} />
            </div>
        )
    } else {
        return (
            <div>Loading.....</div>
        )
    }
    
}