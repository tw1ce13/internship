using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using Microsoft.EntityFrameworkCore;
namespace ProjectJunior.Data.Repositories
{
	public class RecipeDrugRepository : IGeneralRepository<RecipeDrug>
	{
        private readonly ProjectContext _context;
        public RecipeDrugRepository(ProjectContext context)
        {
            _context = context;
        }

        public async void Add(RecipeDrug data)
        {
            _context.RecipesDrugs.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async void Delete(RecipeDrug data)
        {
            if (_context.RecipesDrugs != null)
                _context.RecipesDrugs.Remove(data);
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
            var recipeDrug = await _context.RecipesDrugs.FindAsync(id);
            if (recipeDrug != null)
                _context.RecipesDrugs.Remove(recipeDrug);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<RecipeDrug> Get(int id)
        {
            var recipeDrug = await _context.RecipesDrugs.FindAsync(id);
            return recipeDrug;
        }

        public async Task<IEnumerable<RecipeDrug>> GetAll()
        {
            return await _context.RecipesDrugs.ToListAsync();
        }
    }
}

