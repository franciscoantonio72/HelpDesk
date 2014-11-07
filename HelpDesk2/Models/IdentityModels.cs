using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public enum Nivel : int
        {
            [Display(Name = "Administrador")]
            Administrador = 0,
            [Display(Name = "Operador")]
            Operador = 1
        }

        public Nivel Niveis { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<HelpDesk2.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<HelpDesk2.Models.Servico> Servicoes { get; set; }

        public System.Data.Entity.DbSet<HelpDesk2.Models.TipoServico> TipoServicoes { get; set; }

        public System.Data.Entity.DbSet<HelpDesk2.Models.Setor> Setors { get; set; }

        public System.Data.Entity.DbSet<HelpDesk2.Models.Status> Status { get; set; }

        public System.Data.Entity.DbSet<HelpDesk2.Models.Tecnico> Tecnicoes { get; set; }

        public System.Data.Entity.DbSet<HelpDesk2.Models.Os> Os { get; set; }

        public System.Data.Entity.DbSet<HelpDesk2.Models.Nota> Nota { get; set; }
    }
}