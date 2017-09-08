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
using System.Web.Http.Cors;
using Hoteles_Servidor.Services;
using Hoteles_Servidor.Exceptions;

namespace Hoteles_Servidor.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class ReservasController : ApiController
    {
        private IReservasService reservasService;

        public ReservasController(IReservasService reservasService)
        {
            this.reservasService = reservasService;
        }

        // GET: api/Reservas
        public IQueryable<Reservas> GetPerfiles()
        {
            return reservasService.ReadAll();
        }

        // GET: api/Reservas/5
        [ResponseType(typeof(Reservas))]
        public IHttpActionResult GetPerfil(long id)
        {
            Reservas reservas = reservasService.Read(id);
            if (reservas == null)
            {
                return NotFound();
            }

            return Ok(reservas);
        }

        // PUT: api/Reservas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerfil(long id, Reservas reservas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservas.Id)
            {
                return BadRequest();
            }

            try
            {
                reservasService.Update(reservas);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Reservas
        [ResponseType(typeof(Reservas))]
        public IHttpActionResult PostPerfil(Reservas reservas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            reservas = reservasService.Create(reservas);

            return CreatedAtRoute("DefaultApi", new { id = reservas.Id }, reservas);
        }

        // DELETE: api/Reservas/5
        [ResponseType(typeof(Reservas))]
        public IHttpActionResult DeletePerfil(long id)
        {
            Reservas reservas;
            try
            {
                reservas = reservasService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(reservas);
        }
    }
}