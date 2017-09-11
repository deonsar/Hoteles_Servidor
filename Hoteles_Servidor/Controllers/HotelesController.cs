using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Hoteles_Servidor.Models;
using Hoteles_Servidor.Services;
using Hoteles_Servidor.Exceptions;
using System.Web.Http.Cors;

namespace Hoteles_Servidor.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class HotelesController : ApiController
    {
        private IHotelesService hotelesService;

        public HotelesController(IHotelesService hotelesService)
        {
            this.hotelesService = hotelesService;
        }

        // GET: api/Perfiles
        public IQueryable<Hoteles> GetPerfiles()
        {
            return hotelesService.ReadAll();
        }

        // GET: api/Perfiles/5
        [ResponseType(typeof(Hoteles))]
        public IHttpActionResult GetPerfil(long id)
        {
            Hoteles hoteles = hotelesService.Read(id);
            if (hoteles == null)
            {
                return NotFound();
            }

            return Ok(hoteles);
        }

        // PUT: api/Perfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerfil(long id, Hoteles hoteles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hoteles.Id)
            {
                return BadRequest();
            }

            try
            {
                hotelesService.Update(hoteles);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Perfiles
        [ResponseType(typeof(Hoteles))]
        public IHttpActionResult PostPerfil(Hoteles hoteles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            hoteles = hotelesService.Create(hoteles);

            return CreatedAtRoute("DefaultApi", new { id = hoteles.Id }, hoteles);
        }

        // DELETE: api/Perfiles/5
        [ResponseType(typeof(Hoteles))]
        public IHttpActionResult DeletePerfil(long id)
        {
            Hoteles hoteles;
            try
            {
                hoteles = hotelesService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(hoteles);
        }
    }
}