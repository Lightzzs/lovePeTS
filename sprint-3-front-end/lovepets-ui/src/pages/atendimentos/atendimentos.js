import { Component } from "react";

export default class Atendimentos extends Component{
  constructor(props){
    super(props);
    this.state = {
      // nomeEstado : valorInicial
      listaAtendimentos : []
    };
  };

  buscarAtendimentos = () => {
    console.log('Esta função traz todos os atendimentos.')

    fetch('http://localhost:5000/api/Atendimentos')

    .then(resposta => {
      if (resposta.status !== 200) {
        throw Error();
      }

      return resposta.json();
    })

    .then(resposta => this.setState({ listaAtendimentos : resposta }))

    .catch(erro => console.log(erro));
  };

  componentDidMount(){
    this.buscarAtendimentos();
  };

  render(){
    return(
      <div>
        <h1>Page Atendimentos</h1>

        <section>
          <h2>Lista de Atendimentos</h2>

          <table>

            <thead>
              <tr>
                <th>#</th>
                <th>Pet</th>
                <th>Veterinário</th>
                <th>Descrição</th>
                <th>Data de Atendimento</th>
                <th>Situação</th>
              </tr>
            </thead>

            <tbody>

              {
                this.state.listaAtendimentos.map( (atendimento) => {
                  return(

                    <tr key={atendimento.idAtendimento}>
                      <td>{atendimento.idAtendimento}</td>
                      <td>{atendimento.idPetNavigation.nomePet}</td>
                      <td>{atendimento.idVeterinarioNavigation.nomeVeterinario}</td>
                      <td>{atendimento.descricao}</td>
                      <td>{Intl.DateTimeFormat("pt-BR", {
                        year: 'numeric', month: 'numeric', day: 'numeric',
                        hour: 'numeric', minute: 'numeric',
                        hour12: false
                      }).format(new Date(atendimento.dataAtendimento))}</td>
                      <td>{atendimento.idSituacaoNavigation.nomeSituacao}</td>
                    </tr>

                  )
                } )
              }

            </tbody>

          </table>
        </section>

        <section>
          <h2>Cadastro de Atendimentos</h2>
        </section>
      </div>
    )
  }
}

// export default Atendimentos;