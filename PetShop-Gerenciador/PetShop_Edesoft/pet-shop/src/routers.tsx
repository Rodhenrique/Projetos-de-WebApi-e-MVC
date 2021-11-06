import React from "react";  
import {BrowserRouter, Switch, Route} from 'react-router-dom'
import cadastro from "./pages/cadastro";
import ListaDeCachorros from "./pages/lista";

function Routers(){
   return(
    <BrowserRouter>
        <Switch>
            <Route path="/" exact component={cadastro} />
            <Route path="/Lista" exact component={ListaDeCachorros} />
        </Switch>
    </BrowserRouter>
   )
}

export default Routers;