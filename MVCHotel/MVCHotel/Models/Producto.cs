using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCHotel.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProducto { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string nombreProducto { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string descripcionProducto { get; set; }

        [Required]
        [Display(Name = "Cantidad Disponible")]
        public int cantidad { get; set; }

        [Display(Name = "Categoria")]
        public int idCategoria { get; set; }

        [Display(Name = "Imagen")]
        public byte[]? imagen { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public float precioProducto { get; set; }

        [ForeignKey("idCategoria")]
        [Display(Name = "Categoria")]
        public CategoriaProducto? categoriaProducto { get; set; }

    }
}
