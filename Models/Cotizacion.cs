/// <summary>
/// Archivo donde se definen las clases del Dominio del problema.
/// </summary>

using System.Collections.Generic;
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
    public class Cotizacion
    {
        public int CotizacionId { get; set; }

        [Required(ErrorMessage = "This is required.")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "This is required.")]

        public string Fecha { get; set; }

        [Required(ErrorMessage = "This is required.")]

        public string Servicios { get; set; }

        [Required(ErrorMessage = "This is required.")]

        public uint ValorCotizado { get; set; }

        [Required(ErrorMessage = "This is required.")]

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "This is required.")]

        public int Rut { get; set; }
        
        public Persona Persona { get; set; }
    
    }
}