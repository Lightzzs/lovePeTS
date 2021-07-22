import { Component } from "react";

import axios from 'axios';
import { parseJwt } from '../../services/auth';

export default class Login extends Component{
  constructor(props){
    super(props);
    this.state = {
      email : '',
      senha : ''
    };
  };

  efetuaLogin = (event) => {
    event.preventDefault();

    axios.post('http://localhost:5000/api/login', {
      email : this.state.email,
      senha : this.state.senha
    })

    .then(resposta => {
      if (resposta.status === 200) {
        console.log('Meu token é: ' + resposta.data.token);
        localStorage.setItem('usuario-login', resposta.data.token)

        if (parseJwt().role === "1") {
          this.props.history.push('/atendimentos')
        }

        else {
          this.props.history.push('/meusatendimentos')
        };
      }
    })
  };

  atualizaStateCampo = (campo) => {
    // exemplo          email           :       adm
    this.setState({ [campo.target.name] : campo.target.value })
  };

  render(){
    return(
      <div>
        <h1>Login</h1>

        <section>
          <form onSubmit={this.efetuaLogin}>

            <input 
              // E-mail
              type="text"
              name="email"
              value={this.state.email}
              onChange={this.atualizaStateCampo}
              placeholder="username"
            />

            <input 
              // Senha
              type="password"
              name="senha"
              value={this.state.senha}
              onChange={this.atualizaStateCampo}
              placeholder="password"
            />

            <button type="submit">Entrar</button>

          </form>
        </section>
      </div>
    )
  }
}