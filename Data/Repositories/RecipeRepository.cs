using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Data.IRepositories;

namespace ProjectJunior.Data.Repositories
{
	public class RecipeRepository : IRecipeRepository
    {
        private readonly ProjectContext _context;
        public RecipeRepository(ProjectContext context)
        {
            _context = context;
        }

        public async void Add(Recipe data)
        {
            _context.Recipes.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async void Delete(Recipe data)
        {
            if (_context.Recipes != null)
                _context.Recipes.Remove(data);
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
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
                _context.Recipes.Remove(recipe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<Recipe> Get(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            return recipe;
        }

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            return await _context.Recipes.ToListAsync();
        }


        public async Task<Recipe> Update(Recipe data)
        {
            _context.Recipes.Update(data);
            await _context.SaveChangesAsync();

            return data;
        }
    }
}

