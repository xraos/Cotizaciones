/// <summary>
/// Archivo donde se definen las clases del Dominio del problema.
/// </summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizaciones.Models {

   
    public class Usuario
    {
        [Key]
        public int UsuarioID {get; set;}
        [Required(ErrorMessage = "Campo Obligatorio.")]
        public String NombreUsuario {get; set;}
        [Required(ErrorMessage = "Campo Obligatorio.")]
        [DataType(DataType.Password)]
        public String Password {get; set;}
        [Compare("Password", ErrorMessage ="Password no son iguales")]
        [DataType(DataType.Password)]
        public String ConfirmarPassword {get; set;}
   
    
    }
}