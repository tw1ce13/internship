using System;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;

namespace ProjectJunior.Data.Repositories
{
	public class ClassRepository : IGeneralRepository<Class>
	{
        private readonly ProjectContext _context;
        public ClassRepository(ProjectContext context)
        {
            _context = context;
        }

        public async void Add(Class data)
        {
            _context.Classes.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async void Delete(Class data)
        {
            if (_context.Classes != null)
                _context.Classes.Remove(data);
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
            var obj = await _context.Classes.FindAsync(id);
            if (obj != null)
                _context.Classes.Remove(obj);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

        }

        public async Task<Class> Get(int id)
        {
            var obj = await _context.Classes.FindAsync(id);
            return obj;
        }

        public async Task<IEnumerable<Class>> GetAll()
        {
            return await _context.Classes.ToListAsync();
        }
    }
}

