import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import { Header } from "./Header";
import { Home } from "./Home";

export const Vaga = () => {
    const { vagaId } = useParams();
    const [vaga, setVaga] = useState(null);

    

    useEffect(() => getVaga(), []);

    const config = {
        headers: {
            'Access-Control-Allow-Origin' : '*'
    }
};

    const getVaga = () => {
    axios
    .get('https://localhost:5001/vagas/buscaVaga?textoBusca='+ vagaId, config)
    .then((res) => {
        setVaga(res.data);
    })
        .catch((err) => {
        });
    };

    if(vaga){
        return(
            <div>
                <Header headerHome='true'/>
                <p>
                    {vaga.Vaga.Titulo}
          </p>
          <p>
            <strong>{vaga.Usuario.Nome}</strong>
          </p>
          <button>Candidatura</button>
            </div>
        )
    } else {
        return(
            <div>
                Carregando vaga....
            </div>
        )
    }
    
}