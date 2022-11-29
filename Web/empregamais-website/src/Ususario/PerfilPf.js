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
    console.log(dados);
    if(dados.id && histAcademico.length > 0 && histProfissional.length > 0){
        return (
            <div>
                <Header headerHome={true}/>
                <div className="perfil-main-div">
                    <div className="perfil-main-dados">{dados.usuario.nome}</div>
                    <div>{dados.usuario.contatos.map((contato) => (
                        <div key={contato.id}>
                            <div className="perfil-main-dados">{contato.descricao}</div>
                            </div>
                    ))}</div>
                    <div className="perfil-main-dados">{dados.usuario.enderecos.logradouro}, {dados.usuario.enderecos.complemento}. CEP: {dados.usuario.enderecos.cep}, {dados.usuario.enderecos.uf}/{dados.usuario.enderecos.pais}</div>
                    <div className="perfil-main-historico"><Link to="/perfilpf/hisotricoVagas">Histórico Vagas</Link></div>
                </div>
                <div className="perfil-dados-div">
                    <div className="dados-div dados-titulo">Cargo Desejado</div>
                    { inputs.cargoDesejadoSaveEdit === "true" ? <input value={dados.cargoDesejado} onChange={handleChange} name="cargoDesejado"></input> : <div className="dados-div">{dados.cargoDesejado}</div>}
                    { inputs.cargoDesejadoSaveEdit === "true" ? <button className="btn-perfilpf" onClick={handleSave} name="cargoDesejadoSaveEdit">Salvar</button> : <button className="btn-perfilpf" onClick={handleEdit} name="cargoDesejadoSaveEdit">Editar</button> }
                    <div className="dados-div dados-titulo">Pretensao Salarial</div>
                    { inputs.pretensaoSalarialSaveEdit === "true" ? <input value={dados.pretensaoSalarial} onChange={handleChange} name="pretensaoSalarial"></input> : <div className="dados-div">R$ {dados.pretensaoSalarial}</div>}
                    { inputs.pretensaoSalarialSaveEdit === "true" ? <button className="btn-perfilpf" onClick={handleSave} name="pretensaoSalarialSaveEdit">Salvar</button> : <button className="btn-perfilpf" onClick={handleEdit} name="pretensaoSalarialSaveEdit">Editar</button> }
                    <div className="dados-div dados-titulo">Escolaridade</div>
                    { inputs.escolaridadeSaveEdit === "true" ?<input value={dados.escolaridade} onChange={handleChange} name="escolaridade"></input> : <div className="dados-div">{dados.escolaridade}</div>}
                    { inputs.escolaridadeSaveEdit === "true" ? <button className="btn-perfilpf" onClick={handleSave} name="escolaridadeSaveEdit">Salvar</button> : <button className="btn-perfilpf" onClick={handleEdit} name="escolaridadeSaveEdit">Editar</button> }
                    <div className="dados-div dados-titulo">Resumo Profissional</div>
                    <div>
                        { inputs.resumoProfSaveEdit === "true" ? <ReactQuill theme="snow" value={resumoProf} onChange={saveResumoProf}/> : <div className="dados-div" dangerouslySetInnerHTML={{__html: resumoProf}}></div>} 
                    </div>
                    <div>
                       { inputs.resumoProfSaveEdit === "true" ? <button className="btn-perfilpf" onClick={handleSave} name="resumoProfSaveEdit">Salvar</button> : <button className="btn-perfilpf" onClick={handleEdit} name="resumoProfSaveEdit">Editar</button> } 
                    </div>
                    <div className="dados-div dados-titulo">Historico Academico</div>
                    { 
                        inputs.histAcademicoSaveEdit === "true" ? 
                        <div>
                            <div className="dados-div" dados-titulo>Escolaridade</div>
                                <input value={adicionaHistAcademico.nivelEscolaridade} onChange={handleAdicionaHistAcademico} name="nivelEscolaridade"></input>
                                <div className="dados-div dados-titulo">Nome Instituicao</div>
                                <input value={adicionaHistAcademico.nomeInstituicao} onChange={handleAdicionaHistAcademico} name="nomeInstituicao"></input>
                                <div className="dados-div dados-titulo">Nome Curso</div>
                                <input value={adicionaHistAcademico.nomeCurso} onChange={handleAdicionaHistAcademico} name="nomeCurso"></input>
                                <div className="dados-div dados-titulo">Data Inicio</div>
                                <input value={adicionaHistAcademico.dataInicio} onChange={handleAdicionaHistAcademico} name="dataInicio"></input>
                                <div className="dados-div dados-titulo">Data Conclusao</div>
                                <input value={adicionaHistAcademico.dataConclusao} onChange={handleAdicionaHistAcademico} name="dataConclusao"></input>
                                <div className="dados-div dados-titulo">Cursando</div>
                                { adicionaHistAcademico.cursando === "true" ? <input type="checkbox" checked="checked" value="false" onChange={handleAdicionaHistAcademico} name="cursando"></input> : <input type="checkbox" value="true" onChange={handleAdicionaHistAcademico} name="cursando"></input>}
                            <button className="btn-perfilpf" onClick={handleSaveAdicionaHistAcademico} name="histAcademicoSaveEdit">Salvar</button>
                        </div> : 
                        <button className="btn-perfilpf" onClick={handleEdit} name="histAcademicoSaveEdit">Adicionar</button> 
                    }
                    {
                        histAcademico.map((histAcademico) => (
                            <div key={histAcademico.id}>
                                {histAcademico.histAcademicoSaveEdit === "true" ?
                                <div>
                                {
                                        <div>
                                        <div className="dados-div dados-titulo">Escolaridade</div>
                                        <input value={histAcademico.nivelEscolaridade} onChange={handleHistAcademico} name="nivelEscolaridade" id={histAcademico.id}></input>
                                        <div className="dados-div dados-titulo">Nome Instituicao</div>
                                        <input value={histAcademico.nomeInstituicao} onChange={handleHistAcademico} name="nomeInstituicao" id={histAcademico.id}></input>
                                        <div className="dados-div dados-titulo">Nome Curso</div>
                                        <input value={histAcademico.nomeCurso} onChange={handleHistAcademico} name="nomeCurso"></input>
                                        <div className="dados-div dados-titulo">Data Inicio</div>
                                        <input value={histAcademico.dataInicio} onChange={handleHistAcademico} name="dataInicio"></input>
                                        <div className="dados-div dados-titulo">Data Conclusao</div>
                                        <input value={histAcademico.dataConclusao} onChange={handleHistAcademico} name="dataConclusao"></input>
                                        <div className="dados-div dados-titulo">Cursando</div>
                                        { histAcademico.cursando === "true" ? <input type="checkbox" checked="checked" value="false" onChange={handleHistAcademico} name="cursando"></input> : <input type="checkbox" value="true" onChange={handleHistAcademico} name="cursando"></input>} 
                                        { histAcademico.histAcademicoSaveEdit === "true" ? <button className="btn-perfilpf" onClick={handleSaveHistAcademico} name="histAcademicoSaveEdit" id={histAcademico.id}>Salvar</button> : <button className="btn-perfilpf" onClick={handleHistAcademicoEdit} name="histAcademicoSaveEdit" id={histAcademico.id}>Editar</button> }
                                        </div>
                                }
                                </div> :
                                <div>
                                {
                                    <div>
                                    <div className="dados-div dados-titulo">Escolaridade</div>
                                    <div className="dados-div">{histAcademico.nivelEscolaridade}</div>
                                    <div className="dados-div dados-titulo">Nome Instituicao</div>
                                    <div className="dados-div">{histAcademico.nomeInstituicao}</div>
                                    <div className="dados-div dados-titulo">Nome Curso</div>
                                    <div className="dados-div">{histAcademico.nomeCurso}</div>
                                    <div className="dados-div dados-titulo">Data Inicio</div>
                                    <div className="dados-div">{histAcademico.dataInicio}</div>
                                    <div className="dados-div dados-titulo">Data Conclusao</div>
                                    <div className="dados-div">{histAcademico.dataConclusao}</div>
                                    <div className="dados-div dados-titulo">Cursando</div>
                                    <div className="dados-div">{histAcademico.cursando}</div>
                                    { histAcademico.histAcademicoSaveEdit === "true" ? <button className="btn-perfilpf" onClick={handleSaveHistAcademico} name="histAcademicoSaveEdit" id={histAcademico.id}>Salvar</button> : <button className="btn-perfilpf" onClick={handleHistAcademicoEdit} name="histAcademicoSaveEdit" id={histAcademico.id}>Editar</button> }
                                    </div>
                                }
                                
                            </div>
                                }
                            </div>
                        ))}
                    <div className="dados-div">Historico Profissional</div>
                    { 
                        inputs.histProfissionalSaveEdit === "true" ? 
                        <div>
                            <div className="dados-div dados-titulo">Nome Empresa</div>
                                <input value={adicionaHistProfissional.nomeEmpresa} onChange={handleAdicionaHistProfissional} name="nomeEmpresa"></input>
                                <div className="dados-div dados-titulo">Cargo</div>
                                <input value={adicionaHistProfissional.cargo} onChange={handleAdicionaHistProfissional} name="cargo"></input>
                                <div className="dados-div dados-titulo">Descricao Funcoes</div>
                                <textarea value={adicionaHistProfissional.descricao} onChange={handleAdicionaHistProfissional} name="descricao"></textarea>
                                <div className="dados-div dados-titulo">Data Entrada</div>
                                <input type="date" value={adicionaHistProfissional.dataEntrada} onChange={handleAdicionaHistProfissional} name="dataEntrada"></input>
                                <div className="dados-div dados-titulo">Data Saida</div>
                                <input type="date" value={adicionaHistProfissional.dataSaida} onChange={handleAdicionaHistProfissional} name="dataSaida"></input>
                                <div className="dados-div dados-titulo">Empresa Atual</div>
                                { adicionaHistProfissional.empresaAtual === "true" ? <input type="checkbox" checked="checked" value="false" onChange={handleAdicionaHistProfissional} name="empresaAtual"></input> : <input type="checkbox" value="true" onChange={handleAdicionaHistProfissional} name="empresaAtual"></input>}
                            <button className="btn-perfilpf" onClick={handleSaveAdicionaHistProfissional} name="histProfissionalSaveEdit">Salvar</button>
                        </div> : 
                        <button className="btn-perfilpf" onClick={handleEdit} name="histProfissionalSaveEdit">Adicionar</button> 
                    }
                    { 
                        histProfissional.map((histProfissional) => (
                            <div key={histProfissional.id}>
                                {
                                histProfissional.histProfissionalSaveEdit === "true" ? 
                        <div>
                            <div className="dados-div dados-titulo">Nome Empresa</div>
                            <input value={histProfissional.nomeEmpresa} onChange={handleHistProfissional} name="nomeEmpresa"></input>
                            <div className="dados-div dados-titulo">Cargo</div>
                            <input value={histProfissional.cargo} onChange={handleHistProfissional} name="cargo"></input>
                            <div className="dados-div dados-titulo">Descricao Funcoes</div>
                            <textarea type="text" value={histProfissional.descricao} onChange={handleHistProfissional} name="descricao"></textarea>
                            <div className="dados-div dados-titulo">Data Entrada</div>
                            <input value={histProfissional.dataEntrada} onChange={handleHistProfissional} name="dataEntrada"></input>
                            <div className="dados-div dados-titulo">Data Saida</div>
                            <input value={histProfissional.dataSaida} onChange={handleHistProfissional} name="dataSaida"></input>
                            <div className="dados-div dados-titulo">Empresa Atual</div>
                            { histProfissional.empresaAtual === "true" ? <input type="checkbox" checked="checked" value="false" onChange={handleHistProfissional} name="empresaAtual"></input> : <input type="checkbox" value="true" onChange={handleHistProfissional} name="empresaAtual"></input>} 
                            { histProfissional.histProfissionalSaveEdit === "true" ? <button className="btn-perfilpf" onClick={handleSaveHistProfissional} name="histProfissionalSaveEdit" id={histProfissional.id}>Salvar</button> : <button className="btn-perfilpf" onClick={handleHistProfissionaloEdit} name="histProfissionalSaveEdit" id={histProfissional.id}>Editar</button> }
                        </div> :
                        <div>
                            <div className="dados-div dados-titulo">Nome Empresa</div>
                            <div className="dados-div">{histProfissional.nomeEmpresa}</div>
                            <div className="dados-div dados-titulo">Cargo</div>
                            <div className="dados-div">{histProfissional.cargo}</div>
                            <div className="dados-div dados-titulo">Descricao Funcoes</div>
                            <div className="dados-div">{histProfissional.descricao}</div>
                            <div className="dados-div dados-titulo">Data Entrada</div>
                            <div className="dados-div">{histProfissional.dataEntrada}</div>
                            <div className="dados-div dados-titulo">Data Saida</div>
                            <div className="dados-div">{histProfissional.dataSaida}</div>
                            <div className="dados-div dados-titulo">Empresa Atual</div>
                            <div className="dados-div">{histProfissional.empresaAtual}</div>
                            { histProfissional.histProfissionalSaveEdit === "true" ? <button className="btn-perfilpf" onClick={handleSaveHistProfissional} name="histProfissionalSaveEdit" id={histProfissional.id}>Salvar</button> : <button className="btn-perfilpf" onClick={handleHistProfissionaloEdit} name="histProfissionalSaveEdit" id={histProfissional.id}>Editar</button> }
                        </div>
                        }
                            </div>
                                ))                      
                    }
                    <div className="dados-div dados-titulo">Informacoes Complementares</div>
                    <div>
                        { inputs.infoCompSaveEdit === "true" ? <ReactQuill theme="snow" value={infoComp} onChange={saveInfoComp}/> : <div className="dados-div" dangerouslySetInnerHTML={{__html: infoComp}}></div>} 
                    </div>
                    <div>
                       { inputs.infoCompSaveEdit === "true" ? <button className="btn-perfilpf" onClick={handleSave} name="infoCompSaveEdit">Salvar</button> : <button className="btn-perfilpf" onClick={handleEdit} name="infoCompSaveEdit">Editar</button> } 
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