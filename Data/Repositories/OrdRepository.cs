using System;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;

namespace ProjectJunior.Data.Repositories
{
	public class OrdRepository : IGeneralRepository<Ord>
	{
        private readonly ProjectContext _context;
        public OrdRepository(ProjectContext context)
        {
            _context = context;
        }

        public async void Add(Ord data)
        {
            _context.Ords.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async void Delete(Ord data)
        {
            if (_context.Ords != null)
                _context.Ords.Remove(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async void Delete(int id)
        {
            var ord = await _context.Ords.FindAsync(id);
            if (ord != null)
                _context.Ords.Remove(ord);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<Ord> Get(int id)
        {
            var ord = await _context.Ords.FindAsync(id);
            return ord;
        }

        public async Task<IEnumerable<Ord>> GetAll()
        {
            return await _context.Ords.ToListAsync();
        }
    }
}

