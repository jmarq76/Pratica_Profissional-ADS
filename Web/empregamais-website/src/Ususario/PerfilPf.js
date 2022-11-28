import axios from "axios";
import React, { useEffect, useState } from "react";
import { Header } from "../Shared/Header"
import 'react-quill/dist/quill.snow.css';
import { Link, Navigate } from "react-router-dom";
import ReactQuill from "react-quill";

export const PerfilPf = () => {
    const [dados, setDados] = useState({});
    const [resumoProf, setResumoProf] = useState("");
    const [infoComp, setInfoComp] = useState("");
    const [status, setStatus] = useState("");
    const [inputs, setInputs] = useState({});
    const [histAcademico, setHistAcademico] = useState([]);
    const [adicionaHistAcademico, setAdicionaHistAcademico] = useState({});
    const [histProfissional, setHistProfissional] = useState({});
    const [adicionaHistProfissional, setAdicionaHistProfissional] = useState([]);

    const handleChange = (e) => {
        const name = e.target.name;
        const value = e.target.value;
        setDados(values => ({...values, [name]: value}));
    }

    const handleHistProfissional = (e) => {
        const name = e.target.name;
        const value = e.target.value;
        const newArray = [...histProfissional];
        const index = newArray.findIndex(element => element.id === e.target.id.toString());
        newArray[index] = ({...newArray[index], [name]: value});
        setHistProfissional(newArray);
    };

    const handleAdicionaHistProfissional = (e) => {
        const name = e.target.name;
        const value = e.target.value;
        setAdicionaHistProfissional(values => ([{...values[0], [name]: value}]));
    };

    const handleSaveHistProfissional = (e) => {
        const name = e.target.name;
        const value = "false";
        const newArray = [...histProfissional];
        const index = newArray.findIndex(element => element.id === e.target.id.toString());
        newArray[index] = ({...newArray[index], [name]: value});
        setHistProfissional(newArray);
        saveDataProfissional(histProfissional);
    };

    const handleHistProfissionaloEdit = (e) => {
        const name = e.target.name;
        const value = "true";
        histProfissional.forEach(element => element.histProfissionalSaveEdit = "false");
        const newArray = [...histProfissional];
        const index = newArray.findIndex(element => element.id === e.target.id.toString());
        newArray[index] = ({...newArray[index], [name]: value});
        setHistProfissional(newArray);
        setInputs(values => ({...values, [name]: "false"}));
    };

    const handleSaveAdicionaHistProfissional = (e) => {
        const name = e.target.name;
        const value = "false";
        setInputs(values => ({...values, [name]: value}));
        saveDataProfissional(adicionaHistProfissional);
    };

    const handleHistAcademico = (e) => {
        const name = e.target.name;
        const value = e.target.value;
        const newArray = [...histAcademico];
        const index = newArray.findIndex(element => element.id === e.target.id.toString());
        newArray[index] = ({...newArray[index], [name]: value});
        setHistAcademico(newArray);
    }

    const handleAdicionaHistAcademico = (e) => {
        const name = e.target.name;
        const value = e.target.value;
        setAdicionaHistAcademico(values => ([{...values[0], [name]: value}]));
    }

    const handleSaveHistAcademico = (e) => {
        const name = e.target.name;
        const value = "false";
        const newArray = [...histAcademico];
        const index = newArray.findIndex(element => element.id === e.target.id.toString());
        newArray[index] = ({...newArray[index], [name]: value});
        setHistAcademico(newArray);
        saveDataAcademico(histAcademico);
    };

    const handleHistAcademicoEdit = (e) => {
        const name = e.target.name;
        const value = "true";
        histAcademico.forEach(element => element.histAcademicoSaveEdit = "false");
        const newArray = [...histAcademico];
        const index = newArray.findIndex(element => element.id === e.target.id.toString());
        newArray[index] = ({...newArray[index], [name]: value});
        setHistAcademico(newArray);
        setInputs(values => ({...values, [name]: "false"}));
    };

    const handleSaveAdicionaHistAcademico = (e) => {
        const name = e.target.name;
        const value = "false";
        setInputs(values => ({...values, [name]: value}));
        saveDataAcademico(adicionaHistAcademico);
    };

    const handleSave = (e) => {
        const name = e.target.name;
        const value = "false";
        setInputs(values => ({...values, [name]: value}));
        saveData();
    }

    const handleEdit = (e) => {
        const name = e.target.name;
        const value = "true";
        histAcademico.forEach(element => element.histAcademicoSaveEdit = "false");
        histProfissional.forEach(element => element.histProfissionalSaveEdit = "false");
        setInputs(values => ({...values, [name]: value}));
    };

    const saveResumoProf = (value) => {
        setResumoProf(value);
        setDados(values => ({...values, ["resumoProfissional"]: value}));
    };

    const saveInfoComp = (e) => {
        setInfoComp(e.target.value);
        setDados(values => ({...values, ["informacoesComplementares"]: e.target.value}));
    };

    useEffect(() => {
        getData();
        getDataAcademico();
        getDataProfissional();
    }, []);

    const saveDataProfissional = (dadosProfissional) => {
        const config = {
            headers: {
                'Authorization' : JSON.parse(localStorage.getItem("user"))?.token,
        }
    };
        axios
        .post('https://localhost:5001/perfilpf/gravarhistprofissional', dadosProfissional, config)
        .then((response) => {
            setStatus(response.statusCode)
        }).catch((error) => {
            setStatus(error.statusCode)
        })
    };

    const saveDataAcademico = (dadosAcademico) => {
        const config = {
            headers: {
                'Authorization' : JSON.parse(localStorage.getItem("user"))?.token,
        }
    };
        axios
        .post('https://localhost:5001/perfilpf/gravarhistacademico', dadosAcademico, config)
        .then((response) => {
            setStatus(response.statusCode)
        }).catch((error) => {
            setStatus(error.statusCode)
        })
    };

    const saveData = () => {
        const config = {
            headers: {
                'Authorization' : JSON.parse(localStorage.getItem("user"))?.token,
        }
    };
        axios
        .post('https://localhost:5001/perfilpf/gravarperfil', dados, config)
        .then((response) => {
            setStatus(response.statusCode)
        }).catch((error) => {
            setStatus(error.statusCode)
        })
    };

    const getDataProfissional = () => {

        const config = {
            headers: {
                'Authorization' : JSON.parse(localStorage.getItem("user"))?.token,
        }
    };

        axios
        .get('https://localhost:5001/perfilpf/obterhistoricosprofissionais', config)
        .then((response) => {
            setHistProfissional(response.data);
        }).catch((error) => {
            setStatus(error.response.status);
        })
    };

    const getDataAcademico = () => {

        const config = {
            headers: {
                'Authorization' : JSON.parse(localStorage.getItem("user"))?.token,
        }
    };

        axios
        .get('https://localhost:5001/perfilpf/obterhistoricosacademicos', config)
        .then((response) => {
            setHistAcademico(response.data);
        }).catch((error) => {
            setStatus(error.response.status);
        })
    };

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
            setResumoProf(response.data.resumoProfissional);
            setInfoComp(response.data.informacoesComplementares);
        }).catch((error) => {
            setStatus(error.response.status);
        })
    };

    if(dados.id && histAcademico.length > 0 && histProfissional.length > 0){
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
                    <Link to="/perfilpf/hisotricoVagas">Histórico Vagas</Link>
                </div>
                <div className="perfil-dados-div">
                    <div>Cargo Desejado</div>
                    { inputs.cargoDesejadoSaveEdit === "true" ? <input value={dados.cargoDesejado} onChange={handleChange} name="cargoDesejado"></input> : <div>{dados.cargoDesejado}</div>}
                    { inputs.cargoDesejadoSaveEdit === "true" ? <button onClick={handleSave} name="cargoDesejadoSaveEdit">Salvar</button> : <button onClick={handleEdit} name="cargoDesejadoSaveEdit">Editar</button> }
                    <div>Pretensao Salarial</div>
                    { inputs.pretensaoSalarialSaveEdit === "true" ? <input value={dados.pretensaoSalarial} onChange={handleChange} name="pretensaoSalarial"></input> : <div>{dados.pretensaoSalarial}</div>}
                    { inputs.pretensaoSalarialSaveEdit === "true" ? <button onClick={handleSave} name="pretensaoSalarialSaveEdit">Salvar</button> : <button onClick={handleEdit} name="pretensaoSalarialSaveEdit">Editar</button> }
                    <div>Escolaridade</div>
                    { inputs.escolaridadeSaveEdit === "true" ?<input value={dados.escolaridade} onChange={handleChange} name="escolaridade"></input> : <div>{dados.escolaridade}</div>}
                    { inputs.escolaridadeSaveEdit === "true" ? <button onClick={handleSave} name="escolaridadeSaveEdit">Salvar</button> : <button onClick={handleEdit} name="escolaridadeSaveEdit">Editar</button> }
                    <div>Resumo Profissional</div>
                    <div>
                        { inputs.resumoProfSaveEdit === "true" ? <ReactQuill theme="snow" value={resumoProf} onChange={saveResumoProf}/> : <div dangerouslySetInnerHTML={{__html: resumoProf}}></div>} 
                    </div>
                    <div>
                       { inputs.resumoProfSaveEdit === "true" ? <button onClick={handleSave} name="resumoProfSaveEdit">Salvar</button> : <button onClick={handleEdit} name="resumoProfSaveEdit">Editar</button> } 
                    </div>
                    <div>Historico Academico</div>
                    { 
                        inputs.histAcademicoSaveEdit === "true" ? 
                        <div>
                            <div>Escolaridade</div>
                                <input value={adicionaHistAcademico.nivelEscolaridade} onChange={handleAdicionaHistAcademico} name="nivelEscolaridade"></input>
                                <div>Nome Instituicao</div>
                                <input value={adicionaHistAcademico.nomeInstituicao} onChange={handleAdicionaHistAcademico} name="nomeInstituicao"></input>
                                <div>Nome Curso</div>
                                <input value={adicionaHistAcademico.nomeCurso} onChange={handleAdicionaHistAcademico} name="nomeCurso"></input>
                                <div>Data Inicio</div>
                                <input value={adicionaHistAcademico.dataInicio} onChange={handleAdicionaHistAcademico} name="dataInicio"></input>
                                <div>Data Conclusao</div>
                                <input value={adicionaHistAcademico.dataConclusao} onChange={handleAdicionaHistAcademico} name="dataConclusao"></input>
                                <div>Cursando</div>
                                { adicionaHistAcademico.cursando === "true" ? <input type="checkbox" checked="checked" value="false" onChange={handleAdicionaHistAcademico} name="cursando"></input> : <input type="checkbox" value="true" onChange={handleAdicionaHistAcademico} name="cursando"></input>}
                            <button onClick={handleSaveAdicionaHistAcademico} name="histAcademicoSaveEdit">Salvar</button>
                        </div> : 
                        <button onClick={handleEdit} name="histAcademicoSaveEdit">Adicionar</button> 
                    }
                    {
                        histAcademico.map((histAcademico) => (
                            <div key={histAcademico.id}>
                                {histAcademico.histAcademicoSaveEdit === "true" ?
                                <div>
                                {
                                        <div>
                                        <div>Escolaridade</div>
                                        <input value={histAcademico.nivelEscolaridade} onChange={handleHistAcademico} name="nivelEscolaridade" id={histAcademico.id}></input>
                                        <div>Nome Instituicao</div>
                                        <input value={histAcademico.nomeInstituicao} onChange={handleHistAcademico} name="nomeInstituicao" id={histAcademico.id}></input>
                                        <div>Nome Curso</div>
                                        <input value={histAcademico.nomeCurso} onChange={handleHistAcademico} name="nomeCurso"></input>
                                        <div>Data Inicio</div>
                                        <input value={histAcademico.dataInicio} onChange={handleHistAcademico} name="dataInicio"></input>
                                        <div>Data Conclusao</div>
                                        <input value={histAcademico.dataConclusao} onChange={handleHistAcademico} name="dataConclusao"></input>
                                        <div>Cursando</div>
                                        { histAcademico.cursando === "true" ? <input type="checkbox" checked="checked" value="false" onChange={handleHistAcademico} name="cursando"></input> : <input type="checkbox" value="true" onChange={handleHistAcademico} name="cursando"></input>} 
                                        { histAcademico.histAcademicoSaveEdit === "true" ? <button onClick={handleSaveHistAcademico} name="histAcademicoSaveEdit" id={histAcademico.id}>Salvar</button> : <button onClick={handleHistAcademicoEdit} name="histAcademicoSaveEdit" id={histAcademico.id}>Editar</button> }
                                        </div>
                                }
                                </div> :
                                <div>
                                {
                                    <div>
                                    <div>Escolaridade</div>
                                    <div>{histAcademico.nivelEscolaridade}</div>
                                    <div>Nome Instituicao</div>
                                    <div>{histAcademico.nomeInstituicao}</div>
                                    <div>Nome Curso</div>
                                    <div>{histAcademico.nomeCurso}</div>
                                    <div>Data Inicio</div>
                                    <div>{histAcademico.dataInicio}</div>
                                    <div>Data Conclusao</div>
                                    <div>{histAcademico.dataConclusao}</div>
                                    <div>Cursando</div>
                                    <div>{histAcademico.cursando}</div>
                                    { histAcademico.histAcademicoSaveEdit === "true" ? <button onClick={handleSaveHistAcademico} name="histAcademicoSaveEdit" id={histAcademico.id}>Salvar</button> : <button onClick={handleHistAcademicoEdit} name="histAcademicoSaveEdit" id={histAcademico.id}>Editar</button> }
                                    </div>
                                }
                                
                            </div>
                                }
                            </div>
                        ))}
                    <div>Historico Profissional</div>
                    { 
                        inputs.histProfissionalSaveEdit === "true" ? 
                        <div>
                            <div>Nome Empresa</div>
                                <input value={adicionaHistProfissional.nomeEmpresa} onChange={handleAdicionaHistProfissional} name="nomeEmpresa"></input>
                                <div>Cargo</div>
                                <input value={adicionaHistProfissional.cargo} onChange={handleAdicionaHistProfissional} name="cargo"></input>
                                <div>Descricao Funcoes</div>
                                <textarea value={adicionaHistProfissional.descricao} onChange={handleAdicionaHistProfissional} name="descricao"></textarea>
                                <div>Data Entrada</div>
                                <input type="date" value={adicionaHistProfissional.dataEntrada} onChange={handleAdicionaHistProfissional} name="dataEntrada"></input>
                                <div>Data Saida</div>
                                <input type="date" value={adicionaHistProfissional.dataSaida} onChange={handleAdicionaHistProfissional} name="dataSaida"></input>
                                <div>Empresa Atual</div>
                                { adicionaHistProfissional.empresaAtual === "true" ? <input type="checkbox" checked="checked" value="false" onChange={handleAdicionaHistProfissional} name="empresaAtual"></input> : <input type="checkbox" value="true" onChange={handleAdicionaHistProfissional} name="empresaAtual"></input>}
                            <button onClick={handleSaveAdicionaHistProfissional} name="histProfissionalSaveEdit">Salvar</button>
                        </div> : 
                        <button onClick={handleEdit} name="histProfissionalSaveEdit">Adicionar</button> 
                    }
                    { 
                        histProfissional.map((histProfissional) => (
                            <div key={histProfissional.id}>
                                {
                                histProfissional.histProfissionalSaveEdit === "true" ? 
                        <div>
                            <div>Nome Empresa</div>
                            <input value={histProfissional.nomeEmpresa} onChange={handleHistProfissional} name="nomeEmpresa"></input>
                            <div>Cargo</div>
                            <input value={histProfissional.cargo} onChange={handleHistProfissional} name="cargo"></input>
                            <div>Descricao Funcoes</div>
                            <textarea type="text" value={histProfissional.descricao} onChange={handleHistProfissional} name="descricao"></textarea>
                            <div>Data Entrada</div>
                            <input value={histProfissional.dataEntrada} onChange={handleHistProfissional} name="dataEntrada"></input>
                            <div>Data Saida</div>
                            <input value={histProfissional.dataSaida} onChange={handleHistProfissional} name="dataSaida"></input>
                            <div>Empresa Atual</div>
                            { histProfissional.empresaAtual === "true" ? <input type="checkbox" checked="checked" value="false" onChange={handleHistProfissional} name="empresaAtual"></input> : <input type="checkbox" value="true" onChange={handleHistProfissional} name="empresaAtual"></input>} 
                            { histProfissional.histProfissionalSaveEdit === "true" ? <button onClick={handleSaveHistProfissional} name="histProfissionalSaveEdit" id={histProfissional.id}>Salvar</button> : <button onClick={handleHistProfissionaloEdit} name="histProfissionalSaveEdit" id={histProfissional.id}>Editar</button> }
                        </div> :
                        <div>
                            <div>Nome Empresa</div>
                            <div>{histProfissional.nomeEmpresa}</div>
                            <div>Cargo</div>
                            <div>{histProfissional.cargo}</div>
                            <div>Descricao Funcoes</div>
                            <div>{histProfissional.descricao}</div>
                            <div>Data Entrada</div>
                            <div>{histProfissional.dataEntrada}</div>
                            <div>Data Saida</div>
                            <div>{histProfissional.dataSaida}</div>
                            <div>Empresa Atual</div>
                            <div>{histProfissional.empresaAtual}</div>
                            { histProfissional.histProfissionalSaveEdit === "true" ? <button onClick={handleSaveHistProfissional} name="histProfissionalSaveEdit" id={histProfissional.id}>Salvar</button> : <button onClick={handleHistProfissionaloEdit} name="histProfissionalSaveEdit" id={histProfissional.id}>Editar</button> }
                        </div>
                        }
                            </div>
                                ))                      
                    }
                    <div>Informacoes Complementares</div>
                    <div>
                        { inputs.infoCompSaveEdit === "true" ? <ReactQuill theme="snow" value={infoComp} onChange={saveInfoComp}/> : <div dangerouslySetInnerHTML={{__html: infoComp}}></div>} 
                    </div>
                    <div>
                       { inputs.infoCompSaveEdit === "true" ? <button onClick={handleSave} name="infoCompSaveEdit">Salvar</button> : <button onClick={handleEdit} name="infoCompSaveEdit">Editar</button> } 
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