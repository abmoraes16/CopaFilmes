import React from 'react'
import Item from '../Ranking/item'

class ranking extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error:null,
            isLoaded: false,
            filmes: []
        };
    }
    componentDidMount() {
        fetch("https://localhost:5000//v1/contest")
          .then(res => res.json())
          .then(
            (result) => {
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
        )
    }
    render(){
        const { error, isLoaded, filmes } = this.state;
        if (error) {
            return <div>Error: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Loading...</div>;
        } else {
            return(
                    filmes.map(filme => (
                        <Item titulo={filme.titulo} id={filme.id} posicao="1"/>
                    )
                )
            );
        }
    }
};

export default ranking;