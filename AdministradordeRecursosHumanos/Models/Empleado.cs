using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdministradordeRecursosHumanos.Models
{
    public class Empleado
    {
        [Required(ErrorMessage = "El Legajo no puede estar vacio")]
        [Display(Name = "Legajo")]
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre para el empleado")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Apellido para el empleado")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "La fecha de alta no puede estar vacia")]
        [Display(Name = "Fecha Alta")]
        public DateTime FechaAlta { get; set; }
        
        public int Antiguedad
        {
            get
            {
                return CalcularAntiguedad(FechaAlta);
            }
        }

        public virtual CentroCosto CentroCosto { get; set; }

        [Required(ErrorMessage = "El centro de costo no puede estar vacio")]
        [Display(Name = "Centro de Costo")]
        public int CentroCostoId { get; set; }

        [Display(Name = "Activo")]
        public Boolean Activo { get; set; }

        public virtual ICollection<Direccion> Direcciones { get; set; }

        public virtual ICollection<Telefono> Telefonos { get; set; }

        public virtual ICollection<Mensaje> Mensajes { get; set; }

        public virtual ICollection<Solicitud> Solicitudes { get; set; }

        private int CalcularAntiguedad(DateTime alta)
        {
            int antiguedad = DateTime.Now.Year - alta.Year;

            if (DateTime.Now.DayOfYear < alta.DayOfYear)
            {
                return antiguedad--;
            } else return antiguedad;
        }

    }
}