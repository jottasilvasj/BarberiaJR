using System.Collections.Generic;
using Barbearia.Models;

namespace Barbearia.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Servico> ListaServicos { get; set; } = new List<Servico>();
        public IEnumerable<Servico> ListaDestaques { get; set; } = new List<Servico>();
        public AgendamentoFormViewModel AgendamentoForm { get; set; } = new AgendamentoFormViewModel();
    }
}