import ConsultaVagas from "../Vagas/ConsultaVagas"
import { Header } from "./Header"

export const Home = () =>{
    return (
        <header className="App-header">
        <Header headerHome='true'/>
        <section className='sec-main-section'>
          <div className='div-main-section'>
            <h1 className='h1-main-section'>Encontre sua vaga de Emprego</h1>
            <ConsultaVagas />
          </div>
        </section>
      </header>
    )
}