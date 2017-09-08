using Hoteles_Servidor.Exceptions;
using Hoteles_Servidor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hoteles_Servidor.Repositories
{
    public class ReservasRepository : IReservasRepository
    {
        public Reservas Create(Reservas reservas)
        {
            return ApplicationDbContext.applicationDbContext.Reservas.Add(reservas);
        }

        public Reservas Delete(long Id)
        {
            Reservas reservas = ApplicationDbContext.applicationDbContext.Reservas.Find(Id);
            if (reservas == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Reservas.Remove(reservas);
            return reservas;
        }

        public Reservas Read(long Id)
        {
            return ApplicationDbContext.applicationDbContext.Reservas.Find(Id);
        }

        public IQueryable<Reservas> ReadAll()
        {
            IList<Reservas> lista = new List<Reservas>(ApplicationDbContext.applicationDbContext.Reservas);

            return lista.AsQueryable();
        }

        public void Update(Reservas reservas)
        {
            if (ApplicationDbContext.applicationDbContext.Reservas.Count(p => p.Id == reservas.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(reservas).State = EntityState.Modified;
        }
    }
}