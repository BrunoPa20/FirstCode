using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Agenda
    {
        public int IDAgenda { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha_Hora_Inicio { get; set; }
        public DateTime Fecha_Hora_Fin { get; set; }
        //
        public int IDPaciente { get; set; }
        public int IDOdontologo { get; set; }

        //Propiedades de navegacion
         public Odontologo Odontologo { get; set; }
         public Paciente Paciente { get; set; }




    }


}
