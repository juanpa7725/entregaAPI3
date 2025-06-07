using System.ComponentModel.DataAnnotations;

namespace _3er_entregable.DAL.Entities
{
    public class AuditBase
    {
        [Key]
        [Required]
        public virtual Guid Id { get; set; } // PK de todas las tablas, el guid es altamente seguro, es decir, crea automaticamente un id codificado
        public virtual DateTime? CreatedDate { get; set; } // guarda fecha de creacion de todo registro nuevo
        public virtual DateTime? ModifiedDate { get; set; } // guarda fecha de modificacion de todo registro nuevo
    }
}
