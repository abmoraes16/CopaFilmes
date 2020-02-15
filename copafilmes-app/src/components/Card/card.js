import React from 'react';
import './card.css';

const card = (props) => {
    return(
        <div className="card" id={props.id}>
            <div className="card-checkbox"><input type="checkbox" id={props.id} titulo={props.titulo} onChange={e => props.funcao(props)}/></div>
            <div className="card-info">
                <div>{props.titulo}</div>
                <div>{props.anoLancamento}</div>
            </div>
        </div>
    );
}

export default card;