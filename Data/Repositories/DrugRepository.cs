using System;
using System.Data.Entity;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Data.IRepositories;
using ProjectJunior.Models;

namespace ProjectJunior.Data.Repositories
{
	public class DrugRepository : IDrugRepository
    {
        private readonly ProjectContext _context;
        public DrugRepository(ProjectContext context)
        {
            _context = context;
        }

        public async void Add(Drug data)
        {
            _context.Drugs.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async void Delete(Drug data)
        {
            if (_context.Drugs != null)
                _context.Drugs.Remove(data);
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
            var drug = await _context.Drugs.FindAsync(id);
            if (drug != null)
                _context.Drugs.Remove(drug);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<Drug> Get(int id)
        {
            var drug = await _context.Drugs.FindAsync(id);
            return drug;
        }

        public async Task<IEnumerable<Drug>> GetAll()
        {
            return await _context.Drugs.ToListAsync();
        }

        public async Task<Drug> Update(Drug data)
        {
            _context.Drugs.Update(data);
            await _context.SaveChangesAsync();

            return data;
        }
    }
}

