import './App.css';
import {BrowserRouter, Route, Routes } from "react-router-dom";
import { Home } from './Shared/Home';
import ConsultaVagas from './Vagas/ConsultaVagas';
import { Vaga } from './Vagas/Vaga';
import { CadastroUsuario } from './Ususario/CadastroUsuario';
import { Login } from './Shared/Login';
import { PerfilPf } from './Ususario/PerfilPf';
import { CadastroEmpresa } from './Empresa/CadastroEmpresa';
import { PerfilPj } from './Empresa/PerfilPj';
import { CriarVaga } from './Vagas/CriarVaga';
import { VagasEmpresa } from './Vagas/VagasEmpresa';
import { VagaEmpresa } from './Vagas/VagaEmpresa';
import { BuscaVagas } from './Vagas/BuscaVagas';
import { Empresa } from './Empresa/Empresa';
import { DenunciaVaga } from './Vagas/DenunciaVaga';
import { HistoricoVagas } from './Ususario/HistoricoVagas';
import { ParaVoce } from './Shared/ParaVoce';
import { Institucional } from './Shared/Institucional';

function App() {

  return (
    <div className="App">
      <main>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<Home />}/>
          <Route path='search' element={<ConsultaVagas/>}/>
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
          <Route path='vagasdisponiveis/:busca' element={<BuscaVagas />}/>
          <Route path='denunciavaga/:vagaId' element={<DenunciaVaga />}/>
          <Route path='/perfilpf/hisotricoVagas' element={<HistoricoVagas />}/>
          <Route path='para-voce' element={<ParaVoce />}/>
          <Route path='institucional' element={<Institucional />}/>
        </Routes>
      </BrowserRouter>
      </main>
    </div>
  );
}

export default App;
