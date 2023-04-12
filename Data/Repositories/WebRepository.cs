using System;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Data.IRepositories;
using ProjectJunior.Models;

namespace ProjectJunior.Data.Repositories
{
	public class WebRepository : IWebRepository
    {
        private readonly ProjectContext _context;
		public WebRepository(ProjectContext context)
		{
            _context = context;
		}

        public async void Add(Web data)
        {
            _context.Webs.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
        }

        public async void Delete(Web data)
        {
            if (_context.Webs != null)
                _context.Webs.Remove(data);
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
            var web = await _context.Webs.FindAsync(id);
            if (web != null)
                _context.Webs.Remove(web);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<Web> Get(int id)
        {
            var web = await _context.Webs.FindAsync(id);
            return web;
        }

        public async Task<IEnumerable<Web>> GetAll()
        {
            return await _context.Webs.ToListAsync();
        }


        public async Task<Web> Update(Web data)
        {
            _context.Webs.Update(data);
            await _context.SaveChangesAsync();

            return data;
        }
    }
}

