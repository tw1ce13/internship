using System;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;

namespace ProjectJunior.Data.Repositories
{
	public class AvailabilityRepository : IGeneralRepository<Availability>
	{
        private readonly ProjectContext _context;
        public AvailabilityRepository(ProjectContext context)
        {
            _context = context;
        }

        public async void Add(Availability data)
        {
            _context.Availabilities.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async void Delete(Availability data)
        {
            if (_context.Availabilities != null)
                _context.Availabilities.Remove(data);
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
            var availability = await _context.Availabilities.FindAsync(id);
            if (availability != null)
                _context.Availabilities.Remove(availability);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }


        }

        public async Task<Availability> Get(int id)
        {
            var availability = await _context.Availabilities.FindAsync(id);
            return availability;
        }

        public async Task<IEnumerable<Availability>> GetAll()
        {
            return await _context.Availabilities.ToListAsync();
        }
    }
}

