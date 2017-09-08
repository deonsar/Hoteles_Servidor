using System.Linq;
using Hoteles_Servidor.Models;

namespace Hoteles_Servidor.Services
{
    public interface IReservasService
    {
        Reservas Create(Reservas reservas);
        Reservas Delete(long id);
        Reservas Read(long id);
        IQueryable<Reservas> ReadAll();
        void Update(Reservas reservas);
    }
}