using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloFilme;
using ControleCinema.ConsoleApp.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloSessao
{
    public class TelaCadastroSessao : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Sessao> _repositorioSessao;
        private readonly Notificador _notificador;

        private readonly IRepositorio<Filme> _repositorioFilme;
        private readonly TelaCadastroFilme _telaCadastroFilme;


        public TelaCadastroSessao(IRepositorio<Sessao> repositorioSessao, Notificador notificador)

            : base("Cadastro de Sessoes de Filme")
        {
            _repositorioSessao = repositorioSessao;
            _notificador = notificador;
            
        }

        public override string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Inserir Sessao");
            Console.WriteLine("Digite 2 para Editar Sessão");
            Console.WriteLine("Digite 3 para Excluir Sessao");
            Console.WriteLine("Digite 4 para Visualizar Sessões");
            Console.WriteLine("Digite 5 para venda de Ingressos");


            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public void Inserir()
        {
            Console.WriteLine("Inserindo Sessão");

            Filme filme = ObrerFilme();

            DateTime dataSessao = ObrerData();

            Console.WriteLine("Digite o horério da sessão em minutos");
            string horario = Console.ReadLine();

            Console.WriteLine("Digite o numero da sala");
            int sala = Convert.ToInt32(Console.ReadLine());

            

        }

        private Filme ObrerFilme()
        {
            return null;
        }

        private DateTime ObrerData()
        {
            Console.WriteLine("Digite a data da sessão (dd/MM/yyyy)");
            string dataSessao = Console.ReadLine();

            string[] dataSeparada = dataSessao.Split('/');

            int dia = Convert.ToInt32(dataSeparada[0]);
            int mes = Convert.ToInt32(dataSeparada[1]);
            int ano = Convert.ToInt32(dataSeparada[2]);

            return new DateTime(ano, mes, dia);
            
        }


        public void Editar()
        {
            throw new NotImplementedException();
        }

        public void Excluir()
        {
            throw new NotImplementedException();
        }

        
        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            throw new NotImplementedException();
        }
    }
}
