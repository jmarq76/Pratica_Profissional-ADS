import axios from "axios";
import { useState } from "react";
import { Header } from "../Shared/Header"

export const CadastroEmpresa = () => {
    const [inputs, setInputs] = useState({});
    const [responseStatus, setResponseStatus] = useState(0);

    inputs.TipoUsuario = 2;

    const handleChange = (e) => {
        const name = e.target.name;
        const value = e.target.value;
        setInputs(values => ({...values, [name]: value}))
    }

    const enviaDados = (event) => {
        event.preventDefault();
        axios
        .post('https://localhost:5001/cadastro/empresa', inputs)
        .then((res) => {
            setResponseStatus(res.status);
        })
    }
    return (
        <div>
            <Header />
            <div className="cadastro-usuario-main-div">
            <div className="cadastro-usuario-card-div">
            <h2>Cadastro Empresa</h2>
            <form className="cadastro-usuario-form">
            <div className="cadastro-usuario-login">
            <label className="cadastro-usuario-lbl">CNPJ</label>
            <input className="cadastro-usuario-inpt" maxLength={14} value={inputs.cpfcnpj || ""} onChange={handleChange} name="cpfcnpj"></input>
            <label className="cadastro-usuario-lbl">Email</label>
            <input className="cadastro-usuario-inpt" type="email" required value={inputs.email || ""} onChange={handleChange} name="email"></input>
            <label className="cadastro-usuario-lbl">Senha</label>
            <input className="cadastro-usuario-inpt" value={inputs.password || ""} onChange={handleChange} name="password"></input>
            <label className="cadastro-usuario-lbl">Repetir a senha</label>
            <input className="cadastro-usuario-inpt"></input>
            <label className="cadastro-usuario-lbl">Nome Empresa</label>
            <input className="cadastro-usuario-inpt" value={inputs.nomeCompleto || ""} onChange={handleChange} name="nomeCompleto"></input>
            <label className="cadastro-usuario-lbl">Celular</label>
            <input className="cadastro-usuario-inpt" maxLength={11} value={inputs.celular || ""} onChange={handleChange} name="celular"></input>
            <label className="cadastro-usuario-lbl">Telefone</label>
            <input className="cadastro-usuario-inpt" maxLength={11} value={inputs.telefone || ""} onChange={handleChange} name="telefone"></input>
            <div className="cadastro-usuario-endereco">
                                <label className="cadastro-usuario-lbl">CEP</label>
                                <input className="cadastro-usuario-inpt" type="text" maxLength={8} required value={inputs.cep || ""} onChange={handleChange} name="cep"></input>
                                <label className="cadastro-usuario-lbl">Logradouro</label>
                                <input className="cadastro-usuario-inpt" required value={inputs.logradouro || ""} onChange={handleChange} name="logradouro"></input>
                                <label className="cadastro-usuario-lbl">Complemento</label>
                                <input className="cadastro-usuario-inpt" required value={inputs.complemento || ""} onChange={handleChange} name="complemento"></input>
                                <label className="cadastro-usuario-lbl">UF</label>
                                <input className="cadastro-usuario-inpt" required value={inputs.uf || ""} onChange={handleChange} name="uf"></input>
                                <label className="cadastro-usuario-lbl">País</label>
                                <input className="cadastro-usuario-inpt" required value={inputs.pais || ""} onChange={handleChange} name="pais"></input>
                            </div>
                            <button onClick={enviaDados} className="btn-cadastro">Cadastrar</button>
                            </div>
                            </form>
                            </div>
                            </div>
        </div>
    )
}