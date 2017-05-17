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
            //return PersonaData.ObtenerTodos();
            List<Persona> l = new List<Persona>();
            Persona p = new Persona();
            p.Nombre = ApiEjemplo.Data.DBHelper.ConnectionString;
            p.Id = 1;
            l.add(p);
            return l;
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

        // POST: api/Persona
        [ResponseType(typeof(Persona))]
        public IHttpActionResult Post(Persona persona)
        {
            if (persona==null || string.IsNullOrEmpty(persona.Nombre))//validamos nombre
            {
                return BadRequest("Debe ingresar un nombre.");
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
