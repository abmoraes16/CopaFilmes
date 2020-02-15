import React from 'react';
import './item.css';

const item = (props) => {
    return(
        <div className="item" id={props.id}>
            <div className="item-posicao">{props.posicao}</div>
            <div className="item-info">
                <div>{props.titulo}</div>
            </div>
        </div>
        // <div className="item">
        //     <div className="item-posicao">1º</div>
        //     <div className="item-info">
        //         <div>Titulo do Filme Campeao</div>
        //     </div>
        // </div>
        // <div className="card">
        //     <div className="card-checkbox"><input type="checkbox"/></div>
        //     <div className="card-info">
        //         <div>Titulo do Filme</div>
        //         <div>2018</div>
        //     </div>
        // </div>
    );
}

export default item;