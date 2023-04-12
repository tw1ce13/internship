using System;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Data.IRepositories;
using ProjectJunior.Models;

namespace ProjectJunior.Data.Repositories
{
        public class DiscountRepository : IDiscountRepository
    {
        private readonly ProjectContext _context;
        public DiscountRepository(ProjectContext context)
        {
            _context = context;
        }

        public async void Add(Discount data)
        {
            _context.Discounts.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async void Delete(Discount data)
        {
            if (_context.Discounts != null)
                _context.Discounts.Remove(data);
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
            var obj = await _context.Discounts.FindAsync(id);
            if (obj != null)
                _context.Discounts.Remove(obj);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

        }

        public async Task<Discount> Get(int id)
        {
            var obj = await _context.Discounts.FindAsync(id);
            return obj;
        }

        public async Task<IEnumerable<Discount>> GetAll()
        {
            return await _context.Discounts.ToListAsync();
        }

        public async Task<Discount> Update(Discount data)
        {
            _context.Discounts.Update(data);
            await _context.SaveChangesAsync();

            return data;
        }
    }
}

