import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';
import { usuarioAutenticado, parseJwt } from './services/auth';

import './index.css';

import App from './pages/home/App';
import Atendimentos from './pages/atendimentos/atendimentos';
import MeusAtendimentos from './pages/atendimentos/meusatendimentos';
import Login from './pages/login/login';
import Clinicas from './pages/clinicas/clinicas';
import Donos from './pages/donos/donos'
import NotFound from './pages/notFound/notFound';

import reportWebVitals from './reportWebVitals';

// Estrutura IF TERNÁRIO
// CONDIÇÃO ? FAÇO ALGO SE VERDADEIRO : FAÇO ALGO SE FALSO
// Exemplo
// 2 > 1 ? Sim : Não
// resposta > Sim

const PermissaoAdm = ({ component : Component }) => (
  <Route 
    render = { props => 
      usuarioAutenticado() && parseJwt().role === '1' ?
      <Component {...props} /> : 
      <Redirect to="/login" />
    }  
  />
)

const PermissaoVetPet = ({ component : Component }) => (
  <Route 
    render = { props => 
      usuarioAutenticado() && (parseJwt().role === '2' || parseJwt().role === '3') ?
      <Component {...props} /> : 
      <Redirect to="/login" />
    }  
  />
)

const routing = (
  <Router>
      <Switch>
        <Route exact path="/" component={App} />
        <PermissaoAdm path="/atendimentos" component={Atendimentos} />
        <PermissaoVetPet path="/meusatendimentos" component={MeusAtendimentos} />
        <Route path="/login" component={Login} />
        <Route path="/clinicas" component={Clinicas} />
        <Route path="/donos" component={Donos} />
        <Route exact path="/notfound" component={NotFound} />
        <Redirect to="/notfound" />
      </Switch>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
