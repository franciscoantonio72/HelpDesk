using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpDesk2.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome do status")]
        public string Descricao { get; set; }
    }
}