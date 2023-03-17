using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Pago_Tratamiento
    {
        public int IDPago_Tramiento { get; set; }
        public DateTime PT_Fecha { get; set; }
        public int PT_Monto { get; set; }

    }
}
