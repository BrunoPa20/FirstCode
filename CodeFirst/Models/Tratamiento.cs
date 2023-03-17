using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Tratamiento
    {
        public int IDTratamiento { get; set; }
        public string T_Diagnostico { get; set; }
        public string T_Procedimiento { get; set; }
        public string T_Tipo { get; set; }
        public int T_Monto { get; set; }
        public int Saldo { get; set; }
        //Propiedades de navegacion
        public List<Realiza> Realizas { get; set; }
        public List<Pago_Tratamiento> Pago_Tratamientos { get; set; }

    }
}
