using System.ComponentModel.DataAnnotations;

namespace ChapinesGT.Models
{
    public class Comercio
    {
        public int Comercio_ID { get; set; }
        public string Nombre { get; set; }
        public string NIT { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
