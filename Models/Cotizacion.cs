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
        /// Id de la Cotizacion
        public int CotizacionId { get; set; }
        /// Metodo que obliga a que el elemento no sea nulo y 
        ///el usuario se vea obligado a rellenar el campo
        [Required(ErrorMessage = "Campo Obligatorio.")]
        /// Nombre de la Cotizacion
        public string Nombre { get; set; }
        ///Metodo que evita que el elemento sea nulo
        [Required(ErrorMessage = "Campo Obligatorio.")]
        /// Fecha de la Cotizacion
        public string Fecha { get; set; }
        ///Metodo que evita que el elemento sea nulo
        [Required(ErrorMessage = "Campo Obligatorio.")]
        /// Servicios de la Cotizacion
        public string Servicios { get; set; }
        ///Metodo que evita que el elemento sea nulo
        [Required(ErrorMessage = "Campo Obligatorio.")]
        /// Valor de la cotizacion
        public uint ValorCotizado { get; set; }
        ///Metodo que evita que el elemento sea nulo
        [Required(ErrorMessage = "Campo Obligatorio.")]
        /// Descripcion de la cotizacion
        public string Descripcion { get; set; }
        ///Metodo que evita que el elemento sea nulo
        [Required(ErrorMessage = "Campo Obligatorio.")]

        /// Para cada cotizacion se le asignara una persona
        /// El cual el atributo de referencia sera el rut
        /// se crea esta variable rut dentro de la clase para referencial
        /// y poder mostrar en la interfaz una seleccion del rut
        public int Rut { get; set; }
        
        /// Cada cotizacion esta asignada una persona
        public Persona Persona { get; set; }
    
    }
}