using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Tutor_Padre
    {
        public int ID_Tutor_Padre { get; set; }
        public string TP_Nombre { get; set; }
        public string TP_Telefono { get; set; }
        public string TP_Ocupacion { get; set; }

        public int IDPaciente { get; set; }

        //Propiedades de navegacion

        public Paciente Paciente { get; set; }


    }
}
