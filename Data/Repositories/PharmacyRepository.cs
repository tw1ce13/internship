using System;
using ProjectJunior.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Models;
namespace ProjectJunior.Data.Repositories
{
	public class PharmacyRepository : IGeneralRepository<Pharmacy>
	{
        private readonly ProjectContext _context;
        public PharmacyRepository(ProjectContext context)
        {
            _context = context;
        }

        public async void Add(Pharmacy data)
        {
            _context.Pharmacies.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async void Delete(Pharmacy data)
        {
            if (_context.Pharmacies != null)
                _context.Pharmacies.Remove(data);
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
            var pharmacy = await _context.Pharmacies.FindAsync(id);
            if (pharmacy != null)
                _context.Pharmacies.Remove(pharmacy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<Pharmacy> Get(int id)
        {
            var pharmacy = await _context.Pharmacies.FindAsync(id);
            return pharmacy;
        }

        public async Task<IEnumerable<Pharmacy>> GetAll()
        {
            return await _context.Pharmacies.ToListAsync();
        }
    }
}

