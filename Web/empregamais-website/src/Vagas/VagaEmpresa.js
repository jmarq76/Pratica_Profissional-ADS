import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Header } from "../Shared/Header";

export const VagaEmpresa = () => {
    const { vagaId } = useParams();
    const [vaga, setVaga] = useState(null);

    useEffect(() => getVaga(), []);

    const getVaga = () => {
    axios
    .get('https://localhost:5001/vagas/buscaVaga?textoBusca='+ vagaId)
    .then((res) => {
        setVaga(res.data);
    })
        .catch((err) => {
        });
    };
    
    if(vaga){
        return (
            <div>
                <Header headerHome='true'/>
                <div>{vaga.Vaga.Titulo}</div>
            </div>
        )
    } else {
        <div>
                <Header headerHome='true'/>
                <div>Loading........</div>
            </div>
    }
    
}