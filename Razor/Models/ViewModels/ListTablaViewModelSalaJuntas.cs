using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Razor.Models.ViewModels
{
    public class ListTablaViewModelSalaJuntas
    {
        public int IdSala { get; set; }
        [Required(ErrorMessage = "Ingresa la Sala.")]
        public string Sala { get; set; }
        
        [Required(ErrorMessage = "Ingresa el Nombre del empleado.")]
        [RegularExpression(@"^([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\']+[\s])+([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])+[\s]?([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])?$", ErrorMessage = "Introduce letras, comenzando la primera letra en mayúscula")]
        public string NombreEmpleado { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRecepcion { get; set; }
        [Required(ErrorMessage = "Ingresa total de personas.")]
        public int TotalPersonas { get; set; }
        [Required(ErrorMessage = "Ingresa total de horas.")]
        public int Horas { get; set; }

        public virtual ICollection<Empleados> Empleados { get; set; }




    }
}