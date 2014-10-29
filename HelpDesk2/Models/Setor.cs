using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpDesk2.Models
{
    public class Setor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "informe o nome do Setor")]
        public string Nome { get; set; }
    }
}