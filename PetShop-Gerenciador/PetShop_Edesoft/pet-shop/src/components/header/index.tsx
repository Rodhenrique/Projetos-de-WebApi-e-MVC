import React from "react";
import { Link } from "react-router-dom";
import './style.css';

function Header(){

    return(
      
            <nav className="navbar navbar-expand-lg navbar-light navbar-eder">
                <div className="container">
                    <Link className="navbar-brand" to="/">Pet Shop Edesoft</Link>
                    

                    <div className="itens-menu">
                        <ul>
                            <li className="nav-item">
                                <Link className="nav-link" to="/">Cadastro</Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link" to="/Lista">Lista de cachorros</Link>
                            </li>
                        </ul>
                    </div>

                </div>
            </nav>
        
    )
}
export default Header;