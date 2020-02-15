import React from "react"
import Banner from '../components/Banner/banner';
import Button from '../components/Button/button';
import { useHistory } from "react-router"
import Card from '../components/Card/card'
import Label from '../components/Label/label'
import './Filmes.css';
import { BrowserRouter as Router, Route,Switch, Redirect, Link} from 'react-router-dom'
import Resultado from './FilmesResultado';

class filmes extends React.Component {
    constructor(props){
        super(props);
        this.state = {
            filmes: [],
            filmesSelecionados: [],
            label: "Selecionados 0 de 8 filmes"
        };
    }

    componentDidMount(){
        fetch("http://localhost:5000/v1/filmes")
          .then(res => res.json())
          .then(
            (result) => {
              this.setState({
                  filmes: result
              });
            }
        )
    }

    getCards = (varBack) =>{
        let filmesSel = this.state.filmesSelecionados;
        let filmeSelecionado = {id:varBack.id,titulo:varBack.titulo,ano:varBack.anoLancamento,nota:varBack.nota}
        
        if(filmesSel.some(c => c.id == filmeSelecionado.id)){
            filmesSel = filmesSel.filter(c=>c.id !== filmeSelecionado.id);
        }
        else
        {
            filmesSel.push(filmeSelecionado);
        }

        
        this.setState({
            filmesSelecionados: filmesSel, 
            label: "Selecionados "+filmesSel.length+" de 8 filmes"
        });

        varBack='';
    }

    gerarCampeonato = () =>{
        if(this.state.filmesSelecionados.length == '8'){
            this.props.history.push('/resultado',this.state.filmesSelecionados);
        }
        else
        {
            alert('Por favor, selecionar 8 filmes para o campeonato!');
        }
    }

    render(){
        const { filmes,label } = this.state;

        return(
            
                <div className="page">
                    <Banner tituloSecundario="Campeonato de Filmes" tituloPrincipal="Fase de Seleção" descricao="Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir."/>
                    <div className="botoes">
                        <Label descricao={label}/>
                        <Button name="GERAR MEU CAMPEONATO" onClick={this.gerarCampeonato}/>
                    </div>

                        <div className="cards">
                        {
                            filmes.map(filme => (
                                <Card id={filme.id} titulo={filme.titulo} anoLancamento={filme.ano} nota={filme.nota} key={filme.id} funcao={this.getCards} />
                            ))
                        }
                        </div>
                </div>
        );
    }
}

export default filmes;