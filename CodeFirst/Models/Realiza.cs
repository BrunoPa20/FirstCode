using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Realiza
    {
        public int IDPaciente { get; set; }
        public int IDTratamiento { get; set; }
        public DateTime R_Fecha { get; set; }
        public string R_Procedimiento { get; set; }
        
        //Propiedades de navegacion

        public Paciente Paciente { get; set; }
        public Tratamiento Tratamiento { get; set;}

    }
}
