using ApiEjemplo.Data;
using ApiEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiEjemplo.Controllers
{
    public class PersonaController : ApiController
    {

        // GET: api/Persona
        public IList<Persona> Get()
        {
            return PersonaData.ObtenerTodos();
        }

        // GET: api/Persona/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult Get(int id)
        {
            Persona persona = PersonaData.ObtenerPorId(id);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        // GET: api/Persona/gaby
        [ResponseType(typeof(IList<Persona>))]
        public IHttpActionResult Get(string nombre)
        {
            List<Persona> lista = new List<Persona>();
            lista = PersonaData.ObtenerPorNombre(nombre);
            if (lista.Count==0)
            {
                return NotFound();
            }
            return Ok(lista);
        }

        /*
        // EJEMPLO DE COMO CONFIGURAR EL ROUTE PARA UN ACTION PARTICULAR
        [ResponseType(typeof(IList<Persona>))]
        [Route("api/persona/getbyfecha/{fecha}")]
        public IHttpActionResult GetByFecha(string fecha)
        {
            List<Persona> lista = new List<Persona>();
            lista = PersonaData.ObtenerPorNombre(fecha);
            if (lista.Count == 0)
            {
                return NotFound();
            }
            return Ok(lista);
        }*/

        // POST: api/Persona
        [ResponseType(typeof(Persona))]
        public IHttpActionResult Post(Persona persona)
        {
            if (persona==null || string.IsNullOrEmpty(persona.Nombre))//validamos nombre
            {
                return BadRequest("Datos incorrectos.");
            }
            PersonaData.Insert(persona);
            return Ok();
        }

        // PUT: api/Persona/5
        public IHttpActionResult Put(int id, Persona persona)
        {
            if (id != persona.Id)//Nos tiene que llegar el objeto correctamente
            {
                return BadRequest("El id de la persona es incorrecto.");
            }
            if (PersonaData.ObtenerPorId(id) == null)
            {
                return NotFound();
            }
            PersonaData.Update(persona);
            return Ok();
        }

        // DELETE: api/Persona/5
        public IHttpActionResult Delete(int id)
        {
            if (PersonaData.ObtenerPorId(id) == null)
            {
                return NotFound();
            }
            PersonaData.Delete(id);
            return Ok();
        }
    }
}
