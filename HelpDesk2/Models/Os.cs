﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HelpDesk2.Models
{
    public class Os
    {
        public enum Prioridade : int
        {
            [Display(Name = "Normal")]
            Normal = 0,
            [Display(Name = "Média")]
            Media = 1,
            [Display(Name = "Alta")]
            Alta = 2
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a descrição")]
        public string Descricao { get; set; }
        public string UserId { get; set; }
        public string Usuario { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required(ErrorMessage = "Informe um Cliente")]
        public int ClienteId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Informe uma data válida")]
        public DateTime Data { get; set; }
        [Display(Name = "Prioridade")]
        public virtual Prioridade Prioridades { get; set; }
        public virtual Status Status { get; set; }
        public int StatusId { get; set; }
        public virtual string MsgNota { get; set; }
        [NotMapped]
        public virtual IEnumerable<Nota> Nota { get; set; }
    }
}