import { useParams } from "react-router-dom"
import FeaturedProducts from "./FeaturedProducts"
import { Header } from "./Header";

export const BuscaVagas = () => {
    const busca = useParams();

    return (
        <div>
            <Header />
            <FeaturedProducts valorBusca={busca}/>
        </div>
    )
}