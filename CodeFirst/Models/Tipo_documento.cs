using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Tipo_documento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Tipo_documento { get; set; }
        [ForeignKey("Id_Tipo_documento")]
        public string Documento { get; set; }
        public string Descripcion { get; set; }




    }
}
