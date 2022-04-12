using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloGenero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloFilme
{
    public class Filme : EntidadeBase
    {
        private readonly string nome;
        private readonly Genero genero;
        private readonly int duracao;


        public Filme(string nome, Genero genero, int duracao)
        {
            this.nome = nome;
            this.genero = genero;
            this.duracao = duracao;
        }
    }
}
