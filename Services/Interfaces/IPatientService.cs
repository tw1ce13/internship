using System;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Interfaces
{
	public interface IPatientService
	{
        Task<IBaseResponse<IEnumerable<Patient>>> GetAll();
        Task<IBaseResponse<Patient>> Get(int id);
        IBaseResponse<Patient> Delete(int id);
        IBaseResponse<Patient> Delete(Patient obj);
        IBaseResponse<Patient> Add(Patient obj);
        Task<IBaseResponse<Patient>> Update(int id, Patient obj);

    }
}

