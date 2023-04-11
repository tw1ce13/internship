using System;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;

namespace ProjectJunior.Data.Repositories
{
	public class OrdDrugRepository : IGeneralRepository<OrdDrug>
	{
        private readonly ProjectContext _context;
        public OrdDrugRepository(ProjectContext context)
        {
            _context = context;
        }

        public async void Add(OrdDrug data)
        {
            _context.OrdsDrugs.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async void Delete(OrdDrug data)
        {
            if (_context.OrdsDrugs != null)
                _context.OrdsDrugs.Remove(data);
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
            var ordsDrugs = await _context.OrdsDrugs.FindAsync(id);
            if (ordsDrugs != null)
                _context.OrdsDrugs.Remove(ordsDrugs);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<OrdDrug> Get(int id)
        {
            var ordsDrugs = await _context.OrdsDrugs.FindAsync(id);
            return ordsDrugs;
        }

        public async Task<IEnumerable<OrdDrug>> GetAll()
        {
            return await _context.OrdsDrugs.ToListAsync();
        }
    }
}

