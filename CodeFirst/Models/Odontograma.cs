using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Odontograma
    {
        public int IDOdontograma { get; set; }
        public string O_Posicion { get; set; }
        public string O_Nombre { get; set; }
        public string Categoria { get; set; }
        public string O_Estado { get; set; }

    }
}
