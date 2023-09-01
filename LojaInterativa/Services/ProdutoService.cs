using LojaInterativa.Data;
using LojaInterativa.Models;
using LojaInterativa.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LojaInterativa.Services
{
    public class ProdutoService
    {
        private readonly LojaInterativaContext _context;

        public ProdutoService(LojaInterativaContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> FindAllAsync()
        {
            return await _context.Produto.Include(s => s.Fabricante).OrderBy(s => s.Nome).ToListAsync();
        }

        public async Task InsertAsync(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _context.Produto.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            bool hasAny = await _context.Produto.AnyAsync(x => x.Id == produto.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
