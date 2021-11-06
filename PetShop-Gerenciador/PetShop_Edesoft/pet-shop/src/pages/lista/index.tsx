import React, { useEffect, useState } from "react";
import Header from "../../components/header";
import './style.css';

function ListaDeCachorros(){
    const [cadastros, setCadastros] = useState([]);
    const [racas, setRacas] = useState([]);
    const [raca, setRaca] = useState('');

    const url = 'http://localhost:5000/api/CaesDono';
    const urlRaca = "http://localhost:5000/api/Raca ";
    useEffect(() => {
        Listar();
        listarRaca();
    }, []);

    const listarRaca = () =>{
        fetch(urlRaca, {
            method: 'GET'
        })
        .then(response => response.json())
        .then(dados => {
            setRacas(dados)
        })
        .catch(Erro => console.error(Erro));
    }

    const Listar = () =>{
        fetch(url, {
            method: 'GET'
        })
        .then(response => response.json())
        .then(dados => {
            setCadastros(dados)
        })
        .catch(Erro => console.error(Erro));
    }

    const Deletar = (id:any) =>{
        let resposta = window.prompt("Digite 'excluir cachorro' para excluir esse cão:")?.toLowerCase();

        if (resposta === "excluir cachorro") {
           
            const url = "http://localhost:5000/api/CaesDono/" + id;
            fetch(url, {
                headers: {
                    'Content-Type': 'application/json'
                },
                method: "DELETE"
            }).then(() => {
                Listar();
            })
                .catch(err => {
                    console.error(err);
                })
        }
    }

    function filtro() { 
        if (cadastros.length !== 0) {
           
            var filtrados = cadastros.filter((item: any) => item.idCaoNavigation.idRacaNavigation.titulo.toUpperCase().includes(raca.toUpperCase()));
            console.log(filtrados)
            if (filtrados !== undefined)
                return filtrados; 
        }
        return cadastros; 
    }

    return(
        <div>
            <Header/>
            <div className="container">
            <div className="form-group row">
                <label className="col-md-4 col-form-label text-md-right">Filtro por raça:</label>
                <div className="col-md-6">
                    <select className="form-control" name="raca" id="racaCachorro" onChange={e => setRaca(e.target.value)}>
                        <option value={0} selected disabled hidden>Selecione a raça do cachorro:</option>
                            {
                                racas.map((item:any)=>{
                                    return(
                                        <option value={item.titulo}>{item.titulo}</option>
                                        )
                                    })
                                }
                    </select>
                </div>
            </div>

            <div className="row">
                <div className="col-12">
                <table className="table table-striped" cellSpacing="0" cellPadding="0">
                    <thead>
                    <tr>
                        <th scope="col">Nome do dono</th>
                        <th scope="col">Nome do cachorro</th>
                        <th scope="col">Raça</th>
                        <th scope="col">Ações</th>
                    </tr>
                    </thead>
                    <tbody>
                        {
                            filtro().map((item:any)=>{
                                return(
                            <tr>
                                <td>{item.idDonoNavigation.nome}</td>
                                <td>{item.idCaoNavigation.apelido}</td>
                                <td>{item.idCaoNavigation.idRacaNavigation.titulo}</td>
                                <td>
                                    <button type="button"  onClick={()=>Deletar(item.id)} className="btn btn-danger"><i className="far fa-trash-alt"></i></button>
                                </td>
                            </tr>   
                            )
                            })
                        }
                        </tbody>
                </table>
                </div>
            </div>
            </div>
        </div>
    )
}

export default ListaDeCachorros;
