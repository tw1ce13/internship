using System;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Interfaces
{
	public interface IOrdService
	{
        Task<IBaseResponse<IEnumerable<Ord>>> GetAll();
        Task<IBaseResponse<Ord>> Get(int id);
        IBaseResponse<Ord> Delete(int id);
        IBaseResponse<Ord> Delete(Ord obj);
        IBaseResponse<Ord> Add(Ord obj);
        Task<IBaseResponse<Ord>> Update(int id, Ord obj);

    }
}

