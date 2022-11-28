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
            <div>Cadastro Empresa</div>
            <div>CNPJ</div>
            <input maxLength={14} value={inputs.cpfcnpj || ""} onChange={handleChange} name="cpfcnpj"></input>
            <label className="cadastro-usuario-lbl">Email</label>
                                <input className="cadastro-usuario-inpt" type="email" required value={inputs.email || ""} onChange={handleChange} name="email"></input>
            <div>Senha</div>
            <input value={inputs.password || ""} onChange={handleChange} name="password"></input>
            <div>Repetir a senha</div>
            <input></input>
            <div>Nome Empresa</div>
            <input value={inputs.nomeCompleto || ""} onChange={handleChange} name="nomeCompleto"></input>
            <div>Celular</div>
            <input maxLength={11} value={inputs.celular || ""} onChange={handleChange} name="celular"></input>
            <div>Telefone</div>
            <input maxLength={11} value={inputs.telefone || ""} onChange={handleChange} name="telefone"></input>
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
                            <button onClick={enviaDados}>Cadastrar</button>
        </div>
    )
}