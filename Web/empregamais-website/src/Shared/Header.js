import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import FeaturedProducts from "../Vagas/FeaturedProducts";

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
  
    if(props.headerHome){
        return (
            <nav className='nav-main-navigation'>
            {
              usuario?.tipoUsuario === 1 ? 
              <div className='div-main-navigation'>
              <Link to={'/perfil/' + usuario.userName}><h1>EmpregaMais</h1></Link> 
              <FeaturedProducts />
              <Link to={'/perfil/' + usuario.userName}>Perfil</Link>
              <div onClick={handleLogout}>Logout</div>
              </div> :
              usuario?.tipoUsuario === 2 ?
              <div className='div-main-navigation'> 
              <Link to={'/empresa/' + usuario.userName}></Link>
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
              <p>Para Você</p>
              <Link to='empresa'>Para Empresas</Link>
              <p>Institucional</p>
              </div>
              <div className='buttons-main-navigation'>
                  <Link to={'/login'}>Entrar</Link>
                  <Link to={'/cadastro/usuario'}>Cadastre-se gratuitamente</Link>
              </div>
              </div>
            }
        </nav>
        )
    } else {
        return (
            <nav className='nav-main-navigation'>
              {
              usuario?.tipoUsuario === 1 ? 
              <div className='div-main-navigation'>
              <Link to={'/perfil/' + usuario.userName}><h1>EmpregaMais</h1></Link>
              <Link to={'/perfil/' + usuario.userName}>Perfil</Link>
              <div onClick={handleLogout}>Logout</div>
              </div> :
              <div className='div-main-navigation'>
              <Link to='/'><h1>EmpregaMais</h1></Link>
              <div className='buttons-main-navigation'>
                  <Link to={'/login'}>Entrar</Link>
                  <Link to={'/cadastro/usuario'}>Cadastre-se gratuitamente</Link>
              </div>
              </div>
    }
            </nav>
        )
    }
}