using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdministradordeRecursosHumanos.Models
{
    public class Provincia
    {

        public int ProvinciaId { get; set; }
        [Display(Name = "Provincia")]
        public string Nombre { get; set; }

        public virtual ICollection<Direccion> Direcciones { get; set; }
    }
}