using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Historial
    {
        public int IDHistorial { get; set; }
        public string H_Pregunta { get; set; }
        public string H_Categoria { get; set; }
        public string H_Respuesta { get; set; }
        public string H_Estado { get; set; }

        public int IDPaciente { get; set; }
    }
}
