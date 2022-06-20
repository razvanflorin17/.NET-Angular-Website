using DAW.Models.Entities;
using DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public interface IComponenteRepository : IGenericRepository<Componente>
    {
        Task<List<Componente>> GetAllComponente();
        Task<List<Componente>> GetComponenteByName(string nume);
        Task<List<Componente>> GetComponenteByPrice(int pret);
        Task<List<Componente>> GetComponenteByDetalii(string detalii);
    }
}
