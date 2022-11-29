import { useParams } from "react-router-dom"
import ConsultaVagas from "./ConsultaVagas"
import { Header } from "../Shared/Header";

export const BuscaVagas = () => {
    const busca = useParams();

    return (
        <div>
            <Header consultaVagas="true"/>
            <ConsultaVagas valorBusca={busca}/>
        </div>
    )
}