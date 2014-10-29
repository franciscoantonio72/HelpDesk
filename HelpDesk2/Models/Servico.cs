using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpDesk2.Models
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome do Serviço")]
        public string Nome { get; set; }
        public virtual TipoServico TipoServico { get; set; }
        public int TipoServicoId { get; set; }
    }
}