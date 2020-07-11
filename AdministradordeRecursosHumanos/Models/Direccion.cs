using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdministradordeRecursosHumanos.Models
{
    public class Direccion
    {
        [Display(Name = "Id. de Direccion")]
        public int DireccionId { get; set; }

        [Display(Name = "Apellido")]
        public virtual Empleado Empleado { get; set; }
        public int EmpleadoId { get; set; }

        [Display(Name = "Tipo Domicilio")]
        public TipoDomicilio Tipo { get; set; }

        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Display(Name = "N°")]
        public int Numero { get; set; }

        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        public virtual Provincia Provincia { get; set; }
        [Display(Name = "Provincia")]
        public int ProvinciaId { get; set; }

        public enum TipoDomicilio
        {
            Personal,
            Laboral,
            Legal,
            Otro,
        }


    }
}