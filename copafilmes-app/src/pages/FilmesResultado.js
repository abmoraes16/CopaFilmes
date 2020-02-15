import React, { Component } from "react"
import Banner from '../components/Banner/banner';
import Button from '../components/Button/button';
import Ranking from '../components/Ranking/ranking';
import './Filmes.css';
import Item from '../components/Ranking/item'

class filmesResultado extends Component {
    constructor(props){
        super(props);
        this.state = {
          filmes: []
        }
    }

    componentDidMount(){
        //fetch para atualizar essa pagina
        let filmes = this.props.location.state;
        console.log('filmes');
        console.log(filmes);

        // fetch("http://localhost:5000/v1/contest", { body: JSON.stringify(filmes), method: 'GET' }).then(res => console.log(res));

        fetch("http://localhost:5000/v1/contest", {
            method: 'POST',
            body: JSON.stringify(filmes),
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            }
        })
        .then(res => res.json())
        .then((result) => {
            this.setState({
                isLoaded:true,
                filmes: result
            });
          },
          (error) => {
            this.setState({
              isLoaded:true,
              error
            });
          }
        );
    }

    voltarPagina = () => {
        this.props.history.push('/');
    }

    render(){
        const { filmes } = this.state;
        return(
            <div className="page">
                <Banner tituloSecundario="Campeonato de Filmes" tituloPrincipal="Resultado Final" descricao="Veja o resultado final do Campeonato de filmes de forma simples e rápida"/>
                <Button name="VOLTAR" onClick={this.voltarPagina}/>
                <div className="cards">
                {
                  filmes.map(filme => (
                      <Item titulo={filme.titulo} id={filme.id} posicao="1"/>
                  ))
                }
                </div>
            </div>
        );
    }
}
export default filmesResultado; 