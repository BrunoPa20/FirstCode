using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Receta_Medica
    {
        public int IDReceta_Medica { get; set; }
        public string Medicamento { get; set; }
        public string Dosis { get; set; }
        public string Tiempo { get; set; }

        //--------------------------------------
        public int IDTratamiento { get; set; }
        //Propiedades de navegacion
        public Tratamiento Tratamiento { get; set; }

    }
}
