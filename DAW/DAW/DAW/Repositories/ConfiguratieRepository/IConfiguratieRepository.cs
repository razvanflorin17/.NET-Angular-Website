using DAW.Models.Entities;
using DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public interface IConfiguratieRepository : IGenericRepository<Configuratie>
    {
        Task<List<Configuratie>> GetAllConfiguratie();
        Task<List<Configuratie>> GetConfiguratieByPlaca(string placa);
        Task<List<Configuratie>> GetConfiguratieByProcesor(string procesor);
        Task<List<Configuratie>> GetConfiguratieByRam(int ram);
        Task<List<Configuratie>> GetConfiguratieByStocare(int stocare);
        Task<List<PC>> GetPCsByConfiguratie(int id);
    }
}
