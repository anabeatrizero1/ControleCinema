using ControleCinema.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloSala
{
    public class TelaCadastroSala : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Sala> _repositorioSala;
        private readonly Notificador _notificador;

        public TelaCadastroSala(IRepositorio<Sala> repositorioSala, Notificador notificador)
            : base("Cadastro de Gêneros de Filme")
        {
            _repositorioSala = repositorioSala;
            _notificador = notificador;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Salas");

            Sala sala = ObterSala();

            _repositorioSala.Inserir(sala);

            _notificador.ApresentarMensagem("Sala Cadastrada com Sucesso!", TipoMensagem.Sucesso);


        }

        public void Editar()
        {
            MostrarTitulo("Editando Sala");

            bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");
            if (temRegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhuma sala cadastrada.", TipoMensagem.Atencao);
                return;
            }
            
            int numeroSala = ObterNumeroRegistro();

            Sala salaAtualizada = ObterSala();

            bool conseguiuEditar = _repositorioSala.Editar(numeroSala, salaAtualizada);

            if (!conseguiuEditar)
               _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Sala editada com sucesso!", TipoMensagem.Sucesso);


        }

        public void Excluir()
        {
            MostrarTitulo("Excluir Sala");
            bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");
            if (temRegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhuma sala cadastrada.", TipoMensagem.Atencao);
                return;
            }

            int numeroSala = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioSala.Excluir(numeroSala);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Gênero de Filme excluído com sucesso1", TipoMensagem.Sucesso);

        }



        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Salas");

            List<Sala> salas = _repositorioSala.SelecionarTodos();

            if (salas.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum gênero de filme disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Sala genero in salas)
                Console.WriteLine(genero.ToString());

            Console.ReadLine();

            return true;


        }

        private Sala ObterSala()
        {
            Console.WriteLine("Digite o número da sala: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a capacidade da sala: ");
            int capacidade = Convert.ToInt32(Console.ReadLine());

            return new Sala(numero, capacidade);
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID Sala: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioSala.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID da sala não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}
