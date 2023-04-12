using System;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Interfaces
{
	public interface IDrugService
	{
        Task<IBaseResponse<IEnumerable<Drug>>> GetAll();
        Task<IBaseResponse<Drug>> Get(int id);
        IBaseResponse<Drug> Delete(int id);
        IBaseResponse<Drug> Delete(Drug obj);
        IBaseResponse<Drug> Add(Drug obj);
        Task<IBaseResponse<Drug>> Update(int id, Drug obj);

    }
}

