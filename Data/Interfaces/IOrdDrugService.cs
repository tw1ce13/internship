using System;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Interfaces
{
	public interface IOrdDrugService
	{
        Task<IBaseResponse<IEnumerable<OrdDrug>>> GetAll();
        Task<IBaseResponse<OrdDrug>> Get(int id);
        IBaseResponse<OrdDrug> Delete(int id);
        IBaseResponse<OrdDrug> Delete(OrdDrug obj);
        IBaseResponse<OrdDrug> Add(OrdDrug obj);
    }
}

