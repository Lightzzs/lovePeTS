import { Component } from "react";

export default class Donos extends Component{
  constructor(props){
    super(props);
    this.state = {
      // nomeEstado : valorInicial
      listaDonos : []
    };
  };

  buscarDonos = () => {
    console.log('Esta função traz todos os Donos.')

    fetch('http://localhost:5000/api/Donos')

    .then(resposta => {
      if (resposta.status !== 200) {
        throw Error();
      }

      return resposta.json();
    })

    .then(resposta => this.setState({ listaDonos : resposta }))

    .catch(erro => console.log(erro));
  };

  componentDidMount(){
    this.buscarDonos();
  };

  render(){
    return(
      <div>
        <h1>Page Donos</h1>

        <section>
          <h2>Lista de Donos</h2>

          <table>

            <thead>
              <tr>
                <th>#</th>
                <th>Dono</th>
              </tr>
            </thead>

            <tbody>

              {
                this.state.listaDonos.map( (dono) => {
                  return(

                    <tr key={dono.idDono}>
                      <td>{dono.idDono}</td>
                      <td>{dono.nomeDono}</td>
                    </tr>

                  )
                } )
              }

            </tbody>

          </table>
        </section>

        <section>
          <h2>Cadastro de Donos</h2>
        </section>
      </div>
    )
  }
}