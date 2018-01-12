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
    public class PersonaBuilder
    {
        public int nestedPersonaId { get; set; }

        

        public string nestedRut { get; set; }

        

        public string nestedNombre { get; set; }

        

        public string nestedPaterno { get; set; }

        

        public string nestedMaterno { get; set; }

        public List<Cotizacion> nestedCotizaciones { get; set; }

        public PersonaBuilder()
        {

        }

        public PersonaBuilder setPersonaId(int newpersonaid){
            this.nestedPersonaId = newpersonaid;
            return this;
        }

        public PersonaBuilder setRut(int newrut){
            this.nestedPersonaId = newrut;
            return this;
        }

        public PersonaBuilder setNombre(int newnombre){
            this.nestedPersonaId = newnombre;
            return this;
        }

        public PersonaBuilder setPaterno(int newpaterno){
            this.nestedPersonaId = newpaterno;
            return this;
        }

        public PersonaBuilder setMaterno(int newmaterno){
            this.nestedPersonaId = newmaterno;
            return this;
        }

        public PersonaBuilder setCotizaciones(List<Cotizacion> newcotizaciones){
            this.nestedCotizaciones = newcotizaciones;
            return this;
        }

        public Persona createPersona()
        {
            return new Persona(
                nestedPersonaId,nestedRut,nestedNombre,
                nestedPaterno,nestedMaterno,nestedCotizaciones);
        }

    }
}