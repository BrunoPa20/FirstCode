using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Paciente
    {
        public int IDPaciente { get; set; }
        public string P_Nombre { get; set; }
        public string P_DNI { get; set; }
        public string P_Domicilio { get; set; }
        public string P_Telefono { get; set; }
        public DateTime P_FechaNac { get; set; }
        public string P_Ocupacion { get; set; }

        public Paciente()
        {
            Realizas = new List<Realiza>();
            Agenda = new List<Agenda>();
            Historials = new List<Historial>();
            Tutor_Padres = new List<Tutor_Padre>();
            Pago_Tratamientos = new List<Pago_Tratamiento>();
        }

        //Propiedades de navegacion
        public virtual List<Realiza> Realizas { get; set; }
        public virtual List<Agenda> Agenda { get; set; }
        public virtual List<Historial> Historials { get; set; }
        public virtual List<Tutor_Padre> Tutor_Padres { get; set; }
        public virtual List<Pago_Tratamiento> Pago_Tratamientos { get; set; }




    }
}
