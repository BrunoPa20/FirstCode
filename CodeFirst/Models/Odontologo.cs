﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Odontologo
    {
        public int IDOdontologo { get; set; }
        public string OD_Nombre { get; set; }
        public string OD_Apellido { get; set; }
        public string OD_DNI { get; set; }
        public string OD_Email { get; set; }
        public string OD_Telefono { get; set; }
        public string OD_Domicilio { get; set; }
        public string OD_Turno { get; set; }
        //public string OD_Usuario { get; set; }
        //public string OD_Password { get; set; }

        public Odontologo()
        {
            Agenda = new List<Agenda>();
        }

        //Propiedades de navegacion
        public List<Agenda> Agenda { get; set; }

    }
}
