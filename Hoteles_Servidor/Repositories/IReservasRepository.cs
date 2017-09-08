using System.Linq;
using Hoteles_Servidor.Models;

namespace Hoteles_Servidor.Repositories
{
    public interface IReservasRepository
    {
        Reservas Create(Reservas reservas);
        Reservas Delete(long Id);
        Reservas Read(long Id);
        IQueryable<Reservas> ReadAll();
        void Update(Reservas reservas);
    }
}