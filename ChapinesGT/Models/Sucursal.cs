using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChapinesGT.Models
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        [Required]
        [Display(Name = "Comercio")]
        public int Comercio_ID { get; set; }
        [ForeignKey("Comercio_ID")]
        public Comercio Comercio { get; set; }
        [Required]
        [Display(Name = "Departamento")]
        public int Departamento_ID { get; set; }
        [ForeignKey("Departamento_ID")]
        public Departamento Departamento { get; set; }
        [Required]
        [Display(Name = "Municipio")]
        public int Municipio_ID { get; set; }
        [ForeignKey("Municipio_ID")]
        public Municipio Municipio { get; set; }
        [Required]
        [Display(Name = "Región")]
        public int Region_ID { get; set; }
        [ForeignKey("Region_ID")]
        public Region Region { get; set; }
    }
}
