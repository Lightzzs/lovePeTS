import { Component } from "react";

export default class Clinicas extends Component{
  constructor(props){
    super(props);
    this.state = {
      // nomeEstado : valorInicial
      listaClinicas : []
    };
  };

  buscarClinicas = () => {
    console.log('Esta função traz todas as Clinicas.')

    fetch('http://localhost:5000/api/Clinicas')

    .then(resposta => {
      if (resposta.status !== 200) {
        throw Error();
      }

      return resposta.json();
    })

    .then(resposta => this.setState({ listaClinicas : resposta }))

    .catch(erro => console.log(erro));
  };

  componentDidMount(){
    this.buscarClinicas();
  };

  render(){
    return(
      <div>
        <h1>Page Clinicas</h1>

        <section>
          <h2>Lista de Clinicas</h2>

          <table>

            <thead>
              <tr>
                <th>#</th>
                <th>Endereço</th>
                <th>Razão Social</th>
                <th>CNPJ</th>
              </tr>
            </thead>

            <tbody>

              {
                this.state.listaClinicas.map( (clinica) => {
                  return(

                    <tr key={clinica.idClinica}>
                      <td>{clinica.idClinica}</td>
                      <td>{clinica.endereco}</td>
                      <td>{clinica.razaoSocial}</td>
                      <td>{clinica.cnpj}</td>
                    </tr>

                  )
                } )
              }

            </tbody>

          </table>
        </section>

        <section>
          <h2>Cadastro de Clinicas</h2>
        </section>
      </div>
    )
  }
}