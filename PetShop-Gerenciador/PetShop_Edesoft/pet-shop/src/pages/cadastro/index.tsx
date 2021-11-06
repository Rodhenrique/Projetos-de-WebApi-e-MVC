import React, { useEffect, useState } from 'react';
import Header from '../../components/header';
import Input from '../../components/input';
import './style.css';


function Cadastro() {
    useEffect(() => {
        listarRaca();
    }, []);

    const [dono, setDono] = useState('');
    const [cao, setCao] = useState('');
    const [raca, setRaca] = useState(0);
    const [racas, setRacas] = useState([]);

    const urlCadastro = "http://localhost:5000/api/CaesDono";
    const urlRaca = "http://localhost:5000/api/Raca ";

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
    
    const cadastrar = () =>{

        const dados ={
            nome : dono,
            apelido: cao,
            idRaca: raca
        }

        if ((dono === null) || (dono === ""))
        {
            alert("Por favor digite o nome do dono:");
        }else if ((cao === null) || (cao === ""))
        {
            alert("Por favor digite o nome do cachorro:");
        }else if ((raca === null) || (raca === 0))
        {
            alert("Por favor digite a raça:");
        }else{
            fetch(urlCadastro, {
                    method: "POST",
                    body: JSON.stringify(dados),
                    headers: {
                        'Content-Type': 'application/json',
                    }
                }
            ).then(Response => {
                console.log(Response.status);
                if(Response.status === 201)
                {
                    clear();
                    alert("Usuário cadastrado com sucesso!!!");
                }
            })
            .catch(()=>{
                alert("Ocorreu um erro no cadastro!!!");
            })
        }
    }
    

    const clear = () =>{
        setDono("");
        setCao("");
        setRaca(0);
    }

    return (
        <div className="my-form">
          <Header/>
          
           <div className="cotainer">
                <div className="row justify-content-center">
                    <div className="col-md-8">
                        <div className="card">
                            <div className="card-header">Ficha de cadastro para cachorro</div>
                                <div className="card-body">
                                <form onSubmit={event => {
                                    event.preventDefault();

                                    }}>
                                        <Input name="dono" label="Nome do dono:" value={dono} onChange={e => setDono(e.target.value)} />

                                        <Input name="dono" label="Digite o nome do cachorro:" value={cao} onChange={e => setCao(e.target.value)} />

                                        

                                        <div className="form-group row">
                                            <label className="col-md-4 col-form-label text-md-right">Raça do cachorro:</label>
                                            <div className="col-md-6">
                                                <select className="form-control" name="raca" id="racaCachorro" onChange={e => setRaca(parseInt(e.target.value))}>
                                                    <option value={0} selected disabled hidden>Selecione a raça do cachorro:</option>
                                                        {
                                                            racas.map((item:any)=>{
                                                                return(
                                                                    <option value={item.id}>{item.titulo}</option>
                                                                    )
                                                                })
                                                         }
                                                </select>
                                            </div>
                                        </div>

                                        <div className="buttons">
                                            <button type="submit" onClick={() => clear()} className="btn btn-danger">Cancelar</button>
                        
                                            <button type="submit" onClick={() => cadastrar()} className="btn btn-success">Cadastrar</button>
                                        </div>

                                    </form>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
      </div>
    );
  }
  
  export default Cadastro;