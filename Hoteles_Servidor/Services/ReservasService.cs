using Hoteles_Servidor.Models;
using Hoteles_Servidor.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoteles_Servidor.Services
{
    public class ReservasService : IReservasService
    {
        private IReservasRepository hotelesRepository;

        public ReservasService(IReservasRepository hotelesRepository)
        {
            this.hotelesRepository = hotelesRepository;
        }

        public Reservas Create(Reservas reservas)
        {
            return hotelesRepository.Create(reservas);
        }

        public Reservas Delete(long id)
        {
            return hotelesRepository.Delete(id);
        }

        public Reservas Read(long id)
        {
            return hotelesRepository.Read(id);
        }

        public IQueryable<Reservas> ReadAll()
        {
            return hotelesRepository.ReadAll();
        }

        public void Update(Reservas reservas)
        {
            hotelesRepository.Update(reservas);
        }
    }
}