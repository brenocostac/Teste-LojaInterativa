using LojaInterativa.Data;
using LojaInterativa.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaInterativa.Services
{
    public class FabricanteService
    {
        private readonly LojaInterativaContext _context;

        public FabricanteService(LojaInterativaContext context)
        {
            _context = context;
        }

        public async Task<List<Fabricante>> FindAllAsync()
        {
            return await _context.Fabricante.OrderBy(f => f.Nome).ToListAsync();
        }
    }
}
