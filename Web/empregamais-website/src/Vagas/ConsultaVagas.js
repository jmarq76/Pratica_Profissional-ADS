import React, {useState, useEffect} from 'react';
import axios from 'axios';
import { Link, useNavigate } from 'react-router-dom';

const ConsultaVagas = (props) => {
    const[products, setProducts] = useState([]);

    const [inputValue, setInputValue] = useState("");
    const navigate = useNavigate();

  const handleInputChange = (event) => {
    setInputValue(event.target.value)
  }

  const handleSubmit = (event) => {
      event.preventDefault();
      fetchProducts();
      navigate('/vagasdisponiveis/' + inputValue);
  }
    useEffect(() => {
        fetchProducts();
    }, []);

    const config = {
        headers: {
            'Access-Control-Allow-Origin' : '*',
    }
};

    const fetchProducts = () => {
      if(props.valorBusca?.busca != ""){
          let textoBusca = '?textoBusca=' + props.valorBusca?.busca
          axios
        .get('https://localhost:5001/vagas/busca' + textoBusca, config)
        .then((res) => {
            setProducts(res.data);
        })
        .catch((err) => {
        });
        }
    };
  return (
    <div>
        <form className='form-main-section'>
              <input value={inputValue} onChange={handleInputChange} placeholder='Digite um cargo, cidade ou estado' className='input-main-section' id='input-main-section'></input>
              <button onClick={handleSubmit} type='submit' className='btn-main-section' >Buscar</button>
        </form>
      <div className='item-container'>
        {products.map((product) => (
            <div className='card' key={product.Vaga.Id}>
                <Link to={'/vagas/' + product.Vaga.Id}><p className='vaga-titulo'>{product.Vaga.Titulo}</p></Link>
                <p className='usuario-nome'>{product.Usuario.Nome}</p>
                <p className='vaga-senioridade'>{product.Vaga.NivelSenioridade}</p>
                <p className='vaga-descricao'>{product.Vaga.Descricao}</p>
                <div className='local-data'>
                <p className='vaga-local'>{product.Vaga.Local}</p>
                <p className='vaga-dataCriacao'>{new Date(product.Vaga.DataCriacao).toLocaleDateString()}</p>
                </div>
            </div>
        ))}
      </div>
    </div>
  );
};
export default ConsultaVagas;