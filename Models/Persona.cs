using System.Collections.Generic;
/// <summary>
/// Archivo donde se definen las clases del Dominio del problema.
/// </summary>

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cotizaciones.Models {

    /// <summary>
    /// Clase que representa a una persona en el Sistema.
    /// </summary>
    /// <remarks>
    /// Esta clase pertenece al modelo del Dominio y posee las siguientes restricciones:
    /// - No permite valores null en sus atributos.
    /// </remarks>
    public class Persona
    {
        /// Id de la persona
        public int PersonaId { get; set; }
        /// Metodo que obliga a que el elemento no sea nulo y 
        ///el usuario se vea obligado a rellenar el campo
        [Required(ErrorMessage = "Campo Obligatorio.")]
        /// Rut de la persona
        public string Rut { get; set; }
        ///Metodo que evita que el elemento sea nulo
        [Required(ErrorMessage = "Campo Obligatorio.")]
        /// Nombre de la persona
        public string Nombre { get; set; }
        ///Metodo que evita que el elemento sea nulo
        [Required(ErrorMessage = "Campo Obligatorio.")]
        /// Apellido parterno de la persona
        public string Paterno { get; set; }
        ///Metodo que evita que el elemento sea nulo
        [Required(ErrorMessage = "Campo Obligatorio.")]
        /// Apellido materno de la persona
        public string Materno { get; set; }
        /// cada persona tiene una lista de cotizaciones (1 a muchos)
        
        public List<Cotizacion> Cotizaciones { get; set; }

        

    }
}