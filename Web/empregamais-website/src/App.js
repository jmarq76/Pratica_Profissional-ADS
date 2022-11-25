import './App.css';
import FeaturedProducts from './FeaturedProducts';
import {BrowserRouter, Route, Routes } from "react-router-dom";
import { Home } from './Home';
import { Vaga } from './Vaga';
import { CadastroUsuario } from './CadastroUsuario';
import { Login } from './Login';
import { PerfilPf } from './PerfilPf';
import { Empresa } from './Empresa';
import { CadastroEmpresa } from './CadastroEmpresa';
import { PerfilPj } from './PerfilPj';
import { CriarVaga } from './CriarVaga';
import { VagasEmpresa } from './VagasEmpresa';
import { VagaEmpresa } from './VagaEmpresa';
import { BuscaVagas } from './BuscaVagas';

function App() {

  return (
    <div className="App">
      <main>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<Home />}/>
          <Route path='search' element={<FeaturedProducts/>}/>
          <Route path='vagas/:vagaId' element={<Vaga />}/>
          <Route path='cadastro/usuario' element={<CadastroUsuario />}/>
          <Route path='login' element={<Login />}/>
          <Route path='perfil/:userName' element={<PerfilPf />}/>
          <Route path='empresa' element={<Empresa />}/>
          <Route path='cadastro/empresa' element={<CadastroEmpresa />}/>
          <Route path='perfilpj' element={<PerfilPj />}/>
          <Route path='perfilpj/empresa/criarvaga' element={<CriarVaga />}/>
          <Route path='perfilpj/empresa/vagas' element={<VagasEmpresa />}/>
          <Route path='perfilpj/empresa/vagas/:vagaId' element={<VagaEmpresa />}/>
          <Route path='buscaVagas/:busca' element={<BuscaVagas />}/>
        </Routes>
      </BrowserRouter>
      </main>
    </div>
  );
}

export default App;
