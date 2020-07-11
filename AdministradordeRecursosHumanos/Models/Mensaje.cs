using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdministradordeRecursosHumanos.Models
{
    public class Mensaje
    {
        [Display(Name = "Nro. Mensaje")]
        public int MensajeId { get; set; }

        [Display(Name = "Apellido")]
        public int EmpleadoId { get; set; }
        public virtual Empleado Empleado { get; set; }

        [Display(Name = "Texto Mensaje")]
        [MaxLength(300)]
        public string Texto { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha De Envio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaDeEnvio { get; set; }




    }
}