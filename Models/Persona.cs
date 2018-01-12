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
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "This is required.")]

        public string Rut { get; set; }

        [Required(ErrorMessage = "This is required.")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "This is required.")]

        public string Paterno { get; set; }

        [Required(ErrorMessage = "This is required.")]

        public string Materno { get; set; }

        public List<Cotizacion> Cotizaciones { get; set; }

        public Persona(
            int PersonaId, 
            string Rut, 
            string Nombre, 
            string Paterno, 
            string Materno, 
            List<Cotizacion> Cotizaciones)
        {
            this.PersonaId = PersonaId;
            this.Rut = Rut;
            this.Nombre = Nombre;
            this.Paterno = Paterno;
            this.Materno = Materno;
            this.Cotizaciones = Cotizaciones;

        }

    }
}