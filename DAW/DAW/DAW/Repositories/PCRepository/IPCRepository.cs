using DAW.Models.Entities;
using DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public interface IPCRepository : IGenericRepository<PC>
    {
        Task<List<PC>> GetAllPCs();
        Task<List<PC>> GetPCsByPrice(int price);
        Task<List<PC>> GetPCsByType(string type);
        Task<List<PC>> GetPCsWithUser();
    }
}
