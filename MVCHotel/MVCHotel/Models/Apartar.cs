using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MVCHotel.Models
{
    public class Apartar
    {
        public int ApartarId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int idProducto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Compra")]
        public DateTime fechaCompra { get; set; }


        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }


        [ForeignKey("UserId")]
        [Display(Name = "Usuario")]
        public IdentityUser? usuario { get; set; }

        [ForeignKey("idProducto")]
        [Display(Name = "Producto")]
        public Producto? producto { get; set; }

    }
}
