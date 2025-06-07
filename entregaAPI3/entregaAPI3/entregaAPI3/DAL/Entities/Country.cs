using System.ComponentModel.DataAnnotations;

namespace _3er_entregable.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "País")] // Nombre para mostrar en la interfaz de usuario
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")] // Longitud máxima de 50 caracteres
        [Required(ErrorMessage = "El campo {0} es obligatorio")] // Campo obligatorio
        public string Name { get; set; } // Nombre del país

        public ICollection<State>? States { get; set; } // Relación con la entidad State, un país puede tener varios estados/departamentos 
    }
    

    
}
