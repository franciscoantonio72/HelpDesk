using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpDesk.Models
{
    public class Os
    {
        public enum Prioridade : int
        { 
            Normal,
            Media,
            Alta
        }
        public int Id { get; set; }
        [Required(ErrorMessage="Informe a descrição")]
        public string Descricao { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required(ErrorMessage = "Informe um Cliente")]
        public int ClienteId { get; set; }
        public virtual Tecnico Tecnico { get; set; }
        public int TecnicoId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode= true, DataFormatString="{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Informe uma data válida")]
        public DateTime Data { get; set; }
        public Prioridade Prioridades  { get; set; }
    }
}