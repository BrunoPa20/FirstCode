using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticuloID { get; set; }
        public string ArticuloName { get; set; }

        public string Precio { get; set; }

        public string Stock { get; set; }




    }
}
