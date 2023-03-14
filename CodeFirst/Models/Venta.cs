using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int num_venta { get; set; }

        public int Id_cliente { get; set; }
        [ForeignKey("Id_cliente")]
        public virtual Cliente Cliente { get; set; }

        public int Id_Tipo_documento { get; set; }
      
        [ForeignKey("Id_Tipo_documento")]
        public virtual Tipo_documento Tipo_Documento { get; set; }
        public int ArticuloID { get; set; }
        [ForeignKey("ArticuloID")]
        public virtual Articulo Articulo { get; set; }
    }
  

}
