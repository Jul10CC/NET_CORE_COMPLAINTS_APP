using System.ComponentModel.DataAnnotations;

namespace ChapinesGT.Models
{
    public class Comercio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NIT { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
