using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpDesk2.Models
{
    public class Os
    {
        public enum Prioridade : int
        {
            Normal = 0,
            Media = 1,
            Alta = 2
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a descrição")]
        public string Descricao { get; set; }
        public string UserId { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required(ErrorMessage = "Informe um Cliente")]
        public int ClienteId { get; set; }
        public virtual Tecnico Tecnico { get; set; }
        public int TecnicoId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Informe uma data válida")]
        public DateTime Data { get; set; }
        public Prioridade Prioridades { get; set; }
        public virtual Status Status { get; set; }
        public int StatusId { get; set; }
    }
}