using Hoteles_Servidor.Models;
using Hoteles_Servidor.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoteles_Servidor.Services
{
    public class HotelesService : IHotelesService
    {
        private IHotelesRepository hotelesRepository;

        public HotelesService(IHotelesRepository hotelesRepository)
        {
            this.hotelesRepository = hotelesRepository;
        }

        public Hoteles Create(Hoteles hoteles)
        {
            return hotelesRepository.Create(hoteles);
        }

        public Hoteles Delete(long id)
        {
            return hotelesRepository.Delete(id);
        }

        public Hoteles Read(long id)
        {
            return hotelesRepository.Read(id);
        }

        public IQueryable<Hoteles> ReadAll()
        {
            return hotelesRepository.ReadAll();
        }

        public void Update(Hoteles hoteles)
        {
            hotelesRepository.Update(hoteles);
        }
    }
}