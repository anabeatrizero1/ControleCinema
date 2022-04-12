using ControleCinema.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp
{
    public class Sala : EntidadeBase
    {
        private readonly int numeroSala;
        private readonly int capacidade;
        private int assentosDisponivies;

        public Sala(int numero, int capacidade)
        {
            this.numeroSala = numero;
            this.capacidade = capacidade;   
            assentosDisponivies = capacidade;
        }

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                   "Numero da Sala: " + numeroSala + Environment.NewLine+
                   "Capacidade: " + capacidade + Environment.NewLine+
                   "Assentos Disponiveis" + assentosDisponivies + Environment.NewLine;
        }
    }
}
