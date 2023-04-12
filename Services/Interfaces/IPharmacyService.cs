using System;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Interfaces
{
	public interface IPharmacyService
	{
        Task<IBaseResponse<IEnumerable<Pharmacy>>> GetAll();
        Task<IBaseResponse<Pharmacy>> Get(int id);
        IBaseResponse<Pharmacy> Delete(int id);
        IBaseResponse<Pharmacy> Delete(Pharmacy obj);
        IBaseResponse<Pharmacy> Add(Pharmacy obj);
        Task<IBaseResponse<Pharmacy>> Update(int id, Pharmacy obj);

    }
}

