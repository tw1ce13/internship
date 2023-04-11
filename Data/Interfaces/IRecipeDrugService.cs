using System;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Interfaces
{
	public interface IRecipeDrugService
	{
        Task<IBaseResponse<IEnumerable<RecipeDrug>>> GetAll();
        Task<IBaseResponse<RecipeDrug>> Get(int id);
        IBaseResponse<RecipeDrug> Delete(int id);
        IBaseResponse<RecipeDrug> Delete(RecipeDrug obj);
        IBaseResponse<RecipeDrug> Add(RecipeDrug obj);
    }
}

