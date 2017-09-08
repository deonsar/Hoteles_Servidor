using System.Linq;
using Hoteles_Servidor.Models;

namespace Hoteles_Servidor.Services
{
    public interface IHotelesService
    {
        Hoteles Create(Hoteles hoteles);
        Hoteles Delete(long id);
        Hoteles Read(long id);
        IQueryable<Hoteles> ReadAll();
        void Update(Hoteles hoteles);
    }
}