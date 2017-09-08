using System.Linq;
using Hoteles_Servidor.Models;

namespace Hoteles_Servidor.Repositories
{
    public interface IHotelesRepository
    {
        Hoteles Create(Hoteles hoteles);
        Hoteles Delete(long Id);
        Hoteles Read(long Id);
        IQueryable<Hoteles> ReadAll();
        void Update(Hoteles hoteles);
    }
}