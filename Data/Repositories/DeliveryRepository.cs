using System;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Data.IRepositories;
using ProjectJunior.Models;

namespace ProjectJunior.Data.Repositories
{
	public class DeliveryRepository : IDeliveryRepository
    {
        private readonly ProjectContext _context;
        public DeliveryRepository(ProjectContext context)
        {
            _context = context;
        }

        public async void Add(Delivery data)
        {
            _context.Deliveries.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async void Delete(Delivery data)
        {
            if (_context.Deliveries != null)
                _context.Deliveries.Remove(data);
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
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery != null)
                _context.Deliveries.Remove(delivery);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<Delivery> Get(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            return delivery;
        }

        public async Task<IEnumerable<Delivery>> GetAll()
        {
            return await _context.Deliveries.ToListAsync();
        }

        public async Task<Delivery> Update(Delivery data)
        {
            _context.Deliveries.Update(data);
            await _context.SaveChangesAsync();

            return data;
        }
    }
}

