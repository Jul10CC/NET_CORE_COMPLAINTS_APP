using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChapinesGT.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [EmailAddress(ErrorMessage = "El {0} no es una dirección de correo electrónico válida.")]
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Telefono { get; set; }
        public string Direccion { get; set; }
        public System.DateTime Fecha_nacimiento { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [StringLength(50, ErrorMessage = "El {0} debe ser como mínimo {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }
    }
}
