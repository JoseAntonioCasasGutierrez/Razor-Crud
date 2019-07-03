using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Razor.Models.ViewModels
{
    public class ListTablaViewModelTipoSala
    {
        public int IdTipoSala { get; set; }
        [Required(ErrorMessage = "Ingresa la Sala.")]
        [RegularExpression(@"^([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\']+[\s])+([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])+[\s]?([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])?$", ErrorMessage = "Introduce letras")]
        public string TipoSalaJuntas { get; set; }

    }
}