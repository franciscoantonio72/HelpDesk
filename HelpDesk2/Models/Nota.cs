using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpDesk2.Models
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }
        public int OsId { get; set; }
        public string Operador { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
    }
}