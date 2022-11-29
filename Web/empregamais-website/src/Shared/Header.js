import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import ConsultaVagas from "../Vagas/ConsultaVagas";

export const Header = (props) => {
  const [usuario, setUsuario] = useState("");
  const navigate = useNavigate();

  const handleLogout = () => {
    localStorage.clear();
    setUsuario(0);
    navigate("/");
  }

  useEffect(() => {
    setUsuario(JSON.parse(localStorage.getItem("user")));
  }, []);
  
        return (
            <nav className='nav-main-navigation'>
            {
              usuario?.tipoUsuario === 1 ? 
              <div className='div-main-navigation'>
              <Link to={'/perfil/' + usuario.userName}><h1>EmpregaMais</h1></Link> 
              { props.consultaVagas == "true" ? <div className='form-main-section'></div> : <ConsultaVagas />}
              <div className="header-login-logout">
                <Link to={'/perfil/' + usuario.userName}>Perfil</Link>
                <div className="header-logout" onClick={handleLogout}>Logout</div>
              </div>
              </div> :
              usuario?.tipoUsuario === 2 ?
              <div className='div-main-navigation'> 
              <Link to={'/empresa/' + usuario.userName} className='info-main-nav'></Link>
              <div className='links-main-navigation'>
              <Link to='/perfilpj/empresa/criarvaga'>Criar Vaga</Link>
              <Link to='/perfilpj/empresa/vagas'>Visualizar Vagas</Link>
              </div>
              <Link to='/perfilpj'>Perfil</Link>
                <div onClick={handleLogout}>Logout</div>
              </div> : 
              <div className='div-main-navigation'> 
              <Link to='/'><h1>EmpregaMais</h1></Link>
              <div className='links-main-navigation'>
              <Link to='/para-voce'><div className='info-main-nav'>Para Você</div></Link>
              <Link to='/empresa' ><div className='info-main-nav'>Para Empresas</div></Link>
              <Link to='/institucional'><div className='info-main-nav'>Institucional</div></Link>
              </div>
              <div className='buttons-main-navigation'>
                  <Link to={'/login'}>Entrar</Link>
                  <Link to={'/cadastro/usuario'}>Cadastre-se gratuitamente</Link>
              </div>
              </div>
            }
        </nav>
        )
}