﻿using System.ComponentModel.DataAnnotations.Schema;
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

        public Tratamiento()
        {
            Realizas = new List<Realiza>();
            Pago_Tratamientos = new List<Pago_Tratamiento>();
            Receta_Medicas = new List<Receta_Medica>();
            Odontogramas = new List<Odontograma>();
        }

        //Propiedades de navegacion
        public List<Realiza> Realizas { get; set; }
        public List<Pago_Tratamiento> Pago_Tratamientos { get; set; }
        public List<Receta_Medica> Receta_Medicas { get; set; }
        public List<Odontograma> Odontogramas { get; set; }




    }
}
