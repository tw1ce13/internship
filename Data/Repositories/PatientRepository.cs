using System;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Data.IRepositories;
using ProjectJunior.Models;

namespace ProjectJunior.Data.Repositories
{
	public class PatientRepository : IPatientRepository
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

        public Task<Patient> Update(int id, Patient data)
        {
            throw new NotImplementedException();
        }

        public async Task<Patient> Update(Patient data)
        {
            _context.Patients.Update(data);
            await _context.SaveChangesAsync();

            return data;
        }
    }
}

