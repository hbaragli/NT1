using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdministradordeRecursosHumanos.Models
{
    public class Telefono
    {
        [Display(Name = "Id Telefono")]
        public int TelefonoId { get; set; }

        [Display(Name = "Tipo Domicilio")]
        public TipoTelefono Tipo { get; set; }

        [Display(Name = "Numero")]
        [DataType(DataType.PhoneNumber)]
        public int NroTelefono { get; set; }

        [Display(Name = "Apellido")]
        public int EmpleadoId { get; set; }
        public virtual Empleado Empleado { get; set; }


        public enum TipoTelefono
        {
            Personal,
            Laboral,
            Celular,
        }
    }
}