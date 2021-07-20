import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';

import './index.css';

import App from './pages/home/App';
import Atendimentos from './pages/atendimentos/atendimentos';
import Login from './pages/login/login';
import NotFound from './pages/notFound/notFound';
import Donos from './pages/donos/donos';
import Clinicas from './pages/clinicas/clinicas';

import reportWebVitals from './reportWebVitals';

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={App} />
        <Route path="/atendimentos" component={Atendimentos} />
        <Route path="/clinicas" component={Clinicas} />
        <Route path="/donos" component={Donos} />
        <Route path="/login" component={Login} />
        <Route exact path="/notfound" component={NotFound} />
        <Redirect to="/notfound" />
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
