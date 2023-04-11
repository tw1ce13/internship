using System;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;

namespace ProjectJunior.Data.Repositories
{
	public class PatientRepository : IGeneralRepository<Patient>
	{
        private readonly ProjectContext _context;
        public PatientRepository(ProjectContext context)
        {
            _context = context;
        }

        public async void Add(Patient data)
        {
            _context.Patients.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async void Delete(Patient data)
        {
            if (_context.Patients != null)
                _context.Patients.Remove(data);
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
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
                _context.Patients.Remove(patient);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<Patient> Get(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            return patient;
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await _context.Patients.ToListAsync();
        }
    }
}

