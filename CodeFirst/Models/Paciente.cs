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

        //Propiedades de navegacion
        public List<Realiza> Realizas { get; set; }
        public List<Agenda> Agendas { get; set; }
        public List<Historial> Historials { get; set; }
        public List<Tutor_Padre> Tutor_Padres { get; set; }
        public List<Pago_Tratamiento> Pago_Tratamientos { get; set; }




    }
}
