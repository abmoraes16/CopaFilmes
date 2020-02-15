import React from 'react';
import './banner.css';

const banner = (props) => {
    return(
        <div className="banner">
            <div className="titulo-secundario">
                {props.tituloSecundario}
            </div>
            <div className="titulo-principal">
                {props.tituloPrincipal}
            </div>
            <hr className="divisor"></hr>
            <div className="descricao">
                {props.descricao}
            </div>
        </div>
    );
}

export default banner; 