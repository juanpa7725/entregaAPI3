using System.ComponentModel.DataAnnotations;

namespace _3er_entregable.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")] // Nombre para mostrar en la interfaz de usuario
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")] // Longitud máxima de 50 caracteres
        [Required(ErrorMessage = "El campo {0} es obligatorio")] // Campo obligatorio
        public string Name { get; set; } // Nombre del Estado/departamento

        // Asi es como relaciono 2 tablas con EF core

        [Display(Name = "Pais")]
        public Country? Country { get; set; } // Relación con la entidad Country

        // FK
        [Display(Name = "Id Pais")]
        public Guid CountryId { get; set; } // Clave foránea que referencia al país al que pertenece el estado/departamento




    }
}
