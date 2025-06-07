using System.ComponentModel.DataAnnotations;

namespace _3er_entregable.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "Pa�s")] // Nombre para mostrar en la interfaz de usuario
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener m�ximo {1} caracteres.")] // Longitud m�xima de 50 caracteres
        [Required(ErrorMessage = "El campo {0} es obligatorio")] // Campo obligatorio
        public string Name { get; set; } // Nombre del pa�s

        public ICollection<State>? States { get; set; } // Relaci�n con la entidad State, un pa�s puede tener varios estados/departamentos 
    }
    

    
}
