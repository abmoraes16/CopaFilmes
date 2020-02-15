import React from 'react'
import Card from '../Card/card'

class cards extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error:null,
            isLoaded: false,
            filmes: []
        };
    }
    componentDidMount() {
        fetch("http://localhost:5000/v1/filmes")
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
        const { error, isLoaded, filmes, callbackParent } = this.state;
        if (error) {
            return <div>Error: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Loading...</div>;
        } else {
            return(
                    filmes.map(filme => (
                        <Card titulo={filme.titulo} anoLancamento={filme.ano} nota={filme.nota} key={filme.id}/>
                    )
                )
            );
        }
    }
};

export default cards;