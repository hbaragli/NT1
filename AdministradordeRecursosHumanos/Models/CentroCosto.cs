using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdministradordeRecursosHumanos.Models
{
    public class CentroCosto
    {
        [Display(Name = "Centro de Costo")]
        public int CentroCostoId{ get; set; }

        public string Departamento { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }

    }

}