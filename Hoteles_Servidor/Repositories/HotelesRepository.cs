using Hoteles_Servidor.Exceptions;
using Hoteles_Servidor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hoteles_Servidor.Repositories
{
    public class HotelesRepository : IHotelesRepository
    {

        public Hoteles Create(Hoteles hoteles)
        {
            return ApplicationDbContext.applicationDbContext.Hoteles.Add(hoteles);
        }

        public Hoteles Delete(long Id)
        {
            Hoteles hoteles = ApplicationDbContext.applicationDbContext.Hoteles.Find(Id);
            if (hoteles == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Hoteles.Remove(hoteles);
            return hoteles;
        }

        public Hoteles Read(long Id)
        {
            return ApplicationDbContext.applicationDbContext.Hoteles.Find(Id);
        }

        public IQueryable<Hoteles> ReadAll()
        {
            IList<Hoteles> lista = new List<Hoteles>(ApplicationDbContext.applicationDbContext.Hoteles);

            return lista.AsQueryable();
        }

        public void Update(Hoteles hoteles)
        {
            if (ApplicationDbContext.applicationDbContext.Hoteles.Count((System.Linq.Expressions.Expression<Func<Hoteles, bool>>)(p => p.Id == hoteles.Id)) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(hoteles).State = EntityState.Modified;
        }
                
    }
}