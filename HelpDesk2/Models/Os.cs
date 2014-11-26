using System;
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
        public DateTime? DataFechamento { get; set; }
        public string HoraAbertura { get; set; }
        public string HoraFechamento { get; set; }
        [Display(Name = "Prioridade")]
        public virtual Prioridade Prioridades { get; set; }
        public virtual Status Status { get; set; }
        public int StatusId { get; set; }
        public virtual string MsgNota { get; set; }
        [NotMapped]
        public virtual IEnumerable<Nota> Nota { get; set; }
        [NotMapped]
        public virtual string Tempo
        {
            get
            {
                return CalcularTempo();
            }
        }

        private string CalcularTempo()
        {
            if (this.Status.Id == 2)
            {
                DateTime fim = (DateTime)this.DataFechamento;
                DateTime inicio = this.Data;
                TimeSpan diferenca = fim.Subtract(inicio);

                return diferenca.Days + " Dias e " + diferenca.Hours + ":" + diferenca.Minutes + ":" + diferenca.Seconds;

            }
            else
            {
                return "";
            }
        }
    }
}