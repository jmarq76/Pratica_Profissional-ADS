import axios from "axios";
import { useState } from "react"
import { Navigate } from "react-router-dom";
import { Header } from "./Header"

export const Login = () => {
    const [inputs, setInputs] = useState({});
    const [response, setResponse] = useState(null);

    const handleChange = (e) => {
        const name = e.target.name;
        const value = e.target.value;
        setInputs(values => ({...values, [name]: value }));
    }

    const config = {
        headers: {
            'Authorization' : JSON.parse(localStorage.getItem("user"))?.token,
    }
};

    const enviaDados = (event) => {
        event.preventDefault();
        axios
        .post('https://localhost:5001/login', inputs, config)
        .then((res) => {
            setResponse(res.data);
            if(res.data.userName){
                localStorage.setItem('user', JSON.stringify(res.data)); 
            }
        })
    }
    
    if(response === null){
        return (
            <div>
                <Header />
                <div className="login-div-card">
                    <form className="login-form-card">
                        <h1>Faça seu login</h1>
                        <label className="login-lbl-card">Usuario:</label>
                        <input className="login-in-card" required value={inputs.userName || ""} onChange={handleChange} name='userName'></input>
                        <label className="login-lbl-card">Senha:</label>
                        <input className="login-in-card" type="password" required value={inputs.password || ""} onChange={handleChange} name='password'></input>
                        <button className="login-btn-card" onClick={enviaDados}>Entrar</button>
                    </form>
                </div>
            </div>
        )
    } else if (response.tipoUsuario === 1) {
        return (
            <div>
                <Header />
                <Navigate to={'/perfil/' + response.userName} />
            </div>
        )
    } else if (response.tipoUsuario === 2) {
        return (
            <div>
                <Header />
                <Navigate to='/perfilpj' />
            </div>
        )
    } else {
        return (
            <div>
                <Header />
                <h1>Erro ao fazer login</h1>
            </div>
        )
    }
    
}