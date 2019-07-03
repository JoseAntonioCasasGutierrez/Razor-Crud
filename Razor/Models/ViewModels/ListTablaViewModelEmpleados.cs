using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Razor.Models.ViewModels
{
    public class ListTablaViewModelEmpleados
    {
        public int IdEmpleados { get; set; }
        [RegularExpression(@"^([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\']+[\s])+([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])+[\s]?([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])?$", ErrorMessage = "Introduce letras, comenzando la primera letra en mayúscula")]
        [Required(ErrorMessage = "Ingresa el Nombre Completo del Empleado.")]
        public string Nombre { get; set; }
        [RegularExpression(@"^([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\']+[\s])+([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])+[\s]?([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])?$", ErrorMessage = "Introduce letras, comenzando la primera letra en mayúscula")]
        [Required(ErrorMessage = "Ingresa el habilidades del empleado.")]
        public string Habilidades { get; set; }
        [Required(ErrorMessage = "Ingresa el salario del empleado Solo numeros.")]
        [Column(TypeName = "money")]
        public decimal Salario { get; set; }
        [Required(ErrorMessage = "Ingresa el fechacontratacion del empleado.")]
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime FechaContratacion { get; set; }
    }
}