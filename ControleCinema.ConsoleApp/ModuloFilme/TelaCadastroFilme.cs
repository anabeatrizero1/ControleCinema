using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloFuncionario;
using ControleCinema.ConsoleApp.ModuloGenero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloFilme
{
    internal class TelaCadastroFilme : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Filme> _repositorioFilme;
        private readonly Notificador _notificador;

        private readonly TelaCadastroGenero _telaCadastroGenero;
        private readonly IRepositorio<Genero> _repositorioGenero;

        public TelaCadastroFilme(
            IRepositorio<Filme> repositorioFilme, 
            Notificador notificador,
            TelaCadastroGenero telaCadastroGenero,
            IRepositorio<Genero> repositorioGenero)
            : base("Cadastro de Filme")
        {
            _repositorioFilme = repositorioFilme;
            _notificador = notificador;
            _telaCadastroGenero = telaCadastroGenero;
            _repositorioGenero = repositorioGenero;
            

        }

        public void Inserir()
        {
            MostrarTitulo("Inserindo Novo Filme");

            Filme novoFilme = ObterFilme();

            if (novoFilme != null)
                _notificador.ApresentarMensagem("Filme cadastrado com sucesso! ", TipoMensagem.Sucesso);
            else
                return;

        }

        public void Editar()
        {
            MostrarTitulo("Editando Filme");

            bool temFilmeCadastrado = VisualizarRegistros("Pesquisando");

            if (temFilmeCadastrado == false)
            {
                _notificador.ApresentarMensagem("Nenhuma filme cadastrado para poder editar", TipoMensagem.Atencao);
                return;
            }
            int numeroRevista = ObterNumeroRegistro();

            Filme filme;
        }

        public void Excluir()
        {
            bool temFilmeRegistrados = VisualizarRegistros("Pesquisando");

            if (temFilmeRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum funcionário cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroFilme = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioFilme.Excluir(numeroFilme);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Filme excluído com sucesso!", TipoMensagem.Sucesso);


        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Filmes");

            List<Filme> filmes = _repositorioFilme.SelecionarTodos();

            if (filmes.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum Filme disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Filme filme in filmes)
                Console.WriteLine(filme.ToString());

            Console.ReadLine();

            return true;

        }
        private Filme ObterFilme()
        {
            Filme novoFilme;

            Console.WriteLine("Digite o nome do filme: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o tempo de duração (em minutos)");
            int duracao = Convert.ToInt32(nome);


            Genero generoSelecionado = ObterGenero();

            if (generoSelecionado != null)
            {
                _notificador.ApresentarMensagem("Cadastre um gênero antes de cadastrar o filme.", TipoMensagem.Atencao);
                return null;
            }

            novoFilme = new Filme(nome, generoSelecionado, duracao);

            return novoFilme;
        }
        private Genero ObterGenero()
        {
            bool temGeneroCadastrado = _telaCadastroGenero.VisualizarRegistros("");

            if (!temGeneroCadastrado)
            {
                _notificador.ApresentarMensagem("Não há nenhum genero cadastrado", TipoMensagem.Atencao);
                return null;
            }

            Console.Write("Digite o Id do Gênero disponivel: ");
            int numCaixaSelecionada = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Genero gereroSelecionado = _repositorioGenero.SelecionarRegistro(numCaixaSelecionada);
            

            return gereroSelecionado;
        }
        private int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do gênero de filme que deseja editar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioFilme.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("O ID do filme não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
        public override string ToString()
        {
            return "";        }
    }
}
