using System;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Interfaces
{
	public interface IAvailabilityService
	{
        Task<IBaseResponse<IEnumerable<Availability>>> GetAll();
        Task<IBaseResponse<Availability>> Get(int id);
        IBaseResponse<Availability> Delete(int id);
        IBaseResponse<Availability> Delete(Availability obj);
        IBaseResponse<Availability> Add(Availability obj);
        Task<IBaseResponse<Availability>> Update(int id, Availability obj);
    }
}

