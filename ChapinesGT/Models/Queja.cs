using M04_SLN_APP_04_NET_CORE_LOGIN.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChapinesGT.Models
{
    public class Queja
    {
        public int Queja_ID { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public string Contacto { get; set; }
        
        [Display(Name = "Usuario")]
        public int Usuario_ID { get; set; }
        [ForeignKey("Departamento_ID")]
        public Usuario Usuario { get; set; }
        [Required]
        [Display(Name = "Sucursal")]
        public int Sucursal_ID { get; set; }
        [ForeignKey("Sucursal_ID")]
        public Sucursal Sucursal { get; set; }
    }
}
