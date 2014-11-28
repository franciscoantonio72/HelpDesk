using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk2.Models.Relatorio
{
    public class AtendimentoTecnico
    {
        public int Contador { get; set; }
        public string NomeUsuario { get; set; }
        public List<Os> ListaOs { get; set; }
        public Cliente NomeCliente { get; set; }
    }
}
