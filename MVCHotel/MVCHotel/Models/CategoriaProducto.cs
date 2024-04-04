using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCHotel.Models
{
    public class CategoriaProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCategoria { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        public List<Producto>? Productos { get; set; }
    }
}
