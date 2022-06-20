using DAW.Models;
using DAW.Models.Entities;
using DAW.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public class PCRepository : GenericRepository<PC>, IPCRepository
    {
        public PCRepository(DAWContext context) : base(context) { }

        public async Task<List<PC>> GetAllPCs()
        {
            return await _context.PC.ToListAsync();
        }   

        public async Task<List<PC>> GetPCsByPrice(int price)
        {
            return await _context.PC
                .Where(p => p.Pret.Equals(price)).ToListAsync();
        }

        public async Task<List<PC>> GetPCsByType(string type)
        {
            return await _context.PC
                .Where(p => p.Tip.ToUpper().Equals(type.ToUpper())).ToListAsync();
        }

        public async Task<List<PC>> GetPCsWithUser()
        {
            return await _context.PC.Include(p => p.Client).ToListAsync();
        }
    }
}
