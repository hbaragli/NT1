using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdministradordeRecursosHumanos.Models
{
    public class Solicitud
    {

        public enum tipo
        {
            Licencia,
            Examen,
            Otro
        }

        public enum estado
        {
            Pendiente,
            Aprobada,
            Rechazada
        }
     
            public int SolicitudId { get; set; }

            [Display(Name = "Tipo Solicitud")]
            public tipo TipoSolicitud { get; set; }
            [Display(Name = "Tema")]
            public string Tema { get; set; }
            [Display(Name = "Texto de la solicitud")]
            public string Texto { get; set; }

            [Display(Name = "Apellido")]
            public int EmpleadoId { get; set; }
            public virtual Empleado Empleado { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Required(ErrorMessage = "Fecha de inicio no puede estar vacía")]
            [Display(Name = "Fecha de inicio")]
            public DateTime FechaInicialRango { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Required(ErrorMessage = "Fecha final no puede estar vacía")]
            [Display(Name = "Fecha de final")]
            public DateTime FechaFinalRango { get; set; }

            [Display(Name = "Estado Solicitud")]
            public estado Estado_solicitud { get; set; }

            public void ValidarFecha()
            {
                int value = DateTime.Compare(FechaInicialRango, FechaFinalRango);
                if (FechaInicialRango > FechaFinalRango)
                {
                    Console.Write("La fecha de inicio es mayor a la fecha final");
                }
            }
        }
}